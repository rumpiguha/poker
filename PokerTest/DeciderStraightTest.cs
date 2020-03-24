﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using PokerGame.Model;
using PokerGame.Enum;
using PokerGame.Services;

namespace PokerTest
{
    [TestClass]
    public class DeciderStraightTest
    {
        [TestMethod]
        public void Decide_ValidInput_Straight()
        {
            //Arrange
            var cards = new List<Card>
            {
                new Card { cardValue = 3, suit = Suit.D },
                new Card { cardValue = 5, suit = Suit.D },
                new Card { cardValue = 4, suit = Suit.H },
                new Card { cardValue = 6, suit = Suit.D },
                new Card { cardValue = 7, suit = Suit.C }
            };
            var hand = new Hand(cards);

            //Act
            var obj = new DeciderStraight();
            var rankDecision = obj.Decide(hand);

            //Assert
            Assert.IsTrue(rankDecision.IsDecisionSuccessful());
            Assert.AreEqual(5, rankDecision.rank);
            Assert.AreEqual(0, rankDecision.nonWinningCards.Count);
            Assert.AreEqual(5, rankDecision.winningCards.Count);          
        }

        [TestMethod]
        public void Decide_InvalidInput_NotStaright()
        {
            //Arrange
            var cards = new List<Card>
            {
               new Card { cardValue = 3, suit = Suit.D },
                new Card { cardValue = 6, suit = Suit.D },
                new Card { cardValue = 4, suit = Suit.H},
                new Card { cardValue = 10, suit = Suit.D },
                new Card { cardValue = 7, suit = Suit.D }
            };
            var hand = new Hand(cards);

            //Act
            var obj = new DeciderStraight();
            var rankDecision = obj.Decide(hand);

            //Assert
            Assert.IsFalse(rankDecision.IsDecisionSuccessful());
        }
    }
}
