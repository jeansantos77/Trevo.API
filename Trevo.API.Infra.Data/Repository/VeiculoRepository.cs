using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using Trevo.API.Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Trevo.API.Infra.Data.Repository
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(TrevoContext context) : base(context)
        {
        }

        public override async Task<Veiculo> GetById(Expression<Func<Veiculo, bool>> predicate)
        {
            return await _dbContext.Veiculos.AsNoTracking().Where(predicate)
                .Include(c => c.Modelo).ThenInclude(md => md.Marca)
                .Include(c => c.Versao)
                .Include(c => c.Cor)
                .Include(f => f.FotosVeiculo)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<Veiculo>> GetAll(Expression<Func<Veiculo, bool>> predicate)
        {
            return await _dbContext.Veiculos.Where(predicate)
                .Include(c => c.Modelo).ThenInclude(md => md.Marca)
                .Include(c => c.Versao)
                .Include(c => c.Cor)
                .ToListAsync();
        }

        public async Task RemoveFotoVeiculo(FotoVeiculo entity)
        {
            _dbContext.FotosVeiculo.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddFotoVeiculo(FotoVeiculo entity)
        {
            await _dbContext.FotosVeiculo.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public override Task Delete(Veiculo entidade)
        {
            _dbContext.FotosVeiculo.RemoveRange(entidade.FotosVeiculo);
            entidade.FotosVeiculo.Clear();
            return base.Delete(entidade);
        }

    }
}
