using Wallet.Domain;

namespace Wallet.Application
{
    public sealed class RegisterCustomerUseCase : IRegisterCustomerUseCase
    {
        public CustomerResult Register(string name, string phoneNumber)
        {
            Customer customer = new Customer(name, phoneNumber);
            return new CustomerResult(customer);
        }
    }
}