using IdekuDoku.Models.Dto.Jokul.Request;

namespace IdekuDoku.Models.Dto.Jokul.Response;

public class Response
{
    public Order order { get; set; }
    public Payment payment { get; set; }
    public Customer customer { get; set; }
    public AdditionalInfoMain additional_info { get; set; }
    public string uuid { get; set; }
    public Headers headers { get; set; }
}