using System.Collections.Generic;
using System.Linq;
using ThreatModellingGame.Core;

namespace ThreatModellingGame.Web.ViewModels
{
    public sealed class GameViewModel
    {
        private readonly IGame _game;
        private readonly Player _player;

        public GameViewModel(IGame game, Player player)
        {
            _game = game;
            _player = player;
        }

        public IGame Game
        {
            get { return _game; }
        }

        public Player Player
        {
            get { return _player; }
        }

        public IEnumerable<Card> PlayerHand
        {
            get
            {
                return Game.GetHand(_player).OrderBy(c => c.Suit);
            }
        }
    }
}