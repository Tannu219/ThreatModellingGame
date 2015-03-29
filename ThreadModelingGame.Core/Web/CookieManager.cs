using System;
using System.Web;

namespace ThreadModelingGame.Core.Web
{
    public sealed class CookieManager : ICookieManager
    {
        private const string PlayerCookieName = "Player";

        public void IssueNewPlayerCookie(HttpResponseBase httpResponse, Player player)
        {
            var playerCookie = new HttpCookie(PlayerCookieName)
            {
                HttpOnly = true,
                Expires = DateTime.MaxValue
            };

            playerCookie.Values.Add("Id", player.Id);
            playerCookie.Values.Add("Name", player.Name);

            httpResponse.Cookies.Remove(PlayerCookieName);
            httpResponse.Cookies.Add(playerCookie);
        }

        public Player ExtractPlayerFromCookie(HttpRequestBase httpRequest)
        {
            try
            {
                var playerCookie = httpRequest.Cookies[PlayerCookieName];

                if (playerCookie == null)
                    return null;

                var id = playerCookie["Id"];
                var name = playerCookie["Name"];

                return new Player(id, name);
            }
            catch
            {
                httpRequest.Cookies.Remove(PlayerCookieName);
                return null;
            }
        }
    }
}