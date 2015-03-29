namespace ThreadModelingGame.Core
{
    public sealed class Card
    {
        private readonly Suit _suit;
        private readonly string _id;
        private readonly string _description;

        private Card(Suit suit, string id, string description)
        {
            _suit = suit;
            _id = id;
            _description = description;
        }

        public static Card Create(Suit suit, string id, string description)
        {
            return new Card(suit, id, description);
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}] {2}", _suit, _id, _description);
        }
    }
}