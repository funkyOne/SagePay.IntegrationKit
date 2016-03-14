namespace SagePay.IntegrationKit.Messages
{
    public interface IServerTokenRegisterResult : IPaymentResult
    {
        string NextUrl { get; set; }
    }
}