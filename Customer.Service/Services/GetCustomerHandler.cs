using System;
using System.Threading;
using System.Threading.Tasks;
using Customer.Data.IRepositories;
using Customer.Domain.Dtos;
using Customer.Domain.Queries;
using Customer.Service.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Customer.Service.Services
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerDxos _customerDxos;
        private readonly ILogger _logger;

        public GetCustomerHandler(ICustomerRepository customerRepository, ICustomerDxos customerDxos, ILogger<GetCustomerHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _customerDxos = customerDxos ?? throw new ArgumentNullException(nameof(customerDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(e =>
                e.Id == request.CustomerId);

            if (customer != null)
            {
                _logger.LogInformation($"Got a request get customer Id: {customer.Id}");
                var customerDto = _customerDxos.MapCustomerDto(customer);
                return customerDto;
            }

            return null;
        }
    }
}