using System;
using System.Reflection;
namespace SagePay.IntegrationKit
{
    class ApiRegexAttr : Attribute
    {
        internal ApiRegexAttr(string pattern)
        {
            this.Pattern = pattern;
        }
        public string Pattern { get; private set; }
    }

    public static class ApiRegexExtension
    {
        public static string Pattern(this ApiRegex p)
        {
            return ((ApiRegexAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ApiRegexAttr))).Pattern;
        }

        private static MemberInfo ForValue(ApiRegex p)
        {
            return typeof(ApiRegex).GetField(Enum.GetName(typeof(ApiRegex), p));
        }
    }


    public enum ApiRegex
    {
        [ApiRegexAttr("\\d\\.\\d{2}")]
        VPSPROTOCOL,
        [ApiRegexAttr(".{1,40}")]
        VENDORTXCODE,
        [ApiRegexAttr(".{1,16}")]
        VENDOR, 
        [ApiRegexAttr("[a-zA-Z0-9]{10}")]
        SECURITY_KEY,
        [ApiRegexAttr("\\d{1,10}")]
        TX_AUTH_NO,
        [ApiRegexAttr("[0123]")]
        APPLY_FLAGS,
        [ApiRegexAttr("[01]")]
        ZERO_OR_ONE,
        [ApiRegexAttr(".{0,100}")]
        DESCRIPTION,
        [ApiRegexAttr(".{0,7500}")]
        BASKET,
        [ApiRegexAttr("@[A-F0-9]+")]
        CRYPT,
        [ApiRegexAttr("\\d+(\\.\\d{1,2})?")]
        AMOUNT,
        [ApiRegexAttr(".*")] 
        CUSTOMER_NAME,
        [ApiRegexAttr(".*")] 
        EMAIL_MESSAGE,
        [ApiRegexAttr("[012]")]
        SEND_EMAIL,
        [ApiRegexAttr("[0-9]{2}")]
        DECLINE_CODE,
        [ApiRegexAttr("[0-9A-Z]{2,6}")]
        BANK_AUTH_CODE,
        [ApiRegexAttr("[0-9]{12,20}")]
        CARD_NUMBER,
        [ApiRegexAttr("\\d{4}")]
        CARD_DATE,
        //CARD_DATE(".*"),
        [ApiRegexAttr("\\d{1,2}")]
        CARD_ISSUE_NUMBER,
        [ApiRegexAttr("\\d{3,4}")]
        CARD_CV2,
        [ApiRegexAttr("\\d{4}")]
        LAST_4_DIGITS,
        [ApiRegexAttr(".{0,32}")]
        CAVV,
        [ApiRegexAttr(".*")] 
        ADDRESS_LINE,
        [ApiRegexAttr(".*")] 
        ADDRESS_CITY,
        [ApiRegexAttr("([a-zA-Z\\d\\s\\-]{1,10})")]
        POSTCODE,
        [ApiRegexAttr("[A-Z]{2}")]
        US_STATE,
        [ApiRegexAttr("[A-Z]{2}")]
        COUNTRY,
        [ApiRegexAttr("[A-Z]{3}")]
        CURRENCY,
        [ApiRegexAttr("[a-zA-Z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+(?:[a-zA-Z]{2,4})\\b")]
        EMAIL,
        [ApiRegexAttr("^{?[A-Za-z0-9]{8}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{12}}?$")]
        GUID,
        [ApiRegexAttr("[\\d\\+\\(]([0-9\\-\\s\\(\\)\\+]{1,19})")]
        PHONE,
        [ApiRegexAttr("(http|https):\\/\\/(\\w+:{0,1}\\w*@)?(\\S+)(:[0-9]+)?(\\/|\\/([\\w#!:.?+=&%@!\\-\\/]))?")]
        WEB_URL,
        [ApiRegexAttr("[A-Z_ 0-9]+")]
        CAPS,
        [ApiRegexAttr("(\\d{1,3}\\.){3}\\d{1,3}")]
        IP4,
        [ApiRegexAttr("[a-zA-Z0-9=\\/\\+\\!\\-]+")]
        BASE64,
        [ApiRegexAttr("[a-zA-Z0-9]+")]
        ALPHA_NUMERIC,
        [ApiRegexAttr(".*")]
        ANY,

        // Below are regexes for internal fields
        [ApiRegexAttr(".{1,100}")]
        VENDOR_PROVIDED_NAME
    }
}