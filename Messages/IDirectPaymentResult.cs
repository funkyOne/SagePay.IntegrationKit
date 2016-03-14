using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{

    public interface IDirectPaymentResult : ICaptureResult
    {

        string Cavv { get; set; }

        ThreeDSecureStatus ThreeDSecureStatus { get; set; }

        string Md { get; set; }

        string AcsUrl { get; set; }

        string PaReq { get; set; }

        string PayPalRedirectUrl { get; set; }

    }
}