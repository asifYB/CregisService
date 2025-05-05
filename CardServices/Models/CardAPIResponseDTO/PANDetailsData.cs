namespace CregisService.CardServices.Models.CardAPIResponseDTO
{
    public class PANDetailsData
    {
        public required string Cvv { get; set; }
        public required string ExpiryDate { get; set; }
        public required string Nonce { get; set; }
        public required string Pan { get; set; }
        public required string Sign { get; set; }
        public long Timestamp { get; set; }
    }
}
