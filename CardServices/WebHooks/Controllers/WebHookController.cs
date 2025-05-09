using System;
using System.Text.Json;
using System.Threading.Tasks;
using Cregis.WebHooks.Constants;
using Cregis.WebHooks.DTO;
using Cregis.WebHooks.EventHandlers.Factory;
using Cregis.WebHooks.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Cregis.WebHooks.Controllers
{
    [ApiController]
    [Route("api/webhook")]
    public class WebHookController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> HandleWebhook([FromBody] ByberWebhookEvent<JsonElement> rawPayload)
        {
            if (string.IsNullOrWhiteSpace(rawPayload?.EventName) || string.IsNullOrWhiteSpace(rawPayload.EventType))
            {
                return BadRequest("Missing eventName or eventType.");
            }

            var eventType = rawPayload.EventType.ToLowerInvariant();
            var eventName = rawPayload.EventName.ToLowerInvariant();

            try
            {
                var handler = WebhookHandlerFactory.CreateHandler(
                    rawPayload.EventType,
                    rawPayload.EventName);

                return await handler.HandleAsync(rawPayload);
            }
            catch (NotSupportedException ex)
            {
                return StatusCode(501, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format(WebhookConstants.ProcessingFailed, ex.Message));
            }
        }
    }
}