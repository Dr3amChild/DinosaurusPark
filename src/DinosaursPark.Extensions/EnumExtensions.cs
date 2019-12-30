using System;
using System.ComponentModel;
using System.Linq;

namespace DinosaursPark.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var et = value.GetType();
            var name = Enum.GetName(et, value);

            var result = et.GetField(name)
                    ?.GetCustomAttributes(false)
                    .OfType<DescriptionAttribute>()
                    .FirstOrDefault()
                    ?.Description;

            return result;
        }
    }
}
