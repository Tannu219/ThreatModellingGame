using System.Linq;
using System.Web.Mvc;
using ThreatModellingGame.Core;
using ThreatModellingGame.Core.Repositories;
using ThreatModellingGame.Core.Web;
using ThreatModellingGame.Web.Filters;
using ThreatModellingGame.Web.ViewModels;

namespace ThreatModellingGame.Web.Controllers
{
    [RegisteredPlayer]
    public class GameController : Controller
    {
        private readonly ICookieManager _cookieManager;
        private readonly IGameRepository _gameRepository;
        private readonly IDealer _dealer;

        public GameController(ICookieManager cookieManager, IGameRepository gameRepository, IDealer dealer)
        {
            _cookieManager = cookieManager;
            _gameRepository = gameRepository;
            _dealer = dealer;
        }

        public ActionResult Index(string id)
        {
            if (!GameExists(id))
            {
                return HttpNotFound();
            }

            var game = _gameRepository.Get(id);
            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            if (!IsPlayerInGame(game, player))
            {
                return RedirectToAction("ConfirmJoin", new { id = game.Id });
            }

            var model = new GameViewModel(game, player);

            return View(model);
        }

        [RegisteredPlayer]
        public ActionResult CreateGame()
        {
            var viewModel = new NewGameViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [RegisteredPlayer]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGame(NewGameViewModel viewModel)
        {
            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            if (!ModelState.IsValid)
            {
                return View("CreateGame", viewModel);
            }

            var game = new Game { Name = viewModel.Name };
            game.Players.Add(player);

            _dealer.DealCards(game);
            _gameRepository.Add(game);

            return RedirectToAction("Index", "Game", new { id = game.Id });
        }

        public ActionResult ConfirmJoin(string id)
        {
            if (!GameExists(id))
            {
                return HttpNotFound();
            }

            var game = _gameRepository.Get(id);
            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            if (IsPlayerInGame(game, player))
            {
                return RedirectToAction("Index", new { id = game.Id });
            }

            var viewModel = new JoinGameViewModel { GameId = game.Id, Name = game.Name };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Join(JoinGameViewModel viewModel)
        {
            if (!GameExists(viewModel.GameId))
            {
                return HttpNotFound();
            }

            var game = _gameRepository.Get(viewModel.GameId);
            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            if (IsPlayerInGame(game, player))
            {
                return RedirectToAction("Index", new { id = game.Id });
            }

            game.Players.Add(player);
            _dealer.DealCards(game);

            return RedirectToAction("Index", new { id = game.Id });
        }

        private bool GameExists(string gameId)
        {
            return !string.IsNullOrEmpty(gameId) && _gameRepository.Contains(gameId);
        }

        private static bool IsPlayerInGame(Game game, Player player)
        {
            return game.Players.Any(p => p.Id.Equals(player.Id));
        }
    }
}