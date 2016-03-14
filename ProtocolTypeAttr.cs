using System;

namespace SagePay.IntegrationKit
{
    internal class ProtocolTypeAttr : Attribute
    {
        internal ProtocolTypeAttr(ApiRegex apiRegex, int minLength = 0, int maxLength = 0)
        {
            ApiRegex = apiRegex;
            MinLength = minLength;
            MaxLength = maxLength;

        }

        internal ProtocolTypeAttr(Type type)
        {
            Type = type;
        }

        public ApiRegex ApiRegex { get; private set; }
        public int MinLength { get; private set; }
        public int MaxLength { get; private set; }
        public Type Type { get; private set; }
    }
}