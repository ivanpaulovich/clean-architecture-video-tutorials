using System;
using System.Collections.Generic;
using System.Text;

namespace MyPersonalFinance.Domain
{
    public class RegisterCustomerUseCase
    {
        private ICustomerRepository _customerRepository;

        public RegisterCustomerUseCase(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public void Execute(string name, string phoneNumber, string ssn)
        {
            Customer customer = new Customer(name, phoneNumber, ssn);
            _customerRepository.Save(customer);
        }
    }
}
