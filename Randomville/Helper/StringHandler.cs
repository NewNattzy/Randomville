using System;
using System.Text.RegularExpressions;


namespace Helper
{

    public static class StringHandler
    {

        internal static string ToUpperFirstChar(this string data)
        {
            return Regex.Replace(data.ToLower(), @"\b[a-zа-яё]", m => m.Value.ToUpper());
        }

    }

}