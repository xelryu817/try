using sampleforchecking.Data;
using sampleforchecking.Models;
using Microsoft.EntityFrameworkCore;
using sampleforchecking.Repository.Interfaces;

namespace sampleforchecking.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PharmacyDbContext _context;

        public EmployeeRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync() =>
            await _context.Employees.Include(e => e.Role).ToListAsync();

        public async Task<Employee?> GetByIdAsync(int id) =>
            await _context.Employees.Include(e => e.Role)
                                   .FirstOrDefaultAsync(e => e.Id == id);

        public async Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
