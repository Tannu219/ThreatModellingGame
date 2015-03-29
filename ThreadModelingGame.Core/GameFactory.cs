namespace ThreadModelingGame.Core
{
    public sealed class GameFactory : IGameFactory
    {
        public ICardPool NewCardPool()
        {
            return new CardPool();
        }

        public ICardDeck NewCardDeck()
        {
            return new CardDeck(NewCardPool());
        }

        public IGame NewGame()
        {
            return new Game(NewCardDeck());
        }
    }
}