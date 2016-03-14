using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{

    public interface IServerPaymentResult : IPaymentResult
    {

        string NextUrl { get; set; }

    }

}