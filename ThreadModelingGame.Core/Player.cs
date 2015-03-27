using System;
using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public sealed class Player
    {
        public readonly Guid Id;
        public string Name { get; set; }
        public readonly HashSet<Card> Cards;

        public Player()
        {
            Id = Guid.NewGuid();
            Cards = new HashSet<Card>();
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, Name);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
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