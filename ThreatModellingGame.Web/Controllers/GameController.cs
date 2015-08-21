using System.Web.Mvc;
using ThreatModellingGame.Core.Factories;
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
        private readonly IGameFactory _gameFactory;
        private readonly IGameRepository _gameRepository;

        public GameController(ICookieManager cookieManager, IGameFactory gameFactory, IGameRepository gameRepository)
        {
            _cookieManager = cookieManager;
            _gameFactory = gameFactory;
            _gameRepository = gameRepository;
        }

        public ActionResult Index(string id)
        {
            var game = _gameRepository.Get(id);

            if (game == null)
                return HttpNotFound();

            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            if (!game.HasPlayer(player))
                return RedirectToAction("ConfirmJoin", new { id = game.Id });

            var viewModel = new GameViewModel(game, player);
            return View(viewModel);
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
            if (!ModelState.IsValid)
                return View("CreateGame", viewModel);

            var player = _cookieManager.ExtractPlayerFromCookie(Request);
            var game = _gameFactory.Create(viewModel.Name);

            game.AddPlayer(player);
            game.StartGame();

            _gameRepository.Add(game);

            return RedirectToAction("Index", "Game", new { id = game.Id });
        }

        public ActionResult ConfirmJoin(string id)
        {
            var game = _gameRepository.Get(id);

            if (game == null)
                return HttpNotFound();

            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            if (game.HasPlayer(player))
                return RedirectToAction("Index", new { id = game.Id });

            var viewModel = new JoinGameViewModel { GameId = game.Id, Name = game.Name };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Join(JoinGameViewModel viewModel)
        {
            var game = _gameRepository.Get(viewModel.GameId);

            if (game == null)
                return HttpNotFound();

            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            if (!game.HasPlayer(player))
            {
                game.AddPlayer(player);
                game.StartGame();
                _gameRepository.Update(game);
            }

            return RedirectToAction("Index", new { id = game.Id });
        }
    }
}