using System.Text.Json.Serialization;

namespace Cregis.WebHooks.DTO
{
    public class CardStatusDetail
    {
        [JsonPropertyName("sign")]
        public string Sign { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("nonce")]
        public string Nonce { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("desc")]
        public string Desc { get; set; } = string.Empty;

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; } = 0;
    }
}
