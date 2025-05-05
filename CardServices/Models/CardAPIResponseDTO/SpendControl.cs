using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class SpendControl
    {
        [JsonPropertyName("spendControlCap")]
        public SpendControlCap? SpendControlCap { get; set; }

        [JsonPropertyName("spendControlAmount")]
        public SpendControlAmount? SpendControlAmount { get; set; }

        [JsonPropertyName("atmControl")]
        public object? AtmControl { get; set; }
    }
}
