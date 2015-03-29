using System.Web.Mvc;
using ThreadModelingGame.Core.Web;
using ThreatModelingGame.Web.Filters;
using ThreatModelingGame.Web.Models;

namespace ThreatModelingGame.Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ICookieManager _cookieManager;

        public PlayerController(ICookieManager cookieManager)
        {
            _cookieManager = cookieManager;
        }

        public ActionResult Register()
        {
            return View(new PlayerModel());
        }

        [HttpPost]
        public ActionResult Register(PlayerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var player = model.ToPlayer();

            _cookieManager.IssueNewPlayerCookie(Response, player);

            return RedirectToAction("Details");
        }

        [RegisteredPlayer]
        public ActionResult Details()
        {
            var player = _cookieManager.ExtractPlayerFromCookie(Request);

            return View(new PlayerModel(player));
        }
    }
}