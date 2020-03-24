using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PokerGame.Helpers
{
    public static class EnumExtension
    {
        /// <summary>
        /// Gets the value of the description attribute of an enum
        /// </summary>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static string GetDescription(this System.Enum value)
        {
            return value
                     .GetType()
                     .GetMember(value.ToString())
                     .FirstOrDefault()
                     ?.GetCustomAttribute<DescriptionAttribute>()
                     ?.Description ?? value.ToString();
        }
    }
}
