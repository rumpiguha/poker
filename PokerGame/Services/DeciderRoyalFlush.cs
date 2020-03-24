using PokerGame.Enum;
using PokerGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Services
{
    public class DeciderRoyalFlush : RankDecider
    {
        public DeciderRoyalFlush() : base((int)Combination.RoyalFlush)
        {
        }

        public override RankDecision Decide(Hand hand)
        {
            if (!hand.IsAllSameSuit || hand.Cards.Any(x => x.cardValue < 10))
            {
                return new RankDecision(false);
            }

            return new RankDecision(true, base.rank, hand.Cards, new List<Card>());
        }
    }
}
