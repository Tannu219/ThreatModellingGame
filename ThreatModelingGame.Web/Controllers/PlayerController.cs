using System.Web.Mvc;
using ThreadModelingGame.Core;
using ThreadModelingGame.Core.Repositories;
using ThreadModelingGame.Core.Web;
using ThreatModelingGame.Web.Filters;
using ThreatModelingGame.Web.Models;

namespace ThreatModelingGame.Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ICookieManager _cookieManager;
        private readonly IGameRepository _gamePool;

        public PlayerController(ICookieManager cookieManager, IGameRepository gamePool)
        {
            _cookieManager = cookieManager;
            _gamePool = gamePool;
        }

        public ActionResult Register()
        {
            return View(new ChangePlayerNameModel());
        }

        [HttpPost]
        public ActionResult Register(ChangePlayerNameModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var player = new Player { Name = model.Name };

            _cookieManager.IssueNewPlayerCookie(Response, player);

            return RedirectToAction("Index", "Player");
        }

        [RegisteredPlayer]
        public ActionResult Index()
        {
            var player = _cookieManager.ExtractPlayerFromCookie(Request);
            var games = _gamePool.GetGamesByPlayer(player.Id);

            var viewModel = new PlayerNewGameModel
            {
                PlayerModel = new PlayerModel(player, games),
                ChangePlayerNameModel = new ChangePlayerNameModel { Name = player.Name }
            };

            return View(viewModel);
        }

        [HttpPost]
        [RegisteredPlayer]
        public ActionResult ChangeName(ChangePlayerNameModel model)
        {
            var player = _cookieManager.ExtractPlayerFromCookie(Request);
            var games = _gamePool.GetGamesByPlayer(player.Id);

            if (!ModelState.IsValid)
            {
                player.Name = model.Name;
                var playerModel = new PlayerModel(player, games);
                var viewModel = new PlayerNewGameModel { PlayerModel = playerModel };

                return View("Index", viewModel);
            }

            player.Name = model.Name;

            _cookieManager.IssueNewPlayerCookie(Response, player);

            return RedirectToAction("Index", "Player");
        }
    }
}