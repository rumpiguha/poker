using PokerGame.Enum;
using PokerGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Services
{
    public class DeciderHighCard : RankDecider
    {
        public DeciderHighCard() : base((int)Combination.HighCard)
        {
        }

        public override RankDecision Decide(Hand hand)
        {
            return new RankDecision(true, base.rank, hand.Cards.Skip(4).Take(1).ToList(), hand.Cards.Take(4).ToList());
        }
    }
}
