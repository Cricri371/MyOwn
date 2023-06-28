using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Cricri371.Framework.Configuration.AppSettings
{
    #region AppSettingsClass

    /// <summary>
    /// Class to load and manage the App.config file 
    /// </summary>
    public class AppSettingsClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettingsClass" /> class. 
        /// </summary>
        public AppSettingsClass()
        {
            this.AppSettingsConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this.AppSettings = new List<AppSettingObject>();
        }

        /// <summary>
        /// Gets or sets the application settings. 
        /// </summary>
        /// <value> The application settings. </value>
        internal IList<AppSettingObject> AppSettings { get; set; }

        /// <summary>
        /// Gets or sets the application settings configuration. 
        /// </summary>
        /// <value> The application settings configuration. </value>
        internal System.Configuration.Configuration AppSettingsConfig { get; set; }

        #region Write

        /// <summary>
        /// Add/update the key entry in the app.config. If the key doesn't exist, it will be added. 
        /// </summary>
        /// <param name="keyName">  Name of the key to write/add </param>
        /// <param name="newValue"> Boolean value to write/add </param>
        public void Write(string keyName, bool newValue)
        {
            this.Write(keyName, newValue.ToString());
        }

        /// <summary>
        /// Add/update the key entry in the app.config. If the key doesn't exist, it will be added. 
        /// </summary>
        /// <param name="keyName">  Name of the key to write/add </param>
        /// <param name="newValue"> Integer value to write/add </param>
        public void Write(string keyName, int newValue)
        {
            this.Write(keyName, newValue.ToString());
        }

        /// <summary>
        /// Add/update the key entry in the app.config. If the key doesn't exist, it will be added. 
        /// </summary>
        /// <param name="keyName">  Name of the key to write/add </param>
        /// <param name="newValue"> Decimal value to write/add </param>
        public void Write(string keyName, decimal newValue)
        {
            this.Write(keyName, newValue.ToString());
        }

        /// <summary>
        /// Add/update the key entry in the app.config. If the key doesn't exist, it will be added. 
        /// </summary>
        /// <param name="keyName">  Name of the key to write/add </param>
        /// <param name="newValue"> Double value to write/add </param>
        public void Write(string keyName, double newValue)
        {
            this.Write(keyName, newValue.ToString());
        }

        /// <summary>
        /// Add/update the key entry in the app.config. If the key doesn't exist, it will be added. 
        /// </summary>
        /// <param name="keyName">  Name of the key to write/add </param>
        /// <param name="newValue"> DateTime value to write/add </param>
        public void Write(string keyName, DateTime newValue)
        {
            this.Write(keyName, newValue.ToString());
        }

        /// <summary>
        /// Add/update the key entry in the app.config. If the key doesn't exist, it will be added. 
        /// </summary>
        /// <param name="keyName">  Name of the key to write/add </param>
        /// <param name="newValue"> String value to write/add </param>
        public void Write(string keyName, string newValue)
        {
            if (this.KeyExists(keyName))
            {
                this.AppSettings.First(a => a.Name == keyName).Value = newValue;
                this.AppSettingsConfig.AppSettings.Settings[keyName].Value = newValue;
            }
            else
            {
                this.AppSettings.Add(new AppSettingObject()
                {
                    Name = keyName,
                    Value = newValue
                });
                this.AppSettingsConfig.AppSettings.Settings.Add(keyName, newValue);
            }
        }

        #endregion Write

        #region Save

        /// <summary>
        /// Save the values in the app.config 
        /// </summary>
        public void Save()
        {
            this.AppSettingsConfig.Save(ConfigurationSaveMode.Full);
        }

        #endregion Save

        #region Load

        /// <summary>
        /// Load the appsetting values in memory based on the app.config 
        /// </summary>
        public void Load()
        {
            foreach (var key in this.AppSettingsConfig.AppSettings.Settings.AllKeys)
            {
                this.AppSettings.Add(new AppSettingObject()
                {
                    Name = key,
                    Value = this.AppSettingsConfig.AppSettings.Settings[key].Value
                });
            }
        }

        #endregion Load

        #region KeyExists

        /// <summary>
        /// Check that the key exists in the app.config 
        /// </summary>
        /// <param name="keyName"> Name of the key to find in the app.config </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool KeyExists(string keyName)
        {
            return this.AppSettings.Where(a => a.Name == keyName).Count() == 0 ? false : true;
        }

        #endregion KeyExists

        #region Remove

        /// <summary>
        /// Remove the element with the given key name 
        /// </summary>
        /// <param name="keyName"> Name of the key to remove </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void Remove(string keyName)
        {
            if (this.KeyExists(keyName))
            {
                var selectedObject = this.AppSettings.First(aPS => aPS.Name == keyName);

                this.AppSettings.Remove(selectedObject);

                this.AppSettingsConfig.AppSettings.Settings.Remove(keyName);
            }
            else
                throw new ExceptionClass(string.Format("Missing key {0} in the config file", keyName));
        }

        #endregion Remove

        #region Get typed values

        #region GetBooleanValue

        /// <summary>
        /// Get the value with the given key name. 
        /// </summary>
        /// <param name="keyName"> Name of the key to find </param>
        /// <returns> The converted value in boolean which corresponds to the given key </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool GetBooleanValue(string keyName)
        {
            if (this.KeyExists(keyName))
                return Convert.ToBoolean(this.AppSettings.First(k => k.Name == keyName).Value);
            else
                throw new ExceptionClass(string.Format("Missing key {0} in the config file", keyName));
        }

        #endregion GetBooleanValue

        #region GetStringValue

        /// <summary>
        /// Get the value with the given key name. 
        /// </summary>
        /// <param name="keyName"> Name of the key to find </param>
        /// <returns> The converted value in string which corresponds to the given key </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public string GetStringValue(string keyName)
        {
            if (this.KeyExists(keyName))
                return Convert.ToString(this.AppSettings.First(k => k.Name == keyName).Value);
            else
                throw new ExceptionClass(string.Format("Missing key {0} in the config file", keyName));
        }

        #endregion GetStringValue

        #region GetDateTimeValue

        /// <summary>
        /// Get the value with the given key name. 
        /// </summary>
        /// <param name="keyName"> Name of the key to find </param>
        /// <returns> The converted value in DateTime which corresponds to the given key </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public DateTime GetDateTimeValue(string keyName)
        {
            if (this.KeyExists(keyName))
                return Convert.ToDateTime(this.AppSettings.First(k => k.Name == keyName).Value);
            else
                throw new ExceptionClass(string.Format("Missing key {0} in the config file", keyName));
        }

        /// <summary>
        /// Get the value with the given key name. 
        /// </summary>
        /// <param name="keyName"> Name of the key to find </param>
        /// <param name="format">  Format of the date to retrieve </param>
        /// <returns> The converted value in DateTime which corresponds to the given key </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public DateTime GetDateTimeValue(string keyName, string format)
        {
            if (this.KeyExists(keyName))
                return Convert.ToDateTime(this.AppSettings.First(k => k.Name == keyName).Value);
            else
                throw new ExceptionClass(string.Format("Missing key {0} in the config file", keyName));
        }

        #endregion GetDateTimeValue

        #region GetDoubleValue

        /// <summary>
        /// Get the value with the given key name. 
        /// </summary>
        /// <param name="keyName"> Name of the key to find </param>
        /// <returns> The converted value in double which corresponds to the given key </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public double GetDoubleValue(string keyName)
        {
            if (this.KeyExists(keyName))
                return Convert.ToDouble(this.AppSettings.First(k => k.Name == keyName).Value);
            else
                throw new ExceptionClass(string.Format("Missing key {0} in the config file", keyName));
        }

        #endregion GetDoubleValue

        #region GetDecimalValue

        /// <summary>
        /// Get the value with the given key name. 
        /// </summary>
        /// <param name="keyName"> Name of the key to find </param>
        /// <returns> The converted value in decimal which corresponds to the given key </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public decimal GetDecimalValue(string keyName)
        {
            if (this.KeyExists(keyName))
                return Convert.ToDecimal(this.AppSettings.First(k => k.Name == keyName).Value);
            else
                throw new ExceptionClass(string.Format("Missing key {0} in the config file", keyName));
        }

        #endregion GetDecimalValue

        #region GetIntegerValue

        /// <summary>
        /// Get the value with the given key name. 
        /// </summary>
        /// <param name="keyName"> Name of the key to find </param>
        /// <returns> The converted value in integer which corresponds to the given key </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int GetIntegerValue(string keyName)
        {
            if (this.KeyExists(keyName))
                return Convert.ToInt32(this.AppSettings.First(k => k.Name == keyName).Value);
            else
                throw new ExceptionClass(string.Format("Missing key {0} in the config file", keyName));
        }

        #endregion GetIntegerValue

        #endregion Get typed values
    }

    #endregion AppSettingsClass
}