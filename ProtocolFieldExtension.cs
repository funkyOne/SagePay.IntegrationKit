using System;
using System.Reflection;

namespace SagePay.IntegrationKit
{
    public static class ProtocolFieldExtension
    {
        public static string CanonicalName(this ProtocolField p)
        {
            return ((ProtocolFieldAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolFieldAttr))).CanonicalName;
        }

        public static ProtocolType DataType(this ProtocolField p)
        {
            return ((ProtocolFieldAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolFieldAttr))).DataType;
        }

        private static MemberInfo ForValue(ProtocolField p)
        {
            return typeof(ProtocolField).GetField(Enum.GetName(typeof(ProtocolField), p));
        }
    }
}