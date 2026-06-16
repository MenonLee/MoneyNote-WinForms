using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using ScheduleProject.Models;

namespace ScheduleProject.Services
{
    public class NaturalExpenseResult
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; } = "";

        [JsonPropertyName("paymentMethod")]
        public string PaymentMethod { get; set; } = "";

        [JsonPropertyName("expenseDate")]
        public string ExpenseDate { get; set; } = "";

        [JsonPropertyName("memo")]
        public string Memo { get; set; } = "";
    }

    public class GrokService
    {
        private const string GroqEndpoint = "https://api.groq.com/openai/v1/chat/completions";
        private const string DefaultGroqModel = "meta-llama/llama-4-scout-17b-16e-instruct";

        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<NaturalExpenseResult> ParseNaturalExpenseAsync(string userText)
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            string contentText = await CreateChatCompletionAsync(BuildExpensePrompt(today), userText);
            return ParseExpenseResult(contentText);
        }

        public async Task<NaturalExpenseResult> ParseReceiptImageAsync(string imagePath)
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);
            string base64Image = Convert.ToBase64String(imageBytes);
            string mimeType = GetImageMimeType(imagePath);

            object[] userContent =
            {
                new
                {
                    type = "text",
                    text = "영수증 사진에서 개인 지출 정보를 추출해 주세요."
                },
                new
                {
                    type = "image_url",
                    image_url = new
                    {
                        url = $"data:{mimeType};base64,{base64Image}"
                    }
                }
            };

            string contentText = await CreateChatCompletionAsync(BuildReceiptPrompt(today), userContent);
            return ParseExpenseResult(contentText);
        }

        public async Task<string> AnalyzeMonthlySpendingAsync(MonthlySpendingSummary summary)
        {
            string userText = BuildMonthlyAnalysisInput(summary);
            string contentText = await CreateChatCompletionAsync(BuildAnalysisPrompt(), userText);
            return string.IsNullOrWhiteSpace(contentText)
                ? "AI 소비 분석 결과를 읽을 수 없습니다."
                : contentText.Trim();
        }

        private static NaturalExpenseResult ParseExpenseResult(string contentText)
        {
            NaturalExpenseResult? result = JsonSerializer.Deserialize<NaturalExpenseResult>(CleanJsonText(contentText), jsonOptions);
            if (result == null)
            {
                throw new InvalidOperationException("AI 분석 결과를 읽을 수 없습니다.");
            }

            return result;
        }

        private static async Task<string> CreateChatCompletionAsync(string systemPrompt, object userContent)
        {
            string apiKey = GetApiKey();
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("GROQ_API_KEY 또는 XAI_API_KEY 환경 변수를 먼저 설정해 주세요.");
            }

            string model = Environment.GetEnvironmentVariable("GROQ_MODEL") ?? DefaultGroqModel;
            var requestBody = new Dictionary<string, object?>
            {
                ["model"] = model,
                ["messages"] = new object[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = userContent }
                },
                ["temperature"] = 0.1
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, GroqEndpoint)
            {
                Content = JsonContent.Create(requestBody)
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            using HttpResponseMessage response = await httpClient.SendAsync(request);
            string responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"GroqCloud API 호출에 실패했습니다. ({(int)response.StatusCode}) {ExtractErrorMessage(responseText)}");
            }

            return ExtractMessageContent(responseText);
        }

        private static string GetApiKey()
        {
            string? groqApiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY");
            if (!string.IsNullOrWhiteSpace(groqApiKey))
            {
                return groqApiKey;
            }

            return Environment.GetEnvironmentVariable("XAI_API_KEY") ?? "";
        }

        private static string ExtractMessageContent(string responseText)
        {
            using JsonDocument document = JsonDocument.Parse(responseText);

            if (!document.RootElement.TryGetProperty("choices", out JsonElement choices) ||
                choices.GetArrayLength() == 0)
            {
                throw new InvalidOperationException("AI가 분석 결과를 반환하지 않았습니다.");
            }

            JsonElement firstChoice = choices[0];
            if (!firstChoice.TryGetProperty("message", out JsonElement message) ||
                !message.TryGetProperty("content", out JsonElement content))
            {
                throw new InvalidOperationException("AI 응답 형식을 읽을 수 없습니다.");
            }

            return content.GetString() ?? "";
        }

        private static string ExtractErrorMessage(string responseText)
        {
            if (string.IsNullOrWhiteSpace(responseText))
            {
                return "";
            }

            try
            {
                using JsonDocument document = JsonDocument.Parse(responseText);
                if (document.RootElement.TryGetProperty("error", out JsonElement error))
                {
                    if (error.ValueKind == JsonValueKind.String)
                    {
                        return error.GetString() ?? "";
                    }

                    if (error.TryGetProperty("message", out JsonElement message))
                    {
                        return message.GetString() ?? "";
                    }

                    return error.ToString();
                }
            }
            catch (JsonException)
            {
                // Some providers return plain text error bodies.
            }

            return responseText.Length > 300 ? responseText[..300] : responseText;
        }

        private static string BuildExpensePrompt(string today)
        {
            return
                "너는 개인 지출 문장을 지출 등록용 JSON으로 변환하는 도우미입니다.\n" +
                $"오늘 날짜는 {today} 입니다.\n\n" +
                "반드시 JSON 객체만 반환하세요. 설명, 코드블록, 마크다운은 쓰지 마세요.\n" +
                "스키마:\n" +
                "{\n" +
                "  \"title\": \"지출명\",\n" +
                "  \"amount\": 8500,\n" +
                "  \"category\": \"식비\",\n" +
                "  \"paymentMethod\": \"카드\",\n" +
                $"  \"expenseDate\": \"{today}\",\n" +
                "  \"memo\": \"짧은 메모\"\n" +
                "}\n\n" +
                "규칙:\n" +
                "- amount는 숫자만 반환하세요.\n" +
                "- category는 식비, 교통, 쇼핑, 문화, 생활, 통신, 기타 중 하나만 사용하세요.\n" +
                "- paymentMethod는 카드, 현금, 계좌이체, 간편결제, 기타 중 하나만 사용하세요.\n" +
                "- expenseDate는 yyyy-MM-dd 형식으로 반환하세요.\n" +
                "- 알 수 없는 값은 가장 자연스러운 기본값으로 추론하세요.";
        }

        private static string BuildReceiptPrompt(string today)
        {
            return
                "너는 영수증 사진을 개인 지출 등록용 JSON으로 변환하는 도우미입니다.\n" +
                $"오늘 날짜는 {today} 입니다.\n\n" +
                "반드시 JSON 객체만 반환하세요. 설명, 코드블록, 마크다운은 쓰지 마세요.\n" +
                "스키마:\n" +
                "{\n" +
                "  \"title\": \"상호명 또는 대표 지출명\",\n" +
                "  \"amount\": 8500,\n" +
                "  \"category\": \"식비\",\n" +
                "  \"paymentMethod\": \"카드\",\n" +
                $"  \"expenseDate\": \"{today}\",\n" +
                "  \"memo\": \"짧은 메모\"\n" +
                "}\n\n" +
                "규칙:\n" +
                "- amount는 최종 결제 금액 또는 합계 금액을 숫자만 반환하세요.\n" +
                "- category는 식비, 교통, 쇼핑, 문화, 생활, 통신, 기타 중 하나만 사용하세요.\n" +
                "- paymentMethod는 카드, 현금, 계좌이체, 간편결제, 기타 중 하나만 사용하세요.\n" +
                "- 결제수단이 보이지 않으면 기타를 사용하세요.\n" +
                "- 날짜가 보이지 않으면 오늘 날짜를 사용하세요.";
        }

        private static string BuildAnalysisPrompt()
        {
            return
                "너는 개인 가계부 앱의 월간 소비 분석 도우미입니다.\n" +
                "사용자가 보기 좋은 한국어 소비 코멘트를 1~2문장으로 작성하세요.\n" +
                "불필요한 인사말, 마크다운, 번호 목록은 쓰지 마세요.\n" +
                "예산이 없으면 예산 비교 대신 카테고리와 최근 지출 흐름 위주로 조언하세요.";
        }

        private static string BuildMonthlyAnalysisInput(MonthlySpendingSummary summary)
        {
            string categories = summary.CategorySpending.Count == 0
                ? "없음"
                : string.Join(", ", summary.CategorySpending.Select(item => $"{item.Key}: {item.Value:N0}원"));
            string budgets = summary.CategoryBudgets.Count == 0
                ? "없음"
                : string.Join(", ", summary.CategoryBudgets.Select(item => $"{item.Key}: {item.Value:N0}원"));
            string recentExpenses = summary.RecentExpenses.Count == 0
                ? "없음"
                : string.Join(", ", summary.RecentExpenses.Select(item => $"{item.ExpenseDate:MM-dd} {item.Title} {item.Amount:N0}원"));

            return
                $"분석 월: {summary.Year}년 {summary.Month}월\n" +
                $"이번 달 총 지출: {summary.TotalExpenseAmount:N0}원\n" +
                $"월 예산: {summary.MonthlyBudget:N0}원\n" +
                $"고정지출 합계: {summary.FixedExpenseAmount:N0}원\n" +
                $"카테고리별 지출: {categories}\n" +
                $"카테고리별 예산: {budgets}\n" +
                $"최근 지출: {recentExpenses}";
        }

        private static string CleanJsonText(string text)
        {
            string trimmed = text.Trim();
            if (trimmed.StartsWith("```json", StringComparison.OrdinalIgnoreCase))
            {
                trimmed = trimmed[7..].Trim();
            }
            else if (trimmed.StartsWith("```", StringComparison.OrdinalIgnoreCase))
            {
                trimmed = trimmed[3..].Trim();
            }

            if (trimmed.EndsWith("```", StringComparison.OrdinalIgnoreCase))
            {
                trimmed = trimmed[..^3].Trim();
            }

            return trimmed;
        }

        private static string GetImageMimeType(string imagePath)
        {
            string extension = Path.GetExtension(imagePath).ToLowerInvariant();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".webp" => "image/webp",
                _ => "application/octet-stream"
            };
        }
    }
}
