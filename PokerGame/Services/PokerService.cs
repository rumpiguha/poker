using PokerGame.Enum;
using PokerGame.Helpers;
using PokerGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Services
{
    public static class PokerService
    {
        public static Result Process(List<string> input)
        {
            var cardDict = CardValue.CardValueDict;

            var result = new Result();
            foreach (var line in input)
            {
                var completeInput = new List<Card>();
                var splitInput = line.ToUpper().Split(" ");
                var errorMsg = Validator.GetErrorMessage(splitInput);
                if (string.IsNullOrEmpty(errorMsg))
                {
                    foreach (var item in splitInput)
                    {
                        var cardValue = cardDict[item[0].ToString()];
                        Suit suit = (Suit)System.Enum.Parse(typeof(Suit), item[1].ToString(), true);

                        completeInput.Add(new Card(cardValue, suit));
                    }
                    Hand handPlayer1 = new Hand(completeInput.Where((s, i) => i < 5).ToList());
                    Hand handPlayer2 = new Hand(completeInput.Where((s, i) => i >= 5).ToList());

                    if (handPlayer1.RankDecision.CompareTo(handPlayer2.RankDecision) > 0)
                        result.ScorePlayer1++;
                    else if (handPlayer1.RankDecision.CompareTo(handPlayer2.RankDecision) < 0)
                        result.ScorePlayer2++;

                }
                else
                {
                    result.Errors.Add($"Hand: [{line}] has error - {errorMsg}");
                }

            }

            return result;
        }
    }
}
