using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Web.Administration;

namespace Cricri371.Framework.Tools.IIS
{
    /// <summary>
    /// Class IisClass. 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class IisClass : IDisposable
    {
        private ServerManager _serverManager;

        #region Construtors

        /// <summary>
        /// Initializes a new instance of the <see cref="IisClass" /> class. 
        /// </summary>
        public IisClass()
        {
            this.OpenIis(string.Empty);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IisClass" /> class. 
        /// </summary>
        /// <param name="serverName"> Name of the server. </param>
        public IisClass(string serverName)
        {
            this.OpenIis(serverName);
        }

        #endregion Construtors

        #region GetWebSites

        /// <summary>
        /// Gets the web sites. 
        /// </summary>
        /// <value> The web sites. </value>
        public IList<Site> WebSites
        {
            get
            {
                var sites = new List<Site>();
                this._serverManager.Sites.ToList().ForEach(s => sites.Add(s));

                return sites;
            }
        }

        #endregion GetWebSites

        #region Dispose

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
                if (this._serverManager != null)
                    this._serverManager.Dispose();
            }
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

        #endregion Dispose

        #region Open

        /// <summary>
        /// Opens the IIS. 
        /// </summary>
        /// <param name="serverName"> Name of the server. </param>
        public void OpenIis(string serverName)
        {
            if (!string.IsNullOrEmpty(serverName))
                this._serverManager = ServerManager.OpenRemote(serverName);
            else
                this._serverManager = new ServerManager();
        }

        #endregion Open

        #region GetWebSite

        /// <summary>
        /// Gets the web site. 
        /// </summary>
        /// <param name="webSiteName"> Name of the web site. </param>
        /// <returns> The site. </returns>
        public Site GetWebSite(string webSiteName)
        {
            return this._serverManager.Sites[webSiteName];
        }

        #endregion GetWebSite

        #region StartWebSite

        /// <summary>
        /// Starts the web site. 
        /// </summary>
        /// <param name="webSiteName"> Name of the web site. </param>
        /// <returns> The objectState. </returns>
        public ObjectState StartWebSite(string webSiteName)
        {
            return this._serverManager.Sites[webSiteName].Start();
        }

        /// <summary>
        /// Starts the web site. 
        /// </summary>
        /// <param name="webSite"> The web site. </param>
        /// <returns> The objectState. </returns>
        public static ObjectState StartWebSite(Site webSite)
        {
            return webSite.Start();
        }

        #endregion StartWebSite

        #region StoptWebSite

        /// <summary>
        /// Stops the web site. 
        /// </summary>
        /// <param name="webSiteName"> Name of the web site. </param>
        /// <returns> The objectState. </returns>
        public ObjectState StopWebSite(string webSiteName)
        {
            return this._serverManager.Sites[webSiteName].Stop();
        }

        /// <summary>
        /// Stops the web site. 
        /// </summary>
        /// <param name="webSite"> The web site. </param>
        /// <returns> The objectState. </returns>
        public static ObjectState StopWebSite(Site webSite)
        {
            return webSite.Stop();
        }

        #endregion StoptWebSite

        #region WebSiteExists

        /// <summary>
        /// Webs the site exists. 
        /// </summary>
        /// <param name="webSiteName"> Name of the web site. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool WebSiteExists(string webSiteName)
        {
            return this._serverManager.Sites.Count(s => s.Name == webSiteName) == 1;
        }

        /// <summary>
        /// Webs the site exists. 
        /// </summary>
        /// <param name="webSite"> The web site. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool WebSiteExists(Site webSite)
        {
            return this._serverManager.Sites.Count(s => s == webSite) == 1;
        }

        #endregion WebSiteExists

        #region CreateWebSite

        /// <summary>
        /// Creates the web site. 
        /// </summary>
        /// <param name="webSiteName">  Name of the web site. </param>
        /// <param name="physicalPath"> The physical path. </param>
        /// <param name="portNumber">   The port number. </param>
        /// <param name="autoStart">    if set to <c> true </c> [automatic start]. </param>
        /// <returns> The site. </returns>
        /// <exception cref="ExceptionClass"> Website already exists. Please change the name </exception>
        public Site CreateWebSite(string webSiteName, string physicalPath, int portNumber, bool autoStart)
        {
            if (!this.WebSiteExists(webSiteName))
            {
                var site = this._serverManager.Sites.Add(webSiteName, physicalPath, portNumber);

                site.ServerAutoStart = autoStart;

                this._serverManager.CommitChanges();

                return site;
            }
            else
                throw new ExceptionClass("Website already exists. Please change the name");
        }

        #endregion CreateWebSite

        #region RemoveWebSite

        /// <summary>
        /// Removes the web site. 
        /// </summary>
        /// <param name="webSite"> The web site. </param>
        /// <exception cref="ExceptionClass"> Check that the given website exists </exception>
        public void RemoveWebSite(Site webSite)
        {
            if (this.WebSiteExists(webSite))
                this._serverManager.Sites.Remove(webSite);
            else
                throw new ExceptionClass("Check that the given website exists");
        }

        /// <summary>
        /// Removes the web site. 
        /// </summary>
        /// <param name="webSiteName"> Name of the web site. </param>
        /// <exception cref="ExceptionClass"> Check that the given website exists </exception>
        public void RemoveWebSite(string webSiteName)
        {
            if (this.WebSiteExists(webSiteName))
                this._serverManager.Sites.Remove(this.GetWebSite(webSiteName));
            else
                throw new ExceptionClass("Check that the given website exists");
        }

        #endregion RemoveWebSite

        #region GetWebSiteState

        /// <summary>
        /// Gets the state of the web site. 
        /// </summary>
        /// <param name="webSiteName"> Name of the web site. </param>
        /// <returns> The objectState. </returns>
        /// <exception cref="ExceptionClass"> Check that the given website exists </exception>
        public ObjectState GetWebSiteState(string webSiteName)
        {
            if (this.WebSiteExists(webSiteName))
                return this._serverManager.Sites[webSiteName].State;
            else
                throw new ExceptionClass("Check that the given website exists");
        }

        /// <summary>
        /// Gets the state of the web site. 
        /// </summary>
        /// <param name="webSite"> The web site. </param>
        /// <returns> The objectState. </returns>
        public static ObjectState GetWebSiteState(Site webSite)
        {
            return webSite.State;
        }

        #endregion GetWebSiteState
    }
}