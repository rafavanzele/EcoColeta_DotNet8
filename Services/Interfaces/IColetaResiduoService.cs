using EcoColeta.Api.Models;

namespace EcoColeta.Api.Services.Interfaces
{
    public interface IColetaResiduoService
    {
        Task<IEnumerable<ColetaResiduo>> GetAllAsync();

        Task<ColetaResiduo?> GetByIdAsync(int id);

        Task AddAsync(ColetaResiduo coletaResiduo);

        Task UpdateAsync(ColetaResiduo coletaResiduo);

        Task DeleteAsync(int id);
    }
}