namespace SagePay.IntegrationKit.Messages
{
    public interface IPayPalCompleteRequest : IMessage
    {
        ProtocolVersion VpsProtocol { get; set; }
        TransactionType TransactionType { get; set; }
        string VpsTxId { get; set; }
        decimal Amount { get; set; }
        string Accept { get; set; }
    }
}