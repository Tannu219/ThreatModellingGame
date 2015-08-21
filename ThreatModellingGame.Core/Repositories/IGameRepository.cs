using System.Collections.Generic;

namespace ThreatModellingGame.Core.Repositories
{
    public interface IGameRepository
    {
        bool Contains(string gameId);
        void Add(IGame game);
        void Update(IGame game);
        IGame Get(string gameId);
        IEnumerable<IGame> GetGamesByPlayer(Player player);
    }
}