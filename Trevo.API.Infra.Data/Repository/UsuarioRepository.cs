using Price.API.Domain.Interfaces;
using Price.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Price.API.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(TrevoContext context) : base(context)
        {
        }
    }
}
