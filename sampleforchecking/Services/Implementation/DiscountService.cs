using sampleforchecking.Data;
using sampleforchecking.DTOs.Discount;
using sampleforchecking.Models;
using Microsoft.EntityFrameworkCore;
using sampleforchecking.Services.Interfaces;

namespace sampleforchecking.Services.Implementation
{
    public class DiscountService : IDiscountService
    {
        private readonly PharmacyDbContext _context;

        public DiscountService(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiscountDto>> GetAllAsync()
        {
            return await _context.Discount
                .Select(d => new DiscountDto
                {
                    Id = d.Id,
                    Rate = d.Rate,
                    Description = d.Description
                }).ToListAsync();
        }

        public async Task<DiscountDto?> GetByIdAsync(int id)
        {
            var discount = await _context.Discount.FindAsync(id);
            if (discount == null) return null;

            return new DiscountDto
            {
                Id = discount.Id,
                Rate = discount.Rate,
                Description = discount.Description
            };
        }

        public async Task<DiscountDto> CreateAsync(CreateDiscountDto dto)
        {
            var discount = new Discount
            {
                Rate = dto.Rate,
                Description = dto.Description
            };

            _context.Discount.Add(discount);
            await _context.SaveChangesAsync();

            return new DiscountDto
            {
                Id = discount.Id,
                Rate = discount.Rate,
                Description = discount.Description
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateDiscountDto dto)
        {
            var discount = await _context.Discount.FindAsync(id);
            if (discount == null) return false;

            discount.Rate = dto.Rate;
            discount.Description = dto.Description;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var discount = await _context.Discount.FindAsync(id);
            if (discount == null) return false;

            _context.Discount.Remove(discount);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
