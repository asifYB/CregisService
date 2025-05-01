namespace CregisService.CardServices.Models
{
    public class ResponseDto
    {
        public string taskId { get; set; } = default!;
        public string referenceId { get; set; } = default!;
        public string? Status { get; set; } = default!;
        public string? Remarks { get; set; } = default!;
        public string? CardNo { get; set; } = default!;
        public bool? async { get; set; } = default!;
        public string? cardId { get; set; } = default!;

    }
}
