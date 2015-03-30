using System.Collections.Generic;

namespace ThreadModelingGame.Core.Repositories
{
    public interface IGameRepository
    {
        bool Contains(string gameId);

        void Add(Game game);

        Game Get(string gameId);

        IEnumerable<Game> GetGamesByPlayer(string playerId);
    }
}