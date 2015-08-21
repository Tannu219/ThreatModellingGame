using System.Collections.Generic;

namespace ThreatModellingGame.Core
{
    public interface IGame
    {
        string GetName();

        string Id { get; }
        string Name { get; }

        void AddPlayer(Player player);
        bool HasPlayer(Player player);
        ICollection<Player> GetPlayers();
        IList<Card> GetHand(Player player);

        void StartGame();
    }
}