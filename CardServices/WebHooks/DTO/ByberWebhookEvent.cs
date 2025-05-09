using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cregis.WebHooks.DTO
{
    public class ByberWebhookEvent<T>
    {
        [JsonPropertyName("data")]
        public required T Data { get; set; }

        [JsonPropertyName("eventName")]
        public required string EventName { get; set; }

        [JsonPropertyName("eventType")]
        public required string EventType { get; set; }
    }
}
