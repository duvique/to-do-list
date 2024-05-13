using MediatR;
using ToDoList.Domain.Contracts;

namespace ToDoList.Application.DomainEventsMediatR
{
    internal sealed class DomainEventPublisher(IPublisher publisher) : IDomainEventPublisher
    {
        private readonly IPublisher _publisher = publisher;

        // Logic to wrap IDomainEvent interface from Domain Layer
        // in INotification interface from MediatR without having
        // to install package on Domain Layer
        public async Task Publish(IDomainEvent domainEvent)
        {
            var domainEventNotification = CreateDomainEventNotification(domainEvent);
            await _publisher.Publish(domainEventNotification);
        }

        private static INotification CreateDomainEventNotification(IDomainEvent domainEvent)
        {
            var domainEventNotificationType = typeof(DomainEventNotification<>)
                .MakeGenericType(domainEvent.GetType());

            var domainEventNotification = Activator.CreateInstance(domainEventNotificationType, domainEvent);

            if (domainEventNotification is null)
                throw new Exception($"Internal error while creating MediatR notification based on Domain Event of type {domainEvent.GetType()}");

            return (INotification)domainEventNotification;
        }
    }
}
