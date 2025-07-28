using sampleforchecking.DTOs.Discount;

namespace sampleforchecking.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<IEnumerable<DiscountDto>> GetAllAsync();
        Task<DiscountDto?> GetByIdAsync(int id);
        Task<DiscountDto> CreateAsync(CreateDiscountDto dto);
        Task<bool> UpdateAsync(int id, UpdateDiscountDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
