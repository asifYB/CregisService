using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class OtpPhoneNumber
    {
        [JsonPropertyName("dialCode")]
        public int DialCode { get; set; }

        [JsonPropertyName("phoneNumber")]
        public required string PhoneNumber { get; set; }
    }
}
