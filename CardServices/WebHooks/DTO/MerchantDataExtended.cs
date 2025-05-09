using System.Text.Json.Serialization;

namespace Cregis.WebHooks.DTO
{
    public class MerchantDataExtended
    {
        [JsonPropertyName("merchant_state")]
        public string MerchantState { get; set; } = string.Empty;

        [JsonPropertyName("merchant_post_code")]
        public string MerchantPostCode { get; set; } = string.Empty;
    }
}
