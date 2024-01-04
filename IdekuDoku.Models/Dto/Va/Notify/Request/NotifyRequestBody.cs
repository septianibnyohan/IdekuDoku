namespace IdekuDoku.Models.Dto.Va.Notify.Request;

public class NotifyRequestBody
{
  public ServiceDto Service { get; set; }
  public AcquirerDto Acquirer { get; set; }
  public ChannelDto Channel { get; set; }
  public OrderRequestDto Order { get; set; }
  public VirtualAccountInfoRequestDto? VirtualAccountInfo { get; set; }
  public VirtualAccountPaymentRequestDto? VirtualAccountPayment { get; set; }
}