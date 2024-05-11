using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.Repositories
{
    public class EntityFrameworkGenericRepository<TAggregateRoot, TDbContext> : IGenericRepository<TAggregateRoot>
        where TAggregateRoot : AggregateRoot
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;
        private readonly DbSet<TAggregateRoot> _dbSet;

        public EntityFrameworkGenericRepository(TDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TAggregateRoot>();

        }

        public async Task<IEnumerable<TAggregateRoot>> ListAsync(CancellationToken cancellationToken)
        {
            return _dbSet.AsEnumerable();
        }
        public async Task<IEnumerable<TAggregateRoot>> FindAsync(Expression<Func<TAggregateRoot, bool>>? filter = null, Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null, string includeProperties = "", CancellationToken cancellationToken = default)
        {
            IQueryable<TAggregateRoot> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }
        public async Task<TAggregateRoot?> FindByIdAsync(object id, CancellationToken cancellationToken)
        {
            if (id.Equals(default))
                throw new ArgumentException(nameof(id));

            return await _dbSet.FindAsync([id], cancellationToken: cancellationToken);
        }


        public async Task<bool> AddAsync(TAggregateRoot entity, CancellationToken cancellationToken)
        {
            var result = await _dbSet.AddAsync(entity, cancellationToken);

            return true;
        }
        public async Task UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public async Task DeleteAsync(TAggregateRoot entity, CancellationToken cancellationToken)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }
        public async Task<bool> DeleteByIdAsync(object id, CancellationToken cancellationToken)
        {
            var entityToDelete = await FindByIdAsync(id, cancellationToken);

            await DeleteAsync(entityToDelete, cancellationToken);

            return true;
        }

    }
}
