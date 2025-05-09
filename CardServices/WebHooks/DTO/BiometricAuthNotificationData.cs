using System.Text.Json.Serialization;

namespace Cregis.WebHooks.DTO
{
    public class BiometricAuthNotificationData
    {
        [JsonPropertyName("cardId")]
        public string CardId { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("merchantName")]
        public string MerchantName { get; set; } = string.Empty;

        [JsonPropertyName("initiateActionId")]
        public string InitiateActionId { get; set; } = string.Empty;

        [JsonPropertyName("transactionAmount")]
        public string TransactionAmount { get; set; } = string.Empty;

        [JsonPropertyName("merchantCountryCode")]
        public string MerchantCountryCode { get; set; } = string.Empty;

        [JsonPropertyName("transactionCurrency")]
        public string TransactionCurrency { get; set; } = string.Empty;

        [JsonPropertyName("transactionTimestamp")]
        public DateTime TransactionTimestamp { get; set; } = DateTime.MinValue;

        [JsonPropertyName("sign")]
        public string Sign { get; set; } = string.Empty;

        [JsonPropertyName("nonce")]
        public string Nonce { get; set; } = string.Empty;

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; } = 0;
    }
}
