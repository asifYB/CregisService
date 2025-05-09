using System.Text.Json;
using Cregis.WebHooks.DTO;
using Cregis.WebHooks.EventHandlers.Interface;
using Cregis.WebHooks.EventHandlers.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Cregis.WebHooks.EventHandlers
{
    public class _3DSForwardingHandler : IWebhookHandler
    {
        public Task<IActionResult> HandleAsync(ByberWebhookEvent<JsonElement> payload)
        {
            var payloadJson = payload.SerializeWithDefaultOptions();
            var notificationData = payloadJson.DeserializeWithDefaultOptions<ByberWebhookEvent<BiometricAuthNotificationData>>();

            if (notificationData?.Data == null)
            {
                return Task.FromResult<IActionResult>(
                    new BadRequestObjectResult("Invalid card status data"));
            }

            // Process the card status change
            ProcessBiometricAuthNotification(notificationData.Data);

            // Return success response as required by the API
            return Task.FromResult<IActionResult>(new ContentResult
            {
                Content = "success",
                ContentType = "text/plain",
                StatusCode = 200
            });
        }

        private void ProcessBiometricAuthNotification(BiometricAuthNotificationData authNotificationData)
        {
            //implement your logic to process the card status change
            if (authNotificationData.Status == "PENDING")
            {
                // This is where you would typically:
                // - Notify your system to perform alternative authentication
                // - Queue the request for processing
                // - Initiate your biometric authentication flow

                // Store the initiateActionId to use when responding to the 3DS request
            }
            else
            {
                // Handle other statuses if they exist
            }
        }
    }
}
