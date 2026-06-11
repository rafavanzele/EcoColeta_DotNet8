using EcoColeta.Api.Configurations;
using EcoColeta.Api.Models;
using EcoColeta.Api.Repositories.Interfaces;
using EcoColeta.Api.Services.Interfaces;

namespace EcoColeta.Api.Services.Implementations
{
    public class ColetaResiduoService : IColetaResiduoService
    {
        private readonly IColetaResiduoRepository _repository;

        public ColetaResiduoService(IColetaResiduoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ColetaResiduo>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ColetaResiduo?> GetByIdAsync(int id)
        {
            var coletaResiduo = await _repository.GetByIdAsync(id);

            if (coletaResiduo == null)
            {
                throw new RecursoNaoEncontradoException(
                    $"Coleta de resíduo com ID {id} não encontrada."
                );
            }

            return coletaResiduo;
        }

        public async Task AddAsync(ColetaResiduo coletaResiduo)
        {
            await _repository.AddAsync(coletaResiduo);
        }

        public async Task UpdateAsync(ColetaResiduo coletaResiduo)
        {
            var existente = await _repository.GetByIdAsync(coletaResiduo.IdColeta);

            if (existente == null)
            {
                throw new RecursoNaoEncontradoException(
                    $"Coleta de resíduo com ID {coletaResiduo.IdColeta} não encontrada."
                );
            }

            await _repository.UpdateAsync(coletaResiduo);
        }

        public async Task DeleteAsync(int id)
        {
            var existente = await _repository.GetByIdAsync(id);

            if (existente == null)
            {
                throw new RecursoNaoEncontradoException(
                    $"Coleta de resíduo com ID {id} não encontrada."
                );
            }

            await _repository.DeleteAsync(id);
        }
    }
}