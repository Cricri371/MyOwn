using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;

namespace Cricri371.Framework.Databases.OleDB
{
    /// <summary>
    /// Class AccessClass. 
    /// </summary>
    /// <seealso cref="Cricri371.Framework.Databases.OleDB.OleDbDatabaseClass" />
    public class AccessClass : OleDbDatabaseClass
    {
        /// <summary>
        /// Gets or sets the system database. 
        /// </summary>
        /// <value> The system database. </value>
        public string SystemDatabase { get; set; }

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
                if (File.Exists(this.DatabaseSource))
                {
                    var connectionString = string.Format(CultureInfo.InvariantCulture, "Provider=Microsoft.JET.OLEDB.4.0;Data Source={0};User Id={1};Password={2};", DatabaseSource, UserName, Password);

                    this.OleDatabaseConnection = new OleDbConnection(connectionString);
                    this.OleDatabaseConnection.Open();

                    if (this.OleDatabaseConnection.State == ConnectionState.Open)
                        this.Connected = true;
                    else
                        this.Connected = false;
                }
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

        #region OpenDatabaseWorkgroup

        /// <summary>
        /// Opens the database workgroup. 
        /// </summary>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool OpenDatabaseWorkgroup()
        {
            try
            {
                if (File.Exists(this.DatabaseSource))
                {
                    var connectionString = string.Format(CultureInfo.InvariantCulture, "Provider=Microsoft.JET.OLEDB.4.0;Data Source={0};System Database={1};", DatabaseSource, this.SystemDatabase);

                    this.OleDatabaseConnection = new OleDbConnection(connectionString);
                    this.OleDatabaseConnection.Open();

                    if (this.OleDatabaseConnection.State == ConnectionState.Open)
                        this.Connected = true;
                    else
                        this.Connected = false;
                }
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

        #endregion OpenDatabaseWorkgroup

        #region OpenDatabasePassword

        /// <summary>
        /// Opens the database password. 
        /// </summary>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool OpenDatabasePassword()
        {
            try
            {
                if (File.Exists(this.DatabaseSource))
                {
                    var connectionString = string.Format(CultureInfo.InvariantCulture, "Provider=Microsoft.JET.OLEDB.4.0;Data Source={0};Database Password=={1};", DatabaseSource, Password);

                    this.OleDatabaseConnection = new OleDbConnection(connectionString);
                    this.OleDatabaseConnection.Open();

                    if (this.OleDatabaseConnection.State == ConnectionState.Open)
                        this.Connected = true;
                    else
                        this.Connected = false;
                }
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

        #endregion OpenDatabasePassword
    }
}