using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.Repository
{
    public class CambioRepository : BaseRepository<Cambio>, ICambioRepository
    {
        public CambioRepository(TrevoContext context) : base(context)
        {
        }
    }
}
