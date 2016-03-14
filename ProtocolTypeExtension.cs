using System;
using System.Reflection;

namespace SagePay.IntegrationKit
{
    public static class ProtocolTypeExtension
    {
        public static ApiRegex ApiRegex(this ProtocolType p)
        {
            return ((ProtocolTypeAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolTypeAttr))).ApiRegex;
        }

        public static int MinLength(this ProtocolType p)
        {
            return ((ProtocolTypeAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolTypeAttr))).MinLength;
        }

        public static int MaxLength(this ProtocolType p)
        {
            return ((ProtocolTypeAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolTypeAttr))).MaxLength;
        }

        public static Type Type(this ProtocolType p)
        {
            return ((ProtocolTypeAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolTypeAttr))).Type;
        }

        private static MemberInfo ForValue(ProtocolType p)
        {
            return typeof(ProtocolType).GetField(Enum.GetName(typeof(ProtocolType), p));
        }
    }
}