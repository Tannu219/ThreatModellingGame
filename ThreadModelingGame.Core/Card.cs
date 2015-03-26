namespace ThreadModelingGame.Core
{
    public struct Card
    {
        public readonly Suit Suit;
        public readonly string Id;
        public readonly string Description;

        private Card(Suit suit, string id, string description)
        {
            Suit = suit;
            Id = id;
            Description = description;
        }

        public static Card Create(Suit suit, string id, string description)
        {
            return new Card(suit, id, description);
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}] {2}", Suit, Id, Description);
        }

        public override int GetHashCode()
        {
            return Suit.GetHashCode() ^ Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Card))
                return false;

            var card = (Card) obj;

            return Suit.Equals(card.Suit) && Id.Equals(card.Id);
        }

        public static bool operator ==(Card card1, Card card2)
        {
            return card1.Equals(card2);
        }

        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }
    }
}