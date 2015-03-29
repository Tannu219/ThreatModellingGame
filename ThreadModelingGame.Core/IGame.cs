using System;
using System.Collections.Generic;

namespace ThreadModelingGame.Core
{
    public interface IGame
    {
        bool ContainsPlayer(Guid playerId);
        void AddPlayer(Player player);
        IEnumerable<Player> GetPlayers();
        void DealCards();

        Guid Id { get; }
        string Name { get; set; }
    }
}