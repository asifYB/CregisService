namespace CregisService.CardServices.Models
{
    public class ProviderInformation
    {
        public string? productToken { get; set; }
        public string? Currency { get; set; }
        public string? FirstRechargeAmount { get; set; }
        public string? CardOpeningAmount { get; set; }
        public string? kyctype { get; set; }
        public string? tenantId { get; set; }


        //added new feilds
        public string? taskId { get; set; }
        public string? Status { get; set; }
        public string? UserCreated { get; set; }
        public int? CardBin { get; set; }
        public string? CardUserId { get; set; }
        public string? accountNo { get; set; }
        public string? Association { get; set; }
    }
}
