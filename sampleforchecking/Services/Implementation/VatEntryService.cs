using sampleforchecking.Data;
using sampleforchecking.DTOs.VATEntry;
using sampleforchecking.Models;
using Microsoft.EntityFrameworkCore;
using sampleforchecking.Repository.Interfaces;
using sampleforchecking.Services.Interfaces;

namespace sampleforchecking.Services.Implementation
{
    public class VatEntryService : IVatEntryService
    {
        private readonly PharmacyDbContext _context;

        public VatEntryService(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VATEntryDto>> GetAllAsync()
        {
            return await _context.VATEntries
                .Select(v => new VATEntryDto
                {
                    Id = v.Id,
                    Rate = v.Rate,
                    Description = v.Description
                }).ToListAsync();
        }

        public async Task<VATEntryDto?> GetByIdAsync(int id)
        {
            var vat = await _context.VATEntries.FindAsync(id);
            if (vat == null) return null;

            return new VATEntryDto
            {
                Id = vat.Id,
                Rate = vat.Rate,
                Description = vat.Description
            };
        }

        public async Task<VATEntryDto> CreateAsync(CreateVATEntryDto dto)
        {
            var vat = new VATEntry
            {
                Rate = dto.Rate,
                Description = dto.Description
            };

            _context.VATEntries.Add(vat);
            await _context.SaveChangesAsync();

            return new VATEntryDto
            {
                Id = vat.Id,
                Rate = vat.Rate,
                Description = vat.Description
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateVATEntryDto dto)
        {
            var vat = await _context.VATEntries.FindAsync(id);
            if (vat == null) return false;

            vat.Rate = dto.Rate;
            vat.Description = dto.Description;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vat = await _context.VATEntries.FindAsync(id);
            if (vat == null) return false;

            _context.VATEntries.Remove(vat);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
