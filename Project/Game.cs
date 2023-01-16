using System;
using System.Collections;

namespace Project
{
    public class Game
    {
        private ArrayList _players;
        private Stack _packOfCards;

        public Game(params Player[] players)
        {
            _players.CopyTo(players);
            //_packOfCards = FabricPackOfCards.create(TypePack.STANDART);
            
        }

        public void start()
        {
            Shuffle();
            Prepare();

            ArrayList board = new ArrayList(_players.Count);
            while (true)
            {
                foreach (Player player in _players)
                {
                    board.Add(player.GiveCard());
                }

                Card maxHand = (Card)board[0];
                int playerMaxHand = 0;
                for (int i = 1; i < board.Count; i++)
                {
                    Card cur = (Card) board[i];
                    if (cur.CompareTo(maxHand) > 0)
                    {
                        maxHand = cur;
                        playerMaxHand = i;
                    }
                }

                for (int i = 0; i < board.Count; i++)
                {
                    ((Player) (_players[playerMaxHand])).GetCard((Card) board[i]);
                }
                board.Clear();
                
                
                Player winner = CheckWinner();
                if (!(winner is null))
                {
                    Console.WriteLine($"Winner: {winner.Name}");
                    break;
                }
            }
        }

        protected void Shuffle()
        {
            ArrayList tempList = new ArrayList(_packOfCards);
            var random = new Random();
            int randomPositionCard;
            
            int lenght = _packOfCards.Count;
            for (int i = 0; i < lenght; lenght--)
            {
                randomPositionCard = random.Next(i, lenght - i - 1);
                (tempList[lenght - 1], tempList[randomPositionCard]) 
                    = (tempList[randomPositionCard], tempList[lenght - 1]);
            }

            _packOfCards = new Stack(_packOfCards);
        }

        protected void Prepare()
        {
            while (_packOfCards.Count != 0)
            {
                foreach (Player player in _players)
                {
                    player.GetCard((Card)_packOfCards.Pop());
                }
            }
        }

        public Player CheckWinner()
        {
            foreach (Player player in _players)
            {
                if (player.CountCardHand == 36)
                {
                    return player;
                }
            }

            return null;
        }
    }
}