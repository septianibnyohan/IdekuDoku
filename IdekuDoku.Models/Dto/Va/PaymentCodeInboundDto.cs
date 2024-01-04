namespace IdekuDoku.Models.Dto.Va;

public class PaymentCodeInboundDto
{
  public string CustomerName { get; set; }
  public string Email { get; set; }
  public string PhoneNumber { get; set; }
  public string Address { get; set; }
  public string Country { get; set; }
  public string Province { get; set; }
  public string City { get; set; }
  public string PostalCode { get; set; }
  public string InvoiceNumber { get; set; }
  public long Amount { get; set; }
  public int ExpiredTime { get; set; }
  public bool ReusableStatus { get; set; }
  public string Info1 { get; set; }
  public string Info2 { get; set; }
  public string Info3 { get; set; }
  public string Channel { get; set; }
}