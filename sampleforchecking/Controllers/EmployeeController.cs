using Microsoft.AspNetCore.Mvc;
using sampleforchecking.Data;
using sampleforchecking.Models;
using Microsoft.EntityFrameworkCore;

namespace sampleforchecking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly PharmacyDbContext _context;
        public EmployeeController(PharmacyDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Employees.Include(e => e.Account).ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
