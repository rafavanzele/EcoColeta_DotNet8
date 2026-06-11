using EcoColeta.Api.Data;
using EcoColeta.Api.Models;
using EcoColeta.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoColeta.Api.Repositories.Implementations
{
    public class TipoResiduoRepository : ITipoResiduoRepository
    {
        private readonly AppDbContext _context;

        public TipoResiduoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoResiduo>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.TiposResiduos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<TipoResiduo?> GetByIdAsync(int id)
        {
            return await _context.TiposResiduos.FindAsync(id);
        }

        public async Task AddAsync(TipoResiduo tipoResiduo)
        {
            await _context.TiposResiduos.AddAsync(tipoResiduo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoResiduo tipoResiduo)
        {
            var existente = await _context.TiposResiduos.FindAsync(tipoResiduo.IdTipoResiduo);

            if (existente != null)
            {
                existente.NomeTipo = tipoResiduo.NomeTipo;
                existente.Descricao = tipoResiduo.Descricao;
                existente.Reciclavel = tipoResiduo.Reciclavel;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var tipoResiduo = await _context.TiposResiduos.FindAsync(id);

            if (tipoResiduo != null)
            {
                _context.TiposResiduos.Remove(tipoResiduo);
                await _context.SaveChangesAsync();
            }
        }
    }
}