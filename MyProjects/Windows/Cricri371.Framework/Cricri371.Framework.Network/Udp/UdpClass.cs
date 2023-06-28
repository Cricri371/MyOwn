using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cricri371.Framework.Network.Udp
{
    /// <summary>
    /// Class UdpClass. 
    /// </summary>
    /// <seealso cref="Cricri371.Framework.Network.NetworkClass" />
    public class UdpClass : NetworkClass
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UdpClass" /> class. 
        /// </summary>
        public UdpClass() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UdpClass" /> class. 
        /// </summary>
        /// <param name="ipAddress">  The ip address. </param>
        /// <param name="portNumber"> The port number. </param>
        public UdpClass(string ipAddress, int portNumber) : base(ipAddress, portNumber)
        {
        }

        #endregion Constructors

        #region Send

        /// <summary>
        /// Sends the specified message to send. 
        /// </summary>
        /// <param name="messageToSend"> The message to send. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool Send(string messageToSend)
        {
            UdpClient clientUdp = null;
            var sent = false;

            try
            {
                if (!string.IsNullOrEmpty(messageToSend))
                {
                    clientUdp = new UdpClient();

                    var messageByteArray = Encoding.ASCII.GetBytes(messageToSend);

                    if (clientUdp.Send(messageByteArray, messageByteArray.Length, this.IPAddressString, this.PortNumber) != 0)
                        sent = true;
                }

                return sent;
            }
            catch (SocketException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ObjectDisposedException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            finally
            {
                if (clientUdp != null)
                    clientUdp.Close();
            }
        }

        #endregion Send

        #region Receive

        /// <summary>
        /// Receives this instance. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void Receive()
        {
            UdpClient clientUdp = null;

            try
            {
                clientUdp = new UdpClient(PortNumber);

                var ipEndPoint = new IPEndPoint(IPAddress.Any, 0);

                var temp = clientUdp.Receive(ref ipEndPoint);

                if (temp.Length == 0)
                    return;

                this.MessageReceived = Encoding.ASCII.GetString(temp);
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (SocketException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            finally
            {
                if (clientUdp != null)
                    clientUdp.Close();
            }
        }

        #endregion Receive
    }
}