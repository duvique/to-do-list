using ToDoList.Domain.Contracts;

namespace ToDoList.Domain.Entities
{
    public class AggregateRoot : Entity, IAggregateRoot
    {
        private List<IDomainEvent> _events = new();
        public IEnumerable<IDomainEvent> DomainEvents => _events;
        protected AggregateRoot(Guid id = default) : base(id) { }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }
        protected void ClearDomainEvents()
        {
            _events.Clear();
        }
    }
}
