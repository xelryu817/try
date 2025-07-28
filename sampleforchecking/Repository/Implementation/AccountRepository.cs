using sampleforchecking.Data;
using sampleforchecking.Models;
using Microsoft.EntityFrameworkCore;
using sampleforchecking.Repository.Interfaces;

namespace sampleforchecking.Repository.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PharmacyDbContext _context;
        public AccountRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAsync() =>
            await _context.Accounts.Include(a => a.Employee).ToListAsync();

        public async Task<Account?> GetByIdAsync(int id) =>
            await _context.Accounts.Include(a => a.Employee).FirstOrDefaultAsync(a => a.Id == id);

        public async Task AddAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var account = await GetByIdAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
