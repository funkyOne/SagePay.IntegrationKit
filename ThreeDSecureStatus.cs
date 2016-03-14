namespace SagePay.IntegrationKit
{
    public enum ThreeDSecureStatus
    {
        NONE,
        OK,
        NOAUTH,
        CANTAUTH,
        NOTAUTHED,
        ATTEMPTONLY,
        NOTCHECKED,
        INCOMPLETE,
        MALFORMED,
        INVALID,
        ERROR
    }
}