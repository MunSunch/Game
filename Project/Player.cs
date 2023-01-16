using System;
using System.Collections;

namespace Project
{
    public class Player
    {
        private Queue _cardHand;
        private string _name;

        public Player(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _cardHand = new Queue();
        }
        
        public string Name
        {
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