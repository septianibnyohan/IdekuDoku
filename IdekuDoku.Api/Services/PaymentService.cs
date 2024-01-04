using IdekuDoku.Domain.Entities;
using IdekuDoku.Domain.Repositories;
using IdekuDoku.Infrastructure.Factories;

namespace IdekuDoku.Api.Services;

// Dependency injection using constructor injection
public class PaymentService
{
  private readonly IPaymentMethodFactory _paymentMethodFactory;
  private readonly IUserRepository _userRepository;

  public PaymentService(IPaymentMethodFactory paymentMethodFactory, IUserRepository userRepository)
  {
    _paymentMethodFactory = paymentMethodFactory;
    _userRepository = userRepository;
  }

  public bool ProcessPayment(int userId)
  {
    User user = _userRepository.GetUserById(userId);
    // Additional logic
    IPaymentMethod paymentMethod = _paymentMethodFactory.CreatePaymentMethod();
    paymentMethod.ProcessPayment();
    // Additional logic

    return true;
  }
}
