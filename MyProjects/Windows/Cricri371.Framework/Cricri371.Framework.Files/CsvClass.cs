using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security;

namespace Cricri371.Framework.Files
{
    /// <summary>
    /// Class CsvClass. 
    /// </summary>
    public class CsvClass
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvClass" /> class. 
        /// </summary>
        /// <param name="filePath">  The file path. </param>
        /// <param name="separator"> The separator. </param>
        /// <param name="hasHeader"> if set to <c> true </c> [has header]. </param>
        public CsvClass(string filePath, string separator, bool hasHeader)
        {
            this.Separator = separator;
            this.HasHeader = hasHeader;
            this.FilePath = filePath;

            this.IsValidFilePath();
            this.IsValidSeparator();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance has header. 
        /// </summary>
        /// <value> <c> true </c> if this instance has header; otherwise, <c> false </c>. </value>
        public bool HasHeader { get; set; }

        /// <summary>
        /// Gets or sets the separator. 
        /// </summary>
        /// <value> The separator. </value>
        public string Separator { get; set; }

        /// <summary>
        /// Gets or sets the file path. 
        /// </summary>
        /// <value> The file path. </value>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the stream reader. 
        /// </summary>
        /// <value> The stream reader. </value>
        public StreamReader StreamReader { get; set; }

        #endregion Properties

        #region IsValidSeparator

        /// <summary>
        /// Determines whether [is valid separator]. 
        /// </summary>
        /// <exception cref="ExceptionClass"> The separator must be valid </exception>
        private void IsValidSeparator()
        {
            if (string.IsNullOrEmpty(this.Separator))
                throw new ExceptionClass("The separator must be valid");
        }

        #endregion IsValidSeparator

        #region IsValidFilePath

        /// <summary>
        /// Determines whether [is valid file path]. 
        /// </summary>
        /// <exception cref="ExceptionClass"> The file path must be valid </exception>
        private void IsValidFilePath()
        {
            if (string.IsNullOrEmpty(this.FilePath))
                throw new ExceptionClass("The file path must be valid");
        }

        #endregion IsValidFilePath

        #region OpenFile

        /// <summary>
        /// Opens the file. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void OpenFile()
        {
            try
            {
                if (File.Exists(this.FilePath))
                    this.StreamReader = File.OpenText(this.FilePath);
                else
                    throw new ExceptionClass(string.Format(CultureInfo.InvariantCulture, "Csv file not found : ", this.FilePath));
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (FileNotFoundException fNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fNFE, true));
            }
            catch (NotSupportedException nSE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nSE, true));
            }
            catch (FormatException fE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fE, true));
            }
        }

        #endregion OpenFile

        #region ParseFile

        /// <summary>
        /// Parses the file. 
        /// </summary>
        /// <returns> The list of csv lines. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public IList<CsvLines> ParseFile()
        {
            this.IsValidFilePath();
            this.IsValidSeparator();

            var lines = new List<CsvLines>();

            try
            {
                string line = string.Empty;
                bool firstLine = true;
                int cptLine = 1;
                while (!string.IsNullOrEmpty(line = this.StreamReader.ReadLine()))
                {
                    if (this.HasHeader && firstLine)
                        continue;
                    else
                    {
                        var partOfLine = line.Split(this.Separator.ToCharArray()).ToList();

                        var csvLine = new CsvLines() { CptLine = cptLine };
                        csvLine.AddPartOfLine(partOfLine);

                        lines.Add(csvLine);
                    }

                    firstLine = false;
                }
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (OutOfMemoryException oOME)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oOME, true));
            }
            catch (IOException iE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iE, true));
            }

            return lines;
        }

        #endregion ParseFile

        #region WriteFile

        /// <summary>
        /// Writes the file. 
        /// </summary>
        /// <param name="csvLines">      The CSV lines. </param>
        /// <param name="overwriteFile"> if set to <c> true </c> [overwrite file]. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public void WriteFile(IList<CsvLines> csvLines, bool overwriteFile)
        {
            this.IsValidFilePath();
            this.IsValidSeparator();

            StreamWriter sWriter = null;
            try
            {
                if (overwriteFile)
                    sWriter = new StreamWriter(this.FilePath, overwriteFile);
                else
                {
                    if (File.Exists(this.FilePath))
                        throw new ExceptionClass(string.Format(CultureInfo.InvariantCulture, "A csv file : {0} already exists", this.FilePath));

                    sWriter = new StreamWriter(this.FilePath, overwriteFile);
                }

                foreach (var csvLine in csvLines.OrderBy(l => l.CptLine))
                {
                    string line = string.Empty;

                    int cptNumberOfElement = csvLine.PartOfLine.Count;

                    foreach (var partOfLine in csvLine.PartOfLine)
                    {
                        if (cptNumberOfElement > 0)
                            line = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", line, partOfLine, this.Separator);
                        else
                            line = string.Format(CultureInfo.InvariantCulture, "{0}{1}", line, partOfLine);
                        cptNumberOfElement--;
                    }

                    sWriter.WriteLine(line);
                }
            }
            catch (FormatException fE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fE, true));
            }
            catch (ObjectDisposedException oDE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (IOException iE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            finally
            {
                if (sWriter != null)
                {
                    sWriter.Close();
                    sWriter = null;
                }
            }
        }

        #endregion WriteFile

        #region CloseFile

        /// <summary>
        /// Closes the file. 
        /// </summary>
        public void CloseFile()
        {
            if (this.StreamReader != null)
            {
                this.StreamReader.Close();
                this.StreamReader = null;
            }
        }

        #endregion CloseFile
    }
}