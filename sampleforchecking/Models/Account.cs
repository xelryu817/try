using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sampleforchecking.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public int AccountCode { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public int EmployeeId { get; set; }

        [JsonIgnore]
        public Employee Employee { get; set; }
    }
}
