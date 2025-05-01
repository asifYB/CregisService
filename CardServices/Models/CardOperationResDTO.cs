namespace CregisService.CardServices.Models
{
    public class CardOperationResDTO
    {
        public string TaskId { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string Remarks { get; set; } = default!;
        public string OrderNo { get; set; } = default!;
        public bool? async { get; set; } = default!;
        public double cardBalance { get; set; }
    }
}
