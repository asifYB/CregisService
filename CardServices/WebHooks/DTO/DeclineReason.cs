using System.Text.Json.Serialization;

namespace Cregis.WebHooks.DTO
{
    public class DeclineReason
    {
        [JsonPropertyName("responseCode")]
        public string? ResponseCode { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
