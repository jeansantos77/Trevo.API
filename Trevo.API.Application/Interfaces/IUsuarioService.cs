using Trevo.API.Application.Models;

namespace Trevo.API.Application.Interfaces
{
    public interface IUsuarioService : IBaseService<UsuarioModel, UsuarioResultModel>
    {
        Task<UsuarioResultModel> GetByLogin(LoginModel model);
    }
}
