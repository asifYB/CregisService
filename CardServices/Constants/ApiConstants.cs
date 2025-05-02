namespace CregisService.CardServices.Constants
{
    public static class ApiConstants
    {
        public const string BaseUrl = "https://api-sandbox.byber.cc";
        public const string SignKey = "c6043c5bb7ed4afcba4272f48faa356f";
        public const string MerchantId = "PXqkHKbwGX";

        public static readonly string[] CreateCardSignFields =
            { "cardType", "customerType", "preferredCardName", "timestamp", "nonce" };

        public static readonly string[] ActivationCodeSignFields =
            { "cardId", "timestamp", "nonce" };

        public static class Endpoints
        {
            public static readonly string ApplyCard = $"{BaseUrl}/byber-cards-api/cards/apply/card";
            public static readonly string ActivationCode = $"{BaseUrl}/byber-cards-api/cards/activeCode";
        }

        public static class RSA
        {
            public const string PublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAq3v1x5+4J6X2Z5g7m1h4" +
                                            "Yj6c3f";
            public const string PrivateKey = "";
        }
    }
}
