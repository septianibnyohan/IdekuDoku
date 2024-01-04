using IdekuDoku.Api.Services;
using IdekuDoku.Domain.Repositories;
using IdekuDoku.Infrastructure.Factories;
using Moq;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace IdekuDoku.Tests;

public class PaymentServiceTests
{
  [Fact]
  public void ProcessPayment_Successful()
  {
    // Arrange
    var mockPaymentMethodFactory = new Mock<IPaymentMethodFactory>();
    var mockUserRepository = new Mock<IUserRepository>();

    var paymentService = new PaymentService(mockPaymentMethodFactory.Object, mockUserRepository.Object);

    // Act
    var result = paymentService.ProcessPayment(1);

    // Assert
    Assert.True(result); // Replace this with your actual success condition
  }

  [Fact]
  public void ProcessPayment_Failure()
  {
    // Arrange
    var mockPaymentMethodFactory = new Mock<IPaymentMethodFactory>();
    var mockUserRepository = new Mock<IUserRepository>();

    // Simulate a failure scenario in the PaymentService
    mockUserRepository.Setup(repo => repo.GetUserById(It.IsAny<int>()))
      .Throws(new Exception("Simulated error"));

    var paymentService = new PaymentService(mockPaymentMethodFactory.Object, mockUserRepository.Object);

    // Act and Assert
    Assert.Throws<Exception>(() => paymentService.ProcessPayment(1));
  }
}