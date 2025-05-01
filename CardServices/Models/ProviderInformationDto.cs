namespace CregisService.CardServices.Models
{
    public class ProviderInformationDto
    {
        public string? PublicKey { get; set; }
        public string? PrivateKey { get; set; }
        public string? ApiKey { get; set; }
        public string? Kid { get; set; }
        public string? TenantId { get; set; }
    }
}
