using PokerGame.Enum;
using PokerGame.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PokerGame.Helpers
{
    public class Registry
    {
        public static ArrayList Deciders { get; }

        static Registry()
        {
            Deciders = new ArrayList
            {
                new DeciderRoyalFlush(),
                new DeciderStraightFlush(),
                new DeciderFourofaKind(),
                new DeciderFullHouse(),
                new DeciderFlush(),
                new DeciderStraight(),
                new DeciderThreeofaKind(),
                new DeciderTwoPairs(),
                new DeciderPair(),
                new DeciderHighCard()
            };
        }
    }
}
