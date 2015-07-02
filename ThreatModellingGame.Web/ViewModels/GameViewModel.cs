using System.Collections.Generic;
using System.Linq;
using ThreatModellingGame.Core;

namespace ThreatModellingGame.Web.ViewModels
{
    public sealed class GameViewModel
    {
        private readonly Game _game;
        private readonly Player _player;

        public GameViewModel(Game game, Player player)
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
            get { return _game.Players.Single(p => p.Id.Equals(_player.Id)).Hand.OrderBy(c => c.Suit); }
        }
    }
}