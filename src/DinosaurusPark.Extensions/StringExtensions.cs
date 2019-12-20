using System;
using System.Linq;

namespace DinosaurusPark.Extensions
{
    public static class StringExtensions
    {
        public static string FirstUp(this string input)
        {
            return input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString().ToUpper() + input.Substring(1).ToLower()
            };
        }
    }
}
