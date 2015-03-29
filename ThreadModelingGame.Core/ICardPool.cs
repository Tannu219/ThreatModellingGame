using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public interface ICardPool
    {
        IEnumerable<Card> GetAllCards();
    }
}