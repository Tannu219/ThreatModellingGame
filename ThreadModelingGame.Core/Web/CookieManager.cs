using System;
using System.Web;

namespace ThreadModelingGame.Core.Web
{
    public class CookieManager : ICookieManager
    {
        private readonly ISerializer _serializer;
        private const string PlayerCookieName = "Player";

        public CookieManager(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public void IssueNewCookie(HttpResponseBase httpResponse, Player player)
        {
            var playerCookie = new HttpCookie(PlayerCookieName)
            {
                HttpOnly = true,
                Expires = DateTime.MaxValue,
                Value = _serializer.Serialize(player)
            };

            httpResponse.Cookies.Remove(PlayerCookieName);
            httpResponse.Cookies.Add(playerCookie);
        }

        public Player ExtractFromCookie(HttpRequestBase httpRequest)
        {
            try
            {
                var playerCookie = httpRequest.Cookies[PlayerCookieName];

                return playerCookie == null
                    ? null
                    : _serializer.Deserialize<Player>(playerCookie.Value);
            }
            catch
            {
                httpRequest.Cookies.Remove(PlayerCookieName);
                return null;
            }
        }
    }
}