using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public interface IGame
    {
        bool ContainsPlayer(string playerId);
        void AddPlayer(Player player);
        PlayerInGame GetPlayer(string playerId);
        IEnumerable<Player> GetPlayers();
        void DealCards();

        string Id { get; }
        string Name { get; set; }
    }
}