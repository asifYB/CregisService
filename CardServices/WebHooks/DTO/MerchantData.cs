using System.Text.Json.Serialization;

namespace Cregis.WebHooks.DTO
{
    public class MerchantData
    {
        [JsonPropertyName("mcc_category")]
        public string MccCategory { get; set; } = string.Empty;

        [JsonPropertyName("merchant_city")]
        public string MerchantCity { get; set; } = string.Empty;

        [JsonPropertyName("merchant_state")]
        public string MerchantState { get; set; } = string.Empty;

        [JsonPropertyName("merchant_post_code")]
        public string MerchantPostCode { get; set; } = string.Empty;

        [JsonPropertyName("merchant_name")]
        public string MerchantName { get; set; } = string.Empty;

        [JsonPropertyName("merchant_country")]
        public string MerchantCountry { get; set; } = string.Empty;

        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; set; } = "00000";

        [JsonPropertyName("mcc_code")]
        public string MccCode { get; set; } = "0000";
    }
}
