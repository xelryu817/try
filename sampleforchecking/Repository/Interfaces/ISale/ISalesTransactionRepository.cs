using sampleforchecking.Models.CashierView_model;

namespace sampleforchecking.Repository.Interfaces.ISale
{
    public interface ISalesTransactionRepository
    {
        Task<IEnumerable<SalesTransaction>> GetAllAsync();
        Task<SalesTransaction?> GetByIdAsync(int id);
        Task AddAsync(SalesTransaction transaction);
        Task UpdateAsync(SalesTransaction transaction);
        Task DeleteAsync(SalesTransaction transaction);
        Task SaveChangesAsync();
    }
}
