﻿using System.Web.Mvc;
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

        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View(new ChangePlayerNameViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(ChangePlayerNameViewModel viewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var player = new Player(viewModel.Name);
            _cookieManager.IssueNewPlayerCookie(Response, player);

            return string.IsNullOrEmpty(returnUrl) 
                ? RedirectToAction("Details", "Player") 
                : RedirectToLocal(returnUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            
            return RedirectToAction("Details", "Player");
        }

        [RegisteredPlayer]
        public ActionResult Details()
        {
            var player = _cookieManager.ExtractPlayerFromCookie(Request);
            var games = _gameRepository.GetGamesByPlayer(player);

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
        [ValidateAntiForgeryToken]
        public ActionResult ChangeName(ChangePlayerNameViewModel viewModel)
        {
            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            if (!ModelState.IsValid)
            {
                return View("ChangeName", viewModel);
            }
            
            player.ChangeName(viewModel.Name);
            _cookieManager.IssueNewPlayerCookie(Response, player);

            return RedirectToAction("Details", "Player");
        }
    }
}