using System;
using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public interface IGame
    {
        bool ContainsPlayer(Guid playerId);
        void AddPlayer(Player player);
        PlayerInGame GetPlayer(Guid playerId);
        IEnumerable<Player> GetPlayers();
        void DealCards();

        Guid Id { get; }
        string Name { get; set; }
    }
}