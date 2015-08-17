using System;
using System.Collections.Generic;

namespace ThreatModellingGame.Core
{
    public sealed class Player
    {
        public string Id { get; }
        public string Name { get; private set; }
        public IList<Card> Hand { get; }

        public Player(string name)
        {
            Id = Guid.NewGuid().ToString("N");
            Name = name;
            Hand = new List<Card>();
        }

        public Player(string id, string name) : this(name)
        {
            Id = id;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Player && Equals((Player)obj);
        }

        private bool Equals(Player other)
        {
            return string.Equals(Id, other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}