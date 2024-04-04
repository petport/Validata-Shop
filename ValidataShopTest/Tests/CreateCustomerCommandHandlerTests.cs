using Moq;
using NUnit.Framework;
using ValidataShopTest.Application.Commands;
using ValidataShopTest.Models;


namespace ValidataShopTests
{
    [TestFixture]
    public class CreateCustomerCommandHandlerTests
    {
        [Test]
        public async Task HandleAsync_CallsCompleteAsyncOnUnitOfWork()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var handler = new CreateCustomerCommandHandler(mockUnitOfWork.Object);
            var command = new CreateCustomerCommand("John", "Doe", "123 Main St", "12345");

            // Act
            await handler.HandleAsync(command);

            // Assert
            mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
        }

        //Check that the customer is added to the database
        [Test]
        public async Task HandleAsync_AddsCustomerToDatabase()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var handler = new CreateCustomerCommandHandler(mockUnitOfWork.Object);
            var command = new CreateCustomerCommand("John", "Doe", "123 Main St", "12345");

            // Act
            await handler.HandleAsync(command);

            // Assert
            mockUnitOfWork.Verify(u => u.Customers.AddAsync(It.IsAny<Customer>()), Times.Once);
        }

    }
}
