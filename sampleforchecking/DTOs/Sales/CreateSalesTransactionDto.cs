namespace sampleforchecking.DTOs.Sales
{
    public class CreateSalesTransactionDto
    {
        public string InvoiceNumber { get; set; }
        public decimal DiscountAmount { get; set; }

        public List<CreateSalesItemDto> Items { get; set; } = new();
    }
}
