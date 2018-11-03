using System.Collections.Generic;
using Wallet.Domain;

namespace Wallet.Application
{
    public sealed class CustomerResult
    {
        public CustomerResult(Customer customer)
        {
            this.Id = customer.Id;
            this.Name = customer.Name;
            this.PhoneNumber = customer.PhoneNumber;
        }

        public System.Guid Id { get; }
        public string Name { get; }
        public string PhoneNumber { get; }
    }
}