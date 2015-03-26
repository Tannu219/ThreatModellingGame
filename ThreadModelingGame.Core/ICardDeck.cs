namespace ThreadModelingGame.Core
{
    public interface ICardDeck
    {
        void Reset();
        void Shuffle();
        bool HasCards();
        Card DrawCard();
    }
}