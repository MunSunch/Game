using System;
using System.Collections;

namespace Project
{
    public class FabricPackKarta
    {
        public static ArrayList create(TypePack type)
        {
            switch (type)
            {
                case TypePack.STANDART:
                {
                    ArrayList pack = new ArrayList(36);
                    var typesKarta = Enum.GetValues(typeof(TypeKarta));
                    var suits = Enum.GetValues(typeof(Suit));
                    foreach (var typeKarta in typesKarta)
                    {
                        foreach (var suit in suits)
                        {
                            pack.Add(new Karta((TypeKarta)typeKarta, (Suit)suit));
                        }
                    }
                    return pack;
                }
                default:
                    return null;
            }
        }

        public enum TypePack
        {
            STANDART
        }
    }
    
    public class Karta
    {
        private readonly TypeKarta _typeKarta;
        private readonly Suit _suit;

        public Karta(TypeKarta typeKarta, Suit suit)
        {
            _typeKarta = typeKarta;
            _suit = suit;
        }

        public TypeKarta TypeKarta => _typeKarta;
        public Suit Suit => _suit;

        public override string ToString()
        {
            return $"Karta: {_typeKarta}-{_suit}";
        }
    }

    public enum TypeKarta
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