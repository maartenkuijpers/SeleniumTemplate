using System;
using System.Linq;
using static System.String;

namespace SeleniumTestTemplate.Extensions
{
    public static class StringExtension
    {
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        public static string GenerateAlphaNumeric(this string value, int length)
        {
            return Generate(length, true, true, true);
        }

        public static string GenerateAlpha(this string value, int length)
        {
            return Generate(length, true, true, false);
        }

        public static string GenerateNumeric(this string value, int length)
        {
            return Generate(length, false, false, true);
        }

        private static string Generate(int length, bool includeLowercase, bool includeUppercase, bool includeDigits)
        {
            var chars = Empty;
            if (includeLowercase) chars += "abcdefghijklmnopqrstuvwxyz";
            if (includeUppercase) chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (includeDigits) chars += "1234567890";
            if (IsNullOrEmpty(chars))
                return Empty;
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
