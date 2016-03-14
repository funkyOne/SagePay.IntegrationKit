namespace SagePay.IntegrationKit
{
    public enum ResponseStatus
    {
        OK,
        MALFORMED,
        INVALID,
        NOTAUTHED,
        REJECTED,
        PPREDIRECT,
        AUTHENTICATED,
        REGISTERED,
        ERROR,
        ABORT,
        PAYPALOK,
        THREEDAUTH,
        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        PENDING
    }
}