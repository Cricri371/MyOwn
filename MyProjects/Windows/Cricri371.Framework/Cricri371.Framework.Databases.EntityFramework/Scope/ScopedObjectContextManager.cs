using System;
using System.Data.Objects;
using Cricri371.Framework.Databases.EntityFramework.Common;

namespace Cricri371.Framework.Databases.EntityFramework.Scope
{
    /// <summary>
    /// Class ScopedObjectContextManager. 
    /// </summary>
    /// <typeparam name="T"> An object context. </typeparam>
    /// <seealso cref="Cricri371.Framework.Databases.EntityFramework.Common.ObjectContextManager{T}" />
    /// <seealso cref="System.IDisposable" />
    public class ScopedObjectContextManager<T> : ObjectContextManager<T>, IDisposable where T : ObjectContext, new()
    {
        private T _objectContext;

        /// <summary>
        /// Returns the ObjectContext instance that belongs to the current ObjectContextScope. If
        /// currently no ObjectContextScope exists, a local instance of an ObjectContext class is returned.
        /// </summary>
        /// <value> The object context. </value>
        public override T ObjectContext
        {
            get
            {
                if (ObjectContextScope<T>.CurrentObjectContext != null)
                    return ObjectContextScope<T>.CurrentObjectContext;
                else
                {
                    if (this._objectContext == null)
                        this._objectContext = new T();

                    return this._objectContext;
                }
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources. 
        /// </summary>
        /// <param name="disposing">
        /// <c> true </c> to release both managed and unmanaged resources; <c> false </c> to release
        /// only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._objectContext != null)
                    this._objectContext.Dispose();

                if (ObjectContextScope<T>.CurrentObjectContext != null)
                    ObjectContextScope<T>.CurrentObjectContext.Dispose();
            }

            // free native resources
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}