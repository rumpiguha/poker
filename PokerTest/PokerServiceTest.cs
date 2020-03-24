using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerGame.Services;
using System.Collections.Generic;

namespace PokerTest
{
    [TestClass]
    public class PokerServiceTest
    {
        [TestMethod]
        public void Process_ValidCards_Player1Win()
        {
            //Arrange
            var input = new List<string> { "9C 9D 8D 7C 3C 2S KD TH 9H 8H" };

            //Act
            var result = PokerService.Process(input);

            //Assert
            Assert.AreEqual(1, result.ScorePlayer1);
            Assert.AreEqual(0, result.ScorePlayer2);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void Process_ValidCards_Player2Win()
        {
            //Arrange
            var input = new List<string> { "6C 5H AS 4H 7S 2S KD 7H 2C AC" };

            //Act
            var result = PokerService.Process(input);

            //Assert
            Assert.AreEqual(1, result.ScorePlayer2);
            Assert.AreEqual(0, result.ScorePlayer1);
            Assert.AreEqual(0, result.Errors.Count);
        }


        [TestMethod]
        public void Process_ValidCards_BothPlayersScored()
        {
            //Arrange
            var input = new List<string> {
                "9C 9D 8D 7C 3C 2S KD TH 9H 8H",
                 "6C 5H AS 4H 7S 2S KD 7H 2C AC"
            };

            //Act
            var result = PokerService.Process(input);

            //Assert
            Assert.AreEqual(1, result.ScorePlayer1);
            Assert.AreEqual(1, result.ScorePlayer2);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void Process_InvalidCards_GetErrMessage()
        {
            //Arrange
            var input = new List<string> {
                "9C 9D 8D 7C 3C 2S KD TH 9H 8X"
            };

            //Act
            var result = PokerService.Process(input);

            //Assert
            Assert.AreEqual(0, result.ScorePlayer1);
            Assert.AreEqual(0, result.ScorePlayer2);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.IsTrue(result.Errors[0].Contains("Please enter valid cards."));
        }

        [TestMethod]
        public void Process_MoreThan10Cards_GetErrMessage()
        {
            //Arrange
            var input = new List<string> {
                "9C 9D 8D 7C 3C 2S KD TH 9H 8H 7H"
            };

            //Act
            var result = PokerService.Process(input);

            //Assert
            Assert.AreEqual(0, result.ScorePlayer1);
            Assert.AreEqual(0, result.ScorePlayer2);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.IsTrue(result.Errors[0].Contains("Please enter exactly 10 cards."));
        }

        [TestMethod]
        public void Process_DuplicateCards_GetErrMessage()
        {
            //Arrange
            var input = new List<string> {
                "9C 9D 8D 7C 3C 2S KD TH 9H 9H"
            };

            //Act
            var result = PokerService.Process(input);

            //Assert
            Assert.AreEqual(0, result.ScorePlayer1);
            Assert.AreEqual(0, result.ScorePlayer2);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.IsTrue(result.Errors[0].Contains("Please enter unique cards."));
        }

        [TestMethod]
        public void Process_DuplicateandInvalidCards_GetErrMessage()
        {
            //Arrange
            var input = new List<string> {
                "9C 9D 8D 7C 3C 2S KD TH 9H 9H",
                 "9C 9D 8D 7C 3C 2S KD TH 9H 8X"
            };

            //Act
            var result = PokerService.Process(input);

            //Assert
            Assert.AreEqual(0, result.ScorePlayer1);
            Assert.AreEqual(0, result.ScorePlayer2);
            Assert.AreEqual(2, result.Errors.Count);
        }
    }
}
