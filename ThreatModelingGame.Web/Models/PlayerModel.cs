using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ThreadModelingGame.Core;

namespace ThreatModelingGame.Web.Models
{
    public sealed class PlayerModel
    {
        private readonly Player _player;
        private readonly IEnumerable<IGame> _gamesWithPlayer;

        public PlayerModel()
        {
            _player = new Player();
        }

        public PlayerModel(Player player, IEnumerable<IGame> gamesWithPlayer)
        {
            _player = player;
            _gamesWithPlayer = gamesWithPlayer;
        }

        public Player ToPlayer()
        {
            return _player;
        }

        public string Id
        {
            get { return _player.Id; }
        }

        public IEnumerable<IGame> GamesWithPlayer
        {
            get { return _gamesWithPlayer; }
        }

        [Required]
        public string Name
        {
            get { return _player.Name; }
            set { _player.Name = value; }
        }
    }
}