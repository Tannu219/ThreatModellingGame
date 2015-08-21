using ThreatModellingGame.Core.Repositories;

namespace ThreatModellingGame.Core.Factories
{
    public sealed class CardDeckFactory : ICardDeckFactory
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
}