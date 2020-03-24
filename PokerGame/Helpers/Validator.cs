using PokerGame.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Helpers
{
    public static class Validator
    {
        public static string GetErrorMessage(string[] input)
        {
            if (input.Length != 10 || input.Any(x => string.IsNullOrEmpty(x)))
            {
                return "Please enter exactly 10 cards.";
            }
            else if (input.Length != input.Distinct().Count())
            {
                return "Please enter unique cards.";
            }
            else
            {
                var cardDict = CardValue.CardValueDict;
                foreach (var item in input)
                {
                    if (string.IsNullOrEmpty(item) ||
                        item.Length != 2 ||
                        !cardDict.ContainsKey(item[0].ToString()) ||
                        !System.Enum.IsDefined(typeof(Suit), item[1].ToString().ToUpper()))
                    {
                        return "Please enter valid cards.";
                    }
                }
            }

            return null;
        }

    }
}
