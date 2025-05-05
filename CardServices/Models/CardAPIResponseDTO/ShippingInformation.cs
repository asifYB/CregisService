using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class ShippingInformation
    {
        [JsonPropertyName("bulkShippingID")]
        public required string BulkShippingID { get; set; }

        [JsonPropertyName("sku")]
        public string? Sku { get; set; }
    }
}
