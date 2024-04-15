using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Models;

namespace Trevo.API.Domain.Interfaces
{
    public interface IVersaoRepository : IBaseRepository<Versao>
    {
        Task<IEnumerable<VersaoListModel>> GetList();
    }
}
