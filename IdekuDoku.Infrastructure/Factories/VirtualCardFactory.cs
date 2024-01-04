namespace IdekuDoku.Infrastructure.Factories;

public class VirtualCardFactory : IPaymentMethodFactory
{
  public IPaymentMethod CreatePaymentMethod()
  {
    return new VirtualCardPayment();
  }
}