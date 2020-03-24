using PokerGame.Enum;
using PokerGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Services
{
    public class DeciderFlush : RankDecider
    {
        public DeciderFlush() : base((int)Combination.Flush)
        {
        }

        public override RankDecision Decide(Hand hand)
        {
            if (!hand.IsAllSameSuit)
                return new RankDecision(false);

            return new RankDecision(true, base.rank, hand.Cards, new List<Card>());
        }
    }
}
