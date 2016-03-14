using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{
    public interface IBasicResult : IMessage
    {
        ProtocolVersion VpsProtocol { get; set; }
        ResponseStatus Status{ get; set; }
        string StatusDetail{ get; set; }

    }
}