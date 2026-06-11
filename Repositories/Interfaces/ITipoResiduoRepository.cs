using EcoColeta.Api.Models;

namespace EcoColeta.Api.Repositories.Interfaces
{
    public interface ITipoResiduoRepository
    {
        Task<IEnumerable<TipoResiduo>> GetAllAsync(int pageNumber, int pageSize);

        Task<TipoResiduo?> GetByIdAsync(int id);

        Task AddAsync(TipoResiduo tipoResiduo);

        Task UpdateAsync(TipoResiduo tipoResiduo);

        Task DeleteAsync(int id);
    }
}
