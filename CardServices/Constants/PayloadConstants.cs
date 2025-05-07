namespace CregisService.CardServices.Constants
{
    public static class PayloadConstants
    {
        // Common fields
        public const string CardType = "cardType";
        public const string CustomerType = "customerType";
        public const string PreferredCardName = "preferredCardName";
        public const string CardId = "cardId";
        public const string Timestamp = "timestamp";
        public const string Nonce = "nonce";
        public const string Pin = "pin";

        // Signature field sets
        public static string[] CreateCardSignFields =>
        [
            CardType,
            CustomerType,
            PreferredCardName,
            Timestamp,
            Nonce
        ];

        public static string[] ActivationCodeSignFields =>
        [
            CardId,
            Timestamp,
            Nonce
        ];

        public static string[] RetrieveCardDetailsSignFields =>
        [
            CardId,
            Timestamp,
            Nonce
        ];

        public static string[] ShowPANCardSignFields =>
        [
            CardId,
            Timestamp,
            Nonce
        ];

        public static string[] CardBlockSignFields =>
        [
            CardId,
            Timestamp,
            Nonce
        ];

        public static string[] CardUnblockSignFields =>
        [
            CardId,
            Timestamp,
            Nonce
        ];

        public static string[] SetPinSignFields =>
        [
            CardId,
            Pin,
            Timestamp,
            Nonce
        ];
    }
}
