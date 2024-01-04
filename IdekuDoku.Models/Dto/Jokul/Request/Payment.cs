namespace IdekuDoku.Models.Dto.Jokul.Request;

public class Payment
{
    public string[] payment_method_types { get; set; }
    public int payment_due_date { get; set; }
    public string token_id { get; set; }
    public string url { get; set; }
    public string expired_date { get; set; }
  
    public string token { get; set; }
    public int otp_expiration_timestamp { get; set; }
    public string otp { get; set; }
    public string merchant_unique_reference { get; set; }
    public Identifier[] identifier { get; set; }
}