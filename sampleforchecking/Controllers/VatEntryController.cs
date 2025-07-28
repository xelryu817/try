using Microsoft.AspNetCore.Mvc;
using sampleforchecking.DTOs.VATEntry;
using sampleforchecking.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sampleforchecking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatEntryController : ControllerBase
    {
        private readonly IVatEntryService _vatEntryService;

        public VatEntryController(IVatEntryService vatEntryService)
        {
            _vatEntryService = vatEntryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VATEntryDto>>> GetAll()
        {
            var vats = await _vatEntryService.GetAllAsync();
            return Ok(vats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VATEntryDto>> GetById(int id)
        {
            var vat = await _vatEntryService.GetByIdAsync(id);
            if (vat == null)
                return NotFound();
            return Ok(vat);
        }

        [HttpPost]
        public async Task<ActionResult<VATEntryDto>> Create(CreateVATEntryDto dto)
        {
            var createdVat = await _vatEntryService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdVat.Id }, createdVat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateVATEntryDto dto)
        {
            var result = await _vatEntryService.UpdateAsync(id, dto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _vatEntryService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}