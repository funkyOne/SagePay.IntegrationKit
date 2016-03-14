using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{

    public interface IDirectTokenResult : IBasicResult
    {

        string Token { get; set; }

        /* why is this needed? */
        TransactionType TransactionType { get; set; }

    }
}