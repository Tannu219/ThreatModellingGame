using System.ComponentModel.DataAnnotations;
using ThreadModelingGame.Core;

namespace ThreatModelingGame.Web.Models
{
    public class PlayerModel
    {
        private readonly Player _player;

        public PlayerModel()
        {
            _player = new Player();
        }

        public PlayerModel(Player player)
        {
            _player = player;
        }

        public Player ToPlayer()
        {
            return _player;
        }

        [Required]
        public string Name
        {
            get { return _player.Name; }
            set { _player.Name = value; }
        }
    }
}