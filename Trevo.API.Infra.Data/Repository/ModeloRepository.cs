using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.Repository
{
    public class ModeloRepository : BaseRepository<Modelo>, IModeloRepository
    {
        public ModeloRepository(TrevoContext context) : base(context)
        {
        }
    }
}
