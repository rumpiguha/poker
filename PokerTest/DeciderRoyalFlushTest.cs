using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using PokerGame.Model;
using PokerGame.Enum;
using PokerGame.Services;

namespace PokerTest
{
    [TestClass]
    public class DeciderRoyalFlushTest
    {
        [TestMethod]
        public void Decide_ValidInput_RoyalFlush()
        {
            //Arrange
            var cards = new List<Card>
            {
                new Card { cardValue = 14, suit = Suit.D },
                new Card { cardValue = 10, suit = Suit.D },
                new Card { cardValue = 11, suit = Suit.D },
                new Card { cardValue = 13, suit = Suit.D },
                new Card { cardValue = 12, suit = Suit.D }
            };
            var hand = new Hand(cards);

            //Act
            var obj = new DeciderRoyalFlush();
            var rankDecision = obj.Decide(hand);

            //Assert
            Assert.IsTrue(rankDecision.IsDecisionSuccessful());
            Assert.AreEqual(10, rankDecision.rank);
            Assert.AreEqual(0, rankDecision.nonWinningCards.Count);
            Assert.AreEqual(5, rankDecision.winningCards.Count);
            foreach (var item in cards)
            {
                Assert.IsTrue(rankDecision.winningCards.Contains(item));
            }
          
        }

        [TestMethod]
        public void Decide_InvalidInput_LowerCard()
        {
            //Arrange
            var cards = new List<Card>
            {
                new Card { cardValue = 14, suit = Suit.D },
                new Card { cardValue = 2, suit = Suit.D },
                new Card { cardValue = 11, suit = Suit.D },
                new Card { cardValue = 13, suit = Suit.D },
                new Card { cardValue = 12, suit = Suit.D }
            };
            var hand = new Hand(cards);

            //Act
            var obj = new DeciderRoyalFlush();
            var rankDecision = obj.Decide(hand);

            //Assert
            Assert.IsFalse(rankDecision.IsDecisionSuccessful());
        }

        [TestMethod]
        public void Decide_InvalidInput_DifferentSuit()
        {
            //Arrange
            var cards = new List<Card>
            {
                new Card { cardValue = 14, suit = Suit.D },
                new Card { cardValue = 10, suit = Suit.C },
                new Card { cardValue = 11, suit = Suit.D },
                new Card { cardValue = 13, suit = Suit.D },
                new Card { cardValue = 12, suit = Suit.D }
            };
            var hand = new Hand(cards);

            //Act
            var obj = new DeciderRoyalFlush();
            var rankDecision = obj.Decide(hand);

            //Assert
            Assert.IsFalse(rankDecision.IsDecisionSuccessful());
        }
    }
}
