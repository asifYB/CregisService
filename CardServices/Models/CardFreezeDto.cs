namespace CregisService.CardServices.Models
{
    public class CardFreezeDto : ProviderInformationDto
    {
        public string? ProviderCardToken { get; set; }
        public string? UniqueId { get; set; }
        public string? SignImage { get; set; }
        public string? pinNumber { get; set; }
    }
}
