using EcoColeta.Api.Models;
using EcoColeta.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoColeta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColetaResiduoController : ControllerBase
    {
        private readonly IColetaResiduoService _service;

        public ColetaResiduoController(IColetaResiduoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coletasResiduos = await _service.GetAllAsync();

            return Ok(coletasResiduos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coletaResiduo = await _service.GetByIdAsync(id);

            if (coletaResiduo == null)
            {
                return NotFound();
            }

            return Ok(coletaResiduo);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ColetaResiduo coletaResiduo)
        {
            await _service.AddAsync(coletaResiduo);

            return CreatedAtAction(nameof(GetAll), coletaResiduo);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ColetaResiduo coletaResiduo)
        {
            if (id != coletaResiduo.IdColeta)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(coletaResiduo);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var coletaResiduo = await _service.GetByIdAsync(id);

            if (coletaResiduo == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}