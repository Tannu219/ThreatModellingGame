using System.Web.Mvc;
using ThreadModelingGame.Core;

namespace ThreatModelingGame.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Game(string id, string playerName)
        {
            var game = Request.RequestContext.HttpContext.Application[id] as Game;

            if (game == null)
            {
                game = new Game();
                Request.RequestContext.HttpContext.Application[id] = game;
            }

            Player player;
            if (!game.HasPlayer(playerName))
            {
                player = new Player { Name = playerName };
                game.AddPlayer(player);
                
                game.DealCards();
            }
            else
            {
                player = game.GetPlayer(playerName);
            }

            return View(player);
        }

        //public ActionResult Game2(string gameId, string playerName)
        //{
        //    var game = _gamePool.Find(gameId);

        //    if (game == null)
        //    {
        //        game = new Game(gameId);
        //        _gamePool.Add(game);
        //    }

        //    game.
        //}
    }
}