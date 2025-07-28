namespace sampleforchecking.DTOs.VATEntry
{
    public class CreateVATEntryDto
    {
        public string Description { get; set; } = string.Empty;
        public decimal Rate { get; set; }
    }
}
