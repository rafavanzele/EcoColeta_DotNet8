using EcoColeta.Api.Models;
using EcoColeta.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoColeta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontoColetaController : ControllerBase
    {
        private readonly IPontoColetaService _service;

        public PontoColetaController(IPontoColetaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pontosColeta = await _service.GetAllAsync();

            return Ok(pontosColeta);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pontoColeta = await _service.GetByIdAsync(id);

            if (pontoColeta == null)
            {
                return NotFound();
            }

            return Ok(pontoColeta);
        }


        [HttpPost]
        public async Task<IActionResult> Create(PontoColeta pontoColeta)
        {
            await _service.AddAsync(pontoColeta);

            return CreatedAtAction(nameof(GetAll), pontoColeta);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PontoColeta pontoColeta)
        {
            if (id != pontoColeta.IdPontoColeta)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(pontoColeta);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pontoColeta = await _service.GetByIdAsync(id);

            if (pontoColeta == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}