namespace ThreatModellingGame.Core.Factories
{
    public sealed class GameFactory : IGameFactory
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
}