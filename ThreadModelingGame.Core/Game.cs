using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreadModelingGame.Core
{
    public sealed class Game
    {
        public readonly Guid Id;
        private readonly ICardDeck _cardDeck;
        public HashSet<Player> Players;

        public Game(ICardDeck cardDeck)
        {
            _cardDeck = cardDeck;
            Id = Guid.NewGuid();
            Players = new HashSet<Player>();
        }

        public void DealCards()
        {
            foreach (var player in Players)
            {
                player.ClearHand();
            }

            _cardDeck.Reset();
            _cardDeck.Shuffle();

            while (_cardDeck.HasCards())
            {
                var card = _cardDeck.DrawCard();

                GetNextPlayer().AddCard(card);
            }
        }

        private Player GetNextPlayer()
        {
            return Players.OrderBy(p => p.Cards.Count).First();
        }
    }
}