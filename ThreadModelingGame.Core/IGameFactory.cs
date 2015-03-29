namespace ThreadModelingGame.Core
{
    public interface IGameFactory
    {
        ICardPool NewCardPool();
        ICardDeck NewCardDeck();
        IGame NewGame();
    }
}