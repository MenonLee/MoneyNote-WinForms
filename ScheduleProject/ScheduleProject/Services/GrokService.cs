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
        private const string XaiEndpoint = "https://api.x.ai/v1/chat/completions";
        private const string GroqEndpoint = "https://api.groq.com/openai/v1/chat/completions";

        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<NaturalExpenseResult> ParseNaturalExpenseAsync(string userText)
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            string contentText = await CreateChatCompletionAsync(BuildExpensePrompt(today), userText, true);

            NaturalExpenseResult? result = JsonSerializer.Deserialize<NaturalExpenseResult>(contentText, jsonOptions);
            if (result == null)
            {
                throw new InvalidOperationException("AI 분석 결과를 읽을 수 없습니다.");
            }

            return result;
        }

        public async Task<string> AnalyzeMonthlySpendingAsync(MonthlySpendingSummary summary)
        {
            string userText = BuildMonthlyAnalysisInput(summary);
            string contentText = await CreateChatCompletionAsync(BuildAnalysisPrompt(), userText, false);
            return string.IsNullOrWhiteSpace(contentText)
                ? "AI 소비 분석 결과를 읽을 수 없습니다."
                : contentText.Trim();
        }

        private static async Task<string> CreateChatCompletionAsync(string systemPrompt, string userText, bool useJsonResponse)
        {
            var config = GetApiConfig();
            var requestBody = new Dictionary<string, object?>
            {
                ["model"] = config.Model,
                ["messages"] = new[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = userText }
                },
                ["temperature"] = 0.1
            };

            if (useJsonResponse)
            {
                requestBody["response_format"] = new { type = "json_object" };
            }

            using var request = new HttpRequestMessage(HttpMethod.Post, config.Endpoint)
            {
                Content = JsonContent.Create(requestBody)
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);

            using HttpResponseMessage response = await httpClient.SendAsync(request);
            string responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"{config.ProviderName} API 호출에 실패했습니다. ({(int)response.StatusCode})");
            }

            return ExtractMessageContent(responseText);
        }

        private static ApiConfig GetApiConfig()
        {
            string apiKey = Environment.GetEnvironmentVariable("XAI_API_KEY")
                ?? Environment.GetEnvironmentVariable("GROQ_API_KEY")
                ?? "";
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("XAI_API_KEY 또는 GROQ_API_KEY 환경 변수를 먼저 설정해 주세요.");
            }

            bool isGroqCloudKey = apiKey.StartsWith("gsk_", StringComparison.OrdinalIgnoreCase);
            return new ApiConfig
            {
                ApiKey = apiKey,
                Model = Environment.GetEnvironmentVariable("XAI_MODEL")
                    ?? Environment.GetEnvironmentVariable("GROQ_MODEL")
                    ?? (isGroqCloudKey ? "llama-3.3-70b-versatile" : "grok-4.3"),
                Endpoint = isGroqCloudKey ? GroqEndpoint : XaiEndpoint,
                ProviderName = isGroqCloudKey ? "Groq" : "Grok"
            };
        }

        private static string ExtractMessageContent(string responseText)
        {
            using JsonDocument document = JsonDocument.Parse(responseText);

            if (!document.RootElement.TryGetProperty("choices", out JsonElement choices) ||
                choices.GetArrayLength() == 0)
            {
                throw new InvalidOperationException("Grok API가 분석 결과를 반환하지 않았습니다.");
            }

            JsonElement firstChoice = choices[0];
            if (!firstChoice.TryGetProperty("message", out JsonElement message) ||
                !message.TryGetProperty("content", out JsonElement content))
            {
                throw new InvalidOperationException("Grok API 응답 형식을 읽을 수 없습니다.");
            }

            return content.GetString() ?? "";
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

        private class ApiConfig
        {
            public string ApiKey { get; set; } = "";
            public string Model { get; set; } = "";
            public string Endpoint { get; set; } = "";
            public string ProviderName { get; set; } = "";
        }
    }
}
