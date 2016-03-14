using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{

    public interface IAuthoriseRequest : IMessage
    {

        ProtocolVersion VpsProtocol { get; set; }

        TransactionType TransactionType { get; set; }

        string Vendor { get; set; }

        string VendorTxCode { get; set; }

        string RelatedVendorTxCode { get; set; }

        string RelatedVpsTxId { get; set; }

        string RelatedSecurityKey { get; set; }

        decimal Amount { get; set; }

        string Description { get; set; }

        int ApplyAvsCv2 { get; set; }

    }
}