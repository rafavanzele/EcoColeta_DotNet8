using EcoColeta.Api.Models;

namespace EcoColeta.Api.Repositories.Interfaces
{
    public interface IColetaResiduoRepository
    {
        Task<IEnumerable<ColetaResiduo>> GetAllAsync(int pageNumber, int pageSize);

        Task<ColetaResiduo?> GetByIdAsync(int id);

        Task AddAsync(ColetaResiduo coletaResiduo);

        Task UpdateAsync(ColetaResiduo coletaResiduo);

        Task DeleteAsync(int id);
    }
}