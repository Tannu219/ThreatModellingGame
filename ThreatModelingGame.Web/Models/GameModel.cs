using System.Collections.Generic;
using System.Linq;
using ThreadModelingGame.Core;

namespace ThreatModelingGame.Web.Models
{
    public sealed class GameModel
    {
        private readonly Game _game;
        private readonly Player _player;

        public GameModel(Game game, Player player)
        {
            _game = game;
            _player = player;
        }

        public Game Game
        {
            get { return _game; }
        }

        public Player Player
        {
            get { return _player; }
        }

        public IEnumerable<Card> PlayerHand
        {
            get { return _game.Players.Single(p => p.Id.Equals(_player.Id)).Cards; }
        }
    }
}