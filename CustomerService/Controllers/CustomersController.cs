using CustomersService.DBAccessEntities;
using CustomersService.DomainLogic;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("CustomersService")]
    public class CustomersController : ControllerBase
    {

        private CustomerDomainLogic customerLogic;

        public CustomersController(CustomerDomainLogic customerLogic)
        {
            this.customerLogic = customerLogic;
        }

        [HttpGet("getAllCustomers")]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            return customerLogic.getAllCustomers();
        }

        [HttpGet("getCustomerByFirstName/{firstName}")]
        public ActionResult<Customer> GetCustomerByFirstName(string firstName)
        {
            return customerLogic.getCustomerByFirstName(firstName);
        }

        [HttpGet("customerExists/{firstName}")]
        public ActionResult<Boolean> CustomerExists(string firstName)
        {
            return customerLogic.customerExists(firstName);
        }

        [HttpGet("insertCustomer/{firstName}/{address}/{cash}/{tableNumber}")]
        public ActionResult<Customer> InsertCustomer(string firstName, string address, float cash, int tableNumber)
        {
            return customerLogic.insertCustomer(firstName, address, cash, tableNumber);
        }

        [HttpPost("bootCustomer/{firstName}")]
        public void DeleteCustomer(string firstName)
        {
            customerLogic.deleteCustomer(firstName);
        }

        [HttpGet("getCustomersAtTable/{tableNumber}")]
        public ActionResult<List<Customer>> GetCustomersAtTable(int tableNumber)
        {
            return customerLogic.GetCustomersAtTable(tableNumber);
        }

    }
}
