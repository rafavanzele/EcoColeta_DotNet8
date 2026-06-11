using EcoColeta.Api.Configurations;
using EcoColeta.Api.Models;
using EcoColeta.Api.Repositories.Interfaces;
using EcoColeta.Api.Services.Interfaces;

namespace EcoColeta.Api.Services.Implementations
{
    public class PontoColetaService : IPontoColetaService
    {
        private readonly IPontoColetaRepository _repository;

        public PontoColetaService(IPontoColetaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PontoColeta>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<PontoColeta?> GetByIdAsync(int id)
        {
            var pontoColeta = await _repository.GetByIdAsync(id);

            if (pontoColeta == null)
            {
                throw new RecursoNaoEncontradoException(
                    $"Ponto de coleta com ID {id} não encontrado."
                );
            }

            return pontoColeta;
        }

        public async Task AddAsync(PontoColeta pontoColeta)
        {
            await _repository.AddAsync(pontoColeta);
        }

        public async Task UpdateAsync(PontoColeta pontoColeta)
        {
            var existente = await _repository.GetByIdAsync(pontoColeta.IdPontoColeta);

            if (existente == null)
            {
                throw new RecursoNaoEncontradoException(
                    $"Ponto de coleta com ID {pontoColeta.IdPontoColeta} não encontrado."
                );
            }

            await _repository.UpdateAsync(pontoColeta);
        }

        public async Task DeleteAsync(int id)
        {
            var existente = await _repository.GetByIdAsync(id);

            if (existente == null)
            {
                throw new RecursoNaoEncontradoException(
                    $"Ponto de coleta com ID {id} não encontrado."
                );
            }

            await _repository.DeleteAsync(id);
        }
    }
}