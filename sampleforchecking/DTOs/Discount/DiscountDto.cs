namespace sampleforchecking.DTOs.Discount
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Rate { get; set; }
    }
}
