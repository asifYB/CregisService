using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class CardDetailsData
    {
        [JsonPropertyName("cardName")]
        public required string CardName { get; set; }

        [JsonPropertyName("secondaryCardName")]
        public string? SecondaryCardName { get; set; }

        [JsonPropertyName("cardType")]
        public required string CardType { get; set; }

        [JsonPropertyName("last4")]
        public required string Last4 { get; set; }

        [JsonPropertyName("availableCredit")]
        public required string AvailableCredit { get; set; }

        [JsonPropertyName("status")]
        public required string Status { get; set; }

        [JsonPropertyName("freezeReason")]
        public required string FreezeReason { get; set; }

        [JsonPropertyName("statusReason")]
        public required string StatusReason { get; set; }

        [JsonPropertyName("physicalCardStatus")]
        public required string PhysicalCardStatus { get; set; }

        [JsonPropertyName("shippingAddress")]
        public required string ShippingAddress { get; set; }

        [JsonPropertyName("spendControl")]
        public SpendControl? SpendControl { get; set; }

        [JsonPropertyName("threeDSFowarding")]
        public bool ThreeDSFowarding { get; set; }

        [JsonPropertyName("cardDesign")]
        public string? CardDesign { get; set; }

        [JsonPropertyName("shippingInformation")]
        public ShippingInformation? ShippingInformation { get; set; }

        [JsonPropertyName("meta")]
        public required Meta Meta { get; set; }

        [JsonPropertyName("sign")]
        public required string Sign { get; set; }

        [JsonPropertyName("timestamp")]
        public required long Timestamp { get; set; }

        [JsonPropertyName("nonce")]
        public required string Nonce { get; set; }
    }
}
