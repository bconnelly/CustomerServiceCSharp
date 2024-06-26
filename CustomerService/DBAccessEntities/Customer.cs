﻿namespace CustomersService.DBAccessEntities
{
    public record Customer
    {
        public Customer(string first_name, string address, float cash, int table_number)
        {
            this.first_name = first_name;
            this.address = address;
            this.cash = cash;
            this.table_number = table_number;
        }

        public int Id { get; set; }
        public string first_name { get; set; }
        public string address { get; set; }
        public float cash { get; set; }
        public int table_number { get; set; }

        public bool equalsExceptId(Customer otherCustomer)
        {
            return first_name == otherCustomer.first_name &&
                address == otherCustomer.address &&
                cash == otherCustomer.cash &&
                table_number == otherCustomer.table_number;
        }
    }
}
