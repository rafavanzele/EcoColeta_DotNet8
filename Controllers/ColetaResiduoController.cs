using EcoColeta.Api.Models;
using EcoColeta.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var coletasResiduos = await _service.GetAllAsync(pageNumber, pageSize);

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


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ColetaResiduo coletaResiduo)
        {
            await _service.AddAsync(coletaResiduo);

            return CreatedAtAction(nameof(GetAll), coletaResiduo);
        }


        [Authorize]
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


        [Authorize]
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