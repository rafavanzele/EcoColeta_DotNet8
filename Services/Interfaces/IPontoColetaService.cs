using EcoColeta.Api.Models;

namespace EcoColeta.Api.Services.Interfaces
{
    public interface IPontoColetaService
    {
        Task<IEnumerable<PontoColeta>> GetAllAsync(int pageNumber, int pageSize);

        Task<PontoColeta?> GetByIdAsync(int id);

        Task AddAsync(PontoColeta pontoColeta);

        Task UpdateAsync(PontoColeta pontoColeta);

        Task DeleteAsync(int id);
    }
}