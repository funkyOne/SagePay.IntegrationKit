using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{

    public interface IServerTokenRegisterRequest : IMessage
    {

        ProtocolVersion VpsProtocol { get; set; }

        TransactionType TransactionType { get; set; }

        string Vendor { get; set; }

        string Currency { get; set; }

        string NotificationUrl { get; set; }

        string Profile { get; set; }

        string VendorTxCode { get; set; }
    }

}