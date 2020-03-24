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
    public class DeciderTwoPairTest
    {
        [TestMethod]
        public void Decide_ValidInput_TwoPairs()
        {
            //Arrange
            var cards = new List<Card>
            {
                new Card { cardValue = 3, suit = Suit.D },
                new Card { cardValue = 3, suit = Suit.S },
                new Card { cardValue = 4, suit = Suit.D },
                new Card { cardValue = 4, suit = Suit.H },
                new Card { cardValue = 7, suit = Suit.D }
            };
            var hand = new Hand(cards);

            //Act
            var obj = new DeciderTwoPairs();
            var rankDecision = obj.Decide(hand);

            //Assert
            Assert.IsTrue(rankDecision.IsDecisionSuccessful());
            Assert.AreEqual(3, rankDecision.rank);
            Assert.AreEqual(1, rankDecision.nonWinningCards.Count);
            Assert.AreEqual(4, rankDecision.winningCards.Count);          
        }

        [TestMethod]
        public void Decide_InvalidInput_NotTwoPairs()
        {
            //Arrange
            var cards = new List<Card>
            {
               new Card { cardValue = 3, suit = Suit.D },
                new Card { cardValue = 6, suit = Suit.D },
                new Card { cardValue = 4, suit = Suit.H},
                new Card { cardValue = 4, suit = Suit.D },
                new Card { cardValue = 7, suit = Suit.D }
            };
            var hand = new Hand(cards);

            //Act
            var obj = new DeciderFlush();
            var rankDecision = obj.Decide(hand);

            //Assert
            Assert.IsFalse(rankDecision.IsDecisionSuccessful());
        }
    }
}
