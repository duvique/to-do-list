using MediatR;
using ToDoList.Domain.Contracts;

namespace ToDoList.Application.DomainEventsMediatR
{
    internal sealed class DomainEventNotification<TDomainEvent> : INotification
        where TDomainEvent : IDomainEvent
    {
        public readonly TDomainEvent DomainEvent;

        public DomainEventNotification(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
