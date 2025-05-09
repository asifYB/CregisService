using Cregis.WebHooks.DTO;
using Cregis.WebHooks.EventHandlers.Shared.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Cregis.WebHooks.EventHandlers.TransactionHandler
{
    public class AuthorizationReversalHandler : BaseTransactionHandler
    {
        protected override async Task<IActionResult> ProcessTransaction(TransactionData transactionData)
        {
            // Handle reversal transaction logic
            await Task.CompletedTask;

            if (transactionData.Status == TransactionStatus.PENDING.ToString() ||
                transactionData.Status == TransactionStatus.VOID.ToString())
            {
                return SuccessResponse();
            }

            return new BadRequestObjectResult($"Invalid status {transactionData.Status} for reversal event");
        }
    }
}
