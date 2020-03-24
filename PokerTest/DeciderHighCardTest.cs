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
    public class DeciderHighCardTest
    {
        [TestMethod]
        public void Decide_ValidInput_HighCard()
        {
            //Arrange
            var cards = new List<Card>
            {
                new Card { cardValue = 3, suit = Suit.D },
                new Card { cardValue = 3, suit = Suit.S },
                new Card { cardValue = 4, suit = Suit.D },
                new Card { cardValue = 5, suit = Suit.H },
                new Card { cardValue = 7, suit = Suit.D }
            };
            var hand = new Hand(cards);

            //Act
            var obj = new DeciderHighCard();
            var rankDecision = obj.Decide(hand);

            //Assert
            Assert.IsTrue(rankDecision.IsDecisionSuccessful());
            Assert.AreEqual(1, rankDecision.rank);
            Assert.AreEqual(4, rankDecision.nonWinningCards.Count);
            Assert.AreEqual(1, rankDecision.winningCards.Count);          
        }

    }
}
