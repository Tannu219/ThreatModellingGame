using System.Collections.Generic;
using System.Linq;

namespace ThreatModellingGame.Core
{
    public sealed class Dealer : IDealer
    {
        private readonly ICardDeck _cardDeck;

        public Dealer(ICardDeck cardDeck)
        {
            _cardDeck = cardDeck;
        }

        public void DealCards(Game game)
        {
            RemoveAllCards(game.Players);

            _cardDeck.Reset();
            _cardDeck.Shuffle();

            while (_cardDeck.HasCards())
            {
                var card = _cardDeck.DrawCard();
                var nextPlayer = GetNextPlayer(game.Players);
                
                nextPlayer.Hand.Add(card);
            }
        }

        private static void RemoveAllCards(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                player.Hand.Clear();
            }
        }

        private static Player GetNextPlayer(IEnumerable<Player> players)
        {
            return players.OrderBy(p => p.Hand.Count).First();
        }
    }
}