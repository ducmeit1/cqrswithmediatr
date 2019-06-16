using Microsoft.EntityFrameworkCore;

namespace Customer.Data
{
    public class CustomerDbContextFactory : DesignTimeDbContextFactory<CustomerDbContext>
    {
        protected override CustomerDbContext CreateNewInstance(DbContextOptions<CustomerDbContext> options)
        {
            return new CustomerDbContext(options);
        }
    }
}