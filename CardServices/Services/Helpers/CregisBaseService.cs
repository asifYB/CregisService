using CregisService.CardServices.Constants;
using CregisService.CardServices.Core;
using CregisService.CardServices.Models.CardAPIResponseDTO;
using HtmlAgilityPack;
using System.Net;
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

            // early return in case of cloudflaire security error
            if(!response.IsSuccessStatusCode && response.Content.Headers.ContentType?.MediaType == "text/html")
                // try to extract the html
                return ParseHtmlResponse<T>(responseContent, response.StatusCode);

            var transportDto = JsonSerializer.Deserialize<BaseResponse<T>>(responseContent, CachedJsonSerializerOptions);

            return transportDto;
        }

        // return the content from html response
        private BaseResponse<T> ParseHtmlResponse<T>(string response, HttpStatusCode statusCode)
        {
            // Try to extract error from HTML
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);

            var title = htmlDoc.DocumentNode.SelectSingleNode("//title")?.InnerText;
            var h1 = htmlDoc.DocumentNode.SelectSingleNode("//h1")?.InnerText;
            var h2 = htmlDoc.DocumentNode.SelectSingleNode("//h2")?.InnerText;

            var errorMsg = $"{title ?? "HTML error"} - {h1} {h2}".Trim();

            return new BaseResponse<T>
            {
                Code = statusCode.ToString(),
                Msg = errorMsg,
                Data = default!
            };
        }
    }
}
