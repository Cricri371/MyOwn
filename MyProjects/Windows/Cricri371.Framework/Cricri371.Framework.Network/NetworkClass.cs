namespace Cricri371.Framework.Network
{
    /// <summary>
    /// Class NetworkClass. 
    /// </summary>
    public class NetworkClass
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkClass" /> class. 
        /// </summary>
        public NetworkClass()
        {
            this.IPAddressString = string.Empty;
            this.MessageReceived = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkClass" /> class. 
        /// </summary>
        /// <param name="ipAddress">  The ip address. </param>
        /// <param name="portNumber"> The port number. </param>
        /// <exception cref="ExceptionClass"> The ip address must be valid </exception>
        public NetworkClass(string ipAddress, int portNumber)
        {
            if (string.IsNullOrEmpty(ipAddress))
                throw new ExceptionClass("The ip address must be valid");

            this.IPAddressString = ipAddress;
            this.PortNumber = portNumber;
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets the port number. 
        /// </summary>
        /// <value> The port number. </value>
        public int PortNumber { get; set; }

        /// <summary>
        /// Gets or sets the ip address string. 
        /// </summary>
        /// <value> The ip address string. </value>
        public string IPAddressString { get; set; }

        /// <summary>
        /// Gets or sets the message received. 
        /// </summary>
        /// <value> The message received. </value>
        public string MessageReceived { get; set; }
    }
}