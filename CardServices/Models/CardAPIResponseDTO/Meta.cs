using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class Meta
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [JsonPropertyName("otpPhoneNumber")]
        public OtpPhoneNumber? OtpPhoneNumber { get; set; }
    }
}
