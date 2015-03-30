using System.Web;

namespace ThreadModelingGame.Core.Web
{
    public interface ICookieManager
    {
        void IssueNewPlayerCookie(HttpResponseBase httpResponse, Player player);

        Player ExtractPlayerFromCookie(HttpRequestBase httpRequest);
    }
}