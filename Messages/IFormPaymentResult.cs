using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{

    public interface IFormPaymentResult : IPaymentStatusResult
    {
        decimal Amount { get; set; }
    }

}
