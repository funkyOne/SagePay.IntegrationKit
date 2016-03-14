namespace SagePay.IntegrationKit.Messages
{
    public interface IServerTokenNotificationRequest : IBasicResult
    {
        TransactionType TransactionType { get; set; }
        string VendorTxCode { get; set; }
        string VpsTxId { get; set; }
        string Token { get; set; }
        CardType CardType { get; set; }
        string Last4Digits { get; set; }
        string ExpiryDate { get; set; }
        string VpsSignature { get; set; }
    }
}