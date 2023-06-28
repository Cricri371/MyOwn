using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Cricri371.Framework.Configuration.Registry
{
    #region RegistryClass

    /// <summary>
    /// Class RegistryClass. 
    /// </summary>
    /// <seealso cref="Cricri371.Framework.Configuration.IConfiguration" />
    public class RegistryClass : IConfiguration
    {
        private RegistryKey _registryKey;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryClass" /> class. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public RegistryClass()
        {
            try
            {
                this.PathRegistry = string.Format(CultureInfo.InvariantCulture, @"Software\{0}\{1}", Application.CompanyName, Application.ProductName);

                if ((this._registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(this.PathRegistry, true)) == null)
                    this._registryKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(this.PathRegistry);
            }
            catch (ObjectDisposedException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (UnauthorizedAccessException uAAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAAE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryClass" /> class. 
        /// </summary>
        /// <param name="registryKeyPath"> The registry key path. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public RegistryClass(string registryKeyPath)
        {
            try
            {
                this.PathRegistry = registryKeyPath;

                if ((this._registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(this.PathRegistry, true)) == null)
                    this._registryKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(this.PathRegistry);
            }
            catch (ObjectDisposedException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (UnauthorizedAccessException uAAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAAE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets the path registry. 
        /// </summary>
        /// <value> The path registry. </value>
        public string PathRegistry { get; set; }

        #region RetrieveSubKeyNames

        /// <summary>
        /// Retrieves the sub key names. 
        /// </summary>
        /// <returns> The list of sub keys. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public IList<string> RetrieveSubKeyNames()
        {
            if (this._registryKey != null)
            {
                try
                {
                    return new List<string>(this._registryKey.GetSubKeyNames());
                }
                catch (SecurityException sE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
                }
                catch (ObjectDisposedException oDE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
                }
                catch (UnauthorizedAccessException uAE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
                }
                catch (IOException iE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iE, true));
                }
            }
            else
                return new List<string>();
        }

        #endregion RetrieveSubKeyNames

        #region Read

        /// <summary>
        /// Reads the specified key. 
        /// </summary>
        /// <param name="key"> The key. </param>
        /// <returns> The value for the key. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public string Read(string key)
        {
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    var keyData = this._registryKey.GetValue(key);

                    if (keyData != null)
                        return keyData.ToString();
                }

                return string.Empty;
            }
            catch (ObjectDisposedException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (UnauthorizedAccessException uAAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAAE, true));
            }
        }

        #endregion Read

        #region Write

        /// <summary>
        /// Writes the specified key. 
        /// </summary>
        /// <param name="key">      The key. </param>
        /// <param name="newValue"> The new value. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool Write(string key, string newValue)
        {
            try
            {
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(newValue))
                {
                    this._registryKey.SetValue(key, newValue);
                    return true;
                }
                else
                    return false;
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ObjectDisposedException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (UnauthorizedAccessException uAAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAAE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
        }

        #endregion Write

        #region Close

        /// <summary>
        /// Closes this instance. 
        /// </summary>
        public void Close()
        {
            if (this._registryKey != null)
                this._registryKey.Close();
        }

        #endregion Close
    }

    #endregion RegistryClass
}