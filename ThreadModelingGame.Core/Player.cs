using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public class Player
    {
        public string Name { get; set; }
        public readonly List<Card> Hand;

        public Player()
        {
            Hand = new List<Card>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == GetType() && Equals((Player) obj);
        }

        protected bool Equals(Player other)
        {
            return string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        public void ClearHand()
        {
            Hand.Clear();
        }
    }
}