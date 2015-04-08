namespace ThreatModellingGame.Core
{
    public interface ICardDeck
    {
        void Init();
        void Reset();
        void Shuffle();
        bool HasCards();
        Card DrawCard();
    }
}