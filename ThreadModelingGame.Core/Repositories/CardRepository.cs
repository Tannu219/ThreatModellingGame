using System.Collections.Generic;
using System.Linq;
using ThreadModelingGame.Core.Resources;

namespace ThreadModelingGame.Core.Repositories
{
    public sealed class CardRepository : ICardRepository
    {
        private static IEnumerable<Card> GetAllSpoofingCards()
        {
            return new []
            {
                Card.Create(Suit.Spoofing, "2", Threats.Spoofing_2),
                Card.Create(Suit.Spoofing, "3", Threats.Spoofing_3),
                Card.Create(Suit.Spoofing, "4", Threats.Spoofing_4),
                Card.Create(Suit.Spoofing, "5", Threats.Spoofing_5),
                Card.Create(Suit.Spoofing, "6", Threats.Spoofing_6),
                Card.Create(Suit.Spoofing, "7", Threats.Spoofing_7),
                Card.Create(Suit.Spoofing, "8", Threats.Spoofing_8),
                Card.Create(Suit.Spoofing, "9", Threats.Spoofing_9),
                Card.Create(Suit.Spoofing, "10", Threats.Spoofing_10),
                Card.Create(Suit.Spoofing, "J", Threats.Spoofing_J),
                Card.Create(Suit.Spoofing, "Q", Threats.Spoofing_Q),
                Card.Create(Suit.Spoofing, "K", Threats.Spoofing_K),
                Card.Create(Suit.Spoofing, "A", Threats.Spoofing_A)
            };
        }

        private static IEnumerable<Card> GetAllTamperingCards()
        {
            return new []
            {
                Card.Create(Suit.Tampering, "3", Threats.Tampering_3),
                Card.Create(Suit.Tampering, "4", Threats.Tampering_4),
                Card.Create(Suit.Tampering, "5", Threats.Tampering_5),
                Card.Create(Suit.Tampering, "6", Threats.Tampering_6),
                Card.Create(Suit.Tampering, "7", Threats.Tampering_7),
                Card.Create(Suit.Tampering, "8", Threats.Tampering_8),
                Card.Create(Suit.Tampering, "9", Threats.Tampering_9),
                Card.Create(Suit.Tampering, "10", Threats.Tampering_10),
                Card.Create(Suit.Tampering, "J", Threats.Tampering_J),
                Card.Create(Suit.Tampering, "Q", Threats.Tampering_Q),
                Card.Create(Suit.Tampering, "K", Threats.Tampering_K),
                Card.Create(Suit.Tampering, "A", Threats.Tampering_A)
            };
        }

        private static IEnumerable<Card> GetAllRepudiationCards()
        {
            return new []
            {
                Card.Create(Suit.Repudiation, "2", Threats.Repudiation_2),
                Card.Create(Suit.Repudiation, "3", Threats.Repudiation_3),
                Card.Create(Suit.Repudiation, "4", Threats.Repudiation_4),
                Card.Create(Suit.Repudiation, "5", Threats.Repudiation_5),
                Card.Create(Suit.Repudiation, "6", Threats.Repudiation_6),
                Card.Create(Suit.Repudiation, "7", Threats.Repudiation_7),
                Card.Create(Suit.Repudiation, "8", Threats.Repudiation_8),
                Card.Create(Suit.Repudiation, "9", Threats.Repudiation_9),
                Card.Create(Suit.Repudiation, "10", Threats.Repudiation_10),
                Card.Create(Suit.Repudiation, "J", Threats.Repudiation_J),
                Card.Create(Suit.Repudiation, "Q", Threats.Repudiation_Q),
                Card.Create(Suit.Repudiation, "K", Threats.Repudiation_K),
                Card.Create(Suit.Repudiation, "A", Threats.Repudiation_A)
            };
        }

        private static IEnumerable<Card> GetAllInformationDisclosureCards()
        {
            return new []
            {
                Card.Create(Suit.InformationDisclosure, "2", Threats.InformationDisclosure_2),
                Card.Create(Suit.InformationDisclosure, "3", Threats.InformationDisclosure_3),
                Card.Create(Suit.InformationDisclosure, "4", Threats.InformationDisclosure_4),
                Card.Create(Suit.InformationDisclosure, "5", Threats.InformationDisclosure_5),
                Card.Create(Suit.InformationDisclosure, "6", Threats.InformationDisclosure_6),
                Card.Create(Suit.InformationDisclosure, "7", Threats.InformationDisclosure_7),
                Card.Create(Suit.InformationDisclosure, "8", Threats.InformationDisclosure_8),
                Card.Create(Suit.InformationDisclosure, "9", Threats.InformationDisclosure_9),
                Card.Create(Suit.InformationDisclosure, "10", Threats.InformationDisclosure_10),
                Card.Create(Suit.InformationDisclosure, "J", Threats.InformationDisclosure_J),
                Card.Create(Suit.InformationDisclosure, "Q", Threats.InformationDisclosure_Q),
                Card.Create(Suit.InformationDisclosure, "K", Threats.InformationDisclosure_K),
                Card.Create(Suit.InformationDisclosure, "A", Threats.InformationDisclosure_A)
            };
        }

        private static IEnumerable<Card> GetAllDenialOfServiceCards()
        {
            return new []
            {
                Card.Create(Suit.DenialOfService, "2", Threats.DenialOfService_2),
                Card.Create(Suit.DenialOfService, "3", Threats.DenialOfService_3),
                Card.Create(Suit.DenialOfService, "4", Threats.DenialOfService_4),
                Card.Create(Suit.DenialOfService, "5", Threats.DenialOfService_5),
                Card.Create(Suit.DenialOfService, "6", Threats.DenialOfService_6),
                Card.Create(Suit.DenialOfService, "7", Threats.DenialOfService_7),
                Card.Create(Suit.DenialOfService, "8", Threats.DenialOfService_8),
                Card.Create(Suit.DenialOfService, "9", Threats.DenialOfService_9),
                Card.Create(Suit.DenialOfService, "10", Threats.DenialOfService_10),
                Card.Create(Suit.DenialOfService, "J", Threats.DenialOfService_J),
                Card.Create(Suit.DenialOfService, "Q", Threats.DenialOfService_Q),
                Card.Create(Suit.DenialOfService, "K", Threats.DenialOfService_K),
                Card.Create(Suit.DenialOfService, "A", Threats.DenialOfService_A)
            };
        }

        private static IEnumerable<Card> GetAllElevationOfPrivilegeCards()
        {
            return new []
            {
                Card.Create(Suit.ElevationOfPrivilege, "5", Threats.ElevationOfPrivilege_5),
                Card.Create(Suit.ElevationOfPrivilege, "6", Threats.ElevationOfPrivilege_6),
                Card.Create(Suit.ElevationOfPrivilege, "7", Threats.ElevationOfPrivilege_7),
                Card.Create(Suit.ElevationOfPrivilege, "8", Threats.ElevationOfPrivilege_8),
                Card.Create(Suit.ElevationOfPrivilege, "9", Threats.ElevationOfPrivilege_9),
                Card.Create(Suit.ElevationOfPrivilege, "10", Threats.ElevationOfPrivilege_10),
                Card.Create(Suit.ElevationOfPrivilege, "J", Threats.ElevationOfPrivilege_J),
                Card.Create(Suit.ElevationOfPrivilege, "Q", Threats.ElevationOfPrivilege_Q),
                Card.Create(Suit.ElevationOfPrivilege, "K", Threats.ElevationOfPrivilege_K),
                Card.Create(Suit.ElevationOfPrivilege, "A", Threats.ElevationOfPrivilege_A)
            };
        }

        public IEnumerable<Card> GetAllCards()
        {
            return 
                GetAllSpoofingCards()
                .Union(GetAllTamperingCards())
                .Union(GetAllRepudiationCards())
                .Union(GetAllInformationDisclosureCards())
                .Union(GetAllDenialOfServiceCards())
                .Union(GetAllElevationOfPrivilegeCards());
        }
    }
}