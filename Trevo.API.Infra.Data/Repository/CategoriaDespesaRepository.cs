using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.Repository
{
    public class CategoriaDespesaRepository : BaseRepository<CategoriaDespesa>, ICategoriaDespesaRepository
    {
        public CategoriaDespesaRepository(TrevoContext context) : base(context)
        {
        }
    }
}
