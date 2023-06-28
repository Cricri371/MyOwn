using System;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Cricri371.Framework
{
    /// <summary>
    /// Class ExceptionClass. 
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class ExceptionClass : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionClass" /> class. 
        /// </summary>
        public ExceptionClass()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionClass" /> class. 
        /// </summary>
        /// <param name="message"> The message that describes the error. </param>
        public ExceptionClass(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionClass" /> class. 
        /// </summary>
        /// <param name="message">        The error message that explains the reason for the exception. </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference (Nothing in
        /// Visual Basic) if no inner exception is specified.
        /// </param>
        public ExceptionClass(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionClass" /> class. 
        /// </summary>
        /// <param name="message">           The message. </param>
        /// <param name="displayMessageBox"> if set to <c> true </c> [display message box]. </param>
        public ExceptionClass(string message, bool displayMessageBox)
            : base(message)
        {
            this.DisplayMessageBox = displayMessageBox;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionClass" /> class. 
        /// </summary>
        /// <param name="info">   
        /// The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the
        /// serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains
        /// contextual information about the source or destination.
        /// </param>
        protected ExceptionClass(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets a value indicating whether [display message box]. 
        /// </summary>
        /// <value> <c> true </c> if [display message box]; otherwise, <c> false </c>. </value>
        public bool DisplayMessageBox { get; set; }

        #region GetObjectData

        /// <summary>
        /// When overridden in a derived class, sets the <see
        /// cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">   
        /// The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the
        /// serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains
        /// contextual information about the source or destination.
        /// </param>
        /// <PermissionSet>
        /// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib,
        /// Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1"
        /// Read="*AllFiles*" PathDiscovery="*AllFiles*" /><IPermission
        /// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0,
        /// Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1"
        /// Flags="SerializationFormatter" />
        /// </PermissionSet>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        #endregion GetObjectData

        #region ManageExceptionMessage

        /// <summary>
        /// Manages the exception message. 
        /// </summary>
        /// <param name="innerException"> The inner exception. </param>
        /// <returns> The exception message. </returns>
        public static string ManageExceptionMessage(Exception innerException)
        {
            return ManageExceptionMessage(innerException, false, false);
        }

        /// <summary>
        /// Manages the exception message. 
        /// </summary>
        /// <param name="innerException"> The inner exception. </param>
        /// <param name="displayDetails"> if set to <c> true </c> [display details]. </param>
        /// <returns> The exception message. </returns>
        public static string ManageExceptionMessage(Exception innerException, bool displayDetails)
        {
            return ManageExceptionMessage(innerException, displayDetails, false);
        }

        /// <summary>
        /// Manages the exception message. 
        /// </summary>
        /// <param name="innerException">     The inner exception. </param>
        /// <param name="displayDetails">     if set to <c> true </c> [display details]. </param>
        /// <param name="displayFullDetails"> if set to <c> true </c> [display full details]. </param>
        /// <returns> The exception message. </returns>
        public static string ManageExceptionMessage(Exception innerException, bool displayDetails, bool displayFullDetails)
        {
            string error = string.Empty;

            var exceptionName = innerException.GetType().Name;

            error = string.Concat(error, string.Format(CultureInfo.InvariantCulture, "Exception name : {0}", exceptionName));

            error = string.Concat(error, string.Format(CultureInfo.InvariantCulture, "\n\nMessage : {0}\n\n", innerException.Message));

            if (displayDetails)
            {
                var trace = new System.Diagnostics.StackTrace(innerException, true);

                // Get all frames
                var frames = trace.GetFrames();

                if (frames.Count() != 0)
                {
                    if (displayFullDetails && frames.Count() > 1)
                    {
                        foreach (var frame in frames)
                        {
                            error = AddNewErrorLine(error, frame);
                        }
                    }
                    else
                    {
                        var frame = frames.First();

                        error = AddNewErrorLine(error, frame);
                    }
                }
                else
                    error = string.Concat(error, "No details available\n");
            }

            return error;
        }

        #endregion ManageExceptionMessage

        #region AddNewErrorLine

        /// <summary>
        /// Adds the new error line. 
        /// </summary>
        /// <param name="error"> The error. </param>
        /// <param name="frame"> The frame. </param>
        /// <returns> The error line. </returns>
        private static string AddNewErrorLine(string error, System.Diagnostics.StackFrame frame)
        {
            if (frame.GetFileName() != null)
            {
                var fileName = new System.IO.FileInfo(frame.GetFileName()).Name;
                error = string.Concat(error, string.Format(CultureInfo.InvariantCulture, "File : '{0}' function : '{1}' at position : ({2},{3})", fileName, frame.GetMethod(), frame.GetFileLineNumber(), frame.GetFileColumnNumber()));

                return string.Concat(error, "\n");
            }
            else
                return error;
        }

        #endregion AddNewErrorLine
    }
}