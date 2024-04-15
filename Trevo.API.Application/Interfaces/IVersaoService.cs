using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Interfaces
{
    public interface IVersaoService : IBaseService<VersaoModel, VersaoResultModel>
    {
        Task<IEnumerable<VersaoListModel>> GetList();
    }
}
