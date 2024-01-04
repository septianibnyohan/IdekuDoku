namespace IdekuDoku.Models.Dto.Va;

public class TransactionDto
{
  public int Id { get; set; }
  public string? CustomerName { get; set; }
  public string? Email { get; set; }
  public string? PhoneNumber { get; set; }
  public string? Address { get; set; }
  public string? Country { get; set; }
  public string? City { get; set; }
  public string? PostalCode { get; set; }
  public string? VirtualAccountNumber { get; set; }
  public string? InvoiceNumber { get; set; }
  public string? Status { get; set; }
  public string? HowToPayPage { get; set; }
  public string? HowToPayApi { get; set; }
  public string? ExpiredDate { get; set; }
}