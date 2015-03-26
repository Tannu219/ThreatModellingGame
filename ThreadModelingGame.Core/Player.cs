using System;
using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public sealed class Player
    {
        private readonly Guid _id;
        public string Name { get; set; }
        public readonly HashSet<Card> Cards;

        public Player()
        {
            _id = Guid.NewGuid();
            Cards = new HashSet<Card>();
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", _id, Name);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == GetType() && Equals((Player) obj);
        }

        public bool Equals(Player other)
        {
            return other != null && string.Equals(Name, other.Name);
        }

        public static bool operator ==(Player player1, Player player2)
        {
            if (player1 == null || player2 == null) return false;

            return player1.Equals(player2);
        }

        public static bool operator !=(Player player1, Player player2)
        {
            return !(player1 == player2);
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public void ClearHand()
        {
            Cards.Clear();
        }
    }
}