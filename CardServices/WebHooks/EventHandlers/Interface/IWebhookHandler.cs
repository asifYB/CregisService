using Cregis.WebHooks.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Cregis.WebHooks.EventHandlers.Interface
{
    public interface IWebhookHandler
    {
        Task<IActionResult> HandleAsync(ByberWebhookEvent<JsonElement> payload);
    }
}
