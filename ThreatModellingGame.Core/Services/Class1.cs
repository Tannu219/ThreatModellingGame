using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatModellingGame.Core.Repositories;

namespace ThreatModellingGame.Core.Services
{
    public class Class1
    {
        public void Method1()
        {
            var cardRepository = new CardRepository();
            var cardDeck = new CardDeck(cardRepository);

            var dustin = new Player("Dustin");
            var hetal = new Player("Hetal");

            var game = new Game("My Game 123", cardDeck);

            game.AddPlayer(dustin);
            game.AddPlayer(hetal);

            game.StartGame();
        }

        public void CreateGame(string name, Player creator)
        {
            
        }
    }
}
