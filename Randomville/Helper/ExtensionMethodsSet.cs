using System;
using System.Text.RegularExpressions;


namespace Helper
{

    internal static class ExtensionMethodsSet
    {

        internal static string ToUpperFirstChar(this string data)
        {
            return Regex.Replace(data.ToLower(), @"\b[a-zа-яё]", m => m.Value.ToUpper());
        }

    }

}