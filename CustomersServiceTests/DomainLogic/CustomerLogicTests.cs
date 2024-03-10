using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomersService.DBAccessEntities;
using Microsoft.EntityFrameworkCore;
using CustomersServiceTests.Utilities;

namespace CustomersService.DomainLogic.Tests
{
    [TestClass]
    public class CustomerLogicTests
    {


        private static CustomerDataFixture fixture = new CustomerDataFixture();
        private static CustomerDomainLogic logic = new CustomerDomainLogic(fixture.context);

        [TestInitialize]
        public void init()
        {
            fixture.reset();
            logic = new CustomerDomainLogic(fixture.context);
        }

        [ClassCleanup]
        public static void cleanup()
        {
            fixture.Dispose();
        }

        [TestMethod]
        public void getAllCustomersTest()
        {
            List<Customer> retCustomers = logic.getAllCustomers();

            Assert.AreEqual(5, retCustomers.Count);
            Assert.IsInstanceOfType<Customer>(retCustomers[0]);

        }

        [TestMethod]
        public void getCustomerByFirstNameTest()
        {
            Customer retCustomer = logic.getCustomerByFirstName("test customer 3");
            Assert.AreEqual("test customer 3", retCustomer.first_name);
            Assert.AreEqual("test address 3", retCustomer.address);
            Assert.AreEqual(1f, retCustomer.cash);
            Assert.AreEqual(1, retCustomer.table_number);
        }

        [TestMethod]
        public void customerExistsTest()
        {
            Assert.IsTrue(logic.customerExists("test customer 1"));
            Assert.IsTrue(logic.customerExists("test customer 2"));
            Assert.IsTrue(logic.customerExists("test customer 3"));
            Assert.IsTrue(logic.customerExists("test customer 4"));
            Assert.IsTrue(logic.customerExists("test customer 5"));
        }

        [TestMethod]
        public void insertCustomerTest()
        {
            Customer toInsert = new Customer("alice", "123 main st", 5.00f, 2);
            Customer inserted = logic.insertCustomer("alice", "123 main st", 5.00f, 2);

            Assert.IsTrue(toInsert.equalsExceptId(inserted));
        }

        [TestMethod]
        public void deleteCustomerTest()
        {
            Assert.IsTrue(logic.customerExists("test customer 1"));

            logic.deleteCustomer("test customer 1");

            Assert.IsFalse(logic.customerExists("test customer 1"));
        }

        [TestMethod]
        public void GetCustomersAtTableTest()
        {
            List<Customer> atTableRet = logic.GetCustomersAtTable(1);
            HashSet<string> expected = ["test customer 2", "test customer 3"];

            foreach(Customer customer in atTableRet)
            {
                if (expected.Contains(customer.first_name)) expected.Remove(customer.first_name);
            }

            Assert.IsTrue(expected.Count == 0);
        }
    }
}