using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{

    public interface IDirectTokenRegisterRequest : IMessage
    {

        ProtocolVersion VpsProtocol { get; set; }

        TransactionType TransactionType { get; set; }

        string Vendor { get; set; }

        /* why is currency needed here? */
        string Currency { get; set; }

        string CardHolder { get; set; }

        string CardNumber { get; set; }

        string StartDate { get; set; }

        string ExpiryDate { get; set; }

        string IssueNumber { get; set; }

        string Cv2 { get; set; }

        CardType CardType { get; set; }
    }
}