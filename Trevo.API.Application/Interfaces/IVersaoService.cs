using Trevo.API.Application.Models;
using Trevo.API.Domain.Interfaces;

namespace Trevo.API.Application.Interfaces
{
    public interface IVersaoService : IBaseService<VersaoModel, VersaoResultModel>
    {
        Task<IEnumerable<IVersaoList>> GetList();
    }
}
