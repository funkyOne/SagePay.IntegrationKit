using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{

    public interface IRefundResult : IBasicResult
    {
        string VpsTxId { get; set; }

        int TxAuthNo { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        string SecurityKey { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        FraudResponse FraudResponse { get; set; }

    }
}