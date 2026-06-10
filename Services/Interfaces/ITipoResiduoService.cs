using EcoColeta.Api.Models;

namespace EcoColeta.Api.Services.Interfaces
{
    public interface ITipoResiduoService
    {
        Task<IEnumerable<TipoResiduo>> GetAllAsync();

        Task<TipoResiduo?> GetByIdAsync(int id);

        Task AddAsync(TipoResiduo tipoResiduo);

        Task UpdateAsync(TipoResiduo tipoResiduo);

        Task DeleteAsync(int id);
    }
}