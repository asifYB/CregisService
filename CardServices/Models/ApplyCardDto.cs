namespace CregisService.CardServices.Models
{
    public class ApplyCardDto : ProviderInformationDto
    {
        public string ProgramId { get; set; }
        public KYC? KYC { get; set; }
        public ProviderInformation ProviderInformation { get; set; }
    }
}
