using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>
        where TEntity : Entity
        where TContext : DbContext
    {
        protected TContext Context { get; set; }
        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }


        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IPaginate<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        )
        {
            IQueryable<TEntity> query = this.Query();

            if (predicate != null) query = query.Where(predicate);

            if (!enableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (orderBy != null) return await orderBy(query).ToPaginateAsync(index, size, 0, cancellationToken);

            return await query.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
