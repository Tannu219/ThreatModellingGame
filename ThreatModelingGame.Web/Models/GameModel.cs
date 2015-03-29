using System;
using System.Collections.Generic;
using ThreadModelingGame.Core;

namespace ThreatModelingGame.Web.Models
{
    public sealed class GameModel
    {
        private readonly IGame _game;
        private readonly PlayerInGame _player;

        public GameModel(IGame game, PlayerInGame player)
        {
            _game = game;
            _player = player;
        }

        public string Id { get { return _game.Id; } }
        public string Name { get { return _game.Name; } }

        public PlayerInGame CurrentPlayer
        {
            get { return _player; }
        }

        public IEnumerable<Player> Players
        {
            get { return _game.GetPlayers(); }
        }
    }
}