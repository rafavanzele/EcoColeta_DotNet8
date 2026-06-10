using EcoColeta.Api.Models;

namespace EcoColeta.Api.Repositories.Interfaces
{
    public interface IPontoColetaRepository
    {
        Task<IEnumerable<PontoColeta>> GetAllAsync();

        Task<PontoColeta?> GetByIdAsync(int id);

        Task AddAsync(PontoColeta pontoColeta);

        Task UpdateAsync(PontoColeta pontoColeta);

        Task DeleteAsync(int id);
    }
}