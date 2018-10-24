using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPersonalFinance.Domain
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> customersData;

        public CustomerRepository()
        {
            this.customersData = new List<Customer>() { };
        }

        public CustomerRepository(Customer customer)
        {
            this.customersData = new List<Customer>() { customer };
        }

        public Customer GetCustomer(string ssn)
        {
            return customersData.Where(c => c.SSN == ssn).FirstOrDefault();
        }

        public void Save(Customer newCustomer)
        {
            customersData.Add(newCustomer);
        }
    }
}
