using System;
using MediatR;

namespace Customer.Domain.Events
{
    public class CustomerCreatedEvent : INotification
    {
        public Guid CustomerId { get; set; }

        public CustomerCreatedEvent(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}