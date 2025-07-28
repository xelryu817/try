using sampleforchecking.DTOs;

namespace sampleforchecking.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task AddAsync(EmployeeDto dto);
        Task UpdateAsync(int id, EmployeeDto dto);
        Task DeleteAsync(int id);
    }
}
