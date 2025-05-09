using System.Text.Json;
using Cregis.WebHooks.DTO;
using Cregis.WebHooks.EventHandlers.Interface;
using Cregis.WebHooks.EventHandlers.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Cregis.WebHooks.EventHandlers
{
    public class CardStatusHandler : IWebhookHandler
    {
        public Task<IActionResult> HandleAsync(ByberWebhookEvent<JsonElement> payload)
        {
            try
            {
                var payloadJson = payload.SerializeWithDefaultOptions();
                var cardStatusDetails = payloadJson.DeserializeWithDefaultOptions<ByberWebhookEvent<CardStatusDetail>>();

                if (cardStatusDetails?.Data == null)
                {
                    return Task.FromResult<IActionResult>(
                        new BadRequestObjectResult("Invalid card status data"));
                }

                // Process the card status change
                ProcessCardStatusChange(cardStatusDetails);

                // Return success response as required by the API
                return Task.FromResult<IActionResult>(new ContentResult
                {
                    Content = "success",
                    ContentType = "text/plain",
                    StatusCode = 200
                });
            }
            catch (JsonException ex)
            {
                return Task.FromResult<IActionResult>(
                    new BadRequestObjectResult($"Invalid JSON payload: {ex.Message}"));
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging configured
                return Task.FromResult<IActionResult>(
                    new ObjectResult($"Error processing card status: {ex.Message}")
                    {
                        StatusCode = 500
                    });
            }
        }

        private void ProcessCardStatusChange(ByberWebhookEvent<CardStatusDetail> bybercardStatusDetails)
        {
            switch (bybercardStatusDetails.Data.Status)
            {
                case "ACTIVE":
                    // Handle card activation
                    break;
                case "BLOCKED":
                    // Handle card blocking with possible reason
                    HandleBlockedCard(bybercardStatusDetails.Data);
                    break;
                case "DELETED":
                    // Handle card deletion
                    break;
                case "EXPIRED":
                    // Handle card expiration
                    break;
                case "INACTIVE":
                    // Handle inactive card (KYC not done)
                    break;
                case "FROZEN":
                    // Handle frozen card
                    break;
                default:
                    // Handle unknown status
                    break;
            }
        }

        private void HandleBlockedCard(CardStatusDetail cardStatusDetails)
        {
            // Handle blocked card with specific reason if available
            switch (cardStatusDetails.Desc)
            {
                case "SUSPECTED_FRAUD_CVV":
                    // Handle CVV fraud case
                    break;
                case "SUSPECTED_FRAUD_EXPIRY":
                    // Handle expiry fraud case
                    break;
                case "SUSPECTED_FRAUD_PIN":
                    // Handle PIN fraud case
                    break;
                default:
                    // Handle generic blocking
                    break;
            }
        }
    }
}
