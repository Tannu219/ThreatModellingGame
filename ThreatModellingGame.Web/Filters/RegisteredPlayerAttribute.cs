using System.Web;
using System.Web.Mvc;
using ThreatModellingGame.Core.Web;

namespace ThreatModellingGame.Web.Filters
{
    public class RegisteredPlayerAttribute : AuthorizeAttribute
    {
        private readonly ICookieManager _cookieManager;

        public RegisteredPlayerAttribute()
            : this(DependencyResolver.Current.GetService<ICookieManager>())
        {
            
        }

        public RegisteredPlayerAttribute(ICookieManager cookieManager)
        {
            _cookieManager = cookieManager;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var playerId = _cookieManager.ExtractPlayerFromCookie(httpContext.Request);

            return playerId != null;
        }
    }
}