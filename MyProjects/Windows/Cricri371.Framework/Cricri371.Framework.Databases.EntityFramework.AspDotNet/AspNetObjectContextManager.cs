using System;
using System.Data.Objects;
using System.Diagnostics;
using System.Globalization;
using System.Web;
using Cricri371.Framework.Databases.EntityFramework.Common;

namespace Cricri371.Framework.Databases.EntityFramework.AspDotNet
{
    /// <summary>
    /// Creates one ObjectContext instance per HTTP request. This instance is then shared during the
    /// lifespan of the HTTP request.
    /// </summary>
    /// <typeparam name="T"> An object context. </typeparam>
    /// <seealso cref="Cricri371.Framework.Databases.EntityFramework.Common.ObjectContextManager{T}" />
    public sealed class AspNetObjectContextManager<T> : ObjectContextManager<T> where T : ObjectContext, new()
    {
        private object _lockObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetObjectContextManager{T}" /> class. 
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// An AspNetObjectContextManager can only be used in a HTTP context.
        /// </exception>
        public AspNetObjectContextManager()
        {
            if (HttpContext.Current == null)
                throw new InvalidOperationException("An AspNetObjectContextManager can only be used in a HTTP context.");

            this._lockObject = new object();
        }

        /// <summary>
        /// Returns a shared ObjectContext instance. 
        /// </summary>
        /// <value> The object context. </value>
        public override T ObjectContext
        {
            get
            {
                string ocKey = "ocm_" + HttpContext.Current.GetHashCode().ToString("x", CultureInfo.InvariantCulture);

                lock (this._lockObject)
                {
                    if (!HttpContext.Current.Items.Contains(ocKey))
                    {
                        HttpContext.Current.Items.Add(ocKey, new T());

                        Debug.WriteLine("AspNetObjectContextManager: Created new ObjectContext");
                    }
                }

                return HttpContext.Current.Items[ocKey] as T;
            }
        }
    }
}