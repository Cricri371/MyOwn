namespace Cricri371.Framework.Configuration.AppSettings
{
    /// <summary>
    /// Singleton of the AppSettingsClass object 
    /// </summary>
    public static class AppSettingsSingleton
    {
        private static AppSettingsClass appSettingsClass = null;

        /// <summary>
        /// Gets the instance. 
        /// </summary>
        /// <value> The instance. </value>
        public static AppSettingsClass Instance
        {
            get
            {
                if (appSettingsClass == null)
                    appSettingsClass = new AppSettingsClass();

                return appSettingsClass;
            }
        }
    }
}