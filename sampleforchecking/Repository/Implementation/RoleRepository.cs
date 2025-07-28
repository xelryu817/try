using sampleforchecking.Data;
using sampleforchecking.Models;
using Microsoft.EntityFrameworkCore;
using sampleforchecking.Repository.Interfaces;

namespace sampleforchecking.Repository.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly PharmacyDbContext _context;
        public RoleRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllAsync() =>
            await _context.Role.ToListAsync();

        public async Task<Role?> GetByIdAsync(int id) =>
            await _context.Role.FindAsync(id);

        public async Task AddAsync(Role role)
        {
            _context.Role.Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            _context.Role.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var role = await GetByIdAsync(id);
            if (role != null)
            {
                _context.Role.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}
