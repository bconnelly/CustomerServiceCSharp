using CustomersService.DBAccessEntities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Entity.Core;

namespace CustomersService.DomainLogic
{
    public class CustomerDomainLogic
    {
        private readonly CustomerContext context;

        public CustomerDomainLogic(CustomerContext context) 
        {
            this.context = context;
        }

        public List<Customer> getAllCustomers()
        {
            List<Customer> ret = context.Customers.AsNoTracking().ToList();
            return ret;
        }

        public Customer getCustomerByFirstName(string firstName)
        {
            return context.Customers.Where(x => x.first_name == firstName).AsNoTracking().First();
        }

        public bool customerExists(string firstName)
        {
            return context.Customers.Where(x => x.first_name == firstName).AsNoTracking().ToList().Count >= 1;
        }

        public Customer insertCustomer(string firstName, string address, float cash, int tableNumber)
        {
            Customer newCustomer = new Customer(firstName, address, cash, tableNumber);
            context.Customers.Add(newCustomer);
            context.SaveChanges();

            return context.Customers.Where(x => x.Id == newCustomer.Id).AsNoTracking().First();
        }
        
        public void deleteCustomer(string firstName)
        {
            context.Customers.Remove(context.Customers.Where(x => x.first_name == firstName).First());
            context.SaveChanges();
        }

        public List<Customer> GetCustomersAtTable(int tableNumber)
        {
            return context.Customers.Where(x => x.table_number == tableNumber).AsNoTracking().ToList();
        }

    }
}
