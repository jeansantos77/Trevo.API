using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.Repository
{
    public class MarcaRepository : BaseRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(TrevoContext context) : base(context)
        {
        }
    }
}
