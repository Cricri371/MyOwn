using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Cricri371.Framework.Network.Tcp
{
    /// <summary>
    /// Class TcpClientClass. 
    /// </summary>
    /// <seealso cref="Cricri371.Framework.Network.NetworkClass" />
    /// <seealso cref="System.IDisposable" />
    public class TcpClientClass : NetworkClass, IDisposable
    {
        private NetworkStream _networkStream;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpClientClass" /> class. 
        /// </summary>
        public TcpClientClass() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpClientClass" /> class. 
        /// </summary>
        /// <param name="ipAddress">  The ip address. </param>
        /// <param name="portNumber"> The port number. </param>
        public TcpClientClass(string ipAddress, int portNumber) : base(ipAddress, portNumber)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpClientClass" /> class. 
        /// </summary>
        /// <param name="threadClient"> The thread client. </param>
        /// <param name="clientTcp">    The client TCP. </param>
        public TcpClientClass(Thread threadClient, TcpClient clientTcp)
        {
            this.ClientTcp = clientTcp;
            this.ClientThread = threadClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpClientClass" /> class. 
        /// </summary>
        /// <param name="tcpClient"> The TCP client. </param>
        public TcpClientClass(TcpClient tcpClient)
        {
            this.ClientTcp = tcpClient;
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets the client TCP. 
        /// </summary>
        /// <value> The client TCP. </value>
        public TcpClient ClientTcp { get; set; }

        /// <summary>
        /// Gets or sets the name of the client. 
        /// </summary>
        /// <value> The name of the client. </value>
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets the client thread. 
        /// </summary>
        /// <value> The client thread. </value>
        public Thread ClientThread { get; set; }

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
                if (this.ClientTcp != null)
                    this.ClientTcp.Close();
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

        #region LaunchClient

        /// <summary>
        /// Launches the client. 
        /// </summary>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool LaunchClient()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.IPAddressString) && this.PortNumber != 0)
                {
                    this.ClientTcp = new TcpClient();

                    this.ClientTcp.Connect(this.IPAddressString, this.PortNumber);

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

        #endregion LaunchClient

        #region Send

        /// <summary>
        /// Sends the specified message to send. 
        /// </summary>
        /// <param name="messageToSend"> The message to send. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool Send(string messageToSend)
        {
            try
            {
                this._networkStream = this.ClientTcp.GetStream();

                if (!string.IsNullOrEmpty(messageToSend))
                {
                    var message = Encoding.ASCII.GetBytes(messageToSend);

                    if (this._networkStream.CanWrite)
                    {
                        this._networkStream.Write(message, 0, message.Length);

                        return true;
                    }
                }

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
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (ObjectDisposedException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
        }

        /// <summary>
        /// Sends the specified value to send. 
        /// </summary>
        /// <param name="valueToSend"> The value to send. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool Send(byte[] valueToSend)
        {
            if (valueToSend == null)
                return false;
            else
            {
                try
                {
                    this._networkStream = this.ClientTcp.GetStream();

                    if (this._networkStream.CanWrite)
                    {
                        this._networkStream.Write(valueToSend, 0, valueToSend.Length);

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
                catch (IOException iOE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
                }
                catch (ObjectDisposedException oDE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
                }
            }
        }

        #endregion Send

        #region Receive

        /// <summary>
        /// Receives the specified buffer. 
        /// </summary>
        /// <param name="buffer"> The buffer. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool Receive(byte[] buffer)
        {
            if (buffer == null)
                return false;
            else
            {
                try
                {
                    int lengthReceived = 0;
                    int messageLengthReceived = 0;

                    if (this._networkStream.CanRead)
                    {
                        do
                        {
                            messageLengthReceived = this._networkStream.Read(buffer, 0, buffer.Length);
                            lengthReceived += messageLengthReceived;
                        }
                        while (this._networkStream.DataAvailable);

                        if (lengthReceived != 0)
                            return true;
                    }

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
                catch (IOException iOE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
                }
                catch (ObjectDisposedException oDE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
                }
            }
        }

        /// <summary>
        /// Receives the specified buffer size. 
        /// </summary>
        /// <param name="bufferSize"> Size of the buffer. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool Receive(int bufferSize)
        {
            try
            {
                int lengthReceived = 0;

                this._networkStream = this.ClientTcp.GetStream();

                if (this._networkStream.CanRead)
                {
                    byte[] buffer = new byte[bufferSize];

                    this.MessageReceived = string.Empty;

                    int messageLengthReceived = 0;

                    do
                    {
                        messageLengthReceived = this._networkStream.Read(buffer, 0, buffer.Length);

                        this.MessageReceived += string.Concat(this.MessageReceived, Encoding.ASCII.GetString(buffer, 0, messageLengthReceived));

                        lengthReceived += messageLengthReceived;
                    }
                    while (this._networkStream.DataAvailable);

                    if (lengthReceived != 0)
                        return true;
                }

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
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (ObjectDisposedException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
            catch (NullReferenceException nRE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nRE, true));
            }
        }

        #endregion Receive

        #region CloseClient

        /// <summary>
        /// Closes the client. 
        /// </summary>
        public void CloseClient()
        {
            if (this._networkStream != null)
                this._networkStream.Close();

            if (this.ClientTcp != null)
                this.ClientTcp.Close();
        }

        #endregion CloseClient
    }
}