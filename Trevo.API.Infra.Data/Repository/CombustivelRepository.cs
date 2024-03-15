using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.Repository
{
    public class CombustivelRepository : BaseRepository<Combustivel>, ICombustivelRepository
    {
        public CombustivelRepository(TrevoContext context) : base(context)
        {
        }
    }
}
