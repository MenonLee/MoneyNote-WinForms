using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

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

    public class GeminiService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<NaturalExpenseResult> ParseNaturalExpenseAsync(string userText)
        {
            string apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY") ?? "";
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("GEMINI_API_KEY 환경 변수를 먼저 설정해 주세요.");
            }

            string model = Environment.GetEnvironmentVariable("GEMINI_MODEL") ?? "gemini-2.5-flash";
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent?key={Uri.EscapeDataString(apiKey)}";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new
                            {
                                text = BuildPrompt(userText)
                            }
                        }
                    }
                },
                generationConfig = new
                {
                    responseMimeType = "application/json",
                    temperature = 0.1
                }
            };

            using HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, requestBody);
            string responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Gemini API 호출에 실패했습니다. ({(int)response.StatusCode})");
            }

            using JsonDocument document = JsonDocument.Parse(responseText);
            string contentText = document.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString() ?? "";

            NaturalExpenseResult? result = JsonSerializer.Deserialize<NaturalExpenseResult>(contentText, jsonOptions);
            if (result == null)
            {
                throw new InvalidOperationException("AI 분석 결과를 읽을 수 없습니다.");
            }

            return result;
        }

        private static string BuildPrompt(string userText)
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            return
                "다음 문장에서 개인 지출 정보를 추출해서 JSON만 반환해 주세요.\n" +
                $"오늘 날짜는 {today} 입니다.\n\n" +
                "규칙:\n" +
                "- title: 지출명\n" +
                "- amount: 숫자 금액\n" +
                "- category: 식비, 교통, 쇼핑, 문화, 생활, 통신, 기타 중 하나\n" +
                "- paymentMethod: 카드, 현금, 계좌이체, 간편결제, 기타 중 하나\n" +
                "- expenseDate: yyyy-MM-dd 형식\n" +
                "- memo: 짧은 메모\n" +
                "- 알 수 없는 값은 가장 자연스러운 기본값으로 추론\n\n" +
                "출력 예시:\n" +
                "{\n" +
                "  \"title\": \"김밥천국 점심\",\n" +
                "  \"amount\": 8500,\n" +
                "  \"category\": \"식비\",\n" +
                "  \"paymentMethod\": \"카드\",\n" +
                $"  \"expenseDate\": \"{today}\",\n" +
                "  \"memo\": \"점심\"\n" +
                "}\n\n" +
                "사용자 입력:\n" +
                userText;
        }
    }
}
