using System;
using System.IO;
using System.IO.Ports;
using System.Text;

namespace Cricri371.Framework.Network.Ports
{
    /// <summary>
    /// Class SerialPortClass. 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class SerialPortClass : IDisposable
    {
        private SerialPort _serialPort;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialPortClass" /> class. 
        /// </summary>
        public SerialPortClass()
        {
            this._serialPort = new SerialPort();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialPortClass" /> class. 
        /// </summary>
        /// <param name="portName"> Name of the port. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public SerialPortClass(string portName)
        {
            try
            {
                this._serialPort = new SerialPort(portName);
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialPortClass" /> class. 
        /// </summary>
        /// <param name="portName"> Name of the port. </param>
        /// <param name="baudRate"> The baud rate. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public SerialPortClass(string portName, int baudRate)
        {
            try
            {
                this._serialPort = new SerialPort(portName, baudRate);
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialPortClass" /> class. 
        /// </summary>
        /// <param name="portName"> Name of the port. </param>
        /// <param name="baudRate"> The baud rate. </param>
        /// <param name="parity">   The parity. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public SerialPortClass(string portName, int baudRate, Parity parity)
        {
            try
            {
                this._serialPort = new SerialPort(portName, baudRate, parity);
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialPortClass" /> class. 
        /// </summary>
        /// <param name="portName"> Name of the port. </param>
        /// <param name="baudRate"> The baud rate. </param>
        /// <param name="parity">   The parity. </param>
        /// <param name="dataBits"> The data bits. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public SerialPortClass(string portName, int baudRate, Parity parity, int dataBits)
        {
            try
            {
                this._serialPort = new SerialPort(portName, baudRate, parity, dataBits);
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialPortClass" /> class. 
        /// </summary>
        /// <param name="portName"> Name of the port. </param>
        /// <param name="baudRate"> The baud rate. </param>
        /// <param name="parity">   The parity. </param>
        /// <param name="dataBits"> The data bits. </param>
        /// <param name="stopBits"> The stop bits. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public SerialPortClass(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            try
            {
                this._serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        #endregion Constructors

        #region Members

        /// <summary>
        /// Gets the bytes to read. 
        /// </summary>
        /// <value> The bytes to read. </value>
        public int BytesToRead
        {
            get { return this._serialPort.BytesToRead; }
        }

        /// <summary>
        /// Gets the bytes to write. 
        /// </summary>
        /// <value> The bytes to write. </value>
        public int BytesToWrite
        {
            get { return this._serialPort.BytesToWrite; }
        }

        /// <summary>
        /// Gets the base stream. 
        /// </summary>
        /// <value> The base stream. </value>
        public Stream BaseStream
        {
            get { return this._serialPort.BaseStream; }
        }

        /// <summary>
        /// Gets or sets the size of the read buffer. 
        /// </summary>
        /// <value> The size of the read buffer. </value>
        public int ReadBufferSize
        {
            get { return this._serialPort.ReadBufferSize; }
            set { this._serialPort.ReadBufferSize = value; }
        }

        /// <summary>
        /// Gets or sets the size of the write buffer. 
        /// </summary>
        /// <value> The size of the write buffer. </value>
        public int WriteBufferSize
        {
            get { return this._serialPort.WriteBufferSize; }
            set { this._serialPort.WriteBufferSize = value; }
        }

        /// <summary>
        /// Gets or sets the read timeout. 
        /// </summary>
        /// <value> The read timeout. </value>
        public int ReadTimeout
        {
            get { return this._serialPort.ReadTimeout; }
            set { this._serialPort.ReadTimeout = value; }
        }

        /// <summary>
        /// Gets or sets the write timeout. 
        /// </summary>
        /// <value> The write timeout. </value>
        public int WriteTimeout
        {
            get { return this._serialPort.WriteTimeout; }
            set { this._serialPort.WriteTimeout = value; }
        }

        /// <summary>
        /// Gets a value indicating whether [cd holding]. 
        /// </summary>
        /// <value> <c> true </c> if [cd holding]; otherwise, <c> false </c>. </value>
        public bool CDHolding
        {
            get { return this._serialPort.CDHolding; }
        }

        /// <summary>
        /// Gets a value indicating whether [CTS holding]. 
        /// </summary>
        /// <value> <c> true </c> if [CTS holding]; otherwise, <c> false </c>. </value>
        public bool CtsHolding
        {
            get { return this._serialPort.CtsHolding; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [discard null]. 
        /// </summary>
        /// <value> <c> true </c> if [discard null]; otherwise, <c> false </c>. </value>
        public bool DiscardNull
        {
            get { return this._serialPort.DiscardNull; }
            set { this._serialPort.DiscardNull = value; }
        }

        /// <summary>
        /// Gets a value indicating whether [data set ready holding]. 
        /// </summary>
        /// <value> <c> true </c> if [data set ready holding]; otherwise, <c> false </c>. </value>
        public bool DataSetReadyHolding
        {
            get { return this._serialPort.DsrHolding; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [data terminal ready enable]. 
        /// </summary>
        /// <value> <c> true </c> if [data terminal ready enable]; otherwise, <c> false </c>. </value>
        public bool DataTerminalReadyEnable
        {
            get { return this._serialPort.DtrEnable; }
            set { this._serialPort.DtrEnable = value; }
        }

        /// <summary>
        /// Gets or sets the encoding. 
        /// </summary>
        /// <value> The encoding. </value>
        public Encoding Encoding
        {
            get { return this._serialPort.Encoding; }
            set { this._serialPort.Encoding = value; }
        }

        /// <summary>
        /// Gets or sets the handshake. 
        /// </summary>
        /// <value> The handshake. </value>
        public Handshake Handshake
        {
            get { return this._serialPort.Handshake; }
            set { this._serialPort.Handshake = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is open. 
        /// </summary>
        /// <value> <c> true </c> if this instance is open; otherwise, <c> false </c>. </value>
        public bool IsOpen
        {
            get { return this._serialPort.IsOpen; }
        }

        /// <summary>
        /// Gets or sets the new line. 
        /// </summary>
        /// <value> The new line. </value>
        public string NewLine
        {
            get { return this._serialPort.NewLine; }
            set { this._serialPort.NewLine = value; }
        }

        /// <summary>
        /// Gets or sets the parity replace. 
        /// </summary>
        /// <value> The parity replace. </value>
        public byte ParityReplace
        {
            get { return this._serialPort.ParityReplace; }
            set { this._serialPort.ParityReplace = value; }
        }

        #endregion Members

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
                this._serialPort.Close();
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
        /// Opens this instance. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void Open()
        {
            try
            {
                this._serialPort.Open();
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (IOException iOEx)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOEx, true));
            }
        }

        #endregion Open

        #region Close

        /// <summary>
        /// Closes this instance. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void Close()
        {
            try
            {
                this._serialPort.Close();
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        #endregion Close

        #region ReadByte

        /// <summary>
        /// Reads the byte. 
        /// </summary>
        /// <returns> The number of read bytes. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int ReadByte()
        {
            try
            {
                return this._serialPort.ReadByte();
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (TimeoutException tE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(tE, true));
            }
        }

        #endregion ReadByte

        #region ReadChar

        /// <summary>
        /// Reads the character. 
        /// </summary>
        /// <returns> The number of read characters. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int ReadChar()
        {
            try
            {
                return this._serialPort.ReadChar();
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (TimeoutException tE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(tE, true));
            }
        }

        #endregion ReadChar

        #region ReadByteArray

        /// <summary>
        /// Reads the byte array. 
        /// </summary>
        /// <param name="arrayRead"> The array read. </param>
        /// <param name="offset">    The offset. </param>
        /// <param name="count">     The count. </param>
        /// <returns> The number of read byte. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int ReadByteArray(byte[] arrayRead, int offset, int count)
        {
            try
            {
                return this._serialPort.Read(arrayRead, offset, count);
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentOutOfRangeException aOOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOOE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (TimeoutException tE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(tE, true));
            }
        }

        #endregion ReadByteArray

        #region ReadCharArray

        /// <summary>
        /// Reads the character array. 
        /// </summary>
        /// <param name="arrayRead"> The array read. </param>
        /// <param name="offset">    The offset. </param>
        /// <param name="count">     The count. </param>
        /// <returns> The number of characters. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int ReadCharArray(char[] arrayRead, int offset, int count)
        {
            try
            {
                return this._serialPort.Read(arrayRead, offset, count);
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentOutOfRangeException aOOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOOE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (TimeoutException tE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(tE, true));
            }
        }

        #endregion ReadCharArray

        #region ReadExisting

        /// <summary>
        /// Reads the existing. 
        /// </summary>
        /// <returns> The read bytes. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public string ReadExisting()
        {
            try
            {
                return this._serialPort.ReadExisting();
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        #endregion ReadExisting

        #region ReadLine

        /// <summary>
        /// Reads the line. 
        /// </summary>
        /// <returns> The read line. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public string ReadLine()
        {
            try
            {
                return this._serialPort.ReadLine();
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (TimeoutException tE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(tE, true));
            }
        }

        #endregion ReadLine

        #region ReadTo

        /// <summary>
        /// Reads to. 
        /// </summary>
        /// <param name="message"> The message. </param>
        /// <returns> The string with the content. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public string ReadTo(string message)
        {
            try
            {
                return this._serialPort.ReadTo(message);
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (TimeoutException tE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(tE, true));
            }
        }

        #endregion ReadTo

        #region Write

        /// <summary>
        /// Writes the specified to write. 
        /// </summary>
        /// <param name="toWrite"> To write. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void Write(string toWrite)
        {
            try
            {
                this._serialPort.Write(toWrite);
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (TimeoutException tE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(tE, true));
            }
        }

        #endregion Write

        #region WriteByteArray

        /// <summary>
        /// Writes the byte array. 
        /// </summary>
        /// <param name="arrayToWrite"> The array to write. </param>
        /// <param name="offset">       The offset. </param>
        /// <param name="count">        The count. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void WriteByteArray(byte[] arrayToWrite, int offset, int count)
        {
            try
            {
                this._serialPort.Write(arrayToWrite, offset, count);
            }
            catch (ArgumentOutOfRangeException aOOOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOOOE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (TimeoutException tE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(tE, true));
            }
        }

        #endregion WriteByteArray

        #region WriteCharArray

        /// <summary>
        /// Writes the character array. 
        /// </summary>
        /// <param name="arrayToWrite"> The array to write. </param>
        /// <param name="offset">       The offset. </param>
        /// <param name="count">        The count. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void WriteCharArray(char[] arrayToWrite, int offset, int count)
        {
            try
            {
                this._serialPort.Write(arrayToWrite, offset, count);
            }
            catch (ArgumentOutOfRangeException aOOOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOOOE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (TimeoutException tE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(tE, true));
            }
        }

        #endregion WriteCharArray

        #region WriteLine

        /// <summary>
        /// Writes the line. 
        /// </summary>
        /// <param name="toWrite"> To write. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void WriteLine(string toWrite)
        {
            try
            {
                this._serialPort.WriteLine(toWrite);
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (TimeoutException tE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(tE, true));
            }
        }

        #endregion WriteLine

        #region DiscardOutBuffer

        /// <summary>
        /// Discards the out buffer. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void DiscardOutBuffer()
        {
            try
            {
                this._serialPort.DiscardOutBuffer();
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (IOException iOEx)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOEx, true));
            }
        }

        #endregion DiscardOutBuffer

        #region DiscardInBuffer

        /// <summary>
        /// Discards the in buffer. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void DiscardInBuffer()
        {
            try
            {
                this._serialPort.DiscardInBuffer();
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (IOException iOEx)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOEx, true));
            }
        }

        #endregion DiscardInBuffer

        #region DiscardAllBuffer

        /// <summary>
        /// Discards all buffers. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void DiscardAllBuffers()
        {
            try
            {
                this._serialPort.DiscardOutBuffer();
                this._serialPort.DiscardInBuffer();
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (IOException iOEx)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOEx, true));
            }
        }

        #endregion DiscardAllBuffer
    }
}