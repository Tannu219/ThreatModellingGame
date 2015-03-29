using System;
using System.Web.Mvc;
using ThreadModelingGame.Core;
using ThreadModelingGame.Core.Web;
using ThreatModelingGame.Web.Filters;
using ThreatModelingGame.Web.Models;

namespace ThreatModelingGame.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGamePool _gamePool;
        private readonly IGameFactory _gameFactory;
        private readonly ICookieManager _cookieManager;

        public GameController(IGamePool gamePool, IGameFactory gameFactory, ICookieManager cookieManager)
        {
            _gamePool = gamePool;
            _gameFactory = gameFactory;
            _cookieManager = cookieManager;
        }

        [HttpPost]
        [RegisteredPlayer]
        public ActionResult New(string gameName)
        {

            var game = _gameFactory.NewGame();
            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            game.Name = gameName;
            game.AddPlayer(player);
            game.DealCards();

            _gamePool.Add(game);

            return RedirectToAction("Show", new { gameId = game.Id });
        }

        [RegisteredPlayer]
        public ActionResult Join(string gameId)
        {
            if (string.IsNullOrEmpty(gameId) || !_gamePool.Contains(gameId))
            {
                return HttpNotFound();
            }

            var game = _gamePool.Get(gameId);
            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            game.AddPlayer(player);
            game.DealCards();

            return RedirectToAction("Show", new { gameId = game.Id });
        }

        [RegisteredPlayer]
        public ActionResult Show(string gameId)
        {
            if (string.IsNullOrEmpty(gameId) || !_gamePool.Contains(gameId))
            {
                return HttpNotFound();
            }

            var game = _gamePool.Get(gameId);
            var player = _cookieManager.ExtractPlayerFromCookie(Request);
            var playerInGame = game.GetPlayer(player.Id.ToString());

            var model = new GameModel(game, playerInGame);

            return View(model);
        }
    }
}