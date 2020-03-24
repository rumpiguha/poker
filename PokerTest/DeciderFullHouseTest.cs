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
    public class DeciderFullHouseTest
    {
        [TestMethod]
        public void Decide_ValidInput_FullHouse()
        {
            //Arrange
            var cards = new List<Card>
            {
                new Card { cardValue = 5, suit = Suit.D },
                new Card { cardValue = 5, suit = Suit.H },
                new Card { cardValue = 5, suit = Suit.C },
                new Card { cardValue = 3, suit = Suit.S },
                new Card { cardValue = 3, suit = Suit.C }
            };
            var hand = new Hand(cards);

            //Act
            var obj = new DeciderFullHouse();
            var rankDecision = obj.Decide(hand);

            //Assert
            Assert.IsTrue(rankDecision.IsDecisionSuccessful());
            Assert.AreEqual(7, rankDecision.rank);
        }

        [TestMethod]
        public void Decide_InvalidInput_NotFullHouse()
        {
            //Arrange
            var cards = new List<Card>
            {
                new Card { cardValue = 5, suit = Suit.D },
                new Card { cardValue = 5, suit = Suit.H },
                new Card { cardValue = 8, suit = Suit.C },
                new Card { cardValue = 9, suit = Suit.S },
                new Card { cardValue = 3, suit = Suit.C }
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
