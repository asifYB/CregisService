using System.Text.Json;

namespace Cregis.WebHooks.EventHandlers.Shared
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions DefaultJsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static JsonSerializerOptions GetDefaultJsonOptions(this object _)
        {
            return DefaultJsonOptions;
        }

        public static T? DeserializeWithDefaultOptions<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json, DefaultJsonOptions);
        }

        public static string SerializeWithDefaultOptions<T>(this T obj)
        {
            return JsonSerializer.Serialize(obj, DefaultJsonOptions);
        }
    }
}
