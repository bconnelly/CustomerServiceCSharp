using CustomersService.DBAccessEntities;
using CustomersService.DomainLogic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("CustomersService")]
    public class CustomersController : ControllerBase
    {

        private CustomerLogic customerLogic;

        public CustomersController(CustomerLogic customerLogic)
        {
            this.customerLogic = customerLogic;
        }

        [HttpGet("getAllCustomers")]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            return customerLogic.getAllCustomers();
            //return JsonSerializer.Serialize(new Customer("c sharp bob", "123 main st", 12, 2));
        }

        [HttpGet("getCustomerByFirstName/{firstName}")]
        public ActionResult<IEnumerable<Customer>> GetCustomerByFirstName(string firstName)
        {
            return customerLogic.getCustomerByFirstName(firstName);
        }

        [HttpGet("customerExists/{firstName}")]
        public ActionResult<Boolean> CustomerExists(string firstName)
        {
            return customerLogic.customerExists(firstName);
        }

        [HttpGet("insertCustomer/")]
        public void InsertCustomer(string firstName, string address, float cash, int tableNumber)
        {
            customerLogic.insertCustomer(firstName, address, cash, tableNumber);
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
