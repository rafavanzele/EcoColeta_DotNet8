using EcoColeta.Api.Models;

namespace EcoColeta.Api.Repositories.Interfaces
{
    public interface IPontoColetaRepository
    {
        Task<IEnumerable<PontoColeta>> GetAllAsync(int pageNumber, int pageSize);

        Task<PontoColeta?> GetByIdAsync(int id);

        Task AddAsync(PontoColeta pontoColeta);

        Task UpdateAsync(PontoColeta pontoColeta);

        Task DeleteAsync(int id);
    }
}