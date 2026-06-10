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
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(ColetaResiduo coletaResiduo)
        {
            await _repository.AddAsync(coletaResiduo);
        }

        public async Task UpdateAsync(ColetaResiduo coletaResiduo)
        {
            await _repository.UpdateAsync(coletaResiduo);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}