namespace Cregis.WebHooks.DTO
{
    public class AuthorizationResponse
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string AuthorizationId { get; set; } = string.Empty;
        public long Timestamp { get; set; }
        public string Nonce { get; set; } = string.Empty;
        public string Sign { get; set; } = string.Empty;
    }
}
