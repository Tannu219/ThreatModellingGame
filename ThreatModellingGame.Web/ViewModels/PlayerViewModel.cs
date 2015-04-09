using System.Collections.Generic;
using ThreatModellingGame.Core;

namespace ThreatModellingGame.Web.ViewModels
{
    public sealed class PlayerViewModel
    {
        private readonly Player _player;
        private readonly IEnumerable<Game> _gamesByPlayer;

        public PlayerViewModel(Player player, IEnumerable<Game> gamesByPlayer)
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