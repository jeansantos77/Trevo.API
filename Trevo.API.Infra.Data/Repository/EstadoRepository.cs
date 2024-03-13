using Price.API.Domain.Interfaces;
using Price.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Price.API.Infra.Data.Repository
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(TrevoContext context) : base(context)
        {
        }
    }
}
