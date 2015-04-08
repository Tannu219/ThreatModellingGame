namespace ThreatModellingGame.Core.Extensions
{
    public static class SuitExtensions
    {
        public static string ToFriendlyString(this Suit suit)
        {
            switch (suit)
            {
                case Suit.InformationDisclosure:
                    return "Information Disclosure";
                case Suit.DenialOfService:
                    return "Denial Of Service";
                case Suit.ElevationOfPrivilege:
                    return "Elevation Of Privilege";
                default:
                    return suit.ToString();
            }
        }
    }
}