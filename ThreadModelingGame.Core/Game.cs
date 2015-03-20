using System.Collections.Generic;
using System.Linq;

namespace ThreadModelingGame.Core
{
    public class Game
    {
        public Dictionary<string, Player> Players;

        public Game()
        {
            Players = new Dictionary<string, Player>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player.Name, player);
        }

        public bool HasPlayer(string playerName)
        {
            return Players.ContainsKey(playerName);
        }

        public Player GetPlayer(string playerName)
        {
            return Players[playerName];
        }

        public void DealCards()
        {
            foreach (var key in Players.Keys)
            {
                Players[key].ClearHand();
            }

            var deck = new Card.Deck();
            deck.Shuffle();

            var i = 0;
            while (deck.Cards.Count > 1)
            {
                var card = deck.Cards.Pop();

                Players[Players.Keys.ElementAt(i)].AddCardToHand(card);

                if (++i == Players.Count)
                {
                    i = 0;
                }
            }
        }
    }
}