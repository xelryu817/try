using sampleforchecking.Models;

namespace sampleforchecking.Repository.Interfaces
{
    public interface IVATEntryRepository
    {
        Task<IEnumerable<VATEntry>> GetAllAsync();
        Task<VATEntry?> GetByIdAsync(int id);
        Task<VATEntry> AddAsync(VATEntry vatEntry);
        Task<VATEntry> UpdateAsync(VATEntry vatEntry);
        Task<bool> DeleteAsync(int id);
    }
}
