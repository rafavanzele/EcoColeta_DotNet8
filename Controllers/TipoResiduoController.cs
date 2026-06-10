using EcoColeta.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EcoColeta.Api.Models;

namespace EcoColeta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoResiduoController : ControllerBase
    {
        private readonly ITipoResiduoService _service;

        public TipoResiduoController(ITipoResiduoService service)
        {
            _service = service;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tiposResiduos = await _service.GetAllAsync();

            return Ok(tiposResiduos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipoResiduo = await _service.GetByIdAsync(id);

            if (tipoResiduo == null)
            {
                return NotFound();
            }

            return Ok(tipoResiduo);
        }


        [HttpPost]
        public async Task<IActionResult> Create(TipoResiduo tipoResiduo)
        {
            await _service.AddAsync(tipoResiduo);

            return CreatedAtAction(nameof(GetAll), tipoResiduo);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TipoResiduo tipoResiduo)
        {
            if (id != tipoResiduo.IdTipoResiduo)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(tipoResiduo);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoResiduo = await _service.GetByIdAsync(id);

            if (tipoResiduo == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}