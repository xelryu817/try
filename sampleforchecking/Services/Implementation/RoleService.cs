using sampleforchecking.DTOs;
using sampleforchecking.Models;
using sampleforchecking.Repository.Interfaces;
using sampleforchecking.Services.Interfaces;

namespace sampleforchecking.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();
            return roles.Select(r => new RoleDto
            {
                Id = r.Id,
                RolePosition = r.RolePosition
            });
        }

        public async Task<RoleDto?> GetByIdAsync(int id)
        {
            var r = await _repository.GetByIdAsync(id);
            if (r == null) return null;

            return new RoleDto
            {
                Id = r.Id,
                RolePosition = r.RolePosition
            };
        }

        public async Task AddAsync(RoleDto dto)
        {
            var role = new Role { RolePosition = dto.RolePosition };
            await _repository.AddAsync(role);
        }

        public async Task UpdateAsync(int id, RoleDto dto)
        {
            var role = new Role
            {
                Id = id,
                RolePosition = dto.RolePosition
            };
            await _repository.UpdateAsync(role);
        }

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
