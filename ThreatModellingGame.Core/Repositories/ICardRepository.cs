using System.Collections.Generic;

namespace ThreatModellingGame.Core.Repositories
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAllCards();
    }
}