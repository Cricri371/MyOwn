using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace Cricri371.Framework.Databases.OleDB
{
    /// <summary>
    /// Class OleDbDatabaseClass. 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class OleDbDatabaseClass : IDisposable
    {
        private OleDbCommand _oleDatabaseCommand;
        private OleDbDataAdapter _oleDatabaseAdapter;
        private bool _transactionInProgress;

        /// <summary>
        /// Initializes a new instance of the <see cref="OleDbDatabaseClass" /> class. 
        /// </summary>
        public OleDbDatabaseClass()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="OleDbDatabaseClass" /> is connected. 
        /// </summary>
        /// <value> <c> true </c> if connected; otherwise, <c> false </c>. </value>
        public bool Connected { get; set; }

        /// <summary>
        /// Gets or sets the OLE database reader result. 
        /// </summary>
        /// <value> The OLE database reader result. </value>
        public OleDbDataReader OleDatabaseReaderResult { get; set; }

        /// <summary>
        /// Gets or sets the name of the user. 
        /// </summary>
        /// <value> The name of the user. </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password. 
        /// </summary>
        /// <value> The password. </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the name of the server. 
        /// </summary>
        /// <value> The name of the server. </value>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the database source. 
        /// </summary>
        /// <value> The database source. </value>
        public string DatabaseSource { get; set; }

        /// <summary>
        /// Gets or sets the name of the database. 
        /// </summary>
        /// <value> The name of the database. </value>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the data set result. 
        /// </summary>
        /// <value> The data set result. </value>
        public DataSet DataSetResult { get; set; }

        /// <summary>
        /// Gets or sets the object result. 
        /// </summary>
        /// <value> The object result. </value>
        public object ObjectResult { get; set; }

        /// <summary>
        /// Gets or sets the OLE database connection. 
        /// </summary>
        /// <value> The OLE database connection. </value>
        protected OleDbConnection OleDatabaseConnection { get; set; }

        /// <summary>
        /// Gets or sets the OLE database transaction. 
        /// </summary>
        /// <value> The OLE database transaction. </value>
        protected OleDbTransaction OleDatabaseTransaction { get; set; }

        /// <summary>
        /// Gets the SQL parameter list. 
        /// </summary>
        /// <value> The SQL parameter list. </value>
        protected ArrayList SqlParameterList { get; private set; }

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
                if (this.OleDatabaseConnection != null)
                    this.OleDatabaseConnection.Close();
                if (this._oleDatabaseCommand != null)
                    this._oleDatabaseCommand.Dispose();
                if (this._oleDatabaseAdapter != null)
                    this._oleDatabaseAdapter.Dispose();
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

        #region OpenDatabase

        /// <summary>
        /// Opens the database. 
        /// </summary>
        /// <param name="connectionString"> The connection string. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public bool OpenDatabase(string connectionString)
        {
            try
            {
                this.OleDatabaseConnection = new OleDbConnection(connectionString);
                this.OleDatabaseConnection.Open();

                if (this.OleDatabaseConnection.State == ConnectionState.Open)
                    this.Connected = true;
                else
                    this.Connected = false;

                return this.Connected;
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

        #endregion OpenDatabase

        #region VerifyConnection

        /// <summary>
        /// Verifies the connection. 
        /// </summary>
        /// <returns> The state in string. </returns>
        public string VerifyConnection()
        {
            switch (this.OleDatabaseConnection.State)
            {
                case ConnectionState.Broken:
                    return "The database connection is broken";

                case ConnectionState.Closed:
                    return "The database connection is closed";

                case ConnectionState.Connecting:
                    return "The database connection is connecting";

                case ConnectionState.Executing:
                    return "The database connection is executing";

                case ConnectionState.Fetching:
                    return "The database connection is fetching";

                case ConnectionState.Open:
                    return "The database connection is open";

                default:
                    return string.Empty;
            }
        }

        #endregion VerifyConnection

        #region CloseDatabase

        /// <summary>
        /// Closes the database. 
        /// </summary>
        public void CloseDatabase()
        {
            if (this.OleDatabaseConnection != null)
                this.OleDatabaseConnection.Close();

            if (this.OleDatabaseReaderResult != null)
                this.OleDatabaseReaderResult.Close();

            this.Connected = false;
        }

        #endregion CloseDatabase

        #region CreateParametersList

        /// <summary>
        /// Creates the parameters list. 
        /// </summary>
        public void CreateParametersList()
        {
            this.SqlParameterList = new ArrayList();
        }

        #endregion CreateParametersList

        #region AddParameter

        /// <summary>
        /// Adds the parameter. 
        /// </summary>
        /// <param name="parameterName">  Name of the parameter. </param>
        /// <param name="parameterValue"> The parameter value. </param>
        public void AddParameter(string parameterName, object parameterValue)
        {
            this.SqlParameterList.Add(new OleDbParameter("@" + parameterName, parameterValue.ToString()));
        }

        #endregion AddParameter

        #region ClearParametersList

        /// <summary>
        /// Clears the parameters list. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void ClearParametersList()
        {
            try
            {
                this.SqlParameterList.Clear();
            }
            catch (NotSupportedException nSE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nSE, true));
            }
        }

        #endregion ClearParametersList

        #region Execute

        /// <summary>
        /// Executes the specified query. 
        /// </summary>
        /// <param name="query"> The query. </param>
        /// <returns> The number of updated. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int Execute(string query)
        {
            try
            {
                int fieldNumber = -1;
                if (!string.IsNullOrEmpty(query))
                {
                    this._oleDatabaseCommand = new OleDbCommand(query, this.OleDatabaseConnection);

                    if (this._transactionInProgress)
                        this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                    fieldNumber = this._oleDatabaseCommand.ExecuteNonQuery();
                }

                return fieldNumber;
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Executes the specified query. 
        /// </summary>
        /// <param name="query">   The query. </param>
        /// <param name="timeOut"> The time out. </param>
        /// <returns> The number of updated. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int Execute(string query, int timeOut)
        {
            try
            {
                int fieldNumber = -1;
                if (!string.IsNullOrEmpty(query))
                {
                    this._oleDatabaseCommand = new OleDbCommand(query, this.OleDatabaseConnection);
                    this._oleDatabaseCommand.CommandTimeout = timeOut;

                    if (this._transactionInProgress)
                        this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                    fieldNumber = this._oleDatabaseCommand.ExecuteNonQuery();

                    this._oleDatabaseCommand.ResetCommandTimeout();
                }

                return fieldNumber;
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Executes the specified query. 
        /// </summary>
        /// <param name="query">       The query. </param>
        /// <param name="transaction"> if set to <c> true </c> [transaction]. </param>
        /// <returns> The number of updated. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int Execute(string query, bool transaction)
        {
            try
            {
                int fieldNumber = -1;
                if (!string.IsNullOrEmpty(query))
                {
                    this._oleDatabaseCommand = new OleDbCommand(query, this.OleDatabaseConnection);

                    if (this._transactionInProgress)
                        this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;
                    else
                    {
                        if (transaction)
                        {
                            this.OleDatabaseTransaction = this.OleDatabaseConnection.BeginTransaction();
                            this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;
                            this._transactionInProgress = true;
                        }
                    }

                    fieldNumber = this._oleDatabaseCommand.ExecuteNonQuery();
                }

                return fieldNumber;
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Executes the specified query. 
        /// </summary>
        /// <param name="query">       The query. </param>
        /// <param name="transaction"> if set to <c> true </c> [transaction]. </param>
        /// <param name="timeOut">     The time out. </param>
        /// <returns> The number of updated. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int Execute(string query, bool transaction, int timeOut)
        {
            try
            {
                int fieldNumber = -1;
                if (!string.IsNullOrEmpty(query))
                {
                    this._oleDatabaseCommand = new OleDbCommand(query, this.OleDatabaseConnection);
                    this._oleDatabaseCommand.CommandTimeout = timeOut;

                    if (this._transactionInProgress)
                        this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;
                    else
                    {
                        if (transaction)
                        {
                            this.OleDatabaseTransaction = this.OleDatabaseConnection.BeginTransaction();
                            this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;
                            this._transactionInProgress = true;
                        }
                    }

                    fieldNumber = this._oleDatabaseCommand.ExecuteNonQuery();

                    this._oleDatabaseCommand.ResetCommandTimeout();
                }

                return fieldNumber;
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Sps the execute. 
        /// </summary>
        /// <param name="storedProcName"> Name of the stored proc. </param>
        /// <returns> The number of updated. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int SPExecute(string storedProcName)
        {
            try
            {
                this._oleDatabaseCommand = new OleDbCommand(storedProcName, this.OleDatabaseConnection);

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                this._oleDatabaseCommand.CommandType = CommandType.StoredProcedure;

                if (this.SqlParameterList != null)
                {
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);
                }

                return this._oleDatabaseCommand.ExecuteNonQuery();
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Sps the execute. 
        /// </summary>
        /// <param name="storedProcName"> Name of the stored proc. </param>
        /// <param name="timeOut">        The time out. </param>
        /// <returns> The number of updated. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int SPExecute(string storedProcName, int timeOut)
        {
            try
            {
                this._oleDatabaseCommand = new OleDbCommand(storedProcName, this.OleDatabaseConnection);
                this._oleDatabaseCommand.CommandTimeout = timeOut;

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                this._oleDatabaseCommand.CommandType = CommandType.StoredProcedure;

                if (this.SqlParameterList != null)
                {
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);
                }

                return this._oleDatabaseCommand.ExecuteNonQuery();
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Sps the execute. 
        /// </summary>
        /// <param name="storedProcName"> Name of the stored proc. </param>
        /// <param name="transaction">    if set to <c> true </c> [transaction]. </param>
        /// <returns> The number of updated. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int SPExecute(string storedProcName, bool transaction)
        {
            try
            {
                this._oleDatabaseCommand = new OleDbCommand(storedProcName, this.OleDatabaseConnection);

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;
                else
                {
                    if (transaction)
                    {
                        this.OleDatabaseTransaction = this.OleDatabaseConnection.BeginTransaction();
                        this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;
                        this._transactionInProgress = true;
                    }
                }

                this._oleDatabaseCommand.CommandType = CommandType.StoredProcedure;

                if (this.SqlParameterList != null)
                {
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);
                }

                return this._oleDatabaseCommand.ExecuteNonQuery();
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Sps the execute. 
        /// </summary>
        /// <param name="storedProcName"> Name of the stored proc. </param>
        /// <param name="transaction">    if set to <c> true </c> [transaction]. </param>
        /// <param name="timeOut">        The time out. </param>
        /// <returns> The number of updated. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int SPExecute(string storedProcName, bool transaction, int timeOut)
        {
            try
            {
                this._oleDatabaseCommand = new OleDbCommand(storedProcName, this.OleDatabaseConnection);
                this._oleDatabaseCommand.CommandTimeout = timeOut;

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;
                else
                {
                    if (transaction)
                    {
                        this.OleDatabaseTransaction = this.OleDatabaseConnection.BeginTransaction();
                        this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;
                        this._transactionInProgress = true;
                    }
                }

                this._oleDatabaseCommand.CommandType = CommandType.StoredProcedure;

                if (this.SqlParameterList != null)
                {
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);
                }

                return this._oleDatabaseCommand.ExecuteNonQuery();
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Sps the execute with return value. 
        /// </summary>
        /// <param name="storedProcName"> Name of the stored proc. </param>
        /// <returns> The number of updated. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int SPExecuteWithReturnValue(string storedProcName)
        {
            try
            {
                this._oleDatabaseCommand = new OleDbCommand(storedProcName, this.OleDatabaseConnection);

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                this._oleDatabaseCommand.CommandType = CommandType.StoredProcedure;

                if (this.SqlParameterList != null)
                {
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);
                }

                OleDbParameter sParameter = new OleDbParameter("@RC", SqlDbType.Int);
                sParameter.Direction = ParameterDirection.ReturnValue;

                this._oleDatabaseCommand.Parameters.Add(sParameter);

                this._oleDatabaseCommand.ExecuteNonQuery();

                return Convert.ToInt32(this._oleDatabaseCommand.Parameters["@RC"].Value, CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Sps the execute with return value. 
        /// </summary>
        /// <param name="storedProcName"> Name of the stored proc. </param>
        /// <param name="timeOut">        The time out. </param>
        /// <returns> The number of updated. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int SPExecuteWithReturnValue(string storedProcName, int timeOut)
        {
            try
            {
                this._oleDatabaseCommand = new OleDbCommand(storedProcName, this.OleDatabaseConnection);
                this._oleDatabaseCommand.CommandTimeout = timeOut;

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                this._oleDatabaseCommand.CommandType = CommandType.StoredProcedure;

                if (this.SqlParameterList != null)
                {
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);
                }

                OleDbParameter sParameter = new OleDbParameter("@RC", SqlDbType.Int);
                sParameter.Direction = ParameterDirection.ReturnValue;

                this._oleDatabaseCommand.Parameters.Add(sParameter);

                this._oleDatabaseCommand.ExecuteNonQuery();

                return Convert.ToInt32(this._oleDatabaseCommand.Parameters["@RC"].Value, CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Sps the execute with return value. 
        /// </summary>
        /// <param name="storedProcName"> Name of the stored proc. </param>
        /// <param name="transaction">    if set to <c> true </c> [transaction]. </param>
        /// <returns> The number of updated. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int SPExecuteWithReturnValue(string storedProcName, bool transaction)
        {
            try
            {
                this._oleDatabaseCommand = new OleDbCommand(storedProcName, this.OleDatabaseConnection);

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;
                else
                {
                    if (transaction)
                    {
                        this.OleDatabaseTransaction = this.OleDatabaseConnection.BeginTransaction();
                        this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;
                        this._transactionInProgress = true;
                    }
                }

                this._oleDatabaseCommand.CommandType = CommandType.StoredProcedure;

                if (this.SqlParameterList != null)
                {
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);
                }

                OleDbParameter sParameter = new OleDbParameter("@RC", SqlDbType.Int);
                sParameter.Direction = ParameterDirection.ReturnValue;

                this._oleDatabaseCommand.Parameters.Add(sParameter);

                this._oleDatabaseCommand.ExecuteNonQuery();

                return Convert.ToInt32(this._oleDatabaseCommand.Parameters["@RC"].Value, CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Sps the execute with return value. 
        /// </summary>
        /// <param name="storedProcName"> Name of the stored proc. </param>
        /// <param name="transaction">    if set to <c> true </c> [transaction]. </param>
        /// <param name="timeOut">        The time out. </param>
        /// <returns> The number of updated. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public int SPExecuteWithReturnValue(string storedProcName, bool transaction, int timeOut)
        {
            try
            {
                this._oleDatabaseCommand = new OleDbCommand(storedProcName, this.OleDatabaseConnection);
                this._oleDatabaseCommand.CommandTimeout = timeOut;

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;
                else
                {
                    if (transaction)
                    {
                        this.OleDatabaseTransaction = this.OleDatabaseConnection.BeginTransaction();
                        this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;
                        this._transactionInProgress = true;
                    }
                }

                this._oleDatabaseCommand.CommandType = CommandType.StoredProcedure;

                if (this.SqlParameterList != null)
                {
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);
                }

                OleDbParameter sParameter = new OleDbParameter("@RC", SqlDbType.Int);
                sParameter.Direction = ParameterDirection.ReturnValue;

                this._oleDatabaseCommand.Parameters.Add(sParameter);

                this._oleDatabaseCommand.ExecuteNonQuery();

                return Convert.ToInt32(this._oleDatabaseCommand.Parameters["@RC"].Value, CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        #endregion Execute

        #region Select

        /// <summary>
        /// Selects the specified query. 
        /// </summary>
        /// <param name="query"> The query. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void Select(string query)
        {
            try
            {
                if (!string.IsNullOrEmpty(query))
                {
                    this._oleDatabaseCommand = new OleDbCommand(query, this.OleDatabaseConnection);

                    if (this._transactionInProgress)
                        this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                    this.OleDatabaseReaderResult = this._oleDatabaseCommand.ExecuteReader();
                }
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Selects the scalar. 
        /// </summary>
        /// <param name="query"> The query. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void SelectScalar(string query)
        {
            try
            {
                if (!string.IsNullOrEmpty(query))
                {
                    this._oleDatabaseCommand = new OleDbCommand(query, this.OleDatabaseConnection);

                    if (this._transactionInProgress)
                        this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                    this.ObjectResult = this._oleDatabaseCommand.ExecuteScalar();
                }
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Selects the data set. 
        /// </summary>
        /// <param name="query"> The query. </param>
        public void SelectDataSet(string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                this._oleDatabaseCommand = new OleDbCommand(query, this.OleDatabaseConnection);

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                this._oleDatabaseAdapter = new OleDbDataAdapter(this._oleDatabaseCommand);

                this.DataSetResult = new DataSet();
                this.DataSetResult.Locale = CultureInfo.InvariantCulture;

                this._oleDatabaseAdapter.Fill(this.DataSetResult);
            }
        }

        /// <summary>
        /// Sps the select. 
        /// </summary>
        /// <param name="storedProcName"> Name of the stored proc. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void SPSelect(string storedProcName)
        {
            try
            {
                this._oleDatabaseCommand = new OleDbCommand(storedProcName, this.OleDatabaseConnection);

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                this._oleDatabaseCommand.CommandType = CommandType.StoredProcedure;

                if (this.SqlParameterList != null)
                {
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);
                }

                this.OleDatabaseReaderResult = this._oleDatabaseCommand.ExecuteReader();
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Sps the select scalar. 
        /// </summary>
        /// <param name="storedProcName"> Name of the stored proc. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void SPSelectScalar(string storedProcName)
        {
            try
            {
                this._oleDatabaseCommand = new OleDbCommand(storedProcName, this.OleDatabaseConnection);

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                this._oleDatabaseCommand.CommandType = CommandType.StoredProcedure;

                if (this.SqlParameterList != null)
                {
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);
                }

                this.ObjectResult = this._oleDatabaseCommand.ExecuteScalar();
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Sps the select data set. 
        /// </summary>
        /// <param name="storedProcName"> Name of the stored proc. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void SPSelectDataSet(string storedProcName)
        {
            try
            {
                this._oleDatabaseCommand = new OleDbCommand(storedProcName, this.OleDatabaseConnection);

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                this._oleDatabaseCommand.CommandType = CommandType.StoredProcedure;

                if (this.SqlParameterList != null)
                {
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);
                }

                this._oleDatabaseAdapter = new OleDbDataAdapter(this._oleDatabaseCommand);

                this.DataSetResult = new DataSet();
                this.DataSetResult.Locale = CultureInfo.InvariantCulture;

                this._oleDatabaseAdapter.Fill(this.DataSetResult);
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Functions the select. 
        /// </summary>
        /// <param name="functionName"> Name of the function. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void FunctionSelect(string functionName)
        {
            try
            {
                string sql = "SELECT * FROM dbo." + functionName;

                this._oleDatabaseCommand = new OleDbCommand(sql, this.OleDatabaseConnection);

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                this._oleDatabaseCommand.CommandType = CommandType.Text;

                if (this.SqlParameterList != null)
                {
                    sql += "(";
                    bool first = true;
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                    {
                        if (!first)
                            sql += ",";

                        sql += sqlParameter.ParameterName;
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);

                        first = false;
                    }

                    sql += ")";
                }

                this._oleDatabaseCommand.CommandText = sql;

                this.OleDatabaseReaderResult = this._oleDatabaseCommand.ExecuteReader();
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Functions the select scalar. 
        /// </summary>
        /// <param name="functionName"> Name of the function. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void FunctionSelectScalar(string functionName)
        {
            try
            {
                string sql = "SELECT dbo." + functionName;

                this._oleDatabaseCommand = new OleDbCommand(sql, this.OleDatabaseConnection);

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                this._oleDatabaseCommand.CommandType = CommandType.Text;

                if (this.SqlParameterList != null)
                {
                    sql += "(";
                    bool first = true;
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                    {
                        if (!first)
                            sql += ",";

                        sql += sqlParameter.ParameterName;
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);

                        first = false;
                    }

                    sql += ")";
                }

                this._oleDatabaseCommand.CommandText = sql;

                this.ObjectResult = this._oleDatabaseCommand.ExecuteScalar();
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        /// <summary>
        /// Functions the select data set. 
        /// </summary>
        /// <param name="functionName"> Name of the function. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void FunctionSelectDataSet(string functionName)
        {
            try
            {
                string sql = "SELECT * FROM dbo." + functionName;

                this._oleDatabaseCommand = new OleDbCommand(sql, this.OleDatabaseConnection);

                if (this._transactionInProgress)
                    this._oleDatabaseCommand.Transaction = this.OleDatabaseTransaction;

                this._oleDatabaseCommand.CommandType = CommandType.Text;

                if (this.SqlParameterList != null)
                {
                    sql += "(";
                    bool first = true;
                    foreach (OleDbParameter sqlParameter in this.SqlParameterList)
                    {
                        if (!first)
                            sql += ",";

                        sql += sqlParameter.ParameterName;
                        this._oleDatabaseCommand.Parameters.Add(sqlParameter);

                        first = false;
                    }

                    sql += ")";
                }

                this._oleDatabaseCommand.CommandText = sql;

                this._oleDatabaseAdapter = new OleDbDataAdapter(this._oleDatabaseCommand);

                this.DataSetResult = new DataSet();
                this.DataSetResult.Locale = CultureInfo.InvariantCulture;

                this._oleDatabaseAdapter.Fill(this.DataSetResult);
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        #endregion Select

        #region ReaderClose

        /// <summary>
        /// Readers the close. 
        /// </summary>
        public void ReaderClose()
        {
            if (this.OleDatabaseReaderResult != null)
                this.OleDatabaseReaderResult.Close();
        }

        #endregion ReaderClose

        #region CommitTransaction

        /// <summary>
        /// Commits the transaction. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void CommitTransaction()
        {
            try
            {
                this.OleDatabaseTransaction.Commit();
                this._transactionInProgress = false;
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (Exception ex)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(ex, true));
            }
        }

        #endregion CommitTransaction

        #region RollbackTransaction

        /// <summary>
        /// Rollbacks the transaction. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void RollbackTransaction()
        {
            try
            {
                this.OleDatabaseTransaction.Rollback();
                this._transactionInProgress = false;
            }
            catch (InvalidOperationException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (Exception ex)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(ex, true));
            }
        }

        #endregion RollbackTransaction

        #region PrepareStringForDatabase

        /// <summary>
        /// Prepares the string for database. 
        /// </summary>
        /// <param name="textToPrepare"> The text to prepare. </param>
        /// <returns> The string to use for query. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string PrepareStringForDatabase(string textToPrepare)
        {
            try
            {
                return textToPrepare.Replace("'", "''").Trim();
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

        #endregion PrepareStringForDatabase
    }
}