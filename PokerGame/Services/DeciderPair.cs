using PokerGame.Enum;
using PokerGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Services
{
    public class DeciderPair : RankDecider
    {
        public DeciderPair() : base((int)Combination.Pair)
        {
        }

        public override RankDecision Decide(Hand hand)
        {
            if (hand.Cards.Select(x => x.cardValue).Distinct().Count() > 4)
            {
                return new RankDecision(false);
            }

            //Get all cards with same value
            var groupCards = hand.Cards.GroupBy(p => p.cardValue).OrderByDescending(g => g.Count());

            var winningCards = groupCards.First().ToList();
            if (groupCards.Count() == 4 && winningCards.Count() == 2)
            {
                var nonWinningCards = groupCards.Skip(1).SelectMany(c => c).ToList();
                return new RankDecision(true, base.rank, winningCards, nonWinningCards);
            }
            return new RankDecision(false);
        }
    }
}
