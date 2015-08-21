using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ThreatModellingGame.Core.Repositories
{
    /// <summary>
    /// In memory persistance of games.
    /// This is good enough at the moment and can be replaced to a
    /// better persistance layer at a later point.
    /// Every app pool reset (every 29 hours by default) will evict the memory cache.
    /// </summary>
    public sealed class InMemoryGameRepository : IGameRepository
    {
        private static readonly ConcurrentDictionary<string, IGame> Cache = new ConcurrentDictionary<string, IGame>(); 

        public bool Contains(string gameId)
        {
            return Cache.ContainsKey(gameId);
        }

        public void Add(IGame game)
        {
            Cache[game.Id] = game;
        }

        public void Update(IGame game)
        {
            Cache[game.Id] = game;
        }

        public IGame Get(string gameId)
        {
            IGame game;
            return Cache.TryGetValue(gameId, out game) ? game : null;
        }

        public IEnumerable<IGame> GetGamesByPlayer(Player player)
        {
            return from item in Cache where item.Value.HasPlayer(player) select item.Value;
        }
    }
}