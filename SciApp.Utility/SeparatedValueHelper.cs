using System;

namespace SciApp.Utility
{
    public static class SeparatedValueHelper
    {
        private static readonly string[] EmptyArray = new string[0];
        public static string[] SpaceSeparatedToArray(this string separatedValue)
        {
            if (string.IsNullOrEmpty(separatedValue))
            {
                return EmptyArray;
            }

            return separatedValue.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string ArrayToSpaceSeparated(this string[] stringArray)
        {
            if(stringArray ==null || stringArray.Length == 0)
            {
                return string.Empty;
            }
           return string.Join(" ", stringArray);
        }



    }
}