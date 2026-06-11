using EcoColeta.Api.Models;
using EcoColeta.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var pontosColeta = await _service.GetAllAsync(pageNumber, pageSize);

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


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(PontoColeta pontoColeta)
        {
            await _service.AddAsync(pontoColeta);

            return CreatedAtAction(nameof(GetAll), pontoColeta);
        }


        [Authorize]
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


        [Authorize]
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