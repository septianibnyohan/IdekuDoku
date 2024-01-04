namespace IdekuDoku.Lib.Constant;

public class DokuUrl
{
  public const bool IS_DEV = true;

  public const string SANDBOX_URL = "https://api-sandbox.doku.com";
  public const string PROD_URL = "https://api.doku.com";
  public static string BaseUrl = IS_DEV ? SANDBOX_URL : PROD_URL;
  
  // Credit Card
  public const string CC_GENERATE_PAYMENT_PAGE = "/credit-card/v1/payment-page";
  public const string CC_ONLINE_REFUND = "/credit-card/v1/cancellation/credit-card/refund";
  
  // Virtual Account
  public const string MANDIRI_VA_GENERATE_PAYMENT_CODE = "/mandiri-virtual-account/v2/merchant-payment-code";
  public const string MANDIRI_VA_UPDATE_PAYMENT_CODE = "/mandiri-virtual-account/v2/payment-code";
  public const string BCA_VA_GENERATE_PAYMENT_CODE = "/bca-virtual-account/v2/payment-code";
  public const string BCA_VA_UPDATE_PAYMENT_CODE = "/bca-virtual-account/v2/payment-code";
  public const string BSI_VA_GENERATE_PAYMENT_CODE = "/bsm-virtual-account/v2/payment-code";
  public const string BSI_VA_UPDATE_PAYMENT_CODE = "/bsm-virtual-account/v2/payment-code";
  public const string DOKU_VA_GENERATE_PAYMENT_CODE = "/doku-virtual-account/v2/payment-code";
  public const string DOKU_VA_UPDATE_PAYMENT_CODE = "/doku-virtual-account/v2/payment-code";
  public const string PERMATA_VA_GENERATE_PAYMENT_CODE = "/permata-virtual-account/v2/payment-code";
  public const string PERMATA_VA_UPDATE_PAYMENT_CODE = "/permata-virtual-account/v2/payment-code";
  public const string CIMB_VA_GENERATE_PAYMENT_CODE = "/cimb-virtual-account/v2/payment-code";
  public const string CIMB_VA_UPDATE_PAYMENT_CODE = "/cimb-virtual-account/v2/payment-code";
  public const string BNI_VA_GENERATE_PAYMENT_CODE = "/bni-virtual-account/v2/payment-code";
  
  // O2O
  public const string ALFA_GENERATE_PAYMENT_CODE = "/alfa-online-to-offline/v2/payment-code";
  public const string INDOMARET_GENERATE_PAYMENT_CODE = "/indomaret-online-to-offline/v2/payment-code";
  
  // E-Money
  public const string OVO_PAYMENT = "/ovo-emoney/v1/payment";
  public const string OVO_VOID = "/ovo-emoney/v1/cancel";
  public const string SHOPEEPAY_CREATE_ORDER = "/shopeepay-emoney/v2/order";
  
  // DEBIT
  public const string BRI_REGISTER_CREATE_TOKEN = "/direct-debit/v1/token";
  public const string BRI_REGISTER_VALIDATE_OTP = "/direct-debit/v1/token/validate";
  public const string BRI_REGISTER_RESEND_OTP = "/direct-debit/v1/token-otp";
  public const string BRI_CARD_LIST = "/direct-debit/v1/tokens";
  public const string BRI_PAYMENT_CREATE = "/direct-debit/v1/payment";
  public const string BRI_PAYMENT_VALIDATE_OTP = "/direct-debit/v1/payment/validate";
  public const string BRI_PAYMENT_RESEND_OTP = "/direct-debit/v1/payment-otp";
  public const string BRI_CREATE_PAYMENT_RECURRING = "/direct-debit/v1/payment-recurring";
  public const string BRI_DELETE_CARD = "/direct-debit/v1/token-delete";
  
  // AkuLaku
  public const string AKULAKU_GENERATE_ORDER = "/akulaku-peer-to-peer/v2/generate-order";
  public const string AKULAKU_CANCELLATION = "/akulaku-peer-to-peer/v2/cancel";
  public const string AKULAKU_REFUND = "/akulaku-peer-to-peer/v2/refund";
  
  // Direct Transfer
  public const string BCA_DIRECT_GENERATE_PAYMENT = "/bca-direct-transfer/v1/order";
  
  // Jokul Checkout
  public const string CHECKOUT_INITIATE_PAYMENT = "/checkout/v1/payment";
  
  // Check Status
  public const string CHECK_STATUS = "/orders/v1/status/INV-1640746942";
  
  // Jokul Sub Account
  public const string SAC_CREATE = "/sac-merchant/v1/accounts";
  public const string SAC_PAYOUTS = "/sac-merchant/v1/payouts";
  public const string SAC_TRANSFERS = "/sac-merchant/v1/transfers";
  public const string SAC_BALANCE = "/sac-merchant/v1/balances/SAC-7549-1645676098163";
}