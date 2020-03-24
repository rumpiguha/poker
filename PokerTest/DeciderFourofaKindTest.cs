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
    public class DeciderFourofaKindTest
    {
        [TestMethod]
        public void Decide_ValidInput_FourofaKind()
        {
            //Arrange
            var cards = new List<Card>
            {
                new Card { cardValue = 3, suit = Suit.D },
                new Card { cardValue = 3, suit = Suit.C },
                new Card { cardValue = 3, suit = Suit.H },
                new Card { cardValue = 3, suit = Suit.S },
                new Card { cardValue = 7, suit = Suit.D }
            };
            var hand = new Hand(cards);

            //Act
            var obj = new DeciderFourofaKind();
            var rankDecision = obj.Decide(hand);

            //Assert
            Assert.IsTrue(rankDecision.IsDecisionSuccessful());
            Assert.AreEqual(8, rankDecision.rank);
            Assert.AreEqual(1, rankDecision.nonWinningCards.Count);
            Assert.AreEqual(4, rankDecision.winningCards.Count);
            Assert.IsTrue(rankDecision.nonWinningCards.Contains(cards[4]));
          
        }

        [TestMethod]
        public void Decide_InvalidInput_NotFourofaKind()
        {
            //Arrange
            var cards = new List<Card>
            {
                new Card { cardValue = 3, suit = Suit.D },
                new Card { cardValue = 2, suit = Suit.C },
                new Card { cardValue = 3, suit = Suit.H },
                new Card { cardValue = 3, suit = Suit.S },
                new Card { cardValue = 7, suit = Suit.D }
            };
            var hand = new Hand(cards);

            //Act
            var obj = new DeciderFourofaKind();
            var rankDecision = obj.Decide(hand);

            //Assert
            Assert.IsFalse(rankDecision.IsDecisionSuccessful());
        }
    }
}
