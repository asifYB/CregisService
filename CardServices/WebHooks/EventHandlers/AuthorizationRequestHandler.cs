using System.Text.Json;
using Cregis.WebHooks.Constants;
using Cregis.WebHooks.DTO;
using Cregis.WebHooks.EventHandlers.Interface;
using Cregis.WebHooks.EventHandlers.Shared;
using CregisService.CardServices.Core;
using Microsoft.AspNetCore.Mvc;

namespace Cregis.WebHooks.Handlers
{
    public class AuthorizationRequestHandler : IWebhookHandler
    {
        private const string SignKey = "c6043c5bb7ed4afcba4272f48faa356f";
        private const string SuccessCode = "00";
        private const string TransactionNotPermitted = "57";
        private const string InsufficientFundsCode = "51";
        private const string ActiveStatus = "Active";

        public async Task<IActionResult> HandleAsync(ByberWebhookEvent<JsonElement> payload)
        {
            
            var payloadJson = payload.SerializeWithDefaultOptions();
            var authPayload = payloadJson.DeserializeWithDefaultOptions<ByberWebhookEvent<AuthorizationData>>();

            if (authPayload?.Data is null)
            {
                return new BadRequestObjectResult(WebhookConstants.InvalidAuthData);
            }

            if (!VerifyAndProcessAuthorization(authPayload))
            {
                return new BadRequestObjectResult(WebhookConstants.InvalidSignature);
            }

            var (isValid, declineCode) = await ValidateAuthorization(authPayload.Data);

            return isValid
                ? CreateAuthorizationResponse(authPayload.Data, SuccessCode)
                : CreateAuthorizationResponse(authPayload.Data, declineCode);
        }

        private async Task<(bool isValid, string declineCode)> ValidateAuthorization(AuthorizationData authData)
        {
            if (!await IsCardActiveAsync(authData.CardId))
                return (false, TransactionNotPermitted);

            if (!await HasSufficientBalanceAsync(authData))
                return (false, InsufficientFundsCode);

            return (true, SuccessCode);
        }

        private bool VerifyAndProcessAuthorization(ByberWebhookEvent<AuthorizationData> authPayload)
        {
            var signatureData = new Dictionary<string, string>
            {
                ["card_id"] = authPayload.Data.CardId,
                ["channel"] = authPayload.Data.Channel,
                ["bill_amount"] = authPayload.Data.BillAmount.ToString(),
                ["transaction_id"] = authPayload.Data.TransactionId,
                ["lifecycle_event_id"] = authPayload.Data.LifecycleEventId,
                ["authorization_id"] = authPayload.Data.AuthorizationId,
                ["eventName"] = authPayload.EventName,
                ["eventType"] = authPayload.EventType,
                ["timestamp"] = authPayload.Data.Timestamp.ToString(),
                ["nonce"] = authPayload.Data.Nonce
            };

            return GenerateSignature(signatureData!)
                .Equals(authPayload.Data.Sign, StringComparison.OrdinalIgnoreCase);
        }

        private string GenerateSignature(Dictionary<string, string?> data)
        {
            return new GenerateSignature().GenerateRequestSignature(data, SignKey).ToLowerInvariant();
        }

        private IActionResult CreateAuthorizationResponse(AuthorizationData authData, string responseCode)
        {
            var response = new AuthorizationResponse
            {
                ResponseCode = responseCode,
                AuthorizationId = authData.AuthorizationId,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                Nonce = Guid.NewGuid().ToString(),
                Sign = GenerateSignature(new Dictionary<string, string?>
                {
                    ["response_code"] = responseCode,
                    ["authorization_id"] = authData.AuthorizationId,
                    ["timestamp"] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(),
                    ["nonce"] = Guid.NewGuid().ToString()
                })
            };

            return new OkObjectResult(response);
        }

        private async Task<bool> IsCardActiveAsync(string cardId)
        {
            return await GetCardStatusAsync(cardId) == ActiveStatus;
        }
            

        private async Task<bool> HasSufficientBalanceAsync(AuthorizationData authData)
        {
            return await GetAvailableBalanceAsync(authData.CardId, authData.BillingCurrency) >= authData.BillAmount;
        }
            
        private async Task<string> GetCardStatusAsync(string cardId)
        {
            // Implementation to check card status in the database
            await Task.Delay(10);
            return ActiveStatus;
        }

        private async Task<decimal> GetAvailableBalanceAsync(string cardId, string currency)
        {
            // Implementation to check available balance in the database
            await Task.Delay(10);
            return 1000.00m;
        }
    }
}