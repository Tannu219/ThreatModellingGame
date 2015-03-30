using System;
using System.Web;

namespace ThreadModelingGame.Core.Web
{
    public sealed class CookieManager : ICookieManager
    {
        private const string PlayerCookieName = "Player";

        public void IssueNewPlayerCookie(HttpResponseBase httpResponse, Player player)
        {
            var cookie = new HttpCookie(PlayerCookieName)
            {
                HttpOnly = true,
                Expires = DateTime.MaxValue,
            };

            cookie.Values.Add("Id", player.Id);
            cookie.Values.Add("Name", player.Name);

            httpResponse.Cookies.Remove(PlayerCookieName);
            httpResponse.Cookies.Add(cookie);
        }

        public Player ExtractPlayerFromCookie(HttpRequestBase httpRequest)
        {
            try
            {
                var cookie = httpRequest.Cookies[PlayerCookieName];

                return cookie == null ? null : new Player(cookie["Id"]) { Name = cookie["Name"] };
            }
            catch
            {
                httpRequest.Cookies.Remove(PlayerCookieName);
                return null;
            }
        }
    }
}