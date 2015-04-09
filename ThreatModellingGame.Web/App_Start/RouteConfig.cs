using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace ThreatModellingGame.Web
{
    public static class AppConfig
    {
        public static string ApplicationName
        {
            get { return ConfigurationManager.AppSettings["Application_Name"]; }
        }

        public static bool IsProductionEnvironment
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["Is_Production_Environment"]); }
        }
    }

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
