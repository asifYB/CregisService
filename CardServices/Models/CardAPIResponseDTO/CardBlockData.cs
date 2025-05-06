using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class CardBlockData
    {
        [JsonPropertyName("block")]
        public bool Block { get; set; }

        [JsonPropertyName("sign")]
        public required string Sign { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("nonce")]
        public required string Nonce { get; set; }
    }
}
