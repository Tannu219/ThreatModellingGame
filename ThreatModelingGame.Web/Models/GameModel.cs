using ThreadModelingGame.Core;

namespace ThreatModelingGame.Web.Models
{
    public sealed class GameModel
    {
        private readonly IGame _game;
        private readonly Player _player;

        public GameModel(IGame game, Player player)
        {
            _game = game;
            _player = player;
        }

        public string Name { get { return _game.Name; } }

        public Player Player
        {
            get { return _player; }
        }
    }
}