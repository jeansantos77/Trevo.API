using Trevo.API.Domain.Entities;

namespace Trevo.API.Domain.Interfaces
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        Task AddFotoVeiculo(FotoVeiculo entity);
        Task RemoveFotoVeiculo(FotoVeiculo entity);
    }
}
