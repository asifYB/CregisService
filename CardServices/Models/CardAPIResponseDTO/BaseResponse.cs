using System.Text.Json;
using System.Text.Json.Serialization;

namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class BaseResponse<T>
    {
        [JsonPropertyName("code")]
        public required string Code { get; set; }
        [JsonPropertyName("msg")]
        public required string Msg { get; set; }
        [JsonPropertyName("data")]
        public required T Data { get; set; }
    }

}
