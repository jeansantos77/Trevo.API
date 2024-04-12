using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.Repository
{
    public class VersaoRepository : BaseRepository<Versao>, IVersaoRepository
    {
        public VersaoRepository(TrevoContext context) : base(context)
        {
        }
    }
}
