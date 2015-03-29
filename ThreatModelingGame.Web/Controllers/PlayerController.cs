using System.Web.Mvc;
using ThreadModelingGame.Core;
using ThreadModelingGame.Core.Web;
using ThreatModelingGame.Web.Filters;
using ThreatModelingGame.Web.Models;

namespace ThreatModelingGame.Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ICookieManager _cookieManager;
        private readonly IGamePool _gamePool;

        public PlayerController(ICookieManager cookieManager, IGamePool gamePool)
        {
            _cookieManager = cookieManager;
            _gamePool = gamePool;
        }

        public ActionResult Register()
        {
            return View(new PlayerModel());
        }

        [HttpPost]
        public ActionResult Details(PlayerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var player = model.ToPlayer();
            var gamesWithPlayer = _gamePool.GetGamesWithPlayer(player.Id);

            _cookieManager.IssueNewPlayerCookie(Response, player);

            return View(new PlayerModel(player, gamesWithPlayer));
        }

        [RegisteredPlayer]
        public ActionResult Details()
        {
            var player = _cookieManager.ExtractPlayerFromCookie(Request);
            var gamesWithPlayer = _gamePool.GetGamesWithPlayer(player.Id);

            return View(new PlayerModel(player, gamesWithPlayer));
        }
    }
}