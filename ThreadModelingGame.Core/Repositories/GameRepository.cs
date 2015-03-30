using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreadModelingGame.Core.Repositories
{
    /// <summary>
    /// In memory persistence of games. Each application restart will clear all games.
    /// This is good enough for the first version. Can change to a different persistence 
    /// layer in a later stage of the project.
    /// </summary>
    public sealed class GameRepository : IGameRepository
    {
        public static GameRepository Instance { get { return Lazy.Value; } }
        private static readonly Lazy<GameRepository> Lazy = new Lazy<GameRepository>(() => new GameRepository());

        private readonly IDictionary<string, Game> _gameDictionary;

        private GameRepository()
        {
            _gameDictionary = new Dictionary<string, Game>();
        }

        public bool Contains(string gameId)
        {
            return _gameDictionary.ContainsKey(gameId);
        }

        public void Add(Game game)
        {
            _gameDictionary.Add(game.Id, game);
        }

        public Game Get(string gameId)
        {
            return _gameDictionary[gameId];
        }

        public IEnumerable<Game> GetGamesByPlayer(string playerId)
        {
            return _gameDictionary.Values.Where(game => game.Players.Any(p => p.Id.Equals(playerId)));
        }
    }
}