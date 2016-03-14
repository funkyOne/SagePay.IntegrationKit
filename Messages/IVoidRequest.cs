using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{

    public interface IVoidRequest : IMessage
    {

        ProtocolVersion VpsProtocol { get; set; }

        TransactionType TransactionType { get; set; }

        string Vendor { get; set; }

        string VendorTxCode { get; set; }

        string VpsTxId { get; set; }

        string SecurityKey { get; set; }

        int TxAuthNo { get; set; }

    }
}