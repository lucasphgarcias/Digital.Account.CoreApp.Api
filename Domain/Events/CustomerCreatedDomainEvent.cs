using MediatR;
using Domain.Entities;

namespace Domain.Events
{
    public record CustomerCreatedDomainEvent(Customer Customer) : INotification;
} 