namespace SagePay.IntegrationKit.Messages
{
    public interface IFormPaymentEncrypted : IMessage
    {
        ProtocolVersion VpsProtocol{ get; set;}
        TransactionType TransactionType { get; set; }
        string Vendor { get; set; }
        string Crypt { get; set; }
    }
}
