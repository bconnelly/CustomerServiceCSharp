using CustomersService.DBAccessEntities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("CustomersService")]
    public class CustomersController : ControllerBase
    {

        private readonly CustomerContext context;

        public CustomersController(CustomerContext context)
        {
            this.context = context;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("getAllCustomers")]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return context.Customers;
            //return JsonSerializer.Serialize(new Customer("c sharp bob", "123 main st", 12, 2));
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value: {id}";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
