namespace Ticketing.API
{
    public class AppConfiguration
    {
        public string ValueFromAppSettings
        {
            get;
            set;
        }
        public string ValueFromKubernetesEnvVariable
        {
            get;
            set;
        }
        public string ValueOverride
        {
            get;
            set;
        }
        public string ValueFromKubernetesSecret
        {
            get;
            set;
        }
    }
}