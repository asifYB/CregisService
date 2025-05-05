using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class SpendControlCap
    {
        [JsonPropertyName("transactionLimit")]
        public string? TransactionLimit { get; set; }

        [JsonPropertyName("dailyLimit")]
        public string? DailyLimit { get; set; }

        [JsonPropertyName("weeklyLimit")]
        public string? WeeklyLimit { get; set; }

        [JsonPropertyName("monthlyLimit")]
        public string? MonthlyLimit { get; set; }

        [JsonPropertyName("yearlyLimit")]
        public string? YearlyLimit { get; set; }

        [JsonPropertyName("allTimeLimit")]
        public string? AllTimeLimit { get; set; }
    }
}
