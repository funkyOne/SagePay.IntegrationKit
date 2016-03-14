using System;
using System.Reflection;

namespace SagePay.IntegrationKit
{
    public static class ProtocolVersionExtension
    {
        public static string VersionString(this ProtocolVersion p)
        {
            return ((ProtocolVersionAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolVersionAttr))).VersionString;
        }

        public static int VersionInt(this ProtocolVersion p)
        {
            return ((ProtocolVersionAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ProtocolVersionAttr))).VersionInt;
        }

        private static MemberInfo ForValue(ProtocolVersion p)
        {
            return typeof(ProtocolVersion).GetField(Enum.GetName(typeof(ProtocolVersion), p));
        }
    }
}