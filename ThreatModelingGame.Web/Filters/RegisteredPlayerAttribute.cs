using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;
using System.Web.Security;
using Ninject;
using System.Web;
using System.Web.Mvc;
using ThreadModelingGame.Core.Web;

namespace ThreatModelingGame.Web.Filters
{
    public class RegisteredPlayerAttribute : AuthorizeAttribute
    {
        private readonly ICookieManager _cookieManager;

        public RegisteredPlayerAttribute() 
            : this(NinjectWebCommon.Bootstrapper.Kernel.Get<ICookieManager>())
        {
        }

        public RegisteredPlayerAttribute(ICookieManager cookieManager)
        {
            _cookieManager = cookieManager;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var player = _cookieManager.ExtractPlayerFromCookie(httpContext.Request);

            return player != null;
        }
    }
}