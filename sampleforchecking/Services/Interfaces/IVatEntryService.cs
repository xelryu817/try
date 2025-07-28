using sampleforchecking.DTOs.VATEntry;

namespace sampleforchecking.Services.Interfaces
{
    public interface IVatEntryService
    {
        Task<IEnumerable<VATEntryDto>> GetAllAsync();
        Task<VATEntryDto?> GetByIdAsync(int id);
        Task<VATEntryDto> CreateAsync(CreateVATEntryDto dto);
        Task<bool> UpdateAsync(int id, UpdateVATEntryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
