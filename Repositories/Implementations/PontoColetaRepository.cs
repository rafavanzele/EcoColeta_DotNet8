using EcoColeta.Api.Data;
using EcoColeta.Api.Models;
using EcoColeta.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoColeta.Api.Repositories.Implementations
{
    public class PontoColetaRepository : IPontoColetaRepository
    {
        private readonly AppDbContext _context;

        public PontoColetaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PontoColeta>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.PontosColeta
                .OrderBy(p => p.IdPontoColeta)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<PontoColeta?> GetByIdAsync(int id)
        {
            return await _context.PontosColeta.FindAsync(id);
        }

        public async Task AddAsync(PontoColeta pontoColeta)
        {
            await _context.PontosColeta.AddAsync(pontoColeta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PontoColeta pontoColeta)
        {
            _context.PontosColeta.Update(pontoColeta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pontoColeta = await _context.PontosColeta.FindAsync(id);

            if (pontoColeta != null)
            {
                _context.PontosColeta.Remove(pontoColeta);
                await _context.SaveChangesAsync();
            }
        }
    }
}