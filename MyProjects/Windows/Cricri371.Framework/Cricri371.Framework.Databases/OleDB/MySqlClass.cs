using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace Cricri371.Framework.Databases.OleDB
{
    /// <summary>
    /// Class MySqlClass. 
    /// </summary>
    /// <seealso cref="Cricri371.Framework.Databases.OleDB.OleDbDatabaseClass" />
    public class MySqlClass : OleDbDatabaseClass
    {
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
                var connectionString = string.Format(CultureInfo.InvariantCulture, "Provider=MySqlProv;Data Source={0};User Id={1};Password={2};", ServerName, UserName, Password);

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
    }
}