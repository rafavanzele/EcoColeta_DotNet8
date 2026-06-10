using EcoColeta.Api.Models;
using EcoColeta.Api.Repositories.Interfaces;
using EcoColeta.Api.Services.Interfaces;

namespace EcoColeta.Api.Services.Implementations
{
    public class TipoResiduoService : ITipoResiduoService
    {
        private readonly ITipoResiduoRepository _repository;

        public TipoResiduoService(ITipoResiduoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoResiduo>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TipoResiduo?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(TipoResiduo tipoResiduo)
        {
            await _repository.AddAsync(tipoResiduo);
        }

        public async Task UpdateAsync(TipoResiduo tipoResiduo)
        {
            await _repository.UpdateAsync(tipoResiduo);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}