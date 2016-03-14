namespace SagePay.IntegrationKit.Messages
{
    public interface IPaymentStatusResult : IBasicResult
    {
        string VpsTxId { get; set; }

        /** Same as sent by client server for original payment. */
        string VendorTxCode { get; set; }
        int TxAuthNo { get; set; }
        string AvsCv2 { get; set; }

        CheckResult AddressResult { get; set; }
        CheckResult PostCodeResult { get; set; }
        CheckResult Cv2Result { get; set; }

        /** 
         * 0 = The Gift Aid box was not checked for this transaction
         * 1 = The user checked the Gift Aid box on the payment page
         */
        int GiftAid { get; set; }

        ThreeDSecureStatus ThreeDSecureStatus { get; set; }

        string Cavv { get; set; }

        string AddressStatus { get; set; }
        string PayerStatus { get; set; }
        CardType CardType { get; set; }
        string Last4Digits { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        string ExpiryDate { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        string Token { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        FraudResponse FraudResponse { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        string DeclineCode { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        string BankAuthCode { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        decimal? Surcharge { get; set; }

    }
}
