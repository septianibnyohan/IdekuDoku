using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Payment.Request;

public class PaymentRequestDto
{
    [JsonPropertyName("order")]
    public OrderRequestDto? Order { get; set; }
    [JsonPropertyName("virtual_account_info")]
    public VirtualAccountInfoRequestDto? VirtualAccountInfo { get; set; }
    [JsonPropertyName("customer")]
    public CustomerRequestDto? Customer { get; set; }
    [JsonPropertyName("additional_info")]
    public Dictionary<string, object>? AdditionalInfo { get; set; }

    public class PaymentRequestDtoBuilder
    {
        private Dictionary<string, object> _additionalInfo = new Dictionary<string, object>();
        private OrderRequestDto? _order;
        private VirtualAccountInfoRequestDto? _virtualAccountInfo;
        private CustomerRequestDto? _customer;

        public PaymentRequestDtoBuilder SetOrder(OrderRequestDto? order)
        {
            this._order = order;
            return this;
        }

        public PaymentRequestDtoBuilder SetVirtualAccountInfo(VirtualAccountInfoRequestDto? virtualAccountInfo)
        {
            this._virtualAccountInfo = virtualAccountInfo;
            return this;
        }

        public PaymentRequestDtoBuilder SetCustomer(CustomerRequestDto? customer)
        {
            this._customer = customer;
            return this;
        }

        public PaymentRequestDtoBuilder SetAdditionalInfo()
        {
            _additionalInfo = new Dictionary<string, object>();
            SetDefaultAdditional();
            return this;
        }

        private void SetDefaultAdditional()
        {
            Integration integration = new Integration
            {
                Name = "jokul-java-library",
                Version = "v1.0.3"
            };
            _additionalInfo["integration"] = integration;
        }

        public PaymentRequestDtoBuilder SetAdditionalInfo(string title, object obj)
        {
            _additionalInfo = new Dictionary<string, object>
            {
                { title, obj }
            };
            SetDefaultAdditional();
            return this;
        }

        public PaymentRequestDto Build()
        {
            return new PaymentRequestDto
            {
                Order = _order,
                VirtualAccountInfo = _virtualAccountInfo,
                Customer = _customer,
                AdditionalInfo = _additionalInfo
            };
        }
    }
}