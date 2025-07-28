using System.ComponentModel.DataAnnotations;

namespace sampleforchecking.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } 
        public decimal Rate { get; set; } 
    }
}
