using System;
using System.Net;
using System.Net.Sockets;

namespace Cricri371.Framework.Network.Tcp
{
    /// <summary>
    /// Class TcpServerClass. 
    /// </summary>
    /// <seealso cref="Cricri371.Framework.Network.NetworkClass" />
    public class TcpServerClass : NetworkClass
    {
        private TcpListener _serverListenerTcp;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpServerClass" /> class. 
        /// </summary>
        public TcpServerClass() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpServerClass" /> class. 
        /// </summary>
        /// <param name="ipAddress">  The ip address. </param>
        /// <param name="portNumber"> The port number. </param>
        public TcpServerClass(string ipAddress, int portNumber)
            : base(ipAddress, portNumber)
        {
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets a value indicating whether [server listener TCP launch]. 
        /// </summary>
        /// <value> <c> true </c> if [server listener TCP launch]; otherwise, <c> false </c>. </value>
        public bool ServerListenerTcpLaunch { get; set; }

        /// <summary>
        /// Gets or sets the client TCP. 
        /// </summary>
        /// <value> The client TCP. </value>
        public TcpClient ClientTcp { get; set; }

        #region LaunchServer

        /// <summary>
        /// Launches the server. 
        /// </summary>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool LaunchServer()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.IPAddressString) && this.PortNumber != 0)
                {
                    this._serverListenerTcp = new TcpListener(IPAddress.Any, PortNumber);

                    this._serverListenerTcp.Start();

                    this.ServerListenerTcpLaunch = true;

                    return true;
                }
                else
                    return false;
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (SocketException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (ObjectDisposedException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        #endregion LaunchServer

        #region ListenTcp

        /// <summary>
        /// Listens the TCP. 
        /// </summary>
        /// <returns> The listened Tcp client. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public TcpClient ListenTcp()
        {
            try
            {
                this.PendingTcp();

                if (this.AcceptTcp())
                    return this.ClientTcp;
                else
                    return null;
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (SocketException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (ObjectDisposedException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        #endregion ListenTcp

        #region AcceptTcp

        /// <summary>
        /// Accepts the TCP. 
        /// </summary>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool AcceptTcp()
        {
            try
            {
                if (this.ServerListenerTcpLaunch)
                {
                    this.ClientTcp = this._serverListenerTcp.AcceptTcpClient();

                    return true;
                }
                else
                    return false;
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (SocketException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
        }

        #endregion AcceptTcp

        #region PendingTcp

        /// <summary>
        /// Pendings the TCP. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void PendingTcp()
        {
            try
            {
                var clientFound = false;

                while (!clientFound && this.ServerListenerTcpLaunch)
                {
                    if (this._serverListenerTcp.Pending())
                        clientFound = true;

                    System.Threading.Thread.Sleep(50);
                }
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        #endregion PendingTcp

        #region CloseServer

        /// <summary>
        /// Closes the server. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void CloseServer()
        {
            try
            {
                this.ServerListenerTcpLaunch = false;

                if (this._serverListenerTcp != null)
                    this._serverListenerTcp.Stop();

                if (this.ClientTcp != null)
                    this.ClientTcp.Close();
            }
            catch (SocketException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
        }

        #endregion CloseServer

        #region CloseClient

        /// <summary>
        /// Closes the client. 
        /// </summary>
        public void CloseClient()
        {
            if (this.ClientTcp != null)
                this.ClientTcp.Close();
        }

        #endregion CloseClient
    }
}