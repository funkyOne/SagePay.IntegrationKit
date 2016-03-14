using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{
    public interface IPaymentResult : IBasicResult
    {
        string VpsTxId { get; set; }
        string SecurityKey { get; set; }
    }
}
