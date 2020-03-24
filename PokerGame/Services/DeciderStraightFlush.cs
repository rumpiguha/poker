using PokerGame.Enum;
using PokerGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Services
{
    public class DeciderStraightFlush : RankDecider
    {
        public DeciderStraightFlush() : base((int)Combination.StraightFlush)
        {
        }

        public override RankDecision Decide(Hand hand)
        {
            if (!hand.IsAllSameSuit)
                return new RankDecision(false);

            //Check if all cards are of consecutive value -- straight flush
            bool isConsecutive = !hand.Cards.Select((i, j) => i.cardValue - j).Distinct().Skip(1).Any();

            return isConsecutive ? new RankDecision(true, base.rank, hand.Cards, new List<Card>()) : new RankDecision(false);
        }
    }
}
