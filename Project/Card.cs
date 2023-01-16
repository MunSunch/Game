using System;

namespace Project
{
    public class Card: IComparable
    {
        private readonly TypeCard _typeCard;
        private readonly Suit _suit;

        public Card(TypeCard typeCard, Suit suit)
        {
            _typeCard = typeCard;
            _suit = suit;
        }

        public TypeCard TypeCard => _typeCard;
        public Suit Suit => _suit;

        public override bool Equals(object obj)
        {
            if (obj is Card card)
            {
                return Suit == card.Suit && TypeCard == card.TypeCard;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _suit.GetHashCode() ^ _typeCard.GetHashCode() * 11;
        }
        
        public override string ToString()
        {
            return $"Karta{_typeCard}-{_suit}";
        }

        public int CompareTo(object obj)
        {
            Card anotherCard = (Card) obj;
            return _typeCard - anotherCard.TypeCard;
        }
    }

    public enum TypeCard
    {
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
        ACE
    }

    public enum Suit
    {
        SPADES, DIAMONDS, CLUBS, HEARTS
    }
}