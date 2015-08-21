using System.Collections.Generic;
using ThreatModellingGame.Core;

namespace ThreatModellingGame.Web.ViewModels
{
    public sealed class PlayerViewModel
    {
        private readonly Player _player;
        private readonly IEnumerable<IGame> _gamesByPlayer;

        public PlayerViewModel(Player player, IEnumerable<IGame> gamesByPlayer)
        {
            _player = player;
            _gamesByPlayer = gamesByPlayer;
        }

        public IEnumerable<IGame> Games
        {
            get { return _gamesByPlayer; }
        }

        public string Name
        {
            get { return _player.Name; }
        }
    }
}