using Customer.Domain.Dtos;

namespace Customer.Service.Dxos
{
    public interface ICustomerDxos
    {
        CustomerDto MapCustomerDto(Domain.Models.Customer customer);
    }
}