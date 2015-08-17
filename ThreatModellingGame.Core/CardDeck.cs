using System.Collections.Generic;
using System.Linq;
using ThreatModellingGame.Core.Extensions;
using ThreatModellingGame.Core.Repositories;

namespace ThreatModellingGame.Core
{
    public sealed class CardDeck : ICardDeck
    {
        private readonly ICardRepository _cardRepository;
        private readonly Stack<Card> _cards = new Stack<Card>();

        public CardDeck(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void ResetAndShuffle()
        {
            var cards = _cardRepository.GetAllCards().ToArray();
            cards.Shuffle();

            _cards.Clear();
            foreach (var card in cards)
            {
                _cards.Push(card);
            }
        }

        public bool HasCards()
        {
            return _cards != null && _cards.Count > 0;
        }

        public Card DrawCard()
        {
            return _cards.Pop();
        }
    }
}