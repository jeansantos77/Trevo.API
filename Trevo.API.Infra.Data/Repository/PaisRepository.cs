using Price.API.Domain.Interfaces;
using Price.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Price.API.Infra.Data.Repository
{
    public class PaisRepository : BaseRepository<Pais>, IPaisRepository
    {
        public PaisRepository(TrevoContext context) : base(context)
        {
        }
    }
}
