using Microsoft.EntityFrameworkCore;

namespace CustomersService.DBAccessEntities
{
    public class CustomerContext : DbContext, ICustomerContext
    {
        public CustomerContext() { }
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
    }
}
