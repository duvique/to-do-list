using ToDoList.Domain.DomainEvents;
using ToDoList.Domain.Enumerators;

namespace ToDoList.Domain.Entities
{
    public class ToDoTask : AggregateRoot
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public EVisibilityType Visibility { get; private set; }
        public DateTime? DueDate { get; private set; }
        public bool IsFinished { get; private set; }
        public DateTime? FinishedDate { get; private set; }

        public ToDoTask(Guid id, string name, string description, EVisibilityType visibility, DateTime? dueDate) : base(id)
        {
            Name = name;
            Description = description;
            Visibility = visibility;
            DueDate = dueDate;

            RaiseDomainEvent(new TaskCreatedDomainEvent(id));
        }

        public void FinishTask()
        {
            IsFinished = true;
            FinishedDate = DateTime.Now;
        }

    }
}
