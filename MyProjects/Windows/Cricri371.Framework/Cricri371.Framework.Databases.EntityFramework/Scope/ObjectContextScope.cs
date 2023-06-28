using System;
using System.Data.Objects;
using System.Threading;

namespace Cricri371.Framework.Databases.EntityFramework.Scope
{
    /// <summary>
    /// Defines a scope wherein only one ObjectContext instance is created, and shared by all of
    /// those who use it. Instances of this class are supposed to be used in a using() statement.
    /// </summary>
    /// <typeparam name="T"> An ObjectContext type. </typeparam>
    /// <seealso cref="System.IDisposable" />
    public class ObjectContextScope<T> : IDisposable where T : ObjectContext, new()
    {
        [ThreadStatic]
        private static ObjectContextScope<T> _currentScope;

        private T _objectContext;
        private bool _isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectContextScope{T}" /> class. 
        /// </summary>
        public ObjectContextScope()
            : this(false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectContextScope{T}" /> class. 
        /// </summary>
        /// <param name="saveAllChangesAtEndOfScope">
        /// if set to <c> true </c> [save all changes at end of scope].
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        /// ObjectContextScope instances cannot be nested.
        /// </exception>
        public ObjectContextScope(bool saveAllChangesAtEndOfScope)
        {
            if (_currentScope != null && !_currentScope._isDisposed)
                throw new InvalidOperationException("ObjectContextScope instances cannot be nested.");

            this.SaveAllChangesAtEndOfScope = saveAllChangesAtEndOfScope;

            this._objectContext = new T();
            this._isDisposed = false;

            Thread.BeginThreadAffinity();

            System.Diagnostics.Debug.WriteLine("Begin of ObjectContextScope");

            _currentScope = this;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [save all changes at end of scope]. 
        /// </summary>
        /// <value>
        /// <c> true </c> if [save all changes at end of scope]; otherwise, <c> false </c>.
        /// </value>
        public bool SaveAllChangesAtEndOfScope { get; set; }

        /// <summary>
        /// Gets the current object context. 
        /// </summary>
        /// <value> The current object context. </value>
        protected internal static T CurrentObjectContext
        {
            get { return _currentScope != null ? _currentScope._objectContext : null; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the ObjectContext. 
        /// </summary>
        /// <param name="disposing">
        /// <c> true </c> to release both managed and unmanaged resources; <c> false </c> to release
        /// only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _currentScope = null;

                Thread.EndThreadAffinity();

                try
                {
                    if (this.SaveAllChangesAtEndOfScope)
                        this._objectContext.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    this._objectContext.Dispose();
                    this._isDisposed = disposing;
                }

                System.Diagnostics.Debug.WriteLine("End of ObjectContextScope");
            }
        }
    }
}