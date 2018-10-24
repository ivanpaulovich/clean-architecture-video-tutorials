using Moq;
using MyPersonalFinance.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyPersonalFinance.UnitTests
{
    public class CustomerTests
    {
        [Fact]
        void CustomerIsRegisteredWhenDetailsAreValid()
        {
            //
            // Arrange
            string expectedName = "Jon Doe";
            string expectedPhoneNumber = "555-7777";
            string expectedSsn = "888888888";

            var customerRepository = new CustomerRepository();

            // Act
            RegisterCustomerUseCase register = new RegisterCustomerUseCase(customerRepository);
            register.Execute(expectedName, expectedPhoneNumber, expectedSsn);
            
            GetCustomerDetailsUseCase getCustomer = new GetCustomerDetailsUseCase(customerRepository);
            Customer actualCustomer = getCustomer.Execute(expectedSsn);

            //
            // Assert
            Assert.NotNull(actualCustomer);
            Assert.NotEqual(Guid.Empty, actualCustomer.Id);
            Assert.Equal(expectedName, actualCustomer.Name);
            Assert.Equal(expectedPhoneNumber, actualCustomer.PhoneNumber);
            Assert.Equal(expectedSsn, actualCustomer.SSN);
        }

        [Fact]
        void CustomerCreatedHasPropertiesSetted()
        {
            //
            // Arrange
            string expectedName = "Jon Doe";
            string expectedPhoneNumber = "555-7777";
            string expectedSsn = "888888888";

            //
            // Act
            Customer actualCustomer = new Customer(expectedName, expectedPhoneNumber, expectedSsn);

            //
            // Assert
            Assert.NotEqual(Guid.Empty, actualCustomer.Id);
            Assert.Equal(expectedName, actualCustomer.Name);
            Assert.Equal(expectedPhoneNumber, actualCustomer.PhoneNumber);
            Assert.Equal(expectedSsn, actualCustomer.SSN);
        }

        [Fact]
        void CustomerCreatedCallsRepositorySaveMethod()
        {
            //
            // Arrange
            string expectedName = "Jon Doe";
            string expectedPhoneNumber = "555-7777";
            string expectedSsn = "888888888";

            var customerRepository = new Moq.Mock<ICustomerRepository>();
            RegisterCustomerUseCase register = new RegisterCustomerUseCase(customerRepository.Object);
            register.Execute(expectedName, expectedPhoneNumber, expectedSsn);

            customerRepository.Verify(c => c.Save(It.IsAny<Customer>()), Moq.Times.Once);
        }

        [Fact]
        void RegisterCustomerIsReturnedFromRepository()
        {
            // arrange
            string expectedName = "Jon Doe";
            string expectedPhoneNumber = "555-7777";
            string expectedSsn = "888888888";
            Customer expectedCustomer = new Customer(expectedName, expectedPhoneNumber, expectedSsn);

            var customerRepository = new CustomerRepository(expectedCustomer);

            //
            // act
            GetCustomerDetailsUseCase getCustomer = new GetCustomerDetailsUseCase(customerRepository);
            Customer actualCustomer = getCustomer.Execute(expectedSsn);

            //Assert

            Assert.NotNull(actualCustomer);
            Assert.Equal(expectedCustomer.Name, actualCustomer.Name);
            Assert.Equal(expectedCustomer.PhoneNumber, actualCustomer.PhoneNumber);
            Assert.Equal(expectedCustomer.SSN, actualCustomer.SSN);
            Assert.Equal(expectedCustomer.Id, actualCustomer.Id);
        }
    }
}
