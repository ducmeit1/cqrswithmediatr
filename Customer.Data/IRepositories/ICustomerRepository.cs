using System.Threading.Tasks;

namespace Customer.Data.IRepositories
{
    public interface ICustomerRepository : IRepository<Domain.Models.Customer>
    {
       Task<bool> EmailExistAsync(string email);
    }
}