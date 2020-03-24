using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PokerGame.Helpers
{
    public static class CardValue
    {
        public static readonly Dictionary<string, int> CardValueDict =
             new Dictionary<string, int>
            {
                {"2", 2 },
                {"3", 3 },
                {"4", 4 },
                {"5", 5 },
                {"6", 6 },
                {"7", 7 },
                {"8", 8 },
                {"9", 9 },
                {"T", 10 },
                {"J", 11 },
                {"Q", 12 },
                {"K", 13 },
                {"A", 14 },
            };
    }
}
