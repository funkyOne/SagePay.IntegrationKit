using SagePay.IntegrationKit.Messages;

namespace SagePay.IntegrationKit
{
    public class DataObject : IMessage,
        IFormPayment, IFormPaymentResult, IFormPaymentEncrypted,
        IServerPayment, IServerPaymentResult,
        IServerNotificationRequest, IServerNotificationResult,
        IServerTokenRegisterRequest, IServerTokenRegisterResult,
        IServerTokenNotificationRequest,
        IDirectPayment, IDirectPaymentResult,
        IDirectTokenRegisterRequest, IDirectTokenResult,
        ITokenRemoveRequest,
        IThreeDAuthRequest,
        IPayPalCompleteRequest, IPayPalNotificationRequest,
        IReleaseRequest,
        IVoidRequest,
        IAbortRequest,
        ICancelRequest,
        IRefundRequest, IRefundResult,
        IRepeatRequest, IAuthoriseRequest, ICaptureResult //,Serializable
    {
        // MC-6012
        public string FiRecipientAccountNumber { get; set; }
        public string FiRecipientDateOfBirth { get; set; }
        public string FiRecipientPostCode { get; set; }
        public string FiRecipientSurname { get; set; }

        public ProtocolVersion VpsProtocol { get; set; } = ProtocolVersion.V_300;
        public TransactionType TransactionType { get; set; }
        public string Vendor { get; set; }
        public string VendorTxCode { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public string StartDate { get; set; }
        public string ExpiryDate { get; set; }
        public string IssueNumber { get; set; }
        public string Cv2 { get; set; }
        public CardType CardType { get; set; }
        public string BillingSurname { get; set; }
        public string BillingFirstnames { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingCity { get; set; }
        public string BillingPostCode { get; set; }
        public string BillingCountry { get; set; }
        public string BillingState { get; set; }
        public string BillingPhone { get; set; }
        public string DeliverySurname { get; set; }
        public string DeliveryFirstnames { get; set; }
        public string DeliveryAddress1 { get; set; }
        public string DeliveryAddress2 { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryPostCode { get; set; }
        public string DeliveryCountry { get; set; }
        public string DeliveryState { get; set; }
        public string DeliveryPhone { get; set; }
        public string PayPalCallbackUrl { get; set; }
        public string CustomerEmail { get; set; }
        public string Basket { get; set; }
        public string GiftAidPayment { get; set; }
        public int ApplyAvsCv2 { get; set; }
        public string ClientIpAddress { get; set; }
        public int Apply3dSecure { get; set; }
        public string AccountType { get; set; }
        public string BillingAgreement { get; set; }
        public ResponseStatus Status { get; set; }
        public string StatusDetail { get; set; }
        public string VpsTxId { get; set; }
        public string SecurityKey { get; set; }
        public int TxAuthNo { get; set; }
        public string AvsCv2 { get; set; }
        public string Cavv { get; set; }
        public string Md { get; set; }
        public string AcsUrl { get; set; }
        public string PaReq { get; set; }
        public string PaRes { get; set; }
        public string PayPalRedirectUrl { get; set; }
        public string AddressStatus { get; set; }
        public string PayerStatus { get; set; }
        public string PayerId { get; set; }
        public string Accept { get; set; }
        public string Crypt { get; set; }
        public string SuccessUrl { get; set; }
        public string FailureUrl { get; set; }
        public string CustomerName { get; set; }
        public string VendorEmail { get; set; }
        public string EmailMessage { get; set; }
        public int AllowGiftAid { get; set; }
        public string Last4Digits { get; set; }
        public string RelatedVpsTxId { get; set; }
        public string RelatedVendorTxCode { get; set; }
        public string RelatedSecurityKey { get; set; }
        public int RelatedTxAuthNo { get; set; }
        public int SendEmail { get; set; }
        public string ReferrerId { get; set; }
        public string NotificationUrl { get; set; }
        public string Profile { get; set; }
        public string NextUrl { get; set; }
        public decimal ReleaseAmount { get; set; }
        public int GiftAid { get; set; }
        public string VpsSignature { get; set; }
        public CheckResult AddressResult { get; set; }
        public CheckResult PostCodeResult { get; set; }
        public CheckResult Cv2Result { get; set; }
        public ThreeDSecureStatus ThreeDSecureStatus { get; set; }
        public string RedirectUrl { get; set; }
        public string Token { get; set; }
        public string SurchargeXml { get; set; }
        public int CreateToken { get; set; }
        public string BasketXml { get; set; }
        public decimal? Surcharge { get; set; }
        public string DeclineCode { get; set; }
        public string BankAuthCode { get; set; }
        public FraudResponse FraudResponse { get; set; }
        public string VendorData { get; set; }
        public string CustomerXml { get; set; }
        public int StoreToken { get; set; }
    }
}