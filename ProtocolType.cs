using System;
using System.Reflection;

namespace SagePay.IntegrationKit
{
    public enum ProtocolType
    {
        [ProtocolTypeAttr(ApiRegex.VPSPROTOCOL, 3, 4)]
        VPSPROTOCOL,
        [ProtocolTypeAttr(typeof(ResponseStatus))]
        STATUS,
        [ProtocolTypeAttr(typeof(TransactionType))]
        TRANSACTION_TYPE,
        [ProtocolTypeAttr(typeof(CheckResult))]
        CHECK_RESULT,
        [ProtocolTypeAttr(typeof(ThreeDSecureStatus))]
        THREE_D_SECURE_STATUS,
        [ProtocolTypeAttr(ApiRegex.GUID, 36, 38)]
        GUID,
        [ProtocolTypeAttr(ApiRegex.VENDORTXCODE, 1, 40)]
        VENDORTXCODE,
        [ProtocolTypeAttr(ApiRegex.VENDOR, 1, 15)]
        VENDOR,
        [ProtocolTypeAttr(ApiRegex.SECURITY_KEY)]
        SECURITY_KEY,
        [ProtocolTypeAttr(ApiRegex.TX_AUTH_NO, 1, 12)]
        TX_AUTH_NO,
        [ProtocolTypeAttr(ApiRegex.APPLY_FLAGS, 1, 1)]
        APPLY_FLAGS,
        [ProtocolTypeAttr(ApiRegex.ZERO_OR_ONE, 1, 1)]
        ZERO_OR_ONE,
        [ProtocolTypeAttr(ApiRegex.DESCRIPTION, 1, 100)]
        DESCRIPTION,
        [ProtocolTypeAttr(ApiRegex.BASKET, 1, 7500)]
        BASKET,
        [ProtocolTypeAttr(ApiRegex.ANY, 1, 20000)]
        BASKET_XML,
        [ProtocolTypeAttr(ApiRegex.ANY, 1, 2000)]
        CUSTOMER_XML,
        [ProtocolTypeAttr(ApiRegex.BASE64, 1, 7500)]
        PA_RES,
        [ProtocolTypeAttr(ApiRegex.CUSTOMER_NAME, 1, 100)]
        CUSTOMER_NAME, // could be a business name?
        [ProtocolTypeAttr(ApiRegex.EMAIL_MESSAGE, 1, 7500)]
        EMAIL_MESSAGE, // should be allowed to contain HTML?
        [ProtocolTypeAttr(ApiRegex.EMAIL, 1, 255)]
        EMAIL,
        [ProtocolTypeAttr(ApiRegex.PHONE, 1, 20)]
        PHONE,
        [ProtocolTypeAttr(ApiRegex.SEND_EMAIL, 1, 1)]
        SEND_EMAIL,
        [ProtocolTypeAttr(ApiRegex.DECLINE_CODE, 2, 2)]
        DECLINE_CODE,
        [ProtocolTypeAttr(ApiRegex.BANK_AUTH_CODE, 6, 6)]
        BANK_AUTH_CODE,
        [ProtocolTypeAttr(typeof(CardType))]
        CARD_TYPE,
        [ProtocolTypeAttr(ApiRegex.CARD_NUMBER, 12, 20)]
        CARD_NUMBER,
        [ProtocolTypeAttr(ApiRegex.CARD_DATE, 4, 4)]
        CARD_DATE,
        [ProtocolTypeAttr(ApiRegex.CARD_ISSUE_NUMBER, 1, 2)]
        CARD_ISSUE_NUMBER,
        [ProtocolTypeAttr(ApiRegex.CARD_CV2, 3, 4)]
        CARD_CV2,
        [ProtocolTypeAttr(ApiRegex.LAST_4_DIGITS, 4, 4)]
        LAST_4_DIGITS,
        [ProtocolTypeAttr(ApiRegex.CAVV, 1, 32)]
        CAVV,
        [ProtocolTypeAttr(ApiRegex.ADDRESS_LINE, 1, 100)]
        ADDRESS_LINE,
        [ProtocolTypeAttr(ApiRegex.ADDRESS_CITY, 1, 40)]
        ADDRESS_CITY,
        [ProtocolTypeAttr(ApiRegex.POSTCODE, 1, 10)]
        POSTCODE,
        [ProtocolTypeAttr(ApiRegex.COUNTRY, 2, 2)]
        COUNTRY,
        [ProtocolTypeAttr(ApiRegex.US_STATE, 2, 2)]
        US_STATE,
        [ProtocolTypeAttr(ApiRegex.CAPS, 1, 100)]
        VPS_SIGNATURE,
        [ProtocolTypeAttr(ApiRegex.CRYPT)]
        CRYPT,
        [ProtocolTypeAttr(ApiRegex.AMOUNT, 1, 10)]
        AMOUNT,
        [ProtocolTypeAttr(ApiRegex.CURRENCY, 3, 3)]
        CURRENCY,
        [ProtocolTypeAttr(typeof(FraudResponse))]
        FRAUD_RESPONSE,
        [ProtocolTypeAttr(ApiRegex.WEB_URL, 1, 7500)]
        WEB_URL,
        [ProtocolTypeAttr(ApiRegex.IP4, 1, 15)]
        IP4,
        [ProtocolTypeAttr(ApiRegex.CAPS, 1, 255)]
        CAPS,
        [ProtocolTypeAttr(ApiRegex.ANY, 1, 255)]
        STRING255,
        [ProtocolTypeAttr(ApiRegex.ANY, 1, 800)]
        STRING800,
        [ProtocolTypeAttr(ApiRegex.ANY, 1, 7500)]
        LARGE,
        [ProtocolTypeAttr(ApiRegex.ALPHA_NUMERIC, 1, 40)]
        VENDOR_DATA,
        [ProtocolTypeAttr(ApiRegex.ANY, 1, 15)]
        PAY_PAL_PAYER_ID,
        [ProtocolTypeAttr(ApiRegex.ANY, 1, 15)]
        DOB,
        [ProtocolTypeAttr(ApiRegex.ANY, 1, 40)]
        REFERRER_ID
    }


    class ProtocolTypeAttr : Attribute
    {
        internal ProtocolTypeAttr(ApiRegex apiRegex, int minLength = 0, int maxLength = 0)
        {
            this.ApiRegex = apiRegex;
            this.MinLength = minLength;
            this.MaxLength = maxLength;

        }

        internal ProtocolTypeAttr(Type type)
        {
            this.Type = type;
        }

        public ApiRegex ApiRegex { get; private set; }
        public int MinLength { get; private set; }
        public int MaxLength { get; private set; }
        public Type Type { get; private set; }
    }

    public static class ProtocolTypeExtension
    {
        public static ApiRegex ApiRegex(this ProtocolType p)
        {
            return ((ProtocolTypeAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolTypeAttr))).ApiRegex;
        }

        public static int MinLength(this ProtocolType p)
        {
            return ((ProtocolTypeAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolTypeAttr))).MinLength;
        }

        public static int MaxLength(this ProtocolType p)
        {
            return ((ProtocolTypeAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolTypeAttr))).MaxLength;
        }

        public static Type Type(this ProtocolType p)
        {
            return ((ProtocolTypeAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolTypeAttr))).Type;
        }

        private static MemberInfo ForValue(ProtocolType p)
        {
            return typeof(ProtocolType).GetField(Enum.GetName(typeof(ProtocolType), p));
        }
    }
}