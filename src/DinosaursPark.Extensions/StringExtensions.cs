using System;
using System.Linq;

#pragma warning disable SA1122
namespace DinosaursPark.Extensions
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
#pragma warning restore SA1122
