using System.Data.Objects;

namespace Cricri371.Framework.Databases.EntityFramework.Common
{
    /// <summary>
    /// Abstract base class for all other ObjectContextManager classes. 
    /// </summary>
    /// <typeparam name="T"> An object context. </typeparam>
    public abstract class ObjectContextManager<T> where T : ObjectContext, new()
    {
        /// <summary>
        /// Gets the object context. 
        /// </summary>
        /// <value> The object context. </value>
        public abstract T ObjectContext
        {
            get;
        }
    }
}