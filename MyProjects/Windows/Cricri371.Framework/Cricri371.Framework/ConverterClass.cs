using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Text;

namespace Cricri371.Framework
{
    /// <summary>
    /// Class ConverterClass. This class cannot be inherited. 
    /// </summary>
    public sealed class ConverterClass
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="ConverterClass" /> class from being created. 
        /// </summary>
        private ConverterClass()
        {
        }

        #region ConvertImageToByteArray

        /// <summary>
        /// Converts the image to byte array. 
        /// </summary>
        /// <param name="pictureToConvert"> The picture to convert. </param>
        /// <returns> A byte array. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static byte[] ConvertImageToByteArray(Image pictureToConvert)
        {
            MemoryStream memoryStream = null;

            try
            {
                memoryStream = new MemoryStream();

                pictureToConvert.Save(memoryStream, ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            finally
            {
                if (memoryStream != null)
                    memoryStream.Close();
            }
        }

        #endregion ConvertImageToByteArray

        #region ByteArrayToString

        /// <summary>
        /// Bytes the array to string. 
        /// </summary>
        /// <param name="bufferToConvert"> The buffer to convert. </param>
        /// <returns> The byte array in string. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string ByteArrayToString(byte[] bufferToConvert)
        {
            if (bufferToConvert != null)
            {
                try
                {
                    return new ASCIIEncoding().GetString(bufferToConvert, 0, bufferToConvert.Length);
                }
                catch (ArgumentNullException aNE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
                }
                catch (ArgumentOutOfRangeException aOORE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
                }
                catch (DecoderFallbackException dFE)
                {
                    throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dFE, true));
                }
            }

            return string.Empty;
        }

        #endregion ByteArrayToString

        #region ByteArrayToObject

        /// <summary>
        /// Bytes the array to object. 
        /// </summary>
        /// <param name="buffer"> The buffer. </param>
        /// <returns> An object. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static object ByteArrayToObject(byte[] buffer)
        {
            MemoryStream memoryStream = null;
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                memoryStream = new MemoryStream(buffer);

                return binaryFormatter.Deserialize(memoryStream);
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (SerializationException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            finally
            {
                if (memoryStream != null)
                    memoryStream.Close();
            }
        }

        #endregion ByteArrayToObject

        #region ObjectToByteArray

        /// <summary>
        /// Objects to byte array. 
        /// </summary>
        /// <param name="valueToConvert"> The value to convert. </param>
        /// <returns> The byte array. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static byte[] ObjectToByteArray(object valueToConvert)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                binaryFormatter.Serialize(memoryStream, valueToConvert);

                return memoryStream.ToArray();
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (SerializationException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            finally
            {
                if (memoryStream != null)
                    memoryStream.Close();
            }
        }

        #endregion ObjectToByteArray

        #region EnumToList

        /// <summary>
        /// Converts the enum to list. 
        /// </summary>
        /// <param name="toConvert"> To convert. </param>
        /// <returns> The list of enum values. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static IList<NameValue> ConvertEnumToList(Type toConvert)
        {
            var result = new List<NameValue>();

            try
            {
                var array = Enum.GetValues(toConvert);
                var array2 = Enum.GetNames(toConvert).ToArray<string>();

                for (int i = 0; i < array.Length; i++)
                {
                    result.Add(new NameValue { Name = array2[i], Value = (int)array.GetValue(i) });
                }
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }

            return result;
        }

        #endregion EnumToList
    }
}