using Trevo.API.Domain.Entities;

namespace Trevo.API.Domain.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task AddModeloDesejado(ModeloDesejado entity);
        Task RemoveModeloDesejado(ModeloDesejado entity);
    }
}
