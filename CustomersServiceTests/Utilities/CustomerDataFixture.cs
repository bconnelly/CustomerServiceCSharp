using CustomersService.DBAccessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersServiceTests.Utilities
{
    public class CustomerDataFixture : IDisposable
    {
        private static DbContextOptions<CustomerContext> ops = new DbContextOptionsBuilder<CustomerContext>().UseInMemoryDatabase(databaseName: "testdb").Options;
        public CustomerContext context = new CustomerContext(ops);

        public CustomerDataFixture()
        {
            reset();
        }

        public void reset()
        {

            foreach (var row in context.Customers)
            {
                context.Customers.Remove(row);
            }

            context.Customers.Add(new Customer("test customer 1", "test address 1", 1f, 3));
            context.Customers.Add(new Customer("test customer 2", "test address 2", 1f, 1));
            context.Customers.Add(new Customer("test customer 3", "test address 3", 1f, 1));
            context.Customers.Add(new Customer("test customer 4", "test address 4", 1f, 2));
            context.Customers.Add(new Customer("test customer 5", "test address 5", 1f, 4));
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
