namespace SagePay.IntegrationKit.Messages
{
    public interface ICaptureResult : IPaymentResult
    {
        int TxAuthNo { get; set; }
        string AvsCv2 { get; set; }
        CheckResult AddressResult { get; set; }
        CheckResult PostCodeResult { get; set; }
        CheckResult Cv2Result { get; set; }

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