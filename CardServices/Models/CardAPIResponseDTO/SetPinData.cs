using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class SetPinData
    {
        [JsonPropertyName("pin")]
        public required string Pin { get; set; }

        [JsonPropertyName("sign")]
        public required string Sign { get; set; }

        [JsonPropertyName("timestamp")]
        public required long Timestamp { get; set; }

        [JsonPropertyName("nonce")]
        public required string Nonce { get; set; }
    }
}
