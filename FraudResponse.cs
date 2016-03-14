namespace SagePay.IntegrationKit
{
    public enum FraudResponse
    {
        NONE,
        ACCEPT, 
        DENY, 
        CHALLENGE, 
        NOTCHECKED,
        TIMEOUT
    }
}