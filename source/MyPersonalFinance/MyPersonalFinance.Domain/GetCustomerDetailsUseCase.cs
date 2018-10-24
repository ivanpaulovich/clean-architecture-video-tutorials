using System;
using System.Collections.Generic;
using System.Text;

namespace MyPersonalFinance.Domain
{
    public class GetCustomerDetailsUseCase
    {
        private ICustomerRepository _customerRepository;

        public GetCustomerDetailsUseCase(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public Customer Execute(string ssn)
        {
            Customer lookupCustomer = _customerRepository.GetCustomer(ssn);
            return lookupCustomer;
        }
    }
}
