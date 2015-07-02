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

        public PlayerController(ICookieManager cookieManager, IGameRepository gameRepository)
        {
            _cookieManager = cookieManager;
            _gameRepository = gameRepository;
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

            var viewModel = new PlayerViewModel(player, games);

            return View(viewModel);
        }

        [RegisteredPlayer]
        public ActionResult ChangeName()
        {
            var player = _cookieManager.ExtractPlayerFromCookie(Request);
            var viewModel = new ChangePlayerNameViewModel { Name = player.Name };

            return View(viewModel);
        }

        [HttpPost]
        [RegisteredPlayer]
        public ActionResult ChangeName(ChangePlayerNameViewModel viewModel)
        {
            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            if (!ModelState.IsValid)
            {
                return View("ChangeName", viewModel);
            }
            
            player.Name = viewModel.Name;
            _cookieManager.IssueNewPlayerCookie(Response, player);

            return RedirectToAction("Details", "Player");
        }
    }
}