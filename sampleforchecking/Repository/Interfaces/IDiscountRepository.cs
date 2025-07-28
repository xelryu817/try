using sampleforchecking.Models;

namespace sampleforchecking.Repository.Interfaces
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Discount>> GetAllAsync();
        Task<Discount?> GetByIdAsync(int id);
        Task<Discount> CreateAsync(Discount discount);
        Task<bool> UpdateAsync(int id, Discount discount);
        Task<bool> DeleteAsync(int id);
    }
}
