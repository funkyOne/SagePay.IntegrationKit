namespace SagePay.IntegrationKit.Messages
{
    public interface IFormPayment : IPayment
    {
        int AllowGiftAid { get; set; }
        string SuccessUrl { get; set; }
        string FailureUrl { get; set; }
        string CustomerName { get; set; }
        string VendorEmail { get; set; }
        int SendEmail { get; set; }
        string EmailMessage { get; set; }
        string Crypt { get; set; }
    }
}
