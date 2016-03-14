namespace SagePay.IntegrationKit.Messages
{
    public interface ITokenRemoveRequest : IMessage
    {
        ProtocolVersion VpsProtocol { get; set; }
        TransactionType TransactionType { get; set; }
        string Vendor { get; set; }
        string Token { get; set; }
    }
}