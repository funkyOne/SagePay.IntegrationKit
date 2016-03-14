using System;

namespace SagePay.IntegrationKit
{
    internal class ProtocolMessageAttribute : Attribute
    {
        public ProtocolField[] Required { get; set; }
        public ProtocolField[] Optional { get; set; }

        public ProtocolMessageAttribute(ProtocolField[] required, ProtocolField[] optional)
        {
            Required = required;
            Optional = optional;
        }

        public ProtocolMessageAttribute(ProtocolField[] required)
        {
            Required = required;
        }
    }
}