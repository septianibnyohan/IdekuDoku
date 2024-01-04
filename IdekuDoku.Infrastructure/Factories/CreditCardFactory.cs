namespace IdekuDoku.Infrastructure.Factories;

// Concrete factories
public class CreditCardFactory : IPaymentMethodFactory
{
  public IPaymentMethod CreatePaymentMethod()
  {
    return new CreditCardPayment();
  }
}