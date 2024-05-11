using ToDoList.Domain.DomainEvents;
using ToDoList.Domain.Enumerators;

namespace ToDoList.Domain.Entities
{
    public class ToDoTask : AggregateRoot
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public EVisibilityType Visibility { get; private set; }
        public bool Completed { get; private set; }
        public User User { get; private set; }

        public ToDoTask(Guid id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
            Visibility = EVisibilityType.Private;

            RaiseDomainEvent(new TaskCreatedDomainEvent(id));
        }

    }
}
