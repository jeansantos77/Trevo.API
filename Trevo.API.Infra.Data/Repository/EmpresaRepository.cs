using Price.API.Domain.Interfaces;
using Price.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Price.API.Infra.Data.Repository
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(TrevoContext context) : base(context)
        {
        }
    }
}
