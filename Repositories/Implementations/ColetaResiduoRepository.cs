using EcoColeta.Api.Data;
using EcoColeta.Api.Models;
using EcoColeta.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoColeta.Api.Repositories.Implementations
{
    public class ColetaResiduoRepository : IColetaResiduoRepository
    {
        private readonly AppDbContext _context;

        public ColetaResiduoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ColetaResiduo>> GetAllAsync()
        {
            return await _context.ColetasResiduos
                .Include(c => c.PontoColeta)
                .Include(c => c.TipoResiduo)
                .ToListAsync();
        }

        public async Task<ColetaResiduo?> GetByIdAsync(int id)
        {
            return await _context.ColetasResiduos
                .Include(c => c.PontoColeta)
                .Include(c => c.TipoResiduo)
                .FirstOrDefaultAsync(c => c.IdColeta == id);
        }

        public async Task AddAsync(ColetaResiduo coletaResiduo)
        {
            await _context.ColetasResiduos.AddAsync(coletaResiduo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ColetaResiduo coletaResiduo)
        {
            _context.ColetasResiduos.Update(coletaResiduo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var coletaResiduo = await _context.ColetasResiduos.FindAsync(id);

            if (coletaResiduo != null)
            {
                _context.ColetasResiduos.Remove(coletaResiduo);
                await _context.SaveChangesAsync();
            }
        }
    }
}