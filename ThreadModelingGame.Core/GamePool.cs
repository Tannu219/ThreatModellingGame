using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreadModelingGame.Core
{
    /// <summary>
    /// In memory persistence of games. Each application restart will clear all games.
    /// This is good enough for the first version. Can change to a different persistence 
    /// layer in a later stage of the project.
    /// </summary>
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