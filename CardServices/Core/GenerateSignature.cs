using System.Security.Cryptography;
using System.Text.Json;
using System.Text;

namespace CregisService.CardServices.Core
{
    public class GenerateSignature
    {
        public string GenerateRequestSignature(IReadOnlyDictionary<string, string?> data, string signKey)
        {
            var flatParams = new Dictionary<string, string>();
            using var jsonDoc = JsonDocument.Parse(JsonSerializer.Serialize(data));
            FlattenJson(jsonDoc.RootElement, flatParams, "");

            var signatureBuilder = new StringBuilder(signKey);

            foreach (var kv in flatParams
                .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                .OrderBy(kv => kv.Key))
            {
                signatureBuilder.Append(kv.Key).Append(kv.Value);
            }

            return ComputeMd5Hash(signatureBuilder.ToString());
        }

        private static void FlattenJson(JsonElement element, Dictionary<string, string> result, string prefix)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (var prop in element.EnumerateObject())
                    {
                        FlattenJson(prop.Value, result, $"{prefix}{(string.IsNullOrEmpty(prefix) ? "" : ".")}{prop.Name}");
                    }
                    break;

                case JsonValueKind.Array:
                    int i = 0;
                    foreach (var item in element.EnumerateArray())
                    {
                        FlattenJson(item, result, $"{prefix}[{i}]");
                        i++;
                    }
                    break;

                case JsonValueKind.String:
                case JsonValueKind.Number:
                case JsonValueKind.True:
                case JsonValueKind.False:
                    result[prefix] = element.ToString();
                    break;

                case JsonValueKind.Null:
                case JsonValueKind.Undefined:
                    break;
            }
        }

        private static string ComputeMd5Hash(string input)
        {
            using var md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
