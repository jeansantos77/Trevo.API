using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;

namespace Trevo.API.Infra.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(TrevoContext context) : base(context)
        {
        }

        public override async Task<Cliente> GetById(Expression<Func<Cliente, bool>> predicate)
        {
            return await _dbContext.Clientes.AsNoTracking()
                .Where(predicate)
                .Include(c => c.ModelosDesejados).ThenInclude(md => md.Modelo).ThenInclude(m => m.Marca)
                .Include(c => c.ModelosDesejados).ThenInclude(md => md.Versao)
                .Include(c => c.ModelosDesejados).ThenInclude(md => md.Cor)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<Cliente>> GetAll(Expression<Func<Cliente, bool>> predicate)
        {
            return await _dbContext.Clientes
                .Where(predicate)
                .Include(c => c.ModelosDesejados).ThenInclude(md => md.Modelo).ThenInclude(m => m.Marca)
                .Include(c => c.ModelosDesejados).ThenInclude(md => md.Versao)
                .Include(c => c.ModelosDesejados).ThenInclude(md => md.Cor)
                .ToListAsync();
        }

        public async Task RemoveModeloDesejado(ModeloDesejado entity)
        {
            _dbContext.ModelosDesejados.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddModeloDesejado(ModeloDesejado entity)
        {
            await _dbContext.ModelosDesejados.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public override Task Delete(Cliente entidade)
        {
            _dbContext.ModelosDesejados.RemoveRange(entidade.ModelosDesejados);
            entidade.ModelosDesejados.Clear();
            return base.Delete(entidade);
        }
    }
}
