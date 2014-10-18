using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ilwar.Giregi
{
    static class Util
    {
        public static string RegexReplace(this string text, string pattern, string newValue)
        {
            return Regex.Replace(text, pattern, newValue);
        }
    }
}
