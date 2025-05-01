namespace CregisService.CardServices.Models
{
    public class CardDetailsRespDto
    {
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpirationDate { get; set; }
        public string? CardStatus { get; set; }

    }
}
