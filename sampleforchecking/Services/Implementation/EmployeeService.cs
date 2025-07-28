using sampleforchecking.DTOs;
using sampleforchecking.Models;
using sampleforchecking.Repository.Interfaces;
using sampleforchecking.Services.Interfaces;

namespace sampleforchecking.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                EmployeeCode = e.EmployeeCode,
                LastName = e.LastName,
                FirstName = e.FirstName,
                MiddleName = e.MiddleName,
                Age = e.Age,
                BirthDate = e.BirthDate,
                CivilStatus = e.CivilStatus,
                Gender = e.Gender,
                Email = e.Email,
                Address = e.Address,
                RoleId = e.RoleId,
                RolePosition = e.Role?.RolePosition
            });
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var e = await _repository.GetByIdAsync(id);
            if (e == null) return null;

            return new EmployeeDto
            {
                Id = e.Id,
                EmployeeCode = e.EmployeeCode,
                LastName = e.LastName,
                FirstName = e.FirstName,
                MiddleName = e.MiddleName,
                Age = e.Age,
                BirthDate = e.BirthDate,
                CivilStatus = e.CivilStatus,
                Gender = e.Gender,
                Email = e.Email,
                Address = e.Address,
                RoleId = e.RoleId,
                RolePosition = e.Role?.RolePosition
            };
        }

        public async Task AddAsync(EmployeeDto dto)
        {
            var employee = new Employee
            {
                EmployeeCode = dto.EmployeeCode,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                Age = dto.Age,
                BirthDate = dto.BirthDate,
                CivilStatus = dto.CivilStatus,
                Gender = dto.Gender,
                Email = dto.Email,
                Address = dto.Address,
                RoleId = dto.RoleId
            };
            await _repository.AddAsync(employee);
        }

        public async Task UpdateAsync(int id, EmployeeDto dto)
        {
            var employee = new Employee
            {
                Id = id,
                EmployeeCode = dto.EmployeeCode,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                Age = dto.Age,
                BirthDate = dto.BirthDate,
                CivilStatus = dto.CivilStatus,
                Gender = dto.Gender,
                Email = dto.Email,
                Address = dto.Address,
                RoleId = dto.RoleId
            };
            await _repository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
