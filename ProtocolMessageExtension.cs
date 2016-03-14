using System;
using System.Reflection;

namespace SagePay.IntegrationKit
{
    public static class ProtocolMessageExtension
    {
        public static ProtocolField[] Required(this ProtocolMessage p)
        {
            return ((ProtocolMessageAttribute)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolMessageAttribute))).Required;
        }

        public static ProtocolField[] Optional(this ProtocolMessage p)
        {
            return ((ProtocolMessageAttribute)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolMessageAttribute))).Optional;
        }

        private static MemberInfo ForValue(ProtocolMessage p)
        {
            return typeof(ProtocolMessage).GetField(Enum.GetName(typeof(ProtocolMessage), p));
        }
    }
}