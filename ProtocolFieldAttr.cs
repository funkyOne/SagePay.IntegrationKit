using System;

namespace SagePay.IntegrationKit
{
    internal class ProtocolFieldAttr : Attribute
    {
        internal ProtocolFieldAttr(string canonicalName, ProtocolType dataType)
        {
            CanonicalName = canonicalName;
            DataType = dataType;
        }
        public string CanonicalName { get; private set; }
        public ProtocolType DataType { get; private set; }
    }
}