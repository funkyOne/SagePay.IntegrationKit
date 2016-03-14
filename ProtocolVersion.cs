using System;
using System.Reflection;
namespace SagePay.IntegrationKit
{
    public enum ProtocolVersion
    {
        [ProtocolVersionAttr("2.23", 233)]
        V_223,
        [ProtocolVersionAttr("3.00", 300)]
        V_300
    }

    class ProtocolVersionAttr : Attribute
    {
        internal ProtocolVersionAttr(string versionString, int versionInt)
        {
            this.VersionString = versionString;
            this.VersionInt = versionInt;

        }
        public string VersionString { get; private set; }
        public int VersionInt { get; private set; }
    }

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