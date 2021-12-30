using System;
using System.Text.RegularExpressions;


namespace DevHelper
{

    public static class Helper
    {

        public static string ToUpperFirstChar(this string data)
        {
            data = Regex.Replace(data.ToLower(), @"\b[a-zа-яё]", m => m.Value.ToUpper());
            return data;
        }

    }

}
