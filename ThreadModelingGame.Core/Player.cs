using System;

namespace ThreadModelingGame.Core
{
    public sealed class Player
    {
        private readonly Guid _id;

        public Player()
        {
            _id = Guid.NewGuid();
        }

        public Player(Guid id, string name)
        {
            _id = id;
            Name = name;
        }

        public string Id { get { return _id.ToString(); } }
        public string Name { get; set; }
    }
}