using MediatR;
using Newtonsoft.Json;
using ToDoList.Application.DomainEventsMediatR;
using ToDoList.Domain.DomainEvents;

namespace ToDoList.Application.Tasks.EventHandlers
{
    internal class TaskCreatedHandler : INotificationHandler<DomainEventNotification<TaskCreatedDomainEvent>>
    {
        public async Task Handle(DomainEventNotification<TaskCreatedDomainEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            Console.WriteLine($"Domain event [{domainEvent.Name}]  handled - Type [{domainEvent.GetType()}]");
            Console.WriteLine(JsonConvert.SerializeObject(domainEvent, Formatting.Indented));

            //Handle processing logic (outbox pattern, update entities, etc) within the same transaction of aggregate changes.
        }
    }
}

