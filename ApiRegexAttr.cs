using System;

namespace SagePay.IntegrationKit
{
    internal class ApiRegexAttr : Attribute
    {
        internal ApiRegexAttr(string pattern)
        {
            Pattern = pattern;
        }

        public string Pattern { get; }
    }
}