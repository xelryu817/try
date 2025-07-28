using System.ComponentModel.DataAnnotations;

namespace sampleforchecking.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RolePosition { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
