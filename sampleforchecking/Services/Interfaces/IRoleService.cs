using sampleforchecking.DTOs;

namespace sampleforchecking.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto?> GetByIdAsync(int id);
        Task AddAsync(RoleDto dto);
        Task UpdateAsync(int id, RoleDto dto);
        Task DeleteAsync(int id);
    }
}
