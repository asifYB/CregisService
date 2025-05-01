namespace CregisService.CardServices.Models
{
    public class BindCardDto : ProviderInformationDto
    {
        public string cardid { get; set; }
        public string UniqueId { get; set; }
        public string CardNo { get; set; }
        public string EnvelopeNo { get; set; }
        public string Email { get; set; }
        public string activePhoto { get; set; }
        public KYC? Kyc { get; set; }
    }
}
