using Xunit;
using Wallet.Domain;

namespace Wallet.UnitTests
{
    public sealed class CustomerTests
    {
        [Fact]
        public void RegisterCustomer_Returns_CustomerOutput()
        {
            // Arrange
            string expectedName = "John Doe";
            string expectePhoneNumber = "702-338-0361539";
            string expectedSSN = "539-04-0831";

            // Act
            RegisterCustomerUseCase register = new RegisterCustomerUseCase();
            RegisterCustomerOutput actual = register.Execute(expectedName, expectePhoneNumber, expectedSSN);

            // Assert
            Assert.
        }
    }
}