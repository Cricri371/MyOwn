using System;
using System.Data.Objects;
using System.Globalization;
using System.Web;

namespace Cricri371.Framework.Databases.EntityFramework.AspDotNet
{
    /// <summary>
    /// Disposes an ObjectContext created by an AspNetObjectContextManager instance. 
    /// </summary>
    /// <seealso cref="System.Web.IHttpModule" />
    public class AspNetObjectContextDisposalModule : IHttpModule
    {
        /// <summary>
        /// Initializes this HTTP module. 
        /// </summary>
        /// <param name="context">
        /// An <see cref="T:System.Web.HttpApplication" /> that provides access to the methods,
        /// properties, and events common to all application objects within an ASP.NET application
        /// </param>
        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(this.EndOfHttpRequest);
        }

        /// <summary>
        /// Releases any resources held by this module. 
        /// </summary>
        public void Dispose()
        {
            /* No resources held... */
        }

        /// <summary>
        /// Is invoked at the end of a HTTP request. Disposes the shared ObjectContext instance. 
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">      The <see cref="EventArgs" /> instance containing the event data. </param>
        private void EndOfHttpRequest(object sender, EventArgs e)
        {
            DisposeObjectContext();
        }

        /// <summary>
        /// Disposes the shared ObjectContext instance. 
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// DisposeObjectContext() can only be used in a HTTP context.
        /// </exception>
        public static void DisposeObjectContext()
        {
            if (HttpContext.Current == null)
                throw new InvalidOperationException("DisposeObjectContext() can only be used in a HTTP context.");

            string ocKey = "ocm_" + HttpContext.Current.GetHashCode().ToString("x", CultureInfo.InvariantCulture);
            if (HttpContext.Current.Items.Contains(ocKey))
            {
                var objectContext = HttpContext.Current.Items[ocKey] as ObjectContext;

                if (objectContext != null)
                    objectContext.Dispose();

                HttpContext.Current.Items.Remove(ocKey);

                System.Diagnostics.Debug.WriteLine("AspNetObjectContextManager: Disposed ObjectContext");
            }
        }
    }
}