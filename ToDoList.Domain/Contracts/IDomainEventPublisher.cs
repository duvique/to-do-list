namespace ToDoList.Domain.Contracts
{
    public interface IDomainEventPublisher
    {
        Task Publish(IDomainEvent domainEvent);
    }
}
