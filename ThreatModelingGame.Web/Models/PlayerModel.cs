using System.Collections.Generic;
using ThreadModelingGame.Core;

namespace ThreatModelingGame.Web.Models
{
    public sealed class PlayerModel
    {
        private readonly Player _player;
        private readonly IEnumerable<Game> _gamesByPlayer;

        public PlayerModel(Player player, IEnumerable<Game> gamesByPlayer)
        {
            _player = player;
            _gamesByPlayer = gamesByPlayer;
        }

        public IEnumerable<Game> Games
        {
            get { return _gamesByPlayer; }
        }

        public string Name
        {
            get { return _player.Name; }
        }
    }
}