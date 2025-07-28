using Microsoft.AspNetCore.Mvc;
using sampleforchecking.DTOs.Sales;
using sampleforchecking.Services.Interfaces.ISale;

namespace sampleforchecking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesTransactionDto>>> GetAll()
        {
            var sales = await _salesService.GetAllAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesTransactionDto>> GetById(int id)
        {
            var sale = await _salesService.GetByIdAsync(id);
            if (sale == null) return NotFound();
            return Ok(sale);
        }

        [HttpPost]
        public async Task<ActionResult<SalesTransactionDto>> Create([FromBody] CreateSalesTransactionDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdSale = await _salesService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdSale.Id }, createdSale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSalesTransactionDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _salesService.UpdateAsync(id, dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _salesService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}