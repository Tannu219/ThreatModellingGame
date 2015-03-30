using System.Collections.Generic;

namespace ThreadModelingGame.Core.Repositories
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAllCards();
    }
}