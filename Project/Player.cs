using System;
using System.Collections;

namespace Project
{
    public class Player
    {
        private string _name;
        private Queue _cardHand;

        public Player(string name)
        {
            Name = name;
            _cardHand = new Queue();
        }
        
        public string Name
        {
            private set
            {
                _name = value ?? throw new ArgumentNullException(nameof(value));
            }
            get => _name;
        }

        public int CountCardHand
        {
            get => _cardHand.Count;
        }

        public void GetCard(Card card)
        {
            _cardHand.Enqueue(card);
        }

        public Card GiveCard()
        {
            return _cardHand.Dequeue() as Card;
        }
    }
}