namespace CregisService.CardServices.Constants
{
    public static class ApiConstants
    {
        public const string BaseUrl = "https://api-sandbox.byber.cc";
        public const string SignKey = "c6043c5bb7ed4afcba4272f48faa356f";

        public static readonly string[] CreateCardSignFields =
            { "cardType", "customerType", "preferredCardName", "timestamp", "nonce" };

        public static readonly string[] ActivationCodeSignFields =
            { "cardId", "timestamp", "nonce" };

        public static class Endpoints
        {
            public static readonly string ApplyCard = $"{BaseUrl}/byber-cards-api/cards/apply/card";
            public static readonly string ActivationCode = $"{BaseUrl}/byber-cards-api/cards/activeCode";
        }
    }
}
