using Price.API.Domain.Interfaces;
using Price.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Price.API.Infra.Data.Repository
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(TrevoContext context) : base(context)
        {
        }
    }
}
