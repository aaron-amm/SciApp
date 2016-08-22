using System.Text.RegularExpressions;

namespace SciApp.Utility.Test
{
    public static class StringHelper
    {
        public static string RemoveNewLine(this string input)
        {
            //return Regex.Replace(input, pattern, string.Empty);
            const string pattern = @"^.*(\r\n?|\n)$";
            var regex = new Regex(pattern,RegexOptions.Multiline);
            return regex.Replace(input,string.Empty);
        }
    }
}