using System.Linq.Expressions;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Contracts
{
    public interface IGenericRepository<TAggregateRoot>
        where TAggregateRoot : AggregateRoot
    {
        Task<IEnumerable<TAggregateRoot>> ListAsync(CancellationToken cancellationToken);
        Task<IEnumerable<TAggregateRoot>> FindAsync(Expression<Func<TAggregateRoot, bool>>? filtro = null, Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null, string includeProperties = "", CancellationToken cancellationToken = default);
        Task<TAggregateRoot> FindByIdAsync(object id, CancellationToken cancellationToken);
        Task<bool> AddAsync(TAggregateRoot entidade, CancellationToken cancellationToken);
        Task UpdateAsync(TAggregateRoot entidade, CancellationToken cancellationToken);
        Task DeleteAsync(TAggregateRoot entidade, CancellationToken cancellationToken);
        Task<bool> DeleteByIdAsync(object id, CancellationToken cancellationToken);
    }
}
