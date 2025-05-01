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
        private const string MerchantId = "PXqkHKbwGX";

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
            string? customSignKey = null)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var nonce = Guid.NewGuid().ToString();

            // Efficient serialization and processing
            using var jsonDoc = JsonSerializer.SerializeToDocument(requestData);
            var payload = jsonDoc.RootElement.Deserialize<Dictionary<string, object>>()
                ?? throw new InvalidOperationException("Failed to deserialize request payload");

            payload["timestamp"] = timestamp;
            payload["nonce"] = nonce;

            // Efficient signature generation
            var signingParams = jsonDoc.RootElement.EnumerateObject()
            .Where(p => signKeyFields.Contains(p.Name) && p.Value.ValueKind != JsonValueKind.Null)
            .ToDictionary(
                p => p.Name,
                p => (string?)(p.Value.ValueKind == JsonValueKind.String
                    ? p.Value.GetString()
                    : p.Value.GetRawText()));

            payload["sign"] = _generateRequestSignature.GenerateRequestSignature(
                signingParams,
                customSignKey ?? ApiConstants.SignKey);

            var finalPayload = JsonSerializer.Serialize(payload, CachedJsonSerializerOptions);
            return finalPayload;
        }

        protected async Task<BaseResponse<T>> SendPostRequestAsync<T>(string url, string jsonPayload)
        {
            using var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Add("merchant-id", MerchantId);

            var response = await _httpClient.PostAsync(url, content);

            var responseContent = await response.Content.ReadAsStringAsync();

            var transportDto = JsonSerializer.Deserialize<BaseResponse<T>>(responseContent, CachedJsonSerializerOptions);

            return transportDto;
        }
    }
}
