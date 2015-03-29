using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreadModelingGame.Core
{
    public sealed class GamePool : IGamePool
    {
        public static GamePool Instance { get { return Lazy.Value; } }
        private static readonly Lazy<GamePool> Lazy = new Lazy<GamePool>(() => new GamePool());

        private readonly IDictionary<string, IGame> _gameDictionary;

        private GamePool()
        {
            _gameDictionary = new Dictionary<string, IGame>();
        }

        public bool Contains(string gameId)
        {
            return _gameDictionary.ContainsKey(gameId);
        }

        public void Add(IGame game)
        {
            _gameDictionary.Add(game.Id, game);
        }

        public IGame Get(string gameId)
        {
            return _gameDictionary[gameId];
        }

        public IEnumerable<IGame> GetGamesWithPlayer(string playerId)
        {
            return _gameDictionary.Values.Where(game => game.ContainsPlayer(playerId));
        }
    }
}