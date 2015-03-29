using System;
using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public interface IGamePool
    {
        bool Contains(string gameId);
        void Add(IGame game);
        IGame Get(string gameId);
        IEnumerable<IGame> GetGamesWithPlayer(string playerId);
    }
}