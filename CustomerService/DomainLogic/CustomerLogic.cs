using CustomersService.DBAccessEntities;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace CustomersService.DomainLogic
{
    public class CustomerLogic
    {
        private readonly CustomerContext context;

        public CustomerLogic(CustomerContext context) 
        {
            this.context = context;
        }


        public List<Customer> getAllCustomers()
        {
            return context.Customers.AsNoTracking().ToList();
        }

        public List<Customer> getCustomerByFirstName(string firstName)
        {
            return context.Customers.Where(x => x.first_name == firstName).AsNoTracking().ToList();
        }

        public bool customerExists(string firstName)
        {
            return context.Customers.Where(x => x.first_name == firstName).AsNoTracking().ToList().Count >= 1;
        }

        // assume only one customer is returned? what if more are?
        public Customer insertCustomer(string firstName, string address, float cash, int tableNumber)
        {
            Customer newCustomer = new Customer(firstName, address, cash, tableNumber);
            context.Add(newCustomer);
            context.SaveChanges();

            return context.Customers.Where(x => x.Id == newCustomer.Id).AsNoTracking().First();
        }

        public void deleteCustomer(string firstName)
        {
            context.Customers.Remove(context.Customers.Where(x => x.first_name == firstName).First());
        }

        public List<Customer> GetCustomersAtTable(int tableNumber)
        {
            return context.Customers.Where(x => x.table_number == tableNumber).AsNoTracking().ToList();
        }
    }
}
