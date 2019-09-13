﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleBlackjack.GameLogic.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
