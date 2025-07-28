namespace sampleforchecking.DTOs.Sales
{
    public class SalesTransactionDto
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }

        public List<SalesItemDto> Items { get; set; } = new();
    }
}
