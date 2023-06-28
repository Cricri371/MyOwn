using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;

namespace Cricri371.Framework.Logging
{
    [FlagsAttribute]
    public enum Severity : int
    {
        Info = 1, Warning = 2, Error = 3, Exception = 4
    }

    #region LogClass

    /// <summary>
    /// Class LogClass. 
    /// </summary>
    public class LogClass
    {
        private static readonly object Padlock = new object();

        private string _filePath;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogClass" /> class. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public LogClass()
        {
            try
            {
                this.CurrentDate = DateTime.Now.Date;

                var fileName = string.Format(CultureInfo.InvariantCulture, "{0}{1}.log", "Log_", DateTime.Now.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture));

                var directoryInfo = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules().First().FullyQualifiedName));

                this._filePath = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", directoryInfo.FullName, Path.DirectorySeparatorChar, fileName);
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (FileNotFoundException fNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fNFE, true));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogClass" /> class. 
        /// </summary>
        /// <param name="fileName"> Name of the file. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public LogClass(string fileName)
        {
            try
            {
                this.CurrentDate = DateTime.Now.Date;

                var directoryInfo = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules().First().FullyQualifiedName));

                this._filePath = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", directoryInfo.FullName, Path.DirectorySeparatorChar, fileName);
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (FileNotFoundException fNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fNFE, true));
            }
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets the current date. 
        /// </summary>
        /// <value> The current date. </value>
        public DateTime CurrentDate { get; set; }

        #region WriteLog

        /// <summary>
        /// Writes the log. 
        /// </summary>
        /// <param name="severity"> The severity. </param>
        /// <param name="message">  The message. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void WriteLog(Severity severity, string message)
        {
            lock (this)
            {
                StreamWriter streamWriter = null;

                try
                {
                    streamWriter = new StreamWriter(this._filePath, true, Encoding.Default);

                    var stackFrame = new StackTrace().GetFrame(1);

                    var methodName = stackFrame.GetMethod().Name;
                    var className = stackFrame.GetMethod().ReflectedType.FullName;

                    streamWriter.WriteLine(string.Format(CultureInfo.InvariantCulture, "[{0}][{1}][{2}:{3}] : {4}", DateTime.Now, severity.ToString(), className, methodName, message));
                }
                catch (PathTooLongException pTLE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
                }
                catch (DirectoryNotFoundException dNFE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
                }
                catch (IOException iOE)
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
                catch (SecurityException sE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
                }
                catch (UnauthorizedAccessException uAE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
                }
                catch (FormatException fE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fE, true));
                }
                catch (ObjectDisposedException oDE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
                }
                finally
                {
                    if (streamWriter != null)
                        streamWriter.Close();
                }
            }
        }

        #endregion WriteLog
    }

    #endregion LogClass
}