namespace Cricri371.Framework.Databases.EntityFramework.Program
{
    /// <summary>
    /// Class EntityContext. 
    /// </summary>
    /// <typeparam name="T"> An object context. </typeparam>
    public static class EntityContext<T> where T : global::System.Data.Objects.ObjectContext, new()
    {
        private static StaticObjectContextManager<T> _database;

        /// <summary>
        /// Gets the get entity instance. 
        /// </summary>
        /// <value> The get entity instance. </value>
        private static StaticObjectContextManager<T> GetEntityInstance
        {
            get
            {
                if (_database == null)
                    _database = new StaticObjectContextManager<T>();

                return _database;
            }
        }

        /// <summary>
        /// Gets the get context. 
        /// </summary>
        /// <value> The get context. </value>
        public static T GetContext
        {
            get
            {
                return GetEntityInstance.ObjectContext;
            }
        }
    }
}