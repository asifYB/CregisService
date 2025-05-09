using System.Text.Json.Serialization;

namespace Cregis.WebHooks.DTO
{
    public class TransactionData
    {
        [JsonPropertyName("fees")]
        public Fees Fees { get; set; } = new Fees();

        [JsonPropertyName("bill_amount")]
        public double BillAmount { get; set; } = 0.0;

        [JsonPropertyName("bill_currency")]
        public string BillCurrency { get; set; } = string.Empty;

        [JsonPropertyName("merchant_data")]
        public MerchantData MerchantData { get; set; } = new MerchantData();

        [JsonPropertyName("transaction_amount")]
        public double TransactionAmount { get; set; } = 0.0;

        [JsonPropertyName("channel")]
        public string Channel { get; set; } = string.Empty;

        [JsonPropertyName("sign")]
        public string Sign { get; set; } = string.Empty;

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;

        [JsonPropertyName("mcc_padding_amount")]
        public double MccPaddingAmount { get; set; } = 0.0;

        [JsonPropertyName("nonce")]
        public string Nonce { get; set; } = string.Empty;

        [JsonPropertyName("card_id")]
        public string CardId { get; set; } = string.Empty;

        [JsonPropertyName("lifecycle_event_id")]
        public string LifecycleEventId { get; set; } = string.Empty;

        [JsonPropertyName("cleared_at")]
        public string ClearedAt { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("decline_reason")]
        public DeclineReason DeclineReason { get; set; } = new DeclineReason();

        [JsonPropertyName("conversion_rate")]
        public string ConversionRate { get; set; } = string.Empty;

        [JsonPropertyName("cleared_date")]
        public DateTime ClearedDate { get; set; } = DateTime.MinValue;

        [JsonPropertyName("transaction_currency")]
        public string TransactionCurrency { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; } = 0;
    }
}
