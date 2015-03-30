using System;
using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public sealed class Game
    {
        private readonly string _id;

        public Game()
        {
            _id = Guid.NewGuid().ToString("N");
        }

        public string Id { get { return _id; } }
        public string Name { get; set; }
        public IList<Player> Players { get; set; }
    }
}