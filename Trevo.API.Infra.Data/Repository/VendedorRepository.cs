using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.Repository
{
    public class VendedorRepository : BaseRepository<Vendedor>, IVendedorRepository
    {
        public VendedorRepository(TrevoContext context) : base(context)
        {
        }
    }
}
