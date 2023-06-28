using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Cricri371.Framework.Configuration.File
{
    /// <summary>
    /// Class IniFile. 
    /// </summary>
    public class IniFile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IniFile" /> class. 
        /// </summary>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public IniFile()
        {
            try
            {
                this.Name = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
                this.Name += string.Format(CultureInfo.InvariantCulture, @"\{0}.ini", Application.ProductName);
            }
            catch (FormatException fE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fE, true));
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
            catch (FileNotFoundException fNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fNFE, true));
            }
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets the name. 
        /// </summary>
        /// <value> The name. </value>
        private string Name { get; set; }

        #region SetValue

        /// <summary>
        /// Sets the value. 
        /// </summary>
        /// <param name="section">  The section. </param>
        /// <param name="entry">    The entry. </param>
        /// <param name="newValue"> The new value. </param>
        /// <exception cref="Win32Exception"> Thrown a Win32 exception. </exception>
        public void SetValue(string section, string entry, string newValue)
        {
            if (newValue == null)
                this.RemoveEntry(section, entry);
            else
            {
                if (SafeNativeMethods.WritePrivateProfileString(section, entry, newValue.ToString(), this.Name) == 0)
                    throw new Win32Exception();
            }
        }

        #endregion SetValue

        #region GetValue

        /// <summary>
        /// Gets the value. 
        /// </summary>
        /// <param name="section"> The section. </param>
        /// <param name="entry">   The entry. </param>
        /// <returns> The value for the entry. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public string GetValue(string section, string entry)
        {
            try
            {
                // Loop until the buffer has grown enough to fit the value
                for (int maxSize = 250; true; maxSize *= 2)
                {
                    var result = new StringBuilder(maxSize);
                    var size = SafeNativeMethods.GetPrivateProfileString(section, entry, string.Empty, result, maxSize, this.Name);

                    if (size < maxSize - 1)
                    {
                        if (size == 0 && !this.HasEntry(section, entry))
                            return null;

                        return result.ToString();
                    }
                }
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
        }

        #endregion GetValue

        #region RemoveEntry

        /// <summary>
        /// Removes the entry. 
        /// </summary>
        /// <param name="section"> The section. </param>
        /// <param name="entry">   The entry. </param>
        /// <exception cref="Win32Exception"> Thrown a Win32 exception. </exception>
        public void RemoveEntry(string section, string entry)
        {
            // Verify the entry exists
            if (!this.HasEntry(section, entry))
                return;

            if (SafeNativeMethods.WritePrivateProfileString(section, entry, (IntPtr)0, this.Name) == 0)
                throw new Win32Exception();
        }

        #endregion RemoveEntry

        #region RemoveSection

        /// <summary>
        /// Removes the section. 
        /// </summary>
        /// <param name="section"> The section. </param>
        /// <exception cref="Win32Exception"> Thrown a Win32 exception. </exception>
        public void RemoveSection(string section)
        {
            // Verify the section exists
            if (!this.HasSection(section))
                return;

            if (SafeNativeMethods.WritePrivateProfileString(section, (IntPtr)0, string.Empty, this.Name) == 0)
                throw new Win32Exception();
        }

        #endregion RemoveSection

        #region RetrieveEntryNames

        /// <summary>
        /// Retrieves the entry names. 
        /// </summary>
        /// <param name="section"> The section. </param>
        /// <returns> The list of entry names. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public IList<string> RetrieveEntryNames(string section)
        {
            try
            {
                // Verify the section exists
                if (!this.HasSection(section))
                    return null;

                // Loop until the buffer has grown enough to fit the value
                for (int maxSize = 500; true; maxSize *= 2)
                {
                    var bytes = new byte[maxSize];
                    var size = SafeNativeMethods.GetPrivateProfileString(section, (IntPtr)0, string.Empty, bytes, maxSize, this.Name);

                    if (size < maxSize - 2)
                    {
                        // Convert the buffer to a string and split it
                        var entries = Encoding.ASCII.GetString(bytes, 0, size - (size > 0 ? 1 : 0));

                        if (string.IsNullOrEmpty(entries))
                            return new List<string>();

                        return entries.Split(new char[] { '\0' }).ToList();
                    }
                }
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (DecoderFallbackException dFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dFE, true));
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

        #endregion RetrieveEntryNames

        #region RetrieveSectionNames

        /// <summary>
        /// Retrieves the section names. 
        /// </summary>
        /// <returns> The list of section names. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public IList<string> RetrieveSectionNames()
        {
            try
            {
                // Verify the file exists
                if (!System.IO.File.Exists(this.Name))
                    return null;

                // Loop until the buffer has grown enough to fit the value
                for (int maxSize = 500; true; maxSize *= 2)
                {
                    var bytes = new byte[maxSize];
                    var size = SafeNativeMethods.GetPrivateProfileString((IntPtr)0, string.Empty, string.Empty, bytes, maxSize, this.Name);

                    if (size < maxSize - 2)
                    {
                        // Convert the buffer to a string and split it
                        var sections = Encoding.ASCII.GetString(bytes, 0, size - (size > 0 ? 1 : 0));

                        if (string.IsNullOrEmpty(sections))
                            return new List<string>();

                        return sections.Split(new char[] { '\0' }).ToList();
                    }
                }
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (DecoderFallbackException dFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dFE, true));
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

        #endregion RetrieveSectionNames

        #region HasEntry

        /// <summary>
        /// Determines whether the specified section has entry. 
        /// </summary>
        /// <param name="section">   The section. </param>
        /// <param name="entryName"> Name of the entry. </param>
        /// <returns>
        /// <c> true </c> if the specified section has entry; otherwise, <c> false </c>.
        /// </returns>
        public bool HasEntry(string section, string entryName)
        {
            var entries = this.RetrieveEntryNames(section);

            if (entries.Count != 0)
                return false;

            return entries.Contains(entryName);
        }

        #endregion HasEntry

        #region HasSection

        /// <summary>
        /// Determines whether the specified section has section. 
        /// </summary>
        /// <param name="section"> The section. </param>
        /// <returns>
        /// <c> true </c> if the specified section has section; otherwise, <c> false </c>.
        /// </returns>
        public bool HasSection(string section)
        {
            var sections = this.RetrieveSectionNames();

            if (sections == null)
                return false;

            return sections.Contains(section);
        }

        #endregion HasSection
    }
}