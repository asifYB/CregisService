using Cregis.WebHooks.DTO;
using Cregis.WebHooks.EventHandlers.Shared.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Cregis.WebHooks.EventHandlers.TransactionHandler
{
    public class RefundHandler : BaseTransactionHandler
    {
        protected override async Task<IActionResult> ProcessTransaction(TransactionData transactionData)
        {
            // Handle refund transaction logic
            await Task.CompletedTask;

            if (transactionData.Status == TransactionStatus.CLEARED.ToString())
            {
                return SuccessResponse();
            }

            return new BadRequestObjectResult($"Invalid status {transactionData.Status} for refund event");
        }
    }
}
