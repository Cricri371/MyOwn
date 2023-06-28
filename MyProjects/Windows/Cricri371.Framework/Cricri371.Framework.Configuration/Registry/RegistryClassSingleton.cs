namespace Cricri371.Framework.Configuration.Registry
{
    /// <summary>
    /// Singleton of the RegistryClass object 
    /// </summary>
    public static class RegistryClassSingleton
    {
        private static RegistryClass registryClass = null;

        /// <summary>
        /// Gets the instance. 
        /// </summary>
        /// <value> The instance. </value>
        public static RegistryClass Instance
        {
            get
            {
                if (registryClass == null)
                    registryClass = new RegistryClass();

                return registryClass;
            }
        }
    }
}