using Microsoft.AspNetCore.Mvc;
using sampleforchecking.DTOs.Discount;
using sampleforchecking.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sampleforchecking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountDto>>> GetAll()
        {
            var discounts = await _discountService.GetAllAsync();
            return Ok(discounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiscountDto>> GetById(int id)
        {
            var discount = await _discountService.GetByIdAsync(id);
            if (discount == null)
                return NotFound();
            return Ok(discount);
        }

        [HttpPost]
        public async Task<ActionResult<DiscountDto>> Create(CreateDiscountDto dto)
        {
            var createdDiscount = await _discountService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdDiscount.Id }, createdDiscount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDiscountDto dto)
        {
            var result = await _discountService.UpdateAsync(id, dto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _discountService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}