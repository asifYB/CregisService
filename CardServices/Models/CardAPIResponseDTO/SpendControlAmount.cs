using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class SpendControlAmount
    {
        [JsonPropertyName("dailySpent")]
        public string? DailySpent { get; set; }

        [JsonPropertyName("weeklySpent")]
        public string? WeeklySpent { get; set; }

        [JsonPropertyName("monthlySpent")]
        public string? MonthlySpent { get; set; }

        [JsonPropertyName("yearlySpent")]
        public string? YearlySpent { get; set; }

        [JsonPropertyName("allTimeSpent")]
        public string? AllTimeSpent { get; set; }
    }
}
