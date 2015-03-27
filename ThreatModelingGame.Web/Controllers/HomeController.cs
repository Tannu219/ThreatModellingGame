using System.Web;
using System.Web.Mvc;
using ThreadModelingGame.Core;

namespace ThreatModelingGame.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICardDeck _cardDeck;

        public HomeController(ICardDeck cardDeck)
        {
            _cardDeck = cardDeck;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Game(string id, string playerName)
        {
            return View();

            //var playerCookie = Request.Cookies["Player"];

            //if (playerCookie == null)
            //{
            //    // Redirect to create cookie first
            //}

            //var game = Request.RequestContext.HttpContext.Application[id] as Game;

            //if (game == null)
            //{
            //    game = new Game(_cardDeck);
            //    Request.RequestContext.HttpContext.Application[id] = game;
            //}

            //var player = playerCookie.Value as Player;



            //if (!game.HasPlayer(playerName))
            //{
            //    player = new Player { Name = playerName };
            //    game.AddPlayer(player);

            //    game.DealCards();
            //}
            //else
            //{
            //    player = game.GetPlayer(playerName);
            //}

            //return View(player);
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