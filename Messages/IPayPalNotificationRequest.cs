using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{

    public interface IPayPalNotificationRequest : IBasicResult
    {

        string VpsTxId { get; set; }

        string PayerStatus { get; set; }

        string AddressStatus { get; set; }

        string CustomerEmail { get; set; }

        string PayerId { get; set; }

        string DeliverySurname { get; set; }

        string DeliveryFirstnames { get; set; }

        string DeliveryAddress1 { get; set; }

        string DeliveryAddress2 { get; set; }

        string DeliveryCity { get; set; }

        string DeliveryPostCode { get; set; }

        string DeliveryCountry { get; set; }

        string DeliveryState { get; set; }

        string DeliveryPhone { get; set; }

    }
}