using System;
using System.Collections.Generic;
using System.Text;

namespace MyPersonalFinance.Domain
{
    public class Customer : IAggregateRoot
    {
        private string _name;
        private string _phoneNumber;
        private string _ssn;

        public Customer(string name, string phoneNumber, string ssn)
        {
            this.Id = Guid.NewGuid();
            this._name = name;
            this._phoneNumber = phoneNumber;
            this._ssn = ssn;
        }

        public Guid Id { get; }
        public string Name { get { return _name; } }
        public string SSN { get { return _ssn; } }
        public string PhoneNumber { get { return _phoneNumber; } }
    }
}
