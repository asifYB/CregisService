using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class ShowCardPanData
    {
        [JsonPropertyName("pan")]
        public string? Pan { get; set; }

        [JsonPropertyName("expiryDate")]
        public string? ExpiryDate { get; set; }

        [JsonPropertyName("cvv")]
        public string? Cvv { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("nonce")]
        public string? Nonce { get; set; }

        [JsonPropertyName("sign")]
        public string? Sign { get; set; }
    }
}
