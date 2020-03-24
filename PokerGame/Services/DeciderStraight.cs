using PokerGame.Enum;
using PokerGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Services
{
    public class DeciderStraight : RankDecider
    {
        public DeciderStraight() : base((int)Combination.Straight)
        {
        }

        public override RankDecision Decide(Hand hand)
        {
            //Check if all cards are of consecutive value -- straight
            bool isConsecutive = !hand.Cards.Select((i, j) => i.cardValue - j).Distinct().Skip(1).Any();

            return isConsecutive ? new RankDecision(true, base.rank, hand.Cards, new List<Card>()) : new RankDecision(false);
        }
    }
}
