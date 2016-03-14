using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{

    public interface IServerTokenNotificationResult : IMessage
    {

        ResponseStatus Status { get; set; }

        string StatusDetail { get; set; }

        string RedirectUrl { get; set; }

    }


}