using PokerGame.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PokerGame.Model
{
    public abstract class RankDecider
    {
        protected int rank;

        public RankDecider(int rank)
        {
            this.rank = rank;
        }

        public abstract RankDecision Decide(Hand hand);

    }
}
