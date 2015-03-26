using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public sealed class CardDeck : ICardDeck
    {
        private readonly ICardPool _cardPool;
        private readonly Stack<Card> _cards;

        public CardDeck(ICardPool cardPool)
        {
            _cardPool = cardPool;
            _cards = new Stack<Card>();
        }

        public void Reset()
        {
            _cards.Clear();
            var allCards = _cardPool.GetAllCards();

            foreach (var card in allCards)
            {
                _cards.Push(card);
            }
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