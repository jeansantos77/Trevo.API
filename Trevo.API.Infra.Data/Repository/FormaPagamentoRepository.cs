using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.Repository
{
    public class FormaPagamentoRepository : BaseRepository<FormaPagamento>, IFormaPagamentoRepository
    {
        public FormaPagamentoRepository(TrevoContext context) : base(context)
        {
        }
    }
}
