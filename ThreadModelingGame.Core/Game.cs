using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreadModelingGame.Core
{
    public sealed class Game : IGame
    {
        private readonly Guid _id;
        private readonly IDictionary<Guid, PlayerInGame> _playerDictionary;
        private readonly ICardDeck _cardDeck;

        public Game(ICardDeck cardDeck)
        {
            _id = Guid.NewGuid();
            _playerDictionary = new Dictionary<Guid, PlayerInGame>();
            _cardDeck = cardDeck;
        }

        public bool ContainsPlayer(Guid playerId)
        {
            return _playerDictionary.ContainsKey(playerId);
        }

        public void AddPlayer(Player player)
        {
            _playerDictionary.Add(
                player.Id,
                new PlayerInGame(player));
        }

        public PlayerInGame GetPlayer(Guid playerId)
        {
            return _playerDictionary[playerId];
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _playerDictionary.Values.Select(p => p.Player);
        }

        public void DealCards()
        {
            foreach (var player in _playerDictionary.Values)
            {
                player.ClearCards();
            }

            _cardDeck.Reset();
            _cardDeck.Shuffle();

            while (_cardDeck.HasCards())
            {
                var card = _cardDeck.DrawCard();

                GetNextPlayer().AddCard(card);
            }
        }

        private PlayerInGame GetNextPlayer()
        {
            return _playerDictionary.Values.OrderBy(p => p.GetCards().Count()).First();
        }

        public Guid Id { get { return _id; } }
        public string Name { get; set; }
    }
}