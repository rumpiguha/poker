using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame.Model
{
    public class Result
    {
        public int ScorePlayer1 { get; set; }
        public int ScorePlayer2 { get; set; }
        public List<string> Errors = new List<string>();
    }
}
