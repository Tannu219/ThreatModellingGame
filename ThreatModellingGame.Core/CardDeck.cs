using System.Collections.Generic;
using ThreatModellingGame.Core.Extensions;
using ThreatModellingGame.Core.Repositories;

namespace ThreatModellingGame.Core
{
    public sealed class CardDeck : ICardDeck
    {
        private readonly ICardRepository _cardRepository;
        private readonly Stack<Card> _cards;

        public CardDeck(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
            _cards = new Stack<Card>();
        }

        public void Init()
        {
            var allCards = _cardRepository.GetAllCards();

            foreach (var card in allCards)
            {
                _cards.Push(card);
            }
        }

        public void Reset()
        {
            _cards.Clear();

            Init();
        }

        public void Shuffle()
        {
            var temp = _cards.ToArray();
            temp.Shuffle();

            _cards.Clear();

            foreach (var card in temp)
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