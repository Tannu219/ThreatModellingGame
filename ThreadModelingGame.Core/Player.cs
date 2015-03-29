using System;

namespace ThreadModelingGame.Core
{
    public sealed class Player
    {
        private readonly string _id;

        public Player()
        {
            _id = Guid.NewGuid().ToString("N");
        }

        public Player(string id, string name)
        {
            _id = id;
            Name = name;
        }

        public string Id { get { return _id; } }
        public string Name { get; set; }
    }
}