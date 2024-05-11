using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        IGenericRepository<TAggregateRoot> Repository<TAggregateRoot>() where TAggregateRoot : AggregateRoot;
    }
}
