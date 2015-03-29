namespace ThreadModelingGame.Core
{
    public sealed class Card
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
    }
}