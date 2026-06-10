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

        public async Task<IEnumerable<PontoColeta>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PontoColeta?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(PontoColeta pontoColeta)
        {
            await _repository.AddAsync(pontoColeta);
        }

        public async Task UpdateAsync(PontoColeta pontoColeta)
        {
            await _repository.UpdateAsync(pontoColeta);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}