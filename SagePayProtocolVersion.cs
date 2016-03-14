using System;

namespace SagePay.IntegrationKit
{
    public class SagePayProtocolVersion : Attribute
    {
        internal SagePayProtocolVersion(ProtocolVersion min)
        {
            Min = min;
        }

        public ProtocolVersion Min { get; private set; }
    }
}