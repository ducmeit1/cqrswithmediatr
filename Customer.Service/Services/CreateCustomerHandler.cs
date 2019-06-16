using System;
using System.Threading;
using System.Threading.Tasks;
using Customer.Data.IRepositories;
using Customer.Domain.Commands;
using Customer.Domain.Dtos;
using Customer.Service.Dxos;
using MediatR;

namespace Customer.Service.Services
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerDxos _customerDxos;
        private readonly IMediator _mediator;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IMediator mediator, ICustomerDxos customerDxos)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _customerDxos = customerDxos ?? throw new ArgumentNullException(nameof(customerDxos));
        }


        public async  Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (await _customerRepository.EmailExistAsync(request.Email))
            {
                throw new ArgumentException($"This email {request.Email} is already existed!", nameof(request.Email));
            }
            
            var customer = new Domain.Models.Customer(request.Name, request.Email, request.Address, request.Age, request.PhoneNumber);
            
            _customerRepository.Add(customer);

            if (await _customerRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException();
            }

            await _mediator.Publish(new Domain.Events.CustomerCreatedEvent(customer.Id), cancellationToken);

            var customerDto = _customerDxos.MapCustomerDto(customer);
            return customerDto;
        }
    }
}