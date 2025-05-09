namespace Cregis.WebHooks.Constants
{
    public static class WebhookConstants
    {
        public const string EventTypeAuthorization = "authorization";
        public const string EventTypeTransaction = "transaction";
        public const string EventTypeCard = "card";
        public const string EventTypeNotification = "notification";
        public const string EventNameRequest = "request";
        public const string EventNameAuthorization = "authorization";
        public const string EventNameAuthorizationClearing = "authorization.clearing";
        public const string EventNameAuthorizationReversal = "authorization.reversal";
        public const string EventNameAuthorizationAdvice = "authorizatio.advice";
        public const string EventNameRefund = "refund";
        public const string EventNameCardStatus = "card_status";
        public const string EventNameBiometric = "biometric_auth_notification_received";
        public const string UnhandledEvent = "Unhandled event type '{0}' and event name '{1}'.";
        public const string InvalidAuthData = "Invalid authorization data.";
        public const string AuthRequestProcessed = "Authorization request processed successfully.";
        public const string ProcessingFailed = "Processing failed: {0}";
        public const string InvalidSignature = "Invalid signature.";
        public const string InvalidTransactionData = "Invalid transaction data."; 
    }
}
