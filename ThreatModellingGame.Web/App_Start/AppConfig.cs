using System.Configuration;

namespace ThreatModellingGame.Web
{
    public static class AppConfig
    {
        public static bool IsProductionEnvironment
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["Is_Production_Environment"]); }
        }
    }
}