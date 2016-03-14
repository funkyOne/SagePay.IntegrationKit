namespace SagePay.IntegrationKit.Messages
{
    public interface IDirectPayment : IPayment
    {
        CardType CardType { get; set; }
        string CardHolder { get; set; }
        string CardNumber { get; set; }
        string StartDate { get; set; }
        string ExpiryDate { get; set; }
        string IssueNumber { get; set; }
        string Cv2 { get; set; }
        string Token { get; set; }
        int StoreToken { get; set; }
        string PayPalCallbackUrl { get; set; }
        string GiftAidPayment { get; set; }
        string ClientIpAddress { get; set; }
        string AccountType { get; set; }
    }
}