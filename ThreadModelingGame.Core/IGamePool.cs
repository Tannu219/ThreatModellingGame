using System;
using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public interface IGamePool
    {
        bool Contains(Guid gameId);
        void Add(IGame game);
        IGame Get(Guid gameId);
        IEnumerable<IGame> GetGamesWithPlayer(Guid playerId);
    }
}