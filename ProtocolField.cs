namespace SagePay.IntegrationKit
{
    public enum ProtocolField
    {
        [ProtocolFieldAttr("VPSProtocol", ProtocolType.VPSPROTOCOL)]
        VPS_PROTOCOL,
        [ProtocolFieldAttr("Status", ProtocolType.STATUS)]
        STATUS,
        [ProtocolFieldAttr("StatusDetail", ProtocolType.STRING255)]
        STATUS_DETAIL,
        [ProtocolFieldAttr("TxType", ProtocolType.TRANSACTION_TYPE)]
        TRANSACTION_TYPE,
        [ProtocolFieldAttr("Vendor", ProtocolType.VENDOR)]
        VENDOR,
        [ProtocolFieldAttr("VendorTxCode", ProtocolType.VENDORTXCODE)]
        VENDOR_TX_CODE,
        [ProtocolFieldAttr("Amount", ProtocolType.AMOUNT)]
        AMOUNT,
        [ProtocolFieldAttr("ReleaseAmount", ProtocolType.AMOUNT)]
        RELEASE_AMOUNT,
        [ProtocolFieldAttr("Currency", ProtocolType.CURRENCY)]
        CURRENCY,
        [ProtocolFieldAttr("Description", ProtocolType.DESCRIPTION)]
        DESCRIPTION,
        [ProtocolFieldAttr("CardHolder", ProtocolType.CUSTOMER_NAME)]
        CARD_HOLDER,
        [ProtocolFieldAttr("CardNumber", ProtocolType.CARD_NUMBER)]
        CARD_NUMBER,
        [ProtocolFieldAttr("StartDate", ProtocolType.CARD_DATE)]
        START_DATE,
        [ProtocolFieldAttr("ExpiryDate", ProtocolType.CARD_DATE)]
        EXPIRY_DATE,
        [ProtocolFieldAttr("BillingFirstnames", ProtocolType.CUSTOMER_NAME)]
        BILLING_FIRSTNAMES,
        [ProtocolFieldAttr("BillingSurname", ProtocolType.CUSTOMER_NAME)]
        BILLING_SURNAME,
        [ProtocolFieldAttr("BillingAddress1", ProtocolType.ADDRESS_LINE)]
        BILLING_ADDRESS1,
        [ProtocolFieldAttr("BillingAddress2", ProtocolType.ADDRESS_LINE)]
        BILLING_ADDRESS2,
        [ProtocolFieldAttr("BillingCity", ProtocolType.ADDRESS_CITY)]
        BILLING_CITY,
        [ProtocolFieldAttr("BillingState", ProtocolType.US_STATE)]
        BILLING_STATE,
        [ProtocolFieldAttr("BillingCountry", ProtocolType.COUNTRY)]
        BILLING_COUNTRY,
        [ProtocolFieldAttr("BillingPostCode", ProtocolType.POSTCODE)]
        BILLING_POST_CODE,
        [ProtocolFieldAttr("BillingPhone", ProtocolType.PHONE)]
        BILLING_PHONE,
        [ProtocolFieldAttr("CV2", ProtocolType.CARD_CV2)]
        CV2,
        [ProtocolFieldAttr("CardType", ProtocolType.CARD_TYPE)]
        CARD_TYPE,
        [ProtocolFieldAttr("DeliveryFirstnames", ProtocolType.CUSTOMER_NAME)]
        DELIVERY_FIRSTNAMES,
        [ProtocolFieldAttr("DeliverySurname", ProtocolType.CUSTOMER_NAME)]
        DELIVERY_SURNAME,
        [ProtocolFieldAttr("DeliveryAddress1", ProtocolType.ADDRESS_LINE)]
        DELIVERY_ADDRESS1,
        [ProtocolFieldAttr("DeliveryAddress2", ProtocolType.ADDRESS_LINE)]
        DELIVERY_ADDRESS2,
        [ProtocolFieldAttr("DeliveryCity", ProtocolType.ADDRESS_CITY)]
        DELIVERY_CITY,
        [ProtocolFieldAttr("DeliveryState", ProtocolType.US_STATE)]
        DELIVERY_STATE,
        [ProtocolFieldAttr("DeliveryCountry", ProtocolType.COUNTRY)]
        DELIVERY_COUNTRY,
        [ProtocolFieldAttr("DeliveryPostCode", ProtocolType.POSTCODE)]
        DELIVERY_POST_CODE,
        [ProtocolFieldAttr("DeliveryPhone", ProtocolType.PHONE)]
        DELIVERY_PHONE,
        [ProtocolFieldAttr("IssueNumber", ProtocolType.CARD_ISSUE_NUMBER)]
        ISSUE_NUMBER,
        [ProtocolFieldAttr("Token", ProtocolType.GUID)]
        TOKEN,
        [ProtocolFieldAttr("StoreToken", ProtocolType.ZERO_OR_ONE)]
        STORE_TOKEN,
        [ProtocolFieldAttr("CreateToken", ProtocolType.ZERO_OR_ONE)]
        CREATE_TOKEN, // new for Proto3
        [ProtocolFieldAttr("SurchargeXML", ProtocolType.STRING800)]
        SURCHARGE_XML, // new for Proto3
        [ProtocolFieldAttr("Surcharge", ProtocolType.AMOUNT)]
        SURCHARGE, // new for Proto3
        [ProtocolFieldAttr("BasketXML", ProtocolType.BASKET_XML)]
        BASKET_XML, // new for Proto3
        [ProtocolFieldAttr("CustomerXML", ProtocolType.LARGE)]
        CUSTOMER_XML, // new for Proto3
        [ProtocolFieldAttr("VendorData", ProtocolType.VENDOR_DATA)]
        VENDOR_DATA, // new for Proto3

        [ProtocolFieldAttr("FraudResponse", ProtocolType.FRAUD_RESPONSE)]
        FRAUD_RESPONSE, // new for Proto3

        [ProtocolFieldAttr("MD", ProtocolType.STRING255)]
        MD,
        [ProtocolFieldAttr("PARes", ProtocolType.PA_RES)]
        PA_RES,
        [ProtocolFieldAttr("AccountType", ProtocolType.STRING255)]
        ACCOUNT_TYPE,
        [ProtocolFieldAttr("VPSTxId", ProtocolType.GUID)]
        VPS_TX_ID,
        [ProtocolFieldAttr("TxAuthNo", ProtocolType.TX_AUTH_NO)]
        TX_AUTH_NO,
        [ProtocolFieldAttr("SecurityKey", ProtocolType.SECURITY_KEY)]
        SECURITY_KEY,
        [ProtocolFieldAttr("3DSecureStatus", ProtocolType.THREE_D_SECURE_STATUS)]
        THREE_D_SECURE_STATUS,
        [ProtocolFieldAttr("PayPalCallbackURL", ProtocolType.WEB_URL)]
        PAY_PAL_CALLBACK_URL,
        [ProtocolFieldAttr("PayPalRedirectURL", ProtocolType.WEB_URL)]
        PAY_PAL_REDIRECT_URL,
        [ProtocolFieldAttr("ReferrerID", ProtocolType.REFERRER_ID)]
        REFERRER_ID,
        [ProtocolFieldAttr("NotificationURL", ProtocolType.WEB_URL)]
        NOTIFICATION_URL,
        [ProtocolFieldAttr("NextURL", ProtocolType.WEB_URL)]
        NEXT_URL,
        [ProtocolFieldAttr("AVSCV2", ProtocolType.CAPS)]
        AVS_CV2,
        [ProtocolFieldAttr("AddressResult", ProtocolType.CHECK_RESULT)]
        ADDRESS_RESULT,
        [ProtocolFieldAttr("PostCodeResult", ProtocolType.CHECK_RESULT)]
        POST_CODE_RESULT,
        [ProtocolFieldAttr("CV2Result", ProtocolType.CHECK_RESULT)]
        CV2_RESULT,

        // SERVER
        [ProtocolFieldAttr("RedirectURL", ProtocolType.WEB_URL)]
        REDIRECT_URL,
        [ProtocolFieldAttr("VPSSignature", ProtocolType.VPS_SIGNATURE)]
        VPS_SIGNATURE,

        // DIRECT
        [ProtocolFieldAttr("PAReq", ProtocolType.LARGE)]
        PA_REQ,
        [ProtocolFieldAttr("ACSURL", ProtocolType.WEB_URL)]
        ACS_URL,
        [ProtocolFieldAttr("Accept", ProtocolType.CAPS)]
        ACCEPT,
        [ProtocolFieldAttr("ClientIPAddress", ProtocolType.IP4)]
        CLIENT_IP_ADDRESS,
        [ProtocolFieldAttr("GiftAidPayment", ProtocolType.ZERO_OR_ONE)]
        GIFT_AID_PAYMENT,

        // FORM PROTOCOL 
        [ProtocolFieldAttr("Crypt", ProtocolType.CRYPT)]
        CRYPT,
        [ProtocolFieldAttr("SuccessURL", ProtocolType.WEB_URL)]
        SUCCESS_URL,
        [ProtocolFieldAttr("FailureURL", ProtocolType.WEB_URL)]
        FAILURE_URL,
        [ProtocolFieldAttr("CustomerName", ProtocolType.CUSTOMER_NAME)]
        CUSTOMER_NAME,
        [ProtocolFieldAttr("CustomerEMail", ProtocolType.EMAIL)]
        CUSTOMER_EMAIL,
        [ProtocolFieldAttr("VendorEMail", ProtocolType.EMAIL)]
        VENDOR_EMAIL, // supports multiple sep by ":" ??
        [ProtocolFieldAttr("SendEMail", ProtocolType.SEND_EMAIL)]
        SEND_EMAIL,
        [ProtocolFieldAttr("eMailMessage", ProtocolType.EMAIL_MESSAGE)]
        EMAIL_MESSAGE,
        [ProtocolFieldAttr("Basket", ProtocolType.BASKET)]
        BASKET,
        [ProtocolFieldAttr("AllowGiftAid", ProtocolType.ZERO_OR_ONE)]
        ALLOW_GIFT_AID,
        [ProtocolFieldAttr("ApplyAVSCV2", ProtocolType.APPLY_FLAGS)]
        APPLY_AVS_CV2,
        [ProtocolFieldAttr("Apply3DSecure", ProtocolType.APPLY_FLAGS)]
        APPLY_3D_SECURE,
        [ProtocolFieldAttr("BillingAgreement", ProtocolType.ZERO_OR_ONE)]
        BILLING_AGREEMENT,

        [ProtocolFieldAttr("GiftAid", ProtocolType.ZERO_OR_ONE)]
        GIFT_AID,
        [ProtocolFieldAttr("CAVV", ProtocolType.CAVV)]
        CAVV,
        [ProtocolFieldAttr("AddressStatus", ProtocolType.CAPS)]
        ADDRESS_STATUS,
        [ProtocolFieldAttr("PayerStatus", ProtocolType.CAPS)]
        PAYER_STATUS,
        [ProtocolFieldAttr("PayerID", ProtocolType.PAY_PAL_PAYER_ID)]
        PAYER_ID,
        [ProtocolFieldAttr("Profile", ProtocolType.CAPS)]
        PROFILE,
        [ProtocolFieldAttr("Last4Digits", ProtocolType.LAST_4_DIGITS)]
        LAST_4_DIGITS,

        // SHARED
        [ProtocolFieldAttr("DeclineCode", ProtocolType.DECLINE_CODE)]
        DECLINE_CODE,
        [ProtocolFieldAttr("BankAuthCode", ProtocolType.BANK_AUTH_CODE)]
        BANK_AUTH_CODE,

        [ProtocolFieldAttr("RelatedVPSTxId", ProtocolType.GUID)]
        RELATED_VPS_TX_ID,
        [ProtocolFieldAttr("RelatedVendorTxCode", ProtocolType.VENDORTXCODE)]
        RELATED_VENDOR_TX_CODE,
        [ProtocolFieldAttr("RelatedSecurityKey", ProtocolType.SECURITY_KEY)]
        RELATED_SECURITY_KEY,
        [ProtocolFieldAttr("RelatedTxAuthNo", ProtocolType.TX_AUTH_NO)]
        RELATED_TX_AUTH_NO,

        // MC-6012
        [ProtocolFieldAttr("FiRecipientAcctNumber", ProtocolType.STRING255)]
        FI_RECIPIENT_ACCOUNT_NUMBER,
        
        [ProtocolFieldAttr("FiRecipientDob", ProtocolType.DOB)]
        FI_RECIPIENT_DATE_OF_BIRTH,
        
        [ProtocolFieldAttr("FiRecipientPostCode", ProtocolType.POSTCODE)]
        FI_RECIPIENT_POST_CODE,

        [ProtocolFieldAttr("FiRecipientSurname", ProtocolType.CUSTOMER_NAME)]
        FI_RECIPIENT_SURNAME,
    }
}