using System.Data.Objects;
using Cricri371.Framework.Databases.EntityFramework.Common;

namespace Cricri371.Framework.Databases.EntityFramework.Program
{
    /// <summary>
    /// Maintains an ObjectContext instance in static field. This instance is then shared during the
    /// lifespan of the AppDomain.
    /// </summary>
    /// <typeparam name="T"> An object context. </typeparam>
    /// <seealso cref="Cricri371.Framework.Databases.EntityFramework.Common.ObjectContextManager{T}" />
    public sealed class StaticObjectContextManager<T> : ObjectContextManager<T> where T : ObjectContext, new()
    {
        private static T _objectContext;
        private static object _lockObject = new object();

        /// <summary>
        /// Returns a shared ObjectContext instance. 
        /// </summary>
        /// <value> The object context. </value>
        public override T ObjectContext
        {
            get
            {
                lock (_lockObject)
                {
                    if (_objectContext == null)
                        _objectContext = new T();
                }

                return _objectContext;
            }
        }
    }
}