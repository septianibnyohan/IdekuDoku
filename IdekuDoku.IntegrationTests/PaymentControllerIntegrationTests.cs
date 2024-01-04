using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace IdekuDoku.IntegrationTests;

public class PaymentControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly WebApplicationFactory<Program> _factory;

  public PaymentControllerIntegrationTests(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }

  [Fact]
  public async Task ProcessPayment_ReturnsSuccess()
  {
    // Arrange
    var client = _factory.CreateClient();

    var userId = 1;

    // Act
    var response = await client.PostAsync($"/api/payment/process-payment/{userId}", null);
    response.EnsureSuccessStatusCode();

    var responseBody = await response.Content.ReadAsStringAsync();
    var result = JsonConvert.DeserializeObject<string>(responseBody);

    // Assert
    Assert.Equals("Payment processed successfully.", result);
  }

  // Add more integration tests as needed
}