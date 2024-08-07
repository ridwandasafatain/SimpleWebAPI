using Microsoft.AspNetCore.Mvc;
using Moq;
using Web.Domain;
using Web.Service;
using WebApi.Controllers;
using Xunit;

namespace WebApi.Tests
{

    public class CustomerControllerTest
    {
        private readonly Mock<ICustomerService> _mockCustomerService;
        private readonly CustomerController _controller;

        public CustomerControllerTest()
        {
            _mockCustomerService = new Mock<ICustomerService>();
            _controller = new CustomerController(_mockCustomerService.Object);
        }

        [Fact]
        public void GetAll_ReturnsAllCustomers()
        {
            // Arrange
            var customers = new List<CustomerDTO>
            {
                new CustomerDTO { CustomerId = 1, CustomerName = "Customer1" },
                new CustomerDTO { CustomerId = 2, CustomerName = "Customer2" }
            };
            _mockCustomerService.Setup(service => service.GetCustomers()).Returns(customers);

            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetByID_ReturnsCustomer_WhenCustomerExists()
        {
            // Arrange
            var customer = new CustomerDTO { CustomerId = 1, CustomerName = "Customer1" };
            _mockCustomerService.Setup(service => service.GetCustomerByID(1)).Returns(customer);

            // Act
            var result = _controller.GetByID(1);

            // Assert
            Assert.NotNull(result.Data);
            Assert.Equal("Customer1", ((CustomerResponse)result.Data).CustomerName);
        }

        [Fact]
        public void Insert_ReturnsBadRequest_WhenCustomerIsInvalid()
        {
            // Arrange
            var customerRequest = new InsertCustomerRequest { CustomerName = "" };
            var validator = new InsertCustomerValidator();
            var validationResult = validator.Validate(customerRequest);

            // Act
            var result = _controller.Insert(customerRequest) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Delete_ReturnsOk_WhenCustomerIsDeleted()
        {
            // Arrange
            var customer = new CustomerDTO { CustomerId = 1, CustomerName = "Customer1" };
            _mockCustomerService.Setup(service => service.GetCustomerByID(1)).Returns(customer);
            _mockCustomerService.Setup(service => service.DeleteCustomer(1));

            // Act
            var result = _controller.Delete(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Data Customer dengan id 1 berhasil dihapus", result.Value);
        }

        [Fact]
        public void Delete_ReturnsBadRequest_WhenCustomerDoesNotExist()
        {
            // Arrange
            _mockCustomerService.Setup(service => service.GetCustomerByID(1)).Returns((CustomerDTO)null);

            // Act
            var result = _controller.Delete(1) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Data tidak ditemukan", result.Value);
        }
    }
}
