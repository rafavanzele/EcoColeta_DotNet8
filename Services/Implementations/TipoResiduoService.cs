using EcoColeta.Api.Models;
using EcoColeta.Api.Repositories.Interfaces;
using EcoColeta.Api.Services.Interfaces;
using EcoColeta.Api.Configurations;

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
            var tipoResiduo = await _repository.GetByIdAsync(id);

            if (tipoResiduo == null)
            {
                throw new RecursoNaoEncontradoException(
                    $"Tipo de resíduo com ID {id} não encontrado."
                );
            }

            return tipoResiduo;
        }

        public async Task AddAsync(TipoResiduo tipoResiduo)
        {
            await _repository.AddAsync(tipoResiduo);
        }

        public async Task UpdateAsync(TipoResiduo tipoResiduo)
        {
            var existente = await _repository.GetByIdAsync(tipoResiduo.IdTipoResiduo);

            if (existente == null)
            {
                throw new RecursoNaoEncontradoException(
                    $"Tipo de resíduo com ID {tipoResiduo.IdTipoResiduo} não encontrado."
                );
            }

            await _repository.UpdateAsync(tipoResiduo);
        }

        public async Task DeleteAsync(int id)
        {
            var existente = await _repository.GetByIdAsync(id);

            if (existente == null)
            {
                throw new RecursoNaoEncontradoException(
                    $"Tipo de resíduo com ID {id} não encontrado."
                );
            }

            await _repository.DeleteAsync(id);
        }
    }
}