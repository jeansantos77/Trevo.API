using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.Repository
{
    public class TipoDespesaRepository : BaseRepository<TipoDespesa>, ITipoDespesaRepository
    {
        public TipoDespesaRepository(TrevoContext context) : base(context)
        {
        }
    }
}
