using System;
using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public sealed class GamePool : IGamePool
    {
        public static GamePool Instance { get { return Lazy.Value; } }
        private static readonly Lazy<GamePool> Lazy = new Lazy<GamePool>(() => new GamePool());

        private readonly IDictionary<Guid, IGame> _gameDictionary;

        private GamePool()
        {
            _gameDictionary = new Dictionary<Guid, IGame>();
        }

        public bool Contains(Guid gameId)
        {
            return _gameDictionary.ContainsKey(gameId);
        }

        public void Add(IGame game)
        {
            _gameDictionary.Add(game.Id, game);
        }

        public IGame Get(Guid gameId)
        {
            return _gameDictionary[gameId];
        }
    }
}