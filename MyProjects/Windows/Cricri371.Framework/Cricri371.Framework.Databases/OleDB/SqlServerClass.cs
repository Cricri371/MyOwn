using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace Cricri371.Framework.Databases.OleDB
{
    /// <summary>
    /// Class SqlServerClass. 
    /// </summary>
    /// <seealso cref="Cricri371.Framework.Databases.OleDB.OleDbDatabaseClass" />
    public class SqlServerClass : OleDbDatabaseClass
    {
        private int _port = 1433;

        /// <summary>
        /// Gets or sets the ip address. 
        /// </summary>
        /// <value> The ip address. </value>
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the port. 
        /// </summary>
        /// <value> The port. </value>
        public int Port
        {
            get { return this._port; }
            set { this._port = value; }
        }

        #region OpenDatabaseStandard

        /// <summary>
        /// Opens the database standard. 
        /// </summary>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool OpenDatabaseStandard()
        {
            try
            {
                var connectionString = string.Format(CultureInfo.InvariantCulture, "Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};User Id={2};Password={3};Integrated Security=SSPI;", DatabaseSource, DatabaseName, UserName, Password);

                this.OleDatabaseConnection = new OleDbConnection(connectionString);
                this.OleDatabaseConnection.Open();

                if (this.OleDatabaseConnection.State == ConnectionState.Open)
                    this.Connected = true;
                else
                    this.Connected = false;

                return this.Connected;
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (FormatException fE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (OleDbException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
        }

        #endregion OpenDatabaseStandard

        #region OpenDatabaseTrusted

        /// <summary>
        /// Opens the database trusted. 
        /// </summary>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool OpenDatabaseTrusted()
        {
            try
            {
                var connectionString = string.Format(CultureInfo.InvariantCulture, "Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", ServerName, DatabaseName);

                this.OleDatabaseConnection = new OleDbConnection(connectionString);
                this.OleDatabaseConnection.Open();

                if (this.OleDatabaseConnection.State == ConnectionState.Open)
                    this.Connected = true;
                else
                    this.Connected = false;

                return this.Connected;
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (FormatException fE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (OleDbException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
        }

        #endregion OpenDatabaseTrusted

        #region OpenDatabaseByIP

        /// <summary>
        /// Opens the database by ip. 
        /// </summary>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool OpenDatabaseByIP()
        {
            try
            {
                var connectionString = string.Format(CultureInfo.InvariantCulture, "Provider=SQLOLEDB;Network Library=DBMSSOCN;Data Source={0},{1};Initial Catalog={2};User Id={3};Password={4};", this.IPAddress, this.Port, DatabaseName, UserName, Password);

                this.OleDatabaseConnection = new OleDbConnection(connectionString);
                this.OleDatabaseConnection.Open();

                if (this.OleDatabaseConnection.State == ConnectionState.Open)
                    this.Connected = true;
                else
                    this.Connected = false;

                return this.Connected;
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (FormatException fE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (OleDbException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
        }

        #endregion OpenDatabaseByIP
    }
}