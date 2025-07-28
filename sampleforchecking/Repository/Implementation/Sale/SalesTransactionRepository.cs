using sampleforchecking.Data;
using Microsoft.EntityFrameworkCore;
using sampleforchecking.Models.CashierView_model;
using sampleforchecking.Repository.Interfaces.ISale;

namespace sampleforchecking.Repository.Implementation.Sale
{
    public class SalesTransactionRepository : ISalesTransactionRepository
    {
        private readonly PharmacyDbContext _context;

        public SalesTransactionRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesTransaction>> GetAllAsync()
        {
            return await _context.SalesTransaction
                .Include(t => t.Items)
                .ToListAsync();
        }

        public async Task<SalesTransaction?> GetByIdAsync(int id)
        {
            return await _context.SalesTransaction
                .Include(t => t.Items)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(SalesTransaction transaction)
        {
            await _context.SalesTransaction.AddAsync(transaction);
        }

        public async Task UpdateAsync(SalesTransaction transaction)
        {
            _context.SalesTransaction.Update(transaction);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(SalesTransaction transaction)
        {
            _context.SalesTransaction.Remove(transaction);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
