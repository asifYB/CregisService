using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class PinQueryData
    {
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("nonce")]
        public required string Nonce { get; set; }

        [JsonPropertyName("activationCode")]
        public required string ActivationCode { get; set; }

        [JsonPropertyName("sign")]
        public required string Sign { get; set; }
    }
}
