namespace sampleforchecking.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public int GenericID { get; set; }
        public int FormulationID { get; set; }
        public int ClassificationID { get; set; }
        public int TypeID { get; set; }
        public int SupplierID { get; set; }

        public int ReorderPoint { get; set; }
        public int StockOnHand { get; set; }
        public decimal Price { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
