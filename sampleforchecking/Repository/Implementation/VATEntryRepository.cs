using Microsoft.EntityFrameworkCore;
using sampleforchecking.Repository.Interfaces;
using sampleforchecking.Data;
using sampleforchecking.Models;

namespace PharmacyBackend.Repository.VatRepository
{
    public class VATEntryRepository : IVATEntryRepository
    {
        private readonly PharmacyDbContext _context;

        public VATEntryRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VATEntry>> GetAllAsync()
        {
            return await _context.VATEntries.ToListAsync();
        }

        public async Task<VATEntry?> GetByIdAsync(int id)
        {
            return await _context.VATEntries.FindAsync(id);
        }

        public async Task<VATEntry> AddAsync(VATEntry vatEntry)
        {
            _context.VATEntries.Add(vatEntry);
            await _context.SaveChangesAsync();
            return vatEntry;
        }

        public async Task<VATEntry> UpdateAsync(VATEntry vatEntry)
        {
            _context.VATEntries.Update(vatEntry);
            await _context.SaveChangesAsync();
            return vatEntry;
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