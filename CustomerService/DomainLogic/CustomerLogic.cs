using CustomersService.DBAccessEntities;
using Microsoft.EntityFrameworkCore;

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
        public Boolean insertCustomer(string firstName, string address, float cash, int tableNumber)
        {
            context.Add(new Customer(firstName, address, cash, tableNumber));
            context.SaveChanges();
            
            return true;
            //List<Customer> ret = context.Customers.Where(x => x.first_name == firstName && x.address == address && x.cash == cash && x.table_number == tableNumber).ToList();
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
