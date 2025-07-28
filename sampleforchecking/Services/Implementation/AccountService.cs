using sampleforchecking.DTOs;
using sampleforchecking.Models;
using sampleforchecking.Repository.Interfaces;
using sampleforchecking.Services.Interfaces;

namespace sampleforchecking.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AccountDto>> GetAllAsync()
        {
            var accounts = await _repository.GetAllAsync();
            return accounts.Select(a => new AccountDto
            {
                Id = a.Id,
                AccountCode = a.AccountCode,
                Username = a.Username,
                EncryptedPassword = a.EncryptedPassword,
                EmployeeId = a.EmployeeId,
                EmployeeFullName = $"{a.Employee?.LastName}, {a.Employee?.FirstName}"
            });
        }

        public async Task<AccountDto?> GetByIdAsync(int id)
        {
            var a = await _repository.GetByIdAsync(id);
            if (a == null) return null;

            return new AccountDto
            {
                Id = a.Id,
                AccountCode = a.AccountCode,
                Username = a.Username,
                EncryptedPassword = a.EncryptedPassword,
                EmployeeId = a.EmployeeId,
                EmployeeFullName = $"{a.Employee?.LastName}, {a.Employee?.FirstName}"
            };
        }

        public async Task AddAsync(AccountDto dto)
        {
            var account = new Account
            {
                AccountCode = dto.AccountCode,
                Username = dto.Username,
                EncryptedPassword = dto.EncryptedPassword,
                EmployeeId = dto.EmployeeId
            };
            await _repository.AddAsync(account);
        }

        public async Task UpdateAsync(int id, AccountDto dto)
        {
            var account = new Account
            {
                Id = id,
                AccountCode = dto.AccountCode,
                Username = dto.Username,
                EncryptedPassword = dto.EncryptedPassword,
                EmployeeId = dto.EmployeeId
            };
            await _repository.UpdateAsync(account);
        }

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}