using Cregis.WebHooks.DTO;
using Cregis.WebHooks.EventHandlers.Shared.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Cregis.WebHooks.EventHandlers.TransactionHandler
{
    public class AuthorizationTransactionHandler : BaseTransactionHandler
    {
        protected override async Task<IActionResult> ProcessTransaction(TransactionData transactionData)
        {
            // Handle authorization transaction logic
            // Example: Validate transaction, update database, etc.
            await Task.CompletedTask;

            if (transactionData.Status == TransactionStatus.PENDING.ToString() ||
                transactionData.Status == TransactionStatus.VOID.ToString())
            {
                return SuccessResponse();
            }

            return new BadRequestObjectResult($"Invalid status {transactionData.Status} for authorization event");
        }
    }
}
