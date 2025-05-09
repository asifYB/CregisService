using Cregis.WebHooks.Constants;
using Cregis.WebHooks.DTO;
using Cregis.WebHooks.EventHandlers.Interface;
using Cregis.WebHooks.EventHandlers.Shared;
using CregisService.CardServices.Core;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Cregis.WebHooks.EventHandlers.TransactionHandler
{
    public abstract class BaseTransactionHandler : IWebhookHandler
    {
        private const string SignKey = "c6043c5bb7ed4afcba4272f48faa356f";

        public async Task<IActionResult> HandleAsync(ByberWebhookEvent<JsonElement> payload)
        {
            var payloadJson = payload.SerializeWithDefaultOptions();
            var transactionPayload = payloadJson.DeserializeWithDefaultOptions<ByberWebhookEvent<TransactionData>>();

            if (transactionPayload?.Data is null)
            {
                return new BadRequestObjectResult(WebhookConstants.InvalidTransactionData);
            }

            if (!VerifySignature(transactionPayload))
            {
                return new BadRequestObjectResult(WebhookConstants.InvalidSignature);
            }

            return await ProcessTransaction(transactionPayload.Data);
        }

        protected abstract Task<IActionResult> ProcessTransaction(TransactionData transactionData);

        private bool VerifySignature(ByberWebhookEvent<TransactionData> transactionPayload)
        {
            var data = new Dictionary<string, string>
            {
                ["card_id"] = transactionPayload.Data.CardId,
                ["channel"] = transactionPayload.Data.Channel,
                ["bill_amount"] = transactionPayload.Data.BillAmount.ToString(),
                ["id"] = transactionPayload.Data.Id,
                ["lifecycle_event_id"] = transactionPayload.Data.LifecycleEventId,
                ["status"] = transactionPayload.Data.Status,
                ["eventName"] = transactionPayload.EventName,
                ["eventType"] = transactionPayload.EventType,
                ["timestamp"] = transactionPayload.Data.Timestamp.ToString(),
                ["nonce"] = transactionPayload.Data.Nonce
            };

            string generatedSign = GenerateSignature(data!);
            return generatedSign.Equals(transactionPayload.Data.Sign, StringComparison.OrdinalIgnoreCase);
        }

        private string GenerateSignature(Dictionary<string, string?> data)
        {
            return new GenerateSignature().GenerateRequestSignature(data, SignKey).ToLowerInvariant();
        }

        protected IActionResult SuccessResponse() => new OkObjectResult("success");
    }
}
