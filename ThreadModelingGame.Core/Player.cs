using System;
using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public sealed class Player
    {
        private readonly string _id;

        public Player(string id = null)
        {
            _id = id ?? Guid.NewGuid().ToString("N");
        }

        public string Id { get { return _id; } }
        public string Name { get; set; }
        public IList<Card> Cards { get; set; }
    }
}