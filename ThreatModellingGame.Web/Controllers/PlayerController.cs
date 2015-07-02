using System.Web.Mvc;
using ThreatModellingGame.Core;
using ThreatModellingGame.Core.Repositories;
using ThreatModellingGame.Core.Web;
using ThreatModellingGame.Web.Filters;
using ThreatModellingGame.Web.ViewModels;

namespace ThreatModellingGame.Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ICookieManager _cookieManager;
        private readonly IGameRepository _gameRepository;
        private readonly IDealer _dealer;

        public PlayerController(ICookieManager cookieManager, IGameRepository gameRepository, IDealer dealer)
        {
            _cookieManager = cookieManager;
            _gameRepository = gameRepository;
            _dealer = dealer;
        }

        public ActionResult Register()
        {
            return View(new ChangePlayerNameViewModel());
        }

        [HttpPost]
        public ActionResult Register(ChangePlayerNameViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var player = new Player { Name = viewModel.Name };
            _cookieManager.IssueNewPlayerCookie(Response, player);

            return RedirectToAction("Details", "Player");
        }

        [RegisteredPlayer]
        public ActionResult Details()
        {
            var player = _cookieManager.ExtractPlayerFromCookie(Request);
            var games = _gameRepository.GetGamesByPlayer(player.Id);

            var viewModel = new PlayerDetailsViewModel
            {
                PlayerViewModel = new PlayerViewModel(player, games),
                ChangePlayerNameViewModel = new ChangePlayerNameViewModel { Name = player.Name }
            };

            return View(viewModel);
        }

        [HttpPost]
        [RegisteredPlayer]
        public ActionResult ChangeName([Bind(Include = "ChangePlayerNameViewModel")]PlayerDetailsViewModel viewModel)
        {
            var player = _cookieManager.ExtractPlayerFromCookie(Request);
            var games = _gameRepository.GetGamesByPlayer(player.Id);

            if (!ModelState.IsValid)
            {
                viewModel.PlayerViewModel = new PlayerViewModel(player, games);
                return View("Details", viewModel);
            }

            player.Name = viewModel.ChangePlayerNameViewModel.Name;
            _cookieManager.IssueNewPlayerCookie(Response, player);

            return RedirectToAction("Details", "Player");
        }

        //[HttpPost]
        //public ActionResult CreateGame([Bind(Include = "NewGameViewModel")]PlayerDetailsViewModel viewModel)
        //{
        //    var player = _cookieManager.ExtractPlayerFromCookie(Request);
        //    var games = _gameRepository.GetGamesByPlayer(player.Id);

        //    if (!ModelState.IsValid)
        //    {
        //        viewModel.PlayerViewModel = new PlayerViewModel(player, games);
        //        return View("Details", viewModel);
        //    }

        //    var game = new Game { Name = viewModel.NewGameViewModel.Name };
        //    game.Players.Add(player);

        //    _dealer.DealCards(game);
        //    _gameRepository.Add(game);

        //    return RedirectToAction("Index", "Game", new { id = game.Id });
        //}
    }
}