using CregisService.CardServices.Constants;
using CregisService.CardServices.Core;
using CregisService.CardServices.Models.CardAPIResponseDTO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CregisService.CardServices.Services.Helpers
{
    public abstract class CregisBaseService
    {

        private readonly HttpClient _httpClient;
        protected readonly APIRequest _apiRequest;
        protected readonly GenerateSignature _generateRequestSignature;

        private static readonly JsonSerializerOptions CachedJsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Ensure consistent casing
        };


        protected CregisBaseService()
        {
            _apiRequest = new APIRequest();
            _generateRequestSignature = new GenerateSignature();
            _httpClient = new HttpClient();
        }

        protected string PrepareRequestPayload(
            string requestData,
            string[] signKeyFields,
            string? reason = null)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var nonce = Guid.NewGuid().ToString();

            // Efficient serialization and processing
            var payload = JsonSerializer.Deserialize<Dictionary<string, object>>(requestData) ?? throw new InvalidOperationException("Failed to deserialize the card payload.");

            payload["timestamp"] = timestamp;
            payload["nonce"] = nonce;

            // Efficient signature generation
            var signingParams = payload
                   .Where(kv => signKeyFields.Contains(kv.Key) && kv.Value != null)
                   .ToDictionary(kv => kv.Key, kv => kv.Value.ToString());


            payload["sign"] = _generateRequestSignature.GenerateRequestSignature(
                signingParams, ApiConstants.SignKey);

            if (reason is not null)
                payload["reason"] = reason;

            var finalPayload = JsonSerializer.Serialize(payload, CachedJsonSerializerOptions);
            return finalPayload;
        }

        protected async Task<BaseResponse<T>> SendPostRequestAsync<T>(string url, string jsonPayload)
        {
            using var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Add("merchant-id", ApiConstants.MerchantId);

            var response = await _httpClient.PostAsync(url, content);

            var responseContent = await response.Content.ReadAsStringAsync();

            var transportDto = JsonSerializer.Deserialize<BaseResponse<T>>(responseContent, CachedJsonSerializerOptions);

            return transportDto;
        }
    }
}
