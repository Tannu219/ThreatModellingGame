using System;
using System.Collections.Generic;
using System.Reflection;
using ThreadModelingGame.Core.Resources;

namespace ThreadModelingGame.Core
{
    public class Card
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

        private static Card Create(Suit suit, string id, string description)
        {
            return new Card(suit, id, description);
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}] {2}", Suit, Id, Description);
        }

        public class Deck
        {
            public readonly Stack<Card> Cards; 

            public Deck()
            {
                Cards = new Stack<Card>();

                var allCards = GetAvailableCards();

                foreach (var card in allCards)
                {
                    Cards.Push(card);
                }
            }

            private static IEnumerable<Card> GetAvailableCards()
            {
                return new[]
                {
                    Create(Suit.Spoofing, "2", Threats.Spoofing_2),
                    Create(Suit.Spoofing, "3", Threats.Spoofing_3),
                    Create(Suit.Spoofing, "4", Threats.Spoofing_4),
                    Create(Suit.Spoofing, "5", Threats.Spoofing_5),
                    Create(Suit.Spoofing, "6", Threats.Spoofing_6),
                    Create(Suit.Spoofing, "7", Threats.Spoofing_7),
                    Create(Suit.Spoofing, "8", Threats.Spoofing_8),
                    Create(Suit.Spoofing, "9", Threats.Spoofing_9),
                    Create(Suit.Spoofing, "10", Threats.Spoofing_10),
                    Create(Suit.Spoofing, "J", Threats.Spoofing_J),
                    Create(Suit.Spoofing, "Q", Threats.Spoofing_Q),
                    Create(Suit.Spoofing, "K", Threats.Spoofing_K),
                    Create(Suit.Spoofing, "A", Threats.Spoofing_A),

                    Create(Suit.Tampering, "3", Threats.Tampering_3),
                    Create(Suit.Tampering, "4", Threats.Tampering_4),
                    Create(Suit.Tampering, "5", Threats.Tampering_5),
                    Create(Suit.Tampering, "6", Threats.Tampering_6),
                    Create(Suit.Tampering, "7", Threats.Tampering_7),
                    Create(Suit.Tampering, "8", Threats.Tampering_8),
                    Create(Suit.Tampering, "9", Threats.Tampering_9),
                    Create(Suit.Tampering, "10", Threats.Tampering_10),
                    Create(Suit.Tampering, "J", Threats.Tampering_J),
                    Create(Suit.Tampering, "Q", Threats.Tampering_Q),
                    Create(Suit.Tampering, "K", Threats.Tampering_K),
                    Create(Suit.Tampering, "A", Threats.Tampering_A),

                    Create(Suit.Repudiation, "2", Threats.Repudiation_2),
                    Create(Suit.Repudiation, "3", Threats.Repudiation_3),
                    Create(Suit.Repudiation, "4", Threats.Repudiation_4),
                    Create(Suit.Repudiation, "5", Threats.Repudiation_5),
                    Create(Suit.Repudiation, "6", Threats.Repudiation_6),
                    Create(Suit.Repudiation, "7", Threats.Repudiation_7),
                    Create(Suit.Repudiation, "8", Threats.Repudiation_8),
                    Create(Suit.Repudiation, "9", Threats.Repudiation_9),
                    Create(Suit.Repudiation, "10", Threats.Repudiation_10),
                    Create(Suit.Repudiation, "J", Threats.Repudiation_J),
                    Create(Suit.Repudiation, "Q", Threats.Repudiation_Q),
                    Create(Suit.Repudiation, "K", Threats.Repudiation_K),
                    Create(Suit.Repudiation, "A", Threats.Repudiation_A),

                    Create(Suit.InformationDisclosure, "2", Threats.InformationDisclosure_2),
                    Create(Suit.InformationDisclosure, "3", Threats.InformationDisclosure_3),
                    Create(Suit.InformationDisclosure, "4", Threats.InformationDisclosure_4),
                    Create(Suit.InformationDisclosure, "5", Threats.InformationDisclosure_5),
                    Create(Suit.InformationDisclosure, "6", Threats.InformationDisclosure_6),
                    Create(Suit.InformationDisclosure, "7", Threats.InformationDisclosure_7),
                    Create(Suit.InformationDisclosure, "8", Threats.InformationDisclosure_8),
                    Create(Suit.InformationDisclosure, "9", Threats.InformationDisclosure_9),
                    Create(Suit.InformationDisclosure, "10", Threats.InformationDisclosure_10),
                    Create(Suit.InformationDisclosure, "J", Threats.InformationDisclosure_J),
                    Create(Suit.InformationDisclosure, "Q", Threats.InformationDisclosure_Q),
                    Create(Suit.InformationDisclosure, "K", Threats.InformationDisclosure_K),
                    Create(Suit.InformationDisclosure, "A", Threats.InformationDisclosure_A),

                    Create(Suit.DenialOfService, "2", Threats.DenialOfService_2),
                    Create(Suit.DenialOfService, "3", Threats.DenialOfService_3),
                    Create(Suit.DenialOfService, "4", Threats.DenialOfService_4),
                    Create(Suit.DenialOfService, "5", Threats.DenialOfService_5),
                    Create(Suit.DenialOfService, "6", Threats.DenialOfService_6),
                    Create(Suit.DenialOfService, "7", Threats.DenialOfService_7),
                    Create(Suit.DenialOfService, "8", Threats.DenialOfService_8),
                    Create(Suit.DenialOfService, "9", Threats.DenialOfService_9),
                    Create(Suit.DenialOfService, "10", Threats.DenialOfService_10),
                    Create(Suit.DenialOfService, "J", Threats.DenialOfService_J),
                    Create(Suit.DenialOfService, "Q", Threats.DenialOfService_Q),
                    Create(Suit.DenialOfService, "K", Threats.DenialOfService_K),
                    Create(Suit.DenialOfService, "A", Threats.DenialOfService_A),

                    Create(Suit.ElevationOfPrivilege, "5", Threats.ElevationOfPrivilege_5),
                    Create(Suit.ElevationOfPrivilege, "6", Threats.ElevationOfPrivilege_6),
                    Create(Suit.ElevationOfPrivilege, "7", Threats.ElevationOfPrivilege_7),
                    Create(Suit.ElevationOfPrivilege, "8", Threats.ElevationOfPrivilege_8),
                    Create(Suit.ElevationOfPrivilege, "9", Threats.ElevationOfPrivilege_9),
                    Create(Suit.ElevationOfPrivilege, "10", Threats.ElevationOfPrivilege_10),
                    Create(Suit.ElevationOfPrivilege, "J", Threats.ElevationOfPrivilege_J),
                    Create(Suit.ElevationOfPrivilege, "Q", Threats.ElevationOfPrivilege_Q),
                    Create(Suit.ElevationOfPrivilege, "K", Threats.ElevationOfPrivilege_K),
                    Create(Suit.ElevationOfPrivilege, "A", Threats.ElevationOfPrivilege_A)
                };
            }

            public void Shuffle()
            {
                var tempCardPool = Cards.ToArray();
                tempCardPool.Shuffle();

                foreach (var card in tempCardPool)
                {
                    Cards.Push(card);
                }
            }
        }
    }
}