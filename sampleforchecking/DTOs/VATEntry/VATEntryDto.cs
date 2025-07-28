namespace sampleforchecking.DTOs.VATEntry
{
    public class VATEntryDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Rate { get; set; }
    }
}
