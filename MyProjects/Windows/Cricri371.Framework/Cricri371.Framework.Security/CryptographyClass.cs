using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cricri371.Framework.Security
{
    /// <summary>
    /// Class CryptographyClass. 
    /// </summary>
    public class CryptographyClass
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptographyClass" /> class. 
        /// </summary>
        public CryptographyClass()
        {
            this.Password = string.Empty;
            this.OriginalFileName = string.Empty;
            this.EncryptedFileName = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptographyClass" /> class. 
        /// </summary>
        /// <param name="originalFileName">  Name of the original file. </param>
        /// <param name="encryptedFileName"> Name of the encrypted file. </param>
        /// <param name="password">          The password. </param>
        public CryptographyClass(string originalFileName, string encryptedFileName, string password)
        {
            this.Password = password;
            this.OriginalFileName = originalFileName;
            this.EncryptedFileName = encryptedFileName;
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets the password. 
        /// </summary>
        /// <value> The password. </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the name of the original file. 
        /// </summary>
        /// <value> The name of the original file. </value>
        public string OriginalFileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the encrypted file. 
        /// </summary>
        /// <value> The name of the encrypted file. </value>
        public string EncryptedFileName { get; set; }

        #region GetUnicodeEncoding

        /// <summary>
        /// Gets the unicode encoding. 
        /// </summary>
        /// <returns> The byte array. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public byte[] GetUnicodeEncoding()
        {
            try
            {
                return new UnicodeEncoding().GetBytes(this.Password);
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
        }

        #endregion GetUnicodeEncoding

        #region EncryptFile

        /// <summary>
        /// Encrypts the file. 
        /// </summary>
        /// <exception cref="ExceptionClass">
        /// (CryptographyClass(EncryptFile)) : Verify that you've encoded the password and the files(Original/Encrypted)
        /// </exception>
        public void EncryptFile()
        {
            if (!string.IsNullOrEmpty(this.OriginalFileName) && !string.IsNullOrEmpty(this.EncryptedFileName) & !string.IsNullOrEmpty(this.Password))
            {
                FileStream fileStreamReadOriginal = null;
                FileStream fileStreamWriteEncrypted = null;
                CryptoStream encryptoStream = null;

                try
                {
                    // Make of stream to read file
                    fileStreamReadOriginal = new FileStream(this.OriginalFileName, FileMode.Open);

                    // Make a new encrypted file
                    fileStreamWriteEncrypted = new FileStream(this.EncryptedFileName, FileMode.Create);

                    // Initialize Rijndael object
                    RijndaelManaged rijndaelManaged = new RijndaelManaged();

                    // Obtain byte array of the password
                    byte[] key = this.GetUnicodeEncoding();

                    encryptoStream = new CryptoStream(fileStreamWriteEncrypted, rijndaelManaged.CreateEncryptor(key, key), CryptoStreamMode.Write);

                    int data = 0;

                    while ((data = fileStreamReadOriginal.ReadByte()) != -1)
                        encryptoStream.WriteByte((byte)data);
                }
                catch (ObjectDisposedException oDE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
                }
                catch (NotSupportedException nSE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nSE, true));
                }
                catch (UnauthorizedAccessException uAE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
                }
                catch (System.Security.SecurityException sE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
                }
                catch (ArgumentException aE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
                }
                catch (IOException iOE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
                }
                finally
                {
                    if (fileStreamReadOriginal != null)
                        fileStreamReadOriginal.Close();
                    if (encryptoStream != null)
                        encryptoStream.Close();
                    if (fileStreamWriteEncrypted != null)
                        fileStreamWriteEncrypted.Close();
                }
            }
            else
                throw new ExceptionClass("(CryptographyClass(EncryptFile)) : Verify that you've encoded the password and the files(Orignal/Crypted)");
        }

        #endregion EncryptFile

        #region DecryptFile

        /// <summary>
        /// Decrypts the file. 
        /// </summary>
        /// <exception cref="ExceptionClass">
        /// (CryptographyClass(DecryptFile)) : Verify that you've encoded the password and the files(Original/Encrypted)
        /// </exception>
        public void DecryptFile()
        {
            if (!string.IsNullOrEmpty(this.OriginalFileName) && !string.IsNullOrEmpty(this.EncryptedFileName) & !string.IsNullOrEmpty(this.Password))
            {
                FileStream fileStreamReadEncrypted = null;
                CryptoStream encryptoStream = null;
                FileStream fileStreamWriteOriginal = null;

                try
                {
                    // Make of stream to read file
                    fileStreamReadEncrypted = new FileStream(this.EncryptedFileName, FileMode.Open);

                    // Initialize Rijndael object
                    RijndaelManaged rijndaelManaged = new RijndaelManaged();

                    // Obtain byte array of the password
                    byte[] key = this.GetUnicodeEncoding();

                    encryptoStream = new CryptoStream(fileStreamReadEncrypted, rijndaelManaged.CreateDecryptor(key, key), CryptoStreamMode.Read);

                    FileInfo fInfo = new FileInfo(this.EncryptedFileName);

                    if (fInfo.Exists)
                    {
                        // Make a new non encrypted file
                        fileStreamWriteOriginal = new FileStream(this.OriginalFileName, FileMode.Create);

                        int data = 0;

                        while ((data = encryptoStream.ReadByte()) != -1)
                            fileStreamWriteOriginal.WriteByte((byte)data);
                    }
                }
                catch (ObjectDisposedException oDE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oDE, true));
                }
                catch (NotSupportedException nSE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nSE, true));
                }
                catch (UnauthorizedAccessException uAE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
                }
                catch (System.Security.SecurityException sE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
                }
                catch (ArgumentException aE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
                }
                catch (IOException iOE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
                }
                finally
                {
                    if (fileStreamReadEncrypted != null)
                        fileStreamReadEncrypted.Close();
                    if (encryptoStream != null)
                        encryptoStream.Close();
                    if (fileStreamWriteOriginal != null)
                        fileStreamWriteOriginal.Close();
                }
            }
            else
                throw new ExceptionClass("(CryptographyClass(DecryptFile)) : Verify that you've encoded the password and the files(Orignal/Crypted)");
        }

        #endregion DecryptFile
    }
}