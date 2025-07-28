using System.ComponentModel.DataAnnotations;

namespace sampleforchecking.Models.CashierView_model
{
    public class SalesItem
    {
        [Key]
        public int Id { get; set; }

        public int SalesTransactionId { get; set; }
        public SalesTransaction SalesTransaction { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}
