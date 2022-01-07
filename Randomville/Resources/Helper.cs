using System;
using System.Text.RegularExpressions;


namespace Helper
{

    public static class ExtensionMethodsSet
    {

        public static string ToUpperFirstChar(this string data)
        {
            data = Regex.Replace(data.ToLower(), @"\b[a-zа-яё]", m => m.Value.ToUpper());
            return data;
        }

    }

}