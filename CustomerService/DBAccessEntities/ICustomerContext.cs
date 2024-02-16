using Microsoft.EntityFrameworkCore;

namespace CustomersService.DBAccessEntities
{
    public interface ICustomerContext
    {
        DbSet<Customer> Customers { get; set; }
    }
}