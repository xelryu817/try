using System.ComponentModel.DataAnnotations;

namespace sampleforchecking.Models.CashierView_model
{
    public class SalesTransaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }

        public ICollection<SalesItem> Items { get; set; } = new List<SalesItem>();
    }
}
