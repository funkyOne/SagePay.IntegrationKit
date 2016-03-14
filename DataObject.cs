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

        // P3
        private decimal? surcharge;
        private string declineCode;
        private string bankAuthCode;
        private FraudResponse fraudResponse;
        private string vendorData;
        private string customerXml;

        private ProtocolVersion vpsProtocol = ProtocolVersion.V_300;
        private TransactionType transactionType;
        private string vendor;
        private string vendorTxCode;
        private decimal amount;
        private string currency;
        private string description;
        private string cardHolder;
        private string cardNumber;
        private string startDate;
        private string expiryDate;
        private string issueNumber;
        private string cv2;
        private CardType cardType;
        private string billingSurname;
        private string billingFirstnames;
        private string billingAddress1;
        private string billingAddress2;
        private string billingCity;
        private string billingPostCode;
        private string billingCountry;
        private string billingState;
        private string billingPhone;
        private string deliverySurname;
        private string deliveryFirstnames;
        private string deliveryAddress1;
        private string deliveryAddress2;
        private string deliveryCity;
        private string deliveryPostCode;
        private string deliveryCountry;
        private string deliveryState;
        private string deliveryPhone;
        private string payPalCallbackUrl;
        private string customerEmail;
        private string basket;
        private string basketXml;
        private string giftAidPayment;
        private int giftAid;
        private int applyAvsCv2;
        private string clientIpAddress;
        private int apply3dSecure;
        private string accountType;
        private string billingAgreement;
        private string surchargeXml;
        private int createToken;

        // usually response fields
        private ResponseStatus status;
        private string statusDetail;
        private string vpsTxId;
        private string vpsSignature;
        private string securityKey;
        private int txAuthNo;
        private string avsCv2;
        private CheckResult addressResult;
        private CheckResult postCodeResult;
        private CheckResult cv2Result;
        private ThreeDSecureStatus threeDSecureStatus; // token is '3DSecureStatus'
        private string cavv;
        private string md;
        private string acsUrl;
        private string paReq;
        private string paRes;
        private string redirectUrl;
        private string token;
        private int storeToken;

        private string payPalRedirectUrl;
        private string addressStatus;
        private string payerStatus;
        private string payerId;
        private string accept;

        // form
        private string crypt;
        private string successUrl;
        private string notificationUrl;
        private string failureUrl;
        private string customerName;
        private string vendorEmail;
        private int sendEmail;
        private string emailMessage;
        private int allowGiftAid;
        private string last4Digits;

        private string relatedVpsTxId;
        private string relatedVendorTxCode;
        private string relatedSecurityKey;
        private int relatedTxAuthNo;

        private string referrerId;

        // SERVER
        private string profile;
        private string nextUrl;

        private decimal releaseAmount;

        // MC-6012
		public string FiRecipientAccountNumber { get; set; }
		public string FiRecipientDateOfBirth { get; set; }
		public string FiRecipientPostCode { get; set; }
		public string FiRecipientSurname { get; set; }

        //public string tostring() {
        //    return Utils.tostring(this, false);
        //}

        public ProtocolVersion VpsProtocol
        {
            get
            {
                return vpsProtocol;
            }
            set
            {
                this.vpsProtocol = value;
            }
        }

        public TransactionType TransactionType
        {
            get
            {
                return transactionType;
            }
            set
            {
                this.transactionType = value;
            }
        }

        public string Vendor
        {
            get
            {
                return vendor;
            }
            set
            {
                this.vendor = value;
            }
        }

        public string VendorTxCode
        {
            get
            {
                return vendorTxCode;
            }
            set
            {
                this.vendorTxCode = value;
            }
        }
        public decimal Amount
        {
            get
            {
                return amount;
            }
            set
            {
                this.amount = value;
            }
        }
        public string Currency
        {
            get
            {
                return currency;
            }
            set
            {
                this.currency = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                this.description = value;
            }
        }
        public string CardHolder
        {
            get
            {
                return cardHolder;
            }
            set
            {
                this.cardHolder = value;
            }
        }
        public string CardNumber
        {
            get
            {
                return cardNumber;
            }
            set
            {
                this.cardNumber = value;
            }
        }
        public string StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                this.startDate = value;
            }
        }
        public string ExpiryDate
        {
            get
            {
                return expiryDate;
            }
            set
            {
                this.expiryDate = value;
            }
        }
        public string IssueNumber
        {
            get
            {
                return issueNumber;
            }
            set
            {
                this.issueNumber = value;
            }
        }
        public string Cv2
        {
            get
            {
                return cv2;
            }
            set
            {
                this.cv2 = value;
            }
        }
        public CardType CardType
        {
            get
            {
                return cardType;
            }
            set
            {
                this.cardType = value;
            }
        }
        public string BillingSurname
        {
            get
            {
                return billingSurname;
            }
            set
            {
                this.billingSurname = value;
            }
        }
        public string BillingFirstnames
        {
            get
            {
                return billingFirstnames;
            }
            set
            {
                this.billingFirstnames = value;
            }
        }
        public string BillingAddress1
        {
            get
            {
                return billingAddress1;
            }
            set
            {
                this.billingAddress1 = value;
            }
        }
        public string BillingAddress2
        {
            get
            {
                return billingAddress2;
            }
            set
            {
                this.billingAddress2 = value;
            }
        }
        public string BillingCity
        {
            get
            {
                return billingCity;
            }
            set
            {
                this.billingCity = value;
            }
        }
        public string BillingPostCode
        {
            get
            {
                return billingPostCode;
            }
            set
            {
                this.billingPostCode = value;
            }
        }
        public string BillingCountry
        {
            get
            {
                return billingCountry;
            }
            set
            {
                this.billingCountry = value;
            }
        }
        public string BillingState
        {
            get
            {
                return billingState;
            }
            set
            {
                this.billingState = value;
            }
        }
        public string BillingPhone
        {
            get
            {
                return billingPhone;
            }
            set
            {
                this.billingPhone = value;
            }
        }
        public string DeliverySurname
        {
            get
            {
                return deliverySurname;
            }
            set
            {
                this.deliverySurname = value;
            }
        }
        public string DeliveryFirstnames
        {
            get
            {
                return deliveryFirstnames;
            }
            set
            {
                this.deliveryFirstnames = value;
            }
        }
        public string DeliveryAddress1
        {
            get
            {
                return deliveryAddress1;
            }
            set
            {
                this.deliveryAddress1 = value;
            }
        }
        public string DeliveryAddress2
        {
            get
            {
                return deliveryAddress2;
            }
            set
            {
                this.deliveryAddress2 = value;
            }
        }
        public string DeliveryCity
        {
            get
            {
                return deliveryCity;
            }
            set
            {
                this.deliveryCity = value;
            }
        }
        public string DeliveryPostCode
        {
            get
            {
                return deliveryPostCode;
            }
            set
            {
                this.deliveryPostCode = value;
            }
        }
        public string DeliveryCountry
        {
            get
            {
                return deliveryCountry;
            }
            set
            {
                this.deliveryCountry = value;
            }
        }
        public string DeliveryState
        {
            get
            {
                return deliveryState;
            }
            set
            {
                this.deliveryState = value;
            }
        }
        public string DeliveryPhone
        {
            get
            {
                return deliveryPhone;
            }
            set
            {
                this.deliveryPhone = value;
            }
        }
        public string PayPalCallbackUrl
        {
            get
            {
                return payPalCallbackUrl;
            }
            set
            {
                this.payPalCallbackUrl = value;
            }
        }
        public string CustomerEmail
        {
            get
            {
                return customerEmail;
            }
            set
            {
                this.customerEmail = value;
            }
        }
        public string Basket
        {
            get
            {
                return basket;
            }
            set
            {
                this.basket = value;
            }
        }
        public string GiftAidPayment
        {
            get
            {
                return giftAidPayment;
            }
            set
            {
                this.giftAidPayment = value;
            }
        }
        public int ApplyAvsCv2
        {
            get
            {
                return applyAvsCv2;
            }
            set
            {
                this.applyAvsCv2 = value;
            }
        }

        public string ClientIpAddress
        {
            get
            {
                return clientIpAddress;
            }
            set
            {
                this.clientIpAddress = value;
            }
        }

        public int Apply3dSecure
        {
            get
            {
                return apply3dSecure;
            }
            set
            {
                this.apply3dSecure = value;
            }
        }

        public string AccountType
        {
            get
            {
                return accountType;
            }
            set
            {
                this.accountType = value;
            }
        }

        public string BillingAgreement
        {
            get
            {
                return billingAgreement;
            }
            set
            {
                this.billingAgreement = value;
            }
        }

        public ResponseStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                this.status = value;
            }
        }

        public string StatusDetail
        {
            get
            {
                return statusDetail;
            }
            set
            {
                this.statusDetail = value;
            }
        }

        public string VpsTxId
        {
            get
            {
                return vpsTxId;
            }
            set
            {
                this.vpsTxId = value;
            }
        }

        public string SecurityKey
        {
            get
            {
                return securityKey;
            }
            set
            {
                this.securityKey = value;
            }
        }

        public int TxAuthNo
        {
            get
            {
                return txAuthNo;
            }
            set
            {
                this.txAuthNo = value;
            }
        }

        public string AvsCv2
        {
            get
            {
                return avsCv2;
            }
            set
            {
                this.avsCv2 = value;
            }
        }


        public string Cavv
        {
            get
            {
                return cavv;
            }
            set
            {
                this.cavv = value;
            }
        }

        public string Md
        {
            get
            {
                return md;
            }
            set
            {
                this.md = value;
            }
        }

        public string AcsUrl
        {
            get
            {
                return acsUrl;
            }
            set
            {
                this.acsUrl = value;
            }
        }

        public string PaReq
        {
            get
            {
                return paReq;
            }
            set
            {
                this.paReq = value;
            }
        }

        public string PaRes
        {
            get
            {
                return paRes;
            }
            set
            {
                this.paRes = value;
            }
        }

        public string PayPalRedirectUrl
        {
            get
            {
                return payPalRedirectUrl;
            }
            set
            {
                this.payPalRedirectUrl = value;
            }
        }

        public string AddressStatus
        {
            get
            {
                return addressStatus;
            }
            set
            {
                this.addressStatus = value;
            }
        }

        public string PayerStatus
        {
            get
            {
                return payerStatus;
            }
            set
            {
                this.payerStatus = value;
            }
        }

        public string PayerId
        {
            get
            {
                return payerId;
            }
            set
            {
                this.payerId = value;
            }
        }

        public string Accept
        {
            get
            {
                return accept;
            }
            set
            {
                this.accept = value;
            }
        }

        public string Crypt
        {
            get
            {
                return crypt;
            }
            set
            {
                this.crypt = value;
            }
        }

        public string SuccessUrl
        {
            get
            {
                return successUrl;
            }
            set
            {
                this.successUrl = value;
            }
        }

        public string FailureUrl
        {
            get
            {
                return failureUrl;
            }
            set
            {
                this.failureUrl = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                this.customerName = value;
            }
        }

        public string VendorEmail
        {
            get
            {
                return vendorEmail;
            }
            set
            {
                this.vendorEmail = value;
            }
        }


        public string EmailMessage
        {
            get
            {
                return emailMessage;
            }
            set
            {
                this.emailMessage = value;
            }
        }

        public int AllowGiftAid
        {
            get
            {
                return allowGiftAid;
            }
            set
            {
                this.allowGiftAid = value;
            }
        }

        public string Last4Digits
        {
            get
            {
                return last4Digits;
            }
            set
            {
                this.last4Digits = value;
            }
        }

        public string RelatedVpsTxId
        {
            get
            {
                return relatedVpsTxId;
            }
            set
            {
                this.relatedVpsTxId = value;
            }
        }

        public string RelatedVendorTxCode
        {
            get
            {
                return relatedVendorTxCode;
            }
            set
            {
                this.relatedVendorTxCode = value;
            }
        }

        public string RelatedSecurityKey
        {
            get
            {
                return relatedSecurityKey;
            }
            set
            {
                this.relatedSecurityKey = value;
            }
        }

        public int RelatedTxAuthNo
        {
            get
            {
                return relatedTxAuthNo;
            }
            set
            {
                this.relatedTxAuthNo = value;
            }
        }

        //@Override
        public int SendEmail
        {
            get
            {
                return sendEmail;
            }

            set
            {
                this.sendEmail = value;
            }
        }

        //@Override
        public string ReferrerId
        {
            get
            {
                return referrerId;
            }

            set
            {
                referrerId = value;
            }
        }

        //@Override
        public string NotificationUrl
        {
            get
            {
                return notificationUrl;
            }

            set
            {
                this.notificationUrl = value;
            }
        }

        //@Override
        public string Profile
        {
            get
            {
                return profile;
            }

            set
            {
                this.profile = value;
            }
        }

        //@Override
        public string NextUrl
        {
            get
            {
                return nextUrl;
            }

            set
            {
                this.nextUrl = value;
            }
        }

        //@Override
        public decimal ReleaseAmount
        {
            get
            {
                return releaseAmount;
            }

            //@Override
            set
            {
                this.releaseAmount = value;
            }
        }

        //@Override
        public int GiftAid
        {
            get
            {
                return giftAid;
            }

            set
            {
                this.giftAid = value;
            }
        }

        //@Override
        public string VpsSignature
        {
            get
            {
                return vpsSignature;
            }

            set
            {
                this.vpsSignature = value;
            }
        }

        public CheckResult AddressResult
        {
            get
            {
                return addressResult;
            }

            set
            {
                this.addressResult = value;
            }
        }

        public CheckResult PostCodeResult
        {
            get
            {
                return postCodeResult;
            }

            set
            {
                this.postCodeResult = value;
            }
        }

        public CheckResult Cv2Result
        {
            get
            {
                return cv2Result;
            }

            set
            {
                this.cv2Result = value;
            }
        }

        public ThreeDSecureStatus ThreeDSecureStatus
        {
            get
            {
                return threeDSecureStatus;
            }

            set
            {
                this.threeDSecureStatus = value;
            }
        }

        public string RedirectUrl
        {
            get
            {
                return redirectUrl;
            }

            set
            {
                this.redirectUrl = value;
            }
        }

        public string Token
        {
            get
            {
                return token;
            }

            set
            {
                this.token = value;
            }
        }

        public string SurchargeXml
        {
            get
            {
                return surchargeXml;
            }

            set
            {
                this.surchargeXml = value;
            }
        }

        public int CreateToken
        {
            get
            {
                return createToken;
            }

            set
            {
                this.createToken = value;
            }
        }

        public string BasketXml
        {
            get
            {
                return basketXml;
            }

            set
            {
                this.basketXml = value;
            }
        }

        public decimal? Surcharge
        {
            get
            {
                return surcharge;
            }

            set
            {
                this.surcharge = value;
            }
        }

        public string DeclineCode
        {
            get
            {
                return declineCode;
            }

            set
            {
                this.declineCode = value;
            }
        }

        public string BankAuthCode
        {
            get
            {
                return bankAuthCode;
            }

            set
            {
                this.bankAuthCode = value;
            }
        }

        public FraudResponse FraudResponse
        {
            get
            {
                return fraudResponse;
            }

            set
            {
                this.fraudResponse = value;
            }
        }

        public string VendorData
        {
            get
            {
                return vendorData;
            }

            set
            {
                this.vendorData = value;
            }
        }

        public string CustomerXml
        {
            get
            {
                return customerXml;
            }

            set
            {
                this.customerXml = value;
            }
        }

        public int StoreToken
        {
            get
            {
                return storeToken;
            }

            set
            {
                this.storeToken = value;
            }
        }


    }
}