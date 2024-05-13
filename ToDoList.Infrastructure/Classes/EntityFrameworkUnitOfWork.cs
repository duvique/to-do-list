using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Repositories;

namespace ToDoList.Infrastructure.Classes
{
    internal class EntityFrameworkUnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext : DbContext
    {
        private readonly Dictionary<Type, object> _repositories;
        private readonly IDomainEventPublisher _publisher;
        private readonly TDbContext _context;
        public EntityFrameworkUnitOfWork(TDbContext context, IDomainEventPublisher publisher)
        {
            _context = context;
            _repositories = [];
            _publisher = publisher;
        }

        public async Task<bool> CommitAsync()
        {
            var domainEvents = _context.ChangeTracker.Entries<AggregateRoot>()
                .SelectMany(e => e.Entity.DomainEvents);

            // Publish Domain events within same transaction of aggregate root changes
            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }

            SetUpdatedAt();
            return await _context.SaveChangesAsync() > 0;
        }

        public IGenericRepository<TAggregateRoot> Repository<TAggregateRoot>() where TAggregateRoot : AggregateRoot
        {
            if (_repositories.ContainsKey(typeof(TAggregateRoot)))
            {
                return (IGenericRepository<TAggregateRoot>)_repositories[typeof(TAggregateRoot)];
            }

            var repositorioAdicionar = new EntityFrameworkGenericRepository<TAggregateRoot, TDbContext>(_context);

            _repositories.Add(typeof(TAggregateRoot), repositorioAdicionar);

            return repositorioAdicionar;
        }

        private void SetUpdatedAt()
        {
            var entries = _context.ChangeTracker.Entries<Entity>()
                .Where(e => e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                entry.Entity.SetUpdatedAt();
            }
        }

    }
}
