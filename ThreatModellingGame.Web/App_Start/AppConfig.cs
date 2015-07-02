using System.Configuration;

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
}