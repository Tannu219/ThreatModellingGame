using System;
using System.Collections.Generic;
using System.Linq;
using ThreatModellingGame.Core.Repositories;

namespace ThreatModellingGame.Core
{
    public interface ICardDeckFactory
    {
        ICardDeck Create();
    }

    public sealed class CardDeckFactory
    {
        private readonly ICardRepository _cardRepository;

        public CardDeckFactory(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public ICardDeck Create()
        {
            return new CardDeck(_cardRepository);
        }
    }

    public sealed class GameFactory
    {
        private readonly ICardDeckFactory _cardDeckFactory;

        public GameFactory(ICardDeckFactory cardDeckFactory)
        {
            _cardDeckFactory = cardDeckFactory;
        }

        public IGame Create(string name)
        {
            var cardDeck = _cardDeckFactory.Create();
            return new Game(name, cardDeck);
        }
    }

    public interface IGame
    {
        void AddPlayer(Player player);
        bool HasPlayer(Player player);
        void StartGame();
    }

    public sealed class Game : IGame
    {
        private readonly ICardDeck _cardDeck;
        private readonly Dictionary<Player, IList<Card>> _playerHands = new Dictionary<Player, IList<Card>>();

        public string Id { get; }
        public string Name { get; }
        public HashSet<Player> Players { get; }

        public Game(string name)
        {
            Id = Guid.NewGuid().ToString("N");
            Players = new HashSet<Player>();
            Name = name;
        }

        public Game(string name, ICardDeck cardDeck) : this(name)
        {
            _cardDeck = cardDeck;
        }

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

                if (i++ >= round.Length)
                    i = 0;

                var nextPlayer = round[i];
                _playerHands[nextPlayer].Add(card);
            }
        }
    }
}