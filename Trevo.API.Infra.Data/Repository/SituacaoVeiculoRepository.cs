using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.Repository
{
    public class SituacaoVeiculoRepository : BaseRepository<SituacaoVeiculo>, ISituacaoVeiculoRepository
    {
        public SituacaoVeiculoRepository(TrevoContext context) : base(context)
        {
        }
    }
}
