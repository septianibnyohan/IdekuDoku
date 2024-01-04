namespace IdekuDoku.Models.Dto.Jokul.Request;

public class JokulRequest
{
    public Order order { get; set; }
    public Payment payment { get; set; }
    public Customer customer { get; set; }
}