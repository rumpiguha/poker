using PokerGame.Enum;
using PokerGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Services
{
    public class DeciderThreeofaKind : RankDecider
    {
        public DeciderThreeofaKind() : base((int)Combination.ThreeofaKind)
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

            if (groupCards.Any(g1 => g1.Count() == 3))
            {
                var nonWinningCards = groupCards.Skip(1).SelectMany(c => c).ToList();
                return new RankDecision(true, base.rank, groupCards.FirstOrDefault().ToList(), nonWinningCards);
            }
            return new RankDecision(false);
        }
    }
}
