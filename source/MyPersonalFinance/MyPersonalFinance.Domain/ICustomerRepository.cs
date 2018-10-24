using System;
using System.Collections.Generic;
using System.Text;

namespace MyPersonalFinance.Domain
{
    public interface ICustomerRepository
    {
        void Save(Customer newCustomer);
        Customer GetCustomer(string ssn);
    }
}
