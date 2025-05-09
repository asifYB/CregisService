using Cregis.WebHooks.Constants;
using Cregis.WebHooks.EventHandlers.Interface;
using Cregis.WebHooks.EventHandlers.TransactionHandler;
using Cregis.WebHooks.Handlers;

namespace Cregis.WebHooks.EventHandlers.Factory
{
    public class WebhookHandlerFactory
    {
        public static IWebhookHandler CreateHandler(string eventType, string eventName)
        {
            return (eventType.ToLowerInvariant(), eventName.ToLowerInvariant()) switch
            {
                (WebhookConstants.EventTypeAuthorization, WebhookConstants.EventNameRequest)
                    => new AuthorizationRequestHandler(),
                (WebhookConstants.EventTypeTransaction, WebhookConstants.EventNameAuthorization)
                    => new AuthorizationTransactionHandler(),
                (WebhookConstants.EventTypeTransaction, WebhookConstants.EventNameAuthorizationClearing)
                    => new AuthorizationClearingHandler(),
                (WebhookConstants.EventTypeTransaction, WebhookConstants.EventNameAuthorizationReversal)
                    => new AuthorizationReversalHandler(),
                (WebhookConstants.EventTypeTransaction, WebhookConstants.EventNameAuthorizationAdvice)
                    => new AuthorizationAdviceHandler(),
                (WebhookConstants.EventTypeTransaction, WebhookConstants.EventNameRefund)
                    => new RefundHandler(),
                (WebhookConstants.EventTypeCard, WebhookConstants.EventNameCardStatus)
                    => new CardStatusHandler(),
                (WebhookConstants.EventTypeNotification, WebhookConstants.EventNameBiometric)
               => new  _3DSForwardingHandler() ,
                _ => throw new NotSupportedException(
                    string.Format(WebhookConstants.UnhandledEvent, eventType, eventName))
            };
        }
    }
}
