namespace Cricri371.Framework.Logging
{
    /// <summary>
    /// Singleton of the LogClass object 
    /// </summary>
    public static class LogClassSingleton
    {
        private static LogClass _logClass = null;

        /// <summary>
        /// Gets the instance. 
        /// </summary>
        /// <value> The instance. </value>
        public static LogClass Instance
        {
            get
            {
                if (_logClass == null)
                    _logClass = new LogClass();

                return _logClass;
            }
        }
    }
}