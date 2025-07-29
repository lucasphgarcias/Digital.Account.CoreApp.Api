using MediatR;
using Domain.Entities;

namespace Domain.Events
{
    public record CustomerUpdatedDomainEvent(Customer Customer) : INotification;
} 