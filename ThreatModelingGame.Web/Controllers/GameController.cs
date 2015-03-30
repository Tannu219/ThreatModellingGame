using System.Linq;
using System.Web.Mvc;
using ThreadModelingGame.Core;
using ThreadModelingGame.Core.Repositories;
using ThreadModelingGame.Core.Web;
using ThreatModelingGame.Web.Filters;
using ThreatModelingGame.Web.Models;

namespace ThreatModelingGame.Web.Controllers
{
    [RegisteredPlayer]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IDealer _dealer;
        private readonly ICookieManager _cookieManager;

        public GameController(ICookieManager cookieManager, IGameRepository gameRepository, IDealer dealer)
        {
            _cookieManager = cookieManager;
            _gameRepository = gameRepository;
            _dealer = dealer;
        }

        [HttpPost]
        public ActionResult New(NewGameModel model)
        {
            if (!ModelState.IsValid)
            {
                //return View(model);
            }

            var player = _cookieManager.ExtractPlayerFromCookie(Request);
            var game = new Game { Name = model.Name };

            game.Players.Add(player);

            _dealer.DealCards(game);
            _gameRepository.Add(game);
            
            return RedirectToAction("Index", new { gameId = game.Id });
        }

        public ActionResult Index(string gameId)
        {
            if (string.IsNullOrEmpty(gameId) || !_gameRepository.Contains(gameId))
            {
                return HttpNotFound();
            }

            var game = _gameRepository.Get(gameId);
            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            if (!game.Players.Any(p => p.Id.Equals(player.Id)))
            {
                // Return Join
            }

            var model = new GameModel(game, player);

            return View(model);
        }
    }
}