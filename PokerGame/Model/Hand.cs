using PokerGame.Helpers;
using PokerGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Model
{
    public class Hand
    {
        // All 5 cards of this hand
        public List<Card> Cards { get; }

        public bool IsAllSameSuit { get; }

        public RankDecision RankDecision { get; set; }

        public Hand(List<Card> cards)
        {
            this.Cards = cards.OrderBy(x => x.cardValue).ToList();
            this.IsAllSameSuit = CheckSameSuit();
            SetRankDecision();
        }

        private bool CheckSameSuit()
        {
            return this.Cards.All(x => x.suit == this.Cards[0].suit);
        }

        private void SetRankDecision()
        {
            foreach (var item in Registry.Deciders)
            {
                var decider = (RankDecider)item;
                var res = decider.Decide(this);
                if (res.IsDecisionSuccessful())
                {
                    this.RankDecision = res;
                    break;
                }
            }

        }
    }
}
