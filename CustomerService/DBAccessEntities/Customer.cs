namespace CustomersService.DBAccessEntities
{
    public class Customer
    {
        public Customer(string firstName, string address, float cash, int tableNumber)
        {
            this.firstName = firstName;
            this.address = address;
            this.cash = cash;
            this.tableNumber = tableNumber;
        }

        public string firstName { get; set; }
        public string address { get; set; }
        public float cash { get; set; }
        public int tableNumber { get; set; }
    }
}
