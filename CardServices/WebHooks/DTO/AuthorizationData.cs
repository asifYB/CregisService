using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cregis.WebHooks.DTO
{
    public class AuthorizationData
    {
        [JsonPropertyName("billing_amount")]
        public decimal BillingAmount { get; set; } = 0m;

        [JsonPropertyName("actual_authentication_method")]
        public string ActualAuthenticationMethod { get; set; } = string.Empty;

        [JsonPropertyName("fees")]
        public Fees Fees { get; set; } = new Fees();

        [JsonPropertyName("merchant_city")]
        public string MerchantCity { get; set; } = string.Empty;

        [JsonPropertyName("merchant_data")]
        public MerchantData MerchantData { get; set; } = new MerchantData();

        [JsonPropertyName("transaction_amount")]
        public decimal TransactionAmount { get; set; } = 0m;

        [JsonPropertyName("channel")]
        public string Channel { get; set; } = string.Empty;

        [JsonPropertyName("sign")]
        public string Sign { get; set; } = string.Empty;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; } = string.Empty;

        [JsonPropertyName("merchant_currency")]
        public string MerchantCurrency { get; set; } = string.Empty;

        [JsonPropertyName("mcc")]
        public string MCC { get; set; } = string.Empty;

        [JsonPropertyName("billing_currency")]
        public string BillingCurrency { get; set; } = string.Empty;

        [JsonPropertyName("conversion_rate")]
        public string ConversionRate { get; set; } = string.Empty;

        [JsonPropertyName("transaction_currency")]
        public string TransactionCurrency { get; set; } = string.Empty;

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; } = 0;

        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; } = string.Empty;

        [JsonPropertyName("merchant_amount")]
        public decimal MerchantAmount { get; set; } = 0m;

        [JsonPropertyName("transaction_date")]
        public string TransactionDate { get; set; } = string.Empty;

        [JsonPropertyName("wallet")]
        public string Wallet { get; set; } = string.Empty;

        [JsonPropertyName("bill_amount")]
        public decimal BillAmount { get; set; } = 0m;

        [JsonPropertyName("authorization_id")]
        public string AuthorizationId { get; set; } = string.Empty;

        [JsonPropertyName("bill_currency")]
        public string BillCurrency { get; set; } = string.Empty;

        [JsonPropertyName("exchange_rate")]
        public string ExchangeRate { get; set; } = string.Empty;

        [JsonPropertyName("merchant_name")]
        public string MerchantName { get; set; } = string.Empty;

        [JsonPropertyName("message_id")]
        public string MessageId { get; set; } = string.Empty;

        [JsonPropertyName("transaction_type")]
        public string TransactionType { get; set; } = string.Empty;

        [JsonPropertyName("mcc_padding_amount")]
        public int MccPaddingAmount { get; set; } = 0;

        [JsonPropertyName("nonce")]
        public string Nonce { get; set; } = string.Empty;

        [JsonPropertyName("card_id")]
        public string CardId { get; set; } = string.Empty;

        [JsonPropertyName("lifecycle_event_id")]
        public string LifecycleEventId { get; set; } = string.Empty;

        [JsonPropertyName("settlement_currency")]
        public string SettlementCurrency { get; set; } = string.Empty;

        [JsonPropertyName("settlement_amount")]
        public decimal SettlementAmount { get; set; } = 0m;

        [JsonPropertyName("conversation_rate")]
        public string ConversationRate { get; set; } = string.Empty;

        [JsonPropertyName("merchant_country")]
        public string MerchantCountry { get; set; } = string.Empty;
    }
}