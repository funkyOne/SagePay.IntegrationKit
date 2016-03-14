using System;
using System.Reflection;

namespace SagePay.IntegrationKit
{
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