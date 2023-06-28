using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using Cricri371.Framework.Files;

namespace Cricri371.Framework.Serialization
{
    /// <summary>
    /// Class BinarySerializationClass. 
    /// </summary>
    public class BinarySerializationClass
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySerializationClass" /> class. 
        /// </summary>
        public BinarySerializationClass()
        {
            this.FilePath = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySerializationClass" /> class. 
        /// </summary>
        /// <param name="filePath"> The file path. </param>
        /// <exception cref="ExceptionClass"> The file path must be valid </exception>
        public BinarySerializationClass(string filePath)
        {
            this.FilePath = filePath;

            if (string.IsNullOrEmpty(this.FilePath))
                throw new ExceptionClass("The file path must be valid");
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets the file path. 
        /// </summary>
        /// <value> The file path. </value>
        public string FilePath { get; set; }

        #region LoadArrayList

        /// <summary>
        /// Loads the array list. 
        /// </summary>
        /// <returns> The array list. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public ArrayList LoadArrayList()
        {
            Stream stream = null;
            var list = new ArrayList();
            try
            {
                if (!string.IsNullOrEmpty(this.FilePath))
                {
                    if (File.Exists(this.FilePath))
                    {
                        var binaryFormatter = new BinaryFormatter();

                        stream = new FileStream(this.FilePath, FileMode.Open, FileAccess.Read);

                        list = (ArrayList)binaryFormatter.Deserialize(stream);
                    }
                }

                return list;
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (FileNotFoundException fNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fNFE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (SerializationException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        #endregion LoadArrayList

        #region LoadList

        /// <summary>
        /// Loads the list. 
        /// </summary>
        /// <typeparam name="T"> The kind of data to retrieve. </typeparam>
        /// <returns> The list of objects. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public IList<T> LoadList<T>()
        {
            Stream stream = null;
            var list = new List<T>();

            try
            {
                if (!string.IsNullOrEmpty(this.FilePath))
                {
                    if (File.Exists(this.FilePath))
                    {
                        var binaryFormatter = new BinaryFormatter();

                        stream = new FileStream(this.FilePath, FileMode.Open, FileAccess.Read);

                        list = (List<T>)binaryFormatter.Deserialize(stream);
                    }
                }

                return list;
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (FileNotFoundException fNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fNFE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (SerializationException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        #endregion LoadList

        #region SaveArrayList

        /// <summary>
        /// Saves the array list. 
        /// </summary>
        /// <param name="list">          The list. </param>
        /// <param name="backupOldFile"> if set to <c> true </c> [backup old file]. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void SaveArrayList(ArrayList list, bool backupOldFile)
        {
            Stream stream = null;

            try
            {
                var formatter = new BinaryFormatter();

                if (backupOldFile)
                    FilesDirectoriesClass.Rename(this.FilePath, string.Format(CultureInfo.InvariantCulture, "{0}.old", this.FilePath));

                stream = new FileStream(this.FilePath, FileMode.Create, FileAccess.Write, FileShare.None);

                formatter.Serialize(stream, list);
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (FileNotFoundException fNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fNFE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        #endregion SaveArrayList

        #region SaveList

        /// <summary>
        /// Saves the list. 
        /// </summary>
        /// <typeparam name="T"> The kind of data to save. </typeparam>
        /// <param name="list">          The list. </param>
        /// <param name="backupOldFile"> if set to <c> true </c> [backup old file]. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void SaveList<T>(IList<T> list, bool backupOldFile)
        {
            Stream stream = null;

            try
            {
                var formatter = new BinaryFormatter();

                if (backupOldFile)
                    FilesDirectoriesClass.Rename(this.FilePath, string.Format(CultureInfo.InvariantCulture, "{0}.old", this.FilePath));

                stream = new FileStream(this.FilePath, FileMode.Create, FileAccess.Write, FileShare.None);

                formatter.Serialize(stream, list);
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (FileNotFoundException fNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fNFE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        #endregion SaveList
    }
}