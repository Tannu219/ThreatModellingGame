using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public interface ICardPool
    {
        HashSet<Card> GetAllCards();
    }
}