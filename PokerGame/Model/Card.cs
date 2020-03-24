using PokerGame.Enum;

namespace PokerGame.Model
{
    public class Card
    {
        public Suit suit;
        public int cardValue;

        public Card() { }
        public Card(int value, Suit suit)
        {
            this.suit = suit;
            this.cardValue = value;
        }
    }
}
