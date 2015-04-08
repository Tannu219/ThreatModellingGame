using System.Web;

namespace ThreatModellingGame.Core.Web
{
    public interface ICookieManager
    {
        void IssueNewPlayerCookie(HttpResponseBase httpResponse, Player player);

        Player ExtractPlayerFromCookie(HttpRequestBase httpRequest);
    }
}