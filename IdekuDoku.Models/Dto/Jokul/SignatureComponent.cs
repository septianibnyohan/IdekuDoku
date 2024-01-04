namespace IdekuDoku.Models.Dto.Jokul;

public class SignatureComponent
{
    public Decimal Amount { get; set; }
    public string? ApprovalCode { get; set; }
    public int BatchNumber { get; set; }
    public string? ClientId { get; set; }
    public string? InvoiceNumber { get; set; }
    public string? OvoId { get; set; }
    public int ReferenceNumber { get; set; }
    public int TraceNumber { get; set; }
    public string? Key { get; set; }
}