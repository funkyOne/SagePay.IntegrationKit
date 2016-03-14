using System;

namespace SagePay.IntegrationKit
{
    internal class ProtocolVersionAttr : Attribute
    {
        internal ProtocolVersionAttr(string versionString, int versionInt)
        {
            VersionString = versionString;
            VersionInt = versionInt;

        }
        public string VersionString { get; private set; }
        public int VersionInt { get; private set; }
    }
}