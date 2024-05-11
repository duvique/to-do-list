using ToDoList.Domain.Contracts;

namespace ToDoList.Domain.DomainEvents
{
    public sealed record TaskCreatedDomainEvent(Guid taskId) : IDomainEvent
    {
    }
}
