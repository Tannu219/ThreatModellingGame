namespace ThreatModellingGame.Core
{
    public interface ICardDeck
    {
        void ResetAndShuffle();
        bool HasCards();
        Card DrawCard();
    }
}