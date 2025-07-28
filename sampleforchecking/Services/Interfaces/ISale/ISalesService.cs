using sampleforchecking.DTOs.Sales;

namespace sampleforchecking.Services.Interfaces.ISale
{
    public interface ISalesService
    {
        Task<IEnumerable<SalesTransactionDto>> GetAllAsync();
        Task<SalesTransactionDto?> GetByIdAsync(int id);
        Task<SalesTransactionDto> CreateAsync(CreateSalesTransactionDto dto);
        Task<bool> UpdateAsync(int id, UpdateSalesTransactionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
