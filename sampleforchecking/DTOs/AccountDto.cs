namespace sampleforchecking.DTOs
{
    public class AccountDto
    {
        public int Id { get; set; }
        public int AccountCode { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public int EmployeeId { get; set; }

        public string? EmployeeFullName { get; set; }
    }
}
