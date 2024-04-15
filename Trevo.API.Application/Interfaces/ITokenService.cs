using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Interfaces
{
    public interface ITokenService
    {
        string Generate(UsuarioResultModel model);
    }
}
