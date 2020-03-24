using PokerGame.Enum;
using PokerGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Services
{
    public class DeciderTwoPairs : RankDecider
    {
        public DeciderTwoPairs() : base((int)Combination.TwoPairs)
        {
        }

        public override RankDecision Decide(Hand hand)
        {
            if (hand.Cards.Select(x => x.cardValue).Distinct().Count() > 3)
            {
                return new RankDecision(false);
            }

            //Get all cards with same value
            var groupCards = hand.Cards.GroupBy(p => p.cardValue).OrderByDescending(g => g.Count());

            var winningCards = groupCards.Take(2).SelectMany(c => c).ToList();
            if (groupCards.Count() == 3 && winningCards.Count() == 4)
            {
                var nonWinningCards = groupCards.Skip(2).SelectMany(c => c).ToList();
                return new RankDecision(true, base.rank, winningCards, nonWinningCards);
            }
            return new RankDecision(false);
        }
    }
}
