using System.Text;

namespace CregisService.CardServices.Core
{
    public class APIRequest
    {
        private const string MerchantId = "PXqkHKbwGX";

        private readonly HttpClient _httpClient;

        public APIRequest(HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        public async Task<HttpResponseMessage> SendPostRequestAsync(string url, string jsonPayload)
        {
            using var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("merchant-id", MerchantId);

            var response = await _httpClient.PostAsync(url, content);

            //response.EnsureSuccessStatusCode(); // Throw if not successful

            return response;
        }
    }
}
