using PokerGame.Enum;
using PokerGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Services
{
    public class DeciderFourofaKind : RankDecider
    {
        public DeciderFourofaKind() : base((int)Combination.FourofaKind)
        {
        }

        public override RankDecision Decide(Hand hand)
        {
            if (hand.Cards.Select(x => x.cardValue).Distinct().Count() > 2)
            {
                return new RankDecision(false);
            }

            //Get all cards with same value
            var groupCards = hand.Cards.GroupBy(p => p.cardValue).OrderByDescending(g => g.Count());

            if (groupCards.Any(g1 => g1.Count() == 4) && groupCards.Any(g2 => g2.Count() == 1))
            {
                return new RankDecision(true, base.rank, groupCards.FirstOrDefault().ToList(), groupCards.LastOrDefault().ToList());
            }
            return new RankDecision(false);
        }
    }
}
