using System;
using System.Collections.Generic;

namespace ThreatModellingGame.Core
{
    public sealed class Player
    {
        private readonly string _id;

        public Player(string id = null)
        {
            _id = id ?? Guid.NewGuid().ToString("N");
            Hand = new List<Card>();
        }

        public string Id { get { return _id; } }
        public string Name { get; set; }
        public IList<Card> Hand { get; set; }
    }
}