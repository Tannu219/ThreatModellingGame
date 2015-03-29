using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public sealed class PlayerInGame
    {
        private readonly Player _player;
        private readonly List<Card> _cards;

        public PlayerInGame(Player player)
        {
            _player = player;
            _cards = new List<Card>();
        }

        public void ClearCards()
        {
            _cards.Clear();
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public IEnumerable<Card> GetCards()
        {
            return _cards;
        }

        public Player Player
        {
            get { return _player; }
        }
    }
}