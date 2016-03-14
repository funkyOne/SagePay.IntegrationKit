using System;
using System.Reflection;

namespace SagePay.IntegrationKit
{
    public static class ApiRegexExtension
    {
        public static string Pattern(this ApiRegex p)
        {
            return ((ApiRegexAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ApiRegexAttr))).Pattern;
        }

        private static MemberInfo ForValue(ApiRegex p)
        {
            return typeof(ApiRegex).GetField(Enum.GetName(typeof(ApiRegex), p));
        }
    }
}