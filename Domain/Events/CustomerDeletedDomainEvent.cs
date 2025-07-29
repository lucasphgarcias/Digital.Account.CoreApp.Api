using MediatR;
using Domain.Entities;

namespace Domain.Events
{
    public record CustomerDeletedDomainEvent(Customer Customer) : INotification;
} 