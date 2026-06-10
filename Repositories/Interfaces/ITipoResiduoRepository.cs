using EcoColeta.Api.Models;

namespace EcoColeta.Api.Repositories.Interfaces
{
    public interface ITipoResiduoRepository
    {
        Task<IEnumerable<TipoResiduo>> GetAllAsync();

        Task<TipoResiduo?> GetByIdAsync(int id);

        Task AddAsync(TipoResiduo tipoResiduo);

        Task UpdateAsync(TipoResiduo tipoResiduo);

        Task DeleteAsync(int id);
    }
}
