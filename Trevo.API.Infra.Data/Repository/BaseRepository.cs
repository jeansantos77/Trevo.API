using Microsoft.EntityFrameworkCore;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;
using System.Linq.Expressions;

namespace Trevo.API.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly TrevoContext _dbContext;

        public BaseRepository(TrevoContext context)
        {
            _dbContext = context;
        }

        public async Task Add(T entidade)
        {
            await _dbContext.Set<T>().AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Update(T entidade)
        {
            _dbContext.Set<T>().Update(entidade);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(T entidade)
        {
            _dbContext.Set<T>().Remove(entidade);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public void StartTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _dbContext.Database.RollbackTransaction();
        }
    }
}
