using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ConsoleBlackjack.GameLogic.EnumExtensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetValues<T>() => Enum.GetValues(typeof(T)).Cast<T>();

        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
                return attributes.First().Description;

            return value.ToString();
        }
    }
}
