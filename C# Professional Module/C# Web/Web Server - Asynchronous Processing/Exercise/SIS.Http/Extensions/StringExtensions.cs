namespace SIS.Http.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static string Capitalize(this string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                throw new ArgumentException($"{nameof(result)} cannot be null");
            }

            return char.ToUpper(result[0]) + result.Substring(1).ToLower();
        }
    }
}