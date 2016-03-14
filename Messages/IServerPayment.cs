using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{

    public interface IServerPayment : IPayment
    {

        string NotificationUrl { get; set; }

        int AllowGiftAid { get; set; }

        string Profile { get; set; }

        string AccountType { get; set; }

        string Token { get; set; }

        int StoreToken { get; set; }
    }

}