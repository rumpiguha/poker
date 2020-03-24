using PokerGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Services
{
    public class RankDecision : IComparable<RankDecision>
    {
        private bool isDecisionSuccessful;
        public int rank;
        public List<Card> winningCards;
        public List<Card> nonWinningCards;

        public RankDecision(bool isDecisionSuccessful)
        {
            this.isDecisionSuccessful = isDecisionSuccessful;
        }

        public RankDecision(bool isDecisionSuccessful,
                            int rank,
                            List<Card> winningCards,
                            List<Card> nonWinningCards)
        {
            this.isDecisionSuccessful = isDecisionSuccessful;
            this.rank = rank;
            this.winningCards = winningCards;
            this.nonWinningCards = nonWinningCards;
        }

        public bool IsDecisionSuccessful()
        {
            return isDecisionSuccessful;
        }

        public void SetDecisionSuccessful(bool isDecisionSuccessful)
        {
            this.isDecisionSuccessful = isDecisionSuccessful;
        }

        public int CompareTo(RankDecision other)
        {
            if (this.rank > other.rank)
                return 1;

            if (this.rank < other.rank)
                return -1;

            // Compare the winning cards
            int result = CompareCards(this.winningCards, other.winningCards);

            // Compare the non-winning cards
            if (result == 0)
                return CompareCards(this.nonWinningCards, other.nonWinningCards);

            return result;
        }


        private int CompareCards(List<Card> current, List<Card> other)
        {
            current = current.OrderByDescending(x => x.cardValue).ToList();
            other = other.OrderByDescending(x => x.cardValue).ToList();
            for (int i = 0; i < current.Count; i++)
            {
                if (current[i].cardValue > other[i].cardValue)
                    return 1;

                if (current[i].cardValue < other[i].cardValue)
                    return -1;
            }
            return 0;
        }
    }
}
