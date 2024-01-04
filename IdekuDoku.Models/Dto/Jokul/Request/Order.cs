namespace IdekuDoku.Models.Dto.Jokul.Request;

public class Order
{
    public string invoice_number { get; set; }
    public List<LineItem> line_items { get; set; }
    public Decimal amount { get; set; }
    public string callback_url { get; set; }
    public bool auto_redirect { get; set; }
    public string session_id { get; set; }
    public string currency { get; set; }
}