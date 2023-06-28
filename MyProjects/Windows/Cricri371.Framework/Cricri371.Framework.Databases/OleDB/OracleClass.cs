using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace Cricri371.Framework.Databases.OleDB
{
    /// <summary>
    /// Class OracleClass. 
    /// </summary>
    /// <seealso cref="Cricri371.Framework.Databases.OleDB.OleDbDatabaseClass" />
    public class OracleClass : OleDbDatabaseClass
    {
        /// <summary>
        /// Gets or sets the os authentication. 
        /// </summary>
        /// <value> The os authentication. </value>
        public int OSAuthentication { get; set; }

        #region OpenDatabaseMicrosoft

        /// <summary>
        /// Opens the database microsoft. 
        /// </summary>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool OpenDatabaseMicrosoft()
        {
            try
            {
                var connectionString = string.Format(CultureInfo.InvariantCulture, "Driver=MSDAORA;Data Source={0};User Id={1};Password={2};", ServerName, UserName, Password);

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

        #endregion OpenDatabaseMicrosoft

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
                var connectionString = string.Format(CultureInfo.InvariantCulture, "Driver=OraOLEDB.Oracle;Data Source={0};User Id={1};Password={2};", ServerName, UserName, Password);

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
                var connectionString = string.Format(CultureInfo.InvariantCulture, "Driver=OraOLEDB.Oracle;Server={0};OSAuthent={1};", ServerName, this.OSAuthentication);

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
    }
}