using System;
using System.Collections;
using System.Threading;

namespace Project
{
    public class Game
    {
        private ArrayList _players;
        private Stack _packOfCards;

        public Game(params Player[] players)
        {
            _players = new ArrayList(players);
            _packOfCards = new Stack(PackOfCardsFactory.Create(TypePack.STANDART));
        }

        public void start()
        {
            Shuffle();
            Prepare();

            ArrayList board = new ArrayList(_players.Count);
            int counter = 1;
            while (true)
            {
                Console.WriteLine($"==========Move #{counter++}==========");
                RemoveLosers();
                
                Console.WriteLine("\t\tBoard");
                foreach (Player player in _players)
                {
                    Card cur = player.GiveCard();
                    board.Add(cur);
                    Console.WriteLine($"Player {player.Name}: {cur}");
                }

                int playerMaxHand = GetPlayerWithMaxHand(board);
                Console.WriteLine($"\t\tResult\nPlayer {((Player)(_players[playerMaxHand])).Name} is max hand");   
                for (int i = 0; i < board.Count; i++)
                {
                    ((Player) (_players[playerMaxHand])).GetCard((Card) board[i]);
                }
                board.Clear();
                Console.Write("Count cards: ");
                foreach (Player player in _players)
                {
                    Console.Write($"{player.Name}-{player.CountCardHand} ");
                }
                Console.WriteLine();

                Player winner = CheckWinner();
                if (!(winner is null))
                {
                    Console.WriteLine($"Winner: {winner.Name}");
                    break;
                }
                
                Console.WriteLine();
                Thread.Sleep(4 * 1000);
            }
        }

        protected void Shuffle()
        {
            ArrayList tempList = new ArrayList(_packOfCards);
            var random = new Random();
            
            int lenght = _packOfCards.Count;
            for (int i = 0; i < lenght; lenght--)
            {
                int randomPositionCard = random.Next(i, lenght - i - 1);
                (tempList[lenght - 1], tempList[randomPositionCard]) 
                    = (tempList[randomPositionCard], tempList[lenght - 1]);
            }

            _packOfCards = new Stack(tempList);
        }

        //*
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

        protected int GetPlayerWithMaxHand(ArrayList board)
        {
            Card maxHand = (Card) board[0];
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

            return playerMaxHand;
        }

        protected int GetLoser()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                Player cur = (Player)_players[i];
                if (cur.CountCardHand == 0)
                    return i;
            }

            return -1;
        }

        protected Player CheckWinner()
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

        protected void RemoveLosers()
        {
            int loser;
            do
            {
                loser = GetLoser();
                if (loser != -1)
                {
                    string nameLoser = ((Player) _players[loser]).Name;
                    Console.WriteLine($"Player {nameLoser} is eliminated from the game");
                    _players.RemoveAt(loser);
                }
            } while (loser != -1);
        }
    }
}