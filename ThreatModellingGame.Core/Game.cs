using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreatModellingGame.Core
{
    public sealed class Game : IGame
    {
        private readonly ICardDeck _cardDeck;
        private readonly Dictionary<Player, IList<Card>> _playerHands = new Dictionary<Player, IList<Card>>();

        public Game(string name, ICardDeck cardDeck)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(@"Name cannot be null or empty.", nameof(name));

            Id = Guid.NewGuid().ToString("N");
            Name = name;
            _cardDeck = cardDeck;
        }

        public string GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        public string Id { get; }
        public string Name { get; }

        public void AddPlayer(Player player)
        {
            if (!_playerHands.ContainsKey(player))
            {
                _playerHands.Add(player, new List<Card>());
            }
        }

        public bool HasPlayer(Player player)
        {
            return _playerHands.ContainsKey(player);
        }

        public ICollection<Player> GetPlayers()
        {
            return _playerHands.Keys;
        }

        public IList<Card> GetHand(Player player)
        {
            return _playerHands[player];
        }

        public void StartGame()
        {
            _cardDeck.ResetAndShuffle();
            ClearAllHands();
            DealCards();
        }

        private void ClearAllHands()
        {
            foreach (var playerHand in _playerHands)
            {
                playerHand.Value.Clear();
            }
        }

        private void DealCards()
        {
            var round = _playerHands.Keys.ToArray();
            var i = 0;

            while (_cardDeck.HasCards())
            {
                var card = _cardDeck.DrawCard();

                if (i >= round.Length)
                    i = 0;

                var nextPlayer = round[i++];
                _playerHands[nextPlayer].Add(card);
            }
        }
    }
}