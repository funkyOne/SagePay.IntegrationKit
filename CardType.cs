using System;
using System.Reflection;
using SagePay.IntegrationKit.Messages;

namespace SagePay.IntegrationKit
{
    public enum CardType
    {
        NONE,
        VISA,
        MC,
        DELTA,
        MAESTRO,
        UKE,
        AMEX,
        DC,
        JCB,
        LASER,
        PAYPAL,
        SWITCH,
        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        PLCC,
        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        MCDEBIT,
        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        EPS,
        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        GIROPAY,
        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        IDEAL,
        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        SOFORT,
        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        ELV
    }

    public class SagePayProtocolVersion : Attribute
    {
        internal SagePayProtocolVersion(ProtocolVersion min)
        {
            this.Min = min;

        }

        public ProtocolVersion Min { get; private set; }
    }

    public static class SagePayProtocolVersionExtension
    {
        public static ProtocolVersion Min(this CardType p)
        {
            return ((SagePayProtocolVersion)Attribute.GetCustomAttribute(ForValue(p), typeof(SagePayProtocolVersion))).Min;
        }

        private static MemberInfo ForValue(CardType p)
        {
            return typeof(CardType).GetField(Enum.GetName(typeof(CardType), p));
        }

        public static ProtocolVersion Min(this DataObject p)
        {
            return ((SagePayProtocolVersion)Attribute.GetCustomAttribute(ForValue(p), typeof(SagePayProtocolVersion))).Min;
        }

        private static MemberInfo ForValue(DataObject p)
        {
            return typeof(DataObject).GetField(Enum.GetName(typeof(DataObject), p));
        }
    }
}