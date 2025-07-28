namespace sampleforchecking.DTOs.Sales
{
    public class UpdateSalesTransactionDto
    {
        public decimal DiscountAmount { get; set; }
        public List<UpdateSalesItemDto> Items { get; set; } = new();
    }
}
