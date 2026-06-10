using EcoColeta.Api.Models;

namespace EcoColeta.Api.Services.Interfaces
{
    public interface IPontoColetaService
    {
        Task<IEnumerable<PontoColeta>> GetAllAsync();

        Task<PontoColeta?> GetByIdAsync(int id);

        Task AddAsync(PontoColeta pontoColeta);

        Task UpdateAsync(PontoColeta pontoColeta);

        Task DeleteAsync(int id);
    }
}