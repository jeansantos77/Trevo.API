using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.Repository
{
    public class AcessorioRepository: BaseRepository<Acessorio>, IAcessorioRepository
    {
        public AcessorioRepository(TrevoContext context) : base(context)
        {
        }
    }
}
