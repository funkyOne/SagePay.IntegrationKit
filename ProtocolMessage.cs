namespace SagePay.IntegrationKit
{
    public enum ProtocolMessage
    {
        // FORM_PAYMENT_CRYPT
        [ProtocolMessageAttribute(new ProtocolField[] { 
            ProtocolField.VPS_PROTOCOL, 
            ProtocolField.TRANSACTION_TYPE, 
            ProtocolField.VENDOR, 
            ProtocolField.CRYPT })]
        FORM_PAYMENT_CRYPT,

        //FORM_PAYMENT
        //Required fields
        [ProtocolMessageAttribute(new ProtocolField[] {			
                    ProtocolField.VPS_PROTOCOL,
			        ProtocolField.TRANSACTION_TYPE,
			        ProtocolField.VENDOR,
			        ProtocolField.VENDOR_TX_CODE,
			        ProtocolField.AMOUNT,
			        ProtocolField.CURRENCY,
			        ProtocolField.DESCRIPTION,
			        ProtocolField.SUCCESS_URL,
			        ProtocolField.FAILURE_URL,
			        ProtocolField.BILLING_SURNAME,
			        ProtocolField.BILLING_FIRSTNAMES,
			        ProtocolField.BILLING_ADDRESS1,
			        ProtocolField.BILLING_CITY,
			        ProtocolField.BILLING_COUNTRY,
			        ProtocolField.DELIVERY_SURNAME,
			        ProtocolField.DELIVERY_FIRSTNAMES,
			        ProtocolField.DELIVERY_ADDRESS1,
			        ProtocolField.DELIVERY_CITY,
			        ProtocolField.DELIVERY_COUNTRY },
                new ProtocolField[] {
		// Optional Fields
                    ProtocolField.CRYPT,
			        ProtocolField.CUSTOMER_NAME,
			        ProtocolField.CUSTOMER_EMAIL,
			        ProtocolField.VENDOR_EMAIL,
			        ProtocolField.SEND_EMAIL,
			        ProtocolField.EMAIL_MESSAGE,
			        ProtocolField.BILLING_ADDRESS2,
			        ProtocolField.BILLING_POST_CODE,
			        ProtocolField.BILLING_STATE,
			        ProtocolField.BILLING_PHONE,
			        ProtocolField.DELIVERY_ADDRESS2,
			        ProtocolField.DELIVERY_POST_CODE,
			        ProtocolField.DELIVERY_STATE,
			        ProtocolField.DELIVERY_PHONE,
			        ProtocolField.BASKET,
			        ProtocolField.ALLOW_GIFT_AID,
			        ProtocolField.APPLY_AVS_CV2,
			        ProtocolField.APPLY_3D_SECURE,
			        ProtocolField.BILLING_AGREEMENT,
                    ProtocolField.REFERRER_ID, 
                    ProtocolField.BASKET_XML, 
                    ProtocolField.CUSTOMER_XML, 
                    ProtocolField.SURCHARGE_XML, 
                    ProtocolField.VENDOR_DATA, 

                    ProtocolField.FI_RECIPIENT_ACCOUNT_NUMBER,  // for 6012 merchant code only
                    ProtocolField.FI_RECIPIENT_DATE_OF_BIRTH,   // for 6012 merchant code only
                    ProtocolField.FI_RECIPIENT_POST_CODE,       // for 6012 merchant code only
                    ProtocolField.FI_RECIPIENT_SURNAME,         // for 6012 merchant code only
        })]
        FORM_PAYMENT,

        //FORM_PAYMENT_RESULT
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.STATUS
		            },
                new ProtocolField[] {
            ProtocolField.STATUS_DETAIL,
            ProtocolField.VPS_TX_ID,
            ProtocolField.TX_AUTH_NO,
            ProtocolField.AVS_CV2,
            ProtocolField.ADDRESS_RESULT,
            ProtocolField.POST_CODE_RESULT,
            ProtocolField.CV2_RESULT,
            ProtocolField.THREE_D_SECURE_STATUS,
            ProtocolField.CAVV,
            ProtocolField.ADDRESS_STATUS,
            ProtocolField.PAYER_STATUS,
            ProtocolField.AMOUNT,
            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.GIFT_AID,
            ProtocolField.CARD_TYPE,
            ProtocolField.LAST_4_DIGITS,
            ProtocolField.EXPIRY_DATE, 
            ProtocolField.FRAUD_RESPONSE, 
            ProtocolField.DECLINE_CODE, 
            ProtocolField.BANK_AUTH_CODE, 
            ProtocolField.SURCHARGE, 
            ProtocolField.TOKEN 
		            })]
        FORM_PAYMENT_RESULT,

        //SERVER_PAYMENT
        //Required fields
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR,

            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.AMOUNT,
            ProtocolField.CURRENCY,
            ProtocolField.DESCRIPTION,
            ProtocolField.NOTIFICATION_URL,
            ProtocolField.BILLING_SURNAME,
            ProtocolField.BILLING_FIRSTNAMES,
            ProtocolField.BILLING_ADDRESS1,
            ProtocolField.BILLING_CITY,
            ProtocolField.BILLING_COUNTRY,

            ProtocolField.DELIVERY_SURNAME,
            ProtocolField.DELIVERY_FIRSTNAMES,
            ProtocolField.DELIVERY_ADDRESS1,
            ProtocolField.DELIVERY_CITY,
            ProtocolField.DELIVERY_COUNTRY
		            },
                        new ProtocolField[] {
        //Optional fields
            ProtocolField.CUSTOMER_EMAIL,
            ProtocolField.TOKEN,
            ProtocolField.STORE_TOKEN,
            ProtocolField.BILLING_ADDRESS2,
            ProtocolField.BILLING_POST_CODE,
            ProtocolField.BILLING_STATE,
            ProtocolField.BILLING_PHONE,
            ProtocolField.DELIVERY_ADDRESS2,
            ProtocolField.DELIVERY_POST_CODE,
            ProtocolField.DELIVERY_STATE,
            ProtocolField.DELIVERY_PHONE,
            ProtocolField.BASKET,
            ProtocolField.ALLOW_GIFT_AID,
            ProtocolField.APPLY_AVS_CV2,
            ProtocolField.APPLY_3D_SECURE,
            ProtocolField.BILLING_AGREEMENT,
            ProtocolField.REFERRER_ID,
            ProtocolField.PROFILE,
            ProtocolField.ACCOUNT_TYPE,
            ProtocolField.VENDOR_DATA, 
            ProtocolField.CREATE_TOKEN, 
            ProtocolField.SURCHARGE_XML, 
            ProtocolField.BASKET_XML, 
            ProtocolField.CUSTOMER_XML, 

            ProtocolField.FI_RECIPIENT_ACCOUNT_NUMBER,  // for 6012 merchant code only
            ProtocolField.FI_RECIPIENT_DATE_OF_BIRTH,   // for 6012 merchant code only
            ProtocolField.FI_RECIPIENT_POST_CODE,       // for 6012 merchant code only
            ProtocolField.FI_RECIPIENT_SURNAME,         // for 6012 merchant code only

		            })]
        SERVER_PAYMENT,

        //SERVER_PAYMENT_RESULT
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.STATUS
            },
                new ProtocolField[] {
            ProtocolField.STATUS_DETAIL,
            ProtocolField.VPS_TX_ID,
            ProtocolField.SECURITY_KEY,
            ProtocolField.NEXT_URL
            }
                )]
        SERVER_PAYMENT_RESULT,

        //SERVER_PAYMENT_NOTIFICATION_REQUEST
        //Required fields
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.STATUS
            },
                new ProtocolField[] {
        //Optional Fields
            ProtocolField.VPS_TX_ID,
            ProtocolField.STATUS_DETAIL,
            ProtocolField.TX_AUTH_NO,
            ProtocolField.AVS_CV2,
            ProtocolField.ADDRESS_RESULT,
            ProtocolField.POST_CODE_RESULT,
            ProtocolField.CV2_RESULT,
            ProtocolField.GIFT_AID,
            ProtocolField.THREE_D_SECURE_STATUS,
            ProtocolField.CAVV,
            ProtocolField.ADDRESS_STATUS,
            ProtocolField.PAYER_STATUS,
            ProtocolField.CARD_TYPE,
            ProtocolField.LAST_4_DIGITS,
            ProtocolField.EXPIRY_DATE, 
            ProtocolField.TOKEN, 
            ProtocolField.FRAUD_RESPONSE, 
            ProtocolField.DECLINE_CODE, 
            ProtocolField.BANK_AUTH_CODE, 
            ProtocolField.SURCHARGE, 
            ProtocolField.VPS_SIGNATURE
            })]
        SERVER_PAYMENT_NOTIFICATION_REQUEST,

        //SERVER_PAYMENT_NOTIFICATION_RESULT
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.STATUS
            },
                new ProtocolField[] {
            ProtocolField.REDIRECT_URL,
            ProtocolField.STATUS_DETAIL
            })]
        SERVER_PAYMENT_NOTIFICATION_RESULT,

        //SERVER_TOKEN_REGISTER
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR,

            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.CURRENCY,
            ProtocolField.NOTIFICATION_URL
            },
                new ProtocolField[] {
            ProtocolField.PROFILE
            })]
        SERVER_TOKEN_REGISTER,

        //SERVER_TOKEN_REGISTER_RESULT
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.STATUS
            },
                new ProtocolField[] {
            ProtocolField.STATUS_DETAIL,
            ProtocolField.VPS_TX_ID,
            ProtocolField.SECURITY_KEY,
            ProtocolField.NEXT_URL
            }
                )]
        SERVER_TOKEN_REGISTER_RESULT,

        //SERVER_TOKEN_NOTIFICATION_REQUEST
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.STATUS
            },
                new ProtocolField[] {
            ProtocolField.TOKEN,
            ProtocolField.VPS_TX_ID,
            ProtocolField.STATUS_DETAIL,
            ProtocolField.CARD_TYPE,
            ProtocolField.LAST_4_DIGITS,
            ProtocolField.EXPIRY_DATE,
            ProtocolField.VPS_SIGNATURE
            }
                )]
        SERVER_TOKEN_NOTIFICATION_REQUEST,

        //SERVER_TOKEN_NOTIFICATION_RESULT
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.	STATUS
            },
                new ProtocolField[] {
            ProtocolField.REDIRECT_URL,
            ProtocolField.STATUS_DETAIL
            }
                )]
        SERVER_TOKEN_NOTIFICATION_RESULT,

        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR,
            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.AMOUNT,
            ProtocolField.CURRENCY,
            ProtocolField.DESCRIPTION
            },
                new ProtocolField[] {
            ProtocolField.CARD_TYPE,
            ProtocolField.BASKET,
            ProtocolField.CARD_HOLDER,
            ProtocolField.CARD_NUMBER,
            ProtocolField.BILLING_SURNAME,
            ProtocolField.BILLING_FIRSTNAMES,
            ProtocolField.BILLING_ADDRESS1,
            ProtocolField.BILLING_CITY,
            ProtocolField.BILLING_POST_CODE,
            ProtocolField.BILLING_COUNTRY,
            ProtocolField.BILLING_PHONE,
            ProtocolField.DELIVERY_SURNAME,
            ProtocolField.DELIVERY_FIRSTNAMES,
            ProtocolField.DELIVERY_ADDRESS1,
            ProtocolField.DELIVERY_CITY,
            ProtocolField.DELIVERY_POST_CODE,
            ProtocolField.DELIVERY_COUNTRY,
            ProtocolField.DELIVERY_PHONE,
            ProtocolField.EXPIRY_DATE,
            ProtocolField.START_DATE,
            ProtocolField.ISSUE_NUMBER,
            ProtocolField.CV2,
            ProtocolField.TOKEN,
            ProtocolField.STORE_TOKEN,
            ProtocolField.PAY_PAL_CALLBACK_URL,
            ProtocolField.BILLING_ADDRESS2,
            ProtocolField.BILLING_STATE,
            ProtocolField.DELIVERY_ADDRESS2,
            ProtocolField.DELIVERY_STATE,
            ProtocolField.CUSTOMER_EMAIL,
            ProtocolField.GIFT_AID_PAYMENT,
            ProtocolField.APPLY_AVS_CV2,
            ProtocolField.APPLY_3D_SECURE,
            ProtocolField.CLIENT_IP_ADDRESS,
            ProtocolField.BILLING_AGREEMENT,
            ProtocolField.REFERRER_ID,
            ProtocolField.ACCOUNT_TYPE,
            ProtocolField.SURCHARGE_XML, 
            ProtocolField.BASKET_XML, 
            ProtocolField.CUSTOMER_XML, 
            ProtocolField.VENDOR_DATA, 
            ProtocolField.CREATE_TOKEN, 

            ProtocolField.FI_RECIPIENT_ACCOUNT_NUMBER,  // for 6012 merchant code only
            ProtocolField.FI_RECIPIENT_DATE_OF_BIRTH,   // for 6012 merchant code only
            ProtocolField.FI_RECIPIENT_POST_CODE,       // for 6012 merchant code only
            ProtocolField.FI_RECIPIENT_SURNAME,         // for 6012 merchant code only

            }
                )]
        DIRECT_PAYMENT,
        //Required fields
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR,
            ProtocolField.CURRENCY,
            ProtocolField.CARD_HOLDER,
            ProtocolField.CARD_NUMBER,
            ProtocolField.EXPIRY_DATE,
            ProtocolField.CV2,
            ProtocolField.CARD_TYPE
            },
        //Optional fields
                new ProtocolField[] {
            ProtocolField.START_DATE,
            ProtocolField.ISSUE_NUMBER
            }
                )]
        DIRECT_TOKEN_REGISTER,
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.STATUS,
            ProtocolField.TRANSACTION_TYPE
            },
                new ProtocolField[] {
            ProtocolField.STATUS_DETAIL,
            ProtocolField.TOKEN
            }
                )]
        DIRECT_TOKEN_RESULT,


        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.STATUS
            },
                new ProtocolField[] {
            ProtocolField.STATUS_DETAIL,
            ProtocolField.VPS_TX_ID,
            ProtocolField.ADDRESS_STATUS,
            ProtocolField.PAYER_STATUS,
            ProtocolField.DELIVERY_SURNAME,
            ProtocolField.DELIVERY_FIRSTNAMES,
            ProtocolField.DELIVERY_ADDRESS1,
            ProtocolField.DELIVERY_ADDRESS2,
            ProtocolField.DELIVERY_CITY,
            ProtocolField.DELIVERY_POST_CODE,
            ProtocolField.DELIVERY_COUNTRY,
            ProtocolField.DELIVERY_STATE,
            ProtocolField.DELIVERY_PHONE,
            ProtocolField.PAYER_ID, 
            ProtocolField.CUSTOMER_EMAIL
            })]
        PAYPAL_NOTIFICATION_REQUEST,


        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.MD,
            ProtocolField.PA_RES
            })]
        THREE_D_AUTH_REQUEST,


        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VPS_TX_ID,
            ProtocolField.AMOUNT,
            ProtocolField.ACCEPT
            })]
        PAY_PAL_COMPLETE_REQUEST,

        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.STATUS
            },
                new ProtocolField[] {
            ProtocolField.STATUS_DETAIL,
            ProtocolField.VPS_TX_ID,
            ProtocolField.SECURITY_KEY,
            ProtocolField.TX_AUTH_NO,
            ProtocolField.AVS_CV2,
            ProtocolField.ADDRESS_RESULT,
            ProtocolField.POST_CODE_RESULT,
            ProtocolField.CV2_RESULT,
            ProtocolField.THREE_D_SECURE_STATUS,
            ProtocolField.CAVV,
            ProtocolField.PAY_PAL_REDIRECT_URL,

            ProtocolField.MD,
            ProtocolField.ACS_URL,
            ProtocolField.PA_REQ,
            ProtocolField.EXPIRY_DATE, 
            ProtocolField.FRAUD_RESPONSE, 
            ProtocolField.DECLINE_CODE, 
            ProtocolField.BANK_AUTH_CODE, 
            ProtocolField.TOKEN, 
            ProtocolField.SURCHARGE 
            })]
        DIRECT_PAYMENT_RESULT,


        //-------------------------------------------------------------------------
        // SHARED
        //-------------------------------------------------------------------------
        [ProtocolMessageAttribute(
               new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.STATUS,
            ProtocolField.STATUS_DETAIL
            }
               )]
        BASIC_RESULT,

        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR,
            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.VPS_TX_ID,
            ProtocolField.SECURITY_KEY,
            ProtocolField.TX_AUTH_NO,
            ProtocolField.RELEASE_AMOUNT
            }
                )]
        RELEASE_REQUEST,

        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR,
            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.VPS_TX_ID,
            ProtocolField.SECURITY_KEY,
            ProtocolField.TX_AUTH_NO
            }
                )]
        ABORT_REQUEST,
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR,
            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.AMOUNT,
            ProtocolField.CURRENCY,
            ProtocolField.DESCRIPTION,
            ProtocolField.RELATED_VPS_TX_ID,
            ProtocolField.RELATED_VENDOR_TX_CODE,
            ProtocolField.RELATED_SECURITY_KEY
            },
                new ProtocolField[] {
            ProtocolField.RELATED_TX_AUTH_NO
            }
                )]
        REFUND_REQUEST,
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.STATUS
            },
                new ProtocolField[] {
            ProtocolField.STATUS_DETAIL,
            ProtocolField.VPS_TX_ID,
            ProtocolField.TX_AUTH_NO,
            ProtocolField.SECURITY_KEY,
            ProtocolField.FRAUD_RESPONSE
            }
                )]
        REFUND_RESULT,
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR,
            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.AMOUNT,
            ProtocolField.CURRENCY,
            ProtocolField.DESCRIPTION,
            ProtocolField.RELATED_VPS_TX_ID,
            ProtocolField.RELATED_VENDOR_TX_CODE,
            ProtocolField.RELATED_SECURITY_KEY,
            ProtocolField.RELATED_TX_AUTH_NO
            },
                new ProtocolField[] {
            ProtocolField.CV2
            }
                )]
        REPEAT_REQUEST,
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.STATUS
            },
                new ProtocolField[] {
            ProtocolField.STATUS_DETAIL,
            ProtocolField.VPS_TX_ID,
            ProtocolField.TX_AUTH_NO,
            ProtocolField.SECURITY_KEY,
            ProtocolField.AVS_CV2,
            ProtocolField.ADDRESS_RESULT,
            ProtocolField.POST_CODE_RESULT,
            ProtocolField.CV2_RESULT,
            ProtocolField.EXPIRY_DATE,
            ProtocolField.FRAUD_RESPONSE,
            ProtocolField.DECLINE_CODE,
            ProtocolField.BANK_AUTH_CODE,
            ProtocolField.SURCHARGE, 
            ProtocolField.TOKEN 
            })]
        CAPTURE_RESULT, // Used for repeat & authorise
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR,
            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.VPS_TX_ID,
            ProtocolField.SECURITY_KEY,
            ProtocolField.TX_AUTH_NO
            })]
        VOID_REQUEST,      

        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR,
            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.AMOUNT,
            ProtocolField.DESCRIPTION,
            ProtocolField.RELATED_VPS_TX_ID,
            ProtocolField.RELATED_VENDOR_TX_CODE,
            ProtocolField.RELATED_SECURITY_KEY
            },
                new ProtocolField[] {
            ProtocolField.APPLY_AVS_CV2
            })]
        AUTHORISE_REQUEST,

        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.STATUS
            },
                new ProtocolField[] {
            ProtocolField.STATUS_DETAIL,
            ProtocolField.VPS_TX_ID,
            ProtocolField.TX_AUTH_NO,
            ProtocolField.SECURITY_KEY,
            ProtocolField.AVS_CV2,
            ProtocolField.ADDRESS_RESULT,
            ProtocolField.POST_CODE_RESULT,
            ProtocolField.CV2_RESULT
            })]
        AUTHORISE_RESULT,
        [ProtocolMessageAttribute(
                new ProtocolField[] {	
            ProtocolField.VPS_PROTOCOL,
            ProtocolField.TRANSACTION_TYPE,
            ProtocolField.VENDOR,
            ProtocolField.VENDOR_TX_CODE,
            ProtocolField.VPS_TX_ID,
            ProtocolField.SECURITY_KEY
            })]
        CANCEL_REQUEST
    }
}
