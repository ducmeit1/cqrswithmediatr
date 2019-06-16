using System;
using System.Threading.Tasks;
using Customer.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Customer.Data.Repositories
{
    public class CustomerRepository : Repository<Domain.Models.Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> EmailExistAsync(string email)
        {
           return await ModelDbSets.AsNoTracking().AnyAsync(e => e.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));

        }
    }
}