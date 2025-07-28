using sampleforchecking.Data;
using sampleforchecking.Models;
using Microsoft.EntityFrameworkCore;
using sampleforchecking.Repository.Interfaces;

namespace sampleforchecking.Repository.Implementation
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly PharmacyDbContext _context;

        public DiscountRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Discount>> GetAllAsync()
        {
            return await _context.Discount.ToListAsync();
        }

        public async Task<Discount?> GetByIdAsync(int id)
        {
            return await _context.Discount.FindAsync(id);
        }

        public async Task<Discount> CreateAsync(Discount discount)
        {
            _context.Discount.Add(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task<bool> UpdateAsync(int id, Discount discount)
        {
            var existing = await _context.Discount.FindAsync(id);
            if (existing == null) return false;

            existing.Description = discount.Description;
            existing.Rate = discount.Rate;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Discount.FindAsync(id);
            if (existing == null) return false;

            _context.Discount.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
