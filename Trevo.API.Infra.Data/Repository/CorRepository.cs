using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.Repository
{
    public class CorRepository : BaseRepository<Cor>, ICorRepository
    {
        public CorRepository(TrevoContext context) : base(context)
        {
        }
    }
}
