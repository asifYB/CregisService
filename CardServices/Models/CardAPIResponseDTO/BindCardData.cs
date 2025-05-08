using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class BindCardData
    {
        [JsonPropertyName("isActivated")]
        public bool IsActivated { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("nonce")]
        public required string Nonce { get; set; }

        [JsonPropertyName("sign")]
        public required string Sign { get; set; }
    }
}
