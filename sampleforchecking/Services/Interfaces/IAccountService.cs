using sampleforchecking.DTOs;

namespace sampleforchecking.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAsync();
        Task<AccountDto?> GetByIdAsync(int id);
        Task AddAsync(AccountDto dto);
        Task UpdateAsync(int id, AccountDto dto);
        Task DeleteAsync(int id);
    }
}
