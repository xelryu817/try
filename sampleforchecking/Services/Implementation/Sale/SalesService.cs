using Microsoft.EntityFrameworkCore;
using sampleforchecking.Data;
using sampleforchecking.DTOs.Sales;
using sampleforchecking.Models;
using sampleforchecking.Models.CashierView_model;
using sampleforchecking.Services.Interfaces.ISale;

namespace sampleforchecking.Services.Implementation.Sale
{
    public class SalesService : ISalesService
    {
        private readonly PharmacyDbContext _context;

        public SalesService(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesTransactionDto>> GetAllAsync()
        {
            var transactions = await _context.SalesTransaction
                .Include(t => t.Items)
                    .ThenInclude(i => i.Product)
                .ToListAsync();

            return transactions.Select(t => new SalesTransactionDto
            {
                Id = t.Id,
                TransactionDate = t.TransactionDate,
                InvoiceNumber = t.InvoiceNumber,
                TotalAmount = t.TotalAmount,
                DiscountAmount = t.DiscountAmount,
                NetAmount = t.NetAmount,
                Items = t.Items.Select(i => new SalesItemDto
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    ProductName = i.Product?.ProductName ?? string.Empty,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Subtotal = i.Subtotal
                }).ToList()
            });
        }

        public async Task<SalesTransactionDto?> GetByIdAsync(int id)
        {
            var t = await _context.SalesTransaction
                .Include(t => t.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (t == null) return null;

            return new SalesTransactionDto
            {
                Id = t.Id,
                TransactionDate = t.TransactionDate,
                InvoiceNumber = t.InvoiceNumber,
                TotalAmount = t.TotalAmount,
                DiscountAmount = t.DiscountAmount,
                NetAmount = t.NetAmount,
                Items = t.Items.Select(i => new SalesItemDto
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    ProductName = i.Product?.ProductName ?? string.Empty,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Subtotal = i.Subtotal
                }).ToList()
            };
        }

        public async Task<SalesTransactionDto> CreateAsync(CreateSalesTransactionDto dto)
        {
            var transaction = new SalesTransaction
            {
                TransactionDate = DateTime.Now,
                InvoiceNumber = dto.InvoiceNumber,
                DiscountAmount = dto.DiscountAmount,
                Items = dto.Items.Select(i => new SalesItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Subtotal = i.UnitPrice * i.Quantity
                }).ToList()
            };

            transaction.TotalAmount = transaction.Items.Sum(i => i.Subtotal);
            transaction.NetAmount = transaction.TotalAmount - transaction.DiscountAmount;

            _context.SalesTransaction.Add(transaction);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(transaction.Id) ?? throw new Exception("Creation failed");
        }

        public async Task<bool> UpdateAsync(int id, UpdateSalesTransactionDto dto)
        {
            var transaction = await _context.SalesTransaction
                .Include(t => t.Items)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transaction == null) return false;

            transaction.DiscountAmount = dto.DiscountAmount;

            foreach (var updateItem in dto.Items)
            {
                var existingItem = transaction.Items.FirstOrDefault(i => i.Id == updateItem.Id);
                if (existingItem != null)
                {
                    existingItem.Quantity = updateItem.Quantity;
                    existingItem.UnitPrice = updateItem.UnitPrice;
                    existingItem.Subtotal = updateItem.UnitPrice * updateItem.Quantity;
                }
            }

            transaction.TotalAmount = transaction.Items.Sum(i => i.Subtotal);
            transaction.NetAmount = transaction.TotalAmount - transaction.DiscountAmount;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transaction = await _context.SalesTransaction
                .Include(t => t.Items)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transaction == null) return false;

            _context.SalesItems.RemoveRange(transaction.Items);
            _context.SalesTransaction.Remove(transaction);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

