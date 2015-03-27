using System.Web;

namespace ThreadModelingGame.Core.Web
{
    public interface ICookieManager
    {
        void IssueNewCookie(HttpResponseBase httpResponse, Player player);
        Player ExtractFromCookie(HttpRequestBase httpRequest);
    }
}