using System;
using System.Text.RegularExpressions;

namespace Cricri371.Framework
{
    /// <summary>
    /// Class ManipulateStringClass. This class cannot be inherited. 
    /// </summary>
    public sealed class ManipulateStringClass
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="ManipulateStringClass" /> class from being created.
        /// </summary>
        private ManipulateStringClass()
        {
        }

        #region Right

        /// <summary>
        /// Rights the specified text source. 
        /// </summary>
        /// <param name="textSource"> The text source. </param>
        /// <param name="count">      The count. </param>
        /// <returns> The string on the right. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string Right(string textSource, int count)
        {
            try
            {
                if (!string.IsNullOrEmpty(textSource))
                {
                    if (count <= textSource.Length && count >= 0)
                        return textSource.Substring(textSource.Length - count, count);
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
        }

        #endregion Right

        #region Mid

        /// <summary>
        /// Mids the specified text source. 
        /// </summary>
        /// <param name="textSource">     The text source. </param>
        /// <param name="firstOccurence"> The first occurence. </param>
        /// <param name="count">          The count. </param>
        /// <returns> The string at the mid. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string Mid(string textSource, int firstOccurence, int count)
        {
            try
            {
                if (!string.IsNullOrEmpty(textSource))
                {
                    if (firstOccurence + count <= textSource.Length && firstOccurence >= 0 && count >= 0)
                    {
                        if (firstOccurence != 0)
                            return textSource.Substring(firstOccurence, count);
                        else
                            return textSource.Substring(firstOccurence, count);
                    }
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
        }

        /// <summary>
        /// Mids the specified word. 
        /// </summary>
        /// <param name="word">  The word. </param>
        /// <param name="first"> The first. </param>
        /// <returns> The string at the mid. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string Mid(string word, int first)
        {
            try
            {
                if (!string.IsNullOrEmpty(word))
                {
                    if (first <= word.Length && first >= 0)
                        if (first != 0)
                            return word.Substring(first);
                        else
                            return word.Substring(first);
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
        }

        #endregion Mid

        #region Left

        /// <summary>
        /// Lefts the specified text source. 
        /// </summary>
        /// <param name="textSource"> The text source. </param>
        /// <param name="count">      The count. </param>
        /// <returns> The string at the left. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string Left(string textSource, int count)
        {
            try
            {
                if (!string.IsNullOrEmpty(textSource))
                {
                    if (count <= textSource.Length && count >= 0)
                        return textSource.Substring(0, count);
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
        }

        #endregion Left

        #region FindIndexOfString

        /// <summary>
        /// Finds the index of string. 
        /// </summary>
        /// <param name="textSource"> The text source. </param>
        /// <param name="toFind">     To find. </param>
        /// <returns> The index of the string. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static int FindIndexOfString(string textSource, string toFind)
        {
            try
            {
                if (!string.IsNullOrEmpty(textSource))
                    return textSource.IndexOf(toFind, StringComparison.CurrentCulture);
                else
                    return -1;
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
        }

        #endregion FindIndexOfString

        #region FindIndexOfChar

        /// <summary>
        /// Finds the index of character. 
        /// </summary>
        /// <param name="textSource"> The text source. </param>
        /// <param name="toFind">     To find. </param>
        /// <returns> The index of the character. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static int FindIndexOfChar(string textSource, char toFind)
        {
            try
            {
                if (!string.IsNullOrEmpty(textSource))
                    return textSource.IndexOf(toFind);
                else
                    return -1;
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
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

        #endregion FindIndexOfChar

        #region FindPlaceOfString

        /// <summary>
        /// Finds the place of string. 
        /// </summary>
        /// <param name="textSource"> The text source. </param>
        /// <param name="toFind">     To find. </param>
        /// <param name="startIndex"> The start index. </param>
        /// <returns> The place of the string. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static int FindPlaceOfString(string textSource, string toFind, int startIndex)
        {
            try
            {
                if (!string.IsNullOrEmpty(textSource))
                {
                    if (!string.IsNullOrEmpty(toFind))
                        return textSource.IndexOf(toFind, startIndex, StringComparison.CurrentCulture);
                    else
                        return -1;
                }
                else
                    return -1;
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

        #endregion FindPlaceOfString

        #region FindPlaceOfChar

        /// <summary>
        /// Finds the place of character. 
        /// </summary>
        /// <param name="textSource"> The text source. </param>
        /// <param name="toFind">     To find. </param>
        /// <param name="startIndex"> The start index. </param>
        /// <returns> The place of the character. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static int FindPlaceOfChar(string textSource, char toFind, int startIndex)
        {
            try
            {
                if (!string.IsNullOrEmpty(textSource))
                    return textSource.IndexOf(toFind, startIndex);
                else
                    return -1;
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
        }

        #endregion FindPlaceOfChar

        #region TestFloat

        /// <summary>
        /// Tests the float. 
        /// </summary>
        /// <param name="numberToTest"> The number to test. </param>
        /// <returns> The float in string. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string TestFloat(string numberToTest)
        {
            try
            {
                if (!string.IsNullOrEmpty(numberToTest))
                {
                    string temp = "1.1";
                    if (string.Compare(temp, temp.ToString(), StringComparison.CurrentCulture) == 0)
                        return numberToTest;
                    else
                        return numberToTest.Replace(".", ",");
                }
                else
                    return string.Empty;
            }
            catch (FormatException fE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fE, true));
            }
            catch (OverflowException oE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oE, true));
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

        #endregion TestFloat

        #region FloatToString

        /// <summary>
        /// Floats to string. 
        /// </summary>
        /// <param name="numberToConvert"> The number to convert. </param>
        /// <returns> The converted string. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string FloatToString(string numberToConvert)
        {
            try
            {
                if (!string.IsNullOrEmpty(numberToConvert))
                    return numberToConvert.Replace(",", ".");
                else
                    return string.Empty;
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

        #endregion FloatToString

        #region SplitString

        /// <summary>
        /// Splits the string. 
        /// </summary>
        /// <param name="textToSplit"> The text to split. </param>
        /// <param name="splitter">    The splitter. </param>
        /// <returns> The array of strings. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string[] SplitString(string textToSplit, string splitter)
        {
            try
            {
                Regex regex = new Regex(splitter);
                return regex.Split(textToSplit);
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
        }

        #endregion SplitString

        #region EmailIsCorrect

        /// <summary>
        /// Emails the is correct. 
        /// </summary>
        /// <param name="emailAddress"> The email address. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public static bool EmailIsCorrect(string emailAddress)
        {
            if (!string.IsNullOrEmpty(emailAddress))
            {
                if (emailAddress.IndexOf('@') != -1 && emailAddress.IndexOf('.') != -1 && (emailAddress.IndexOf('@') == emailAddress.LastIndexOf('@')) && (emailAddress.IndexOf('.') == emailAddress.LastIndexOf('.')))
                {
                    if (emailAddress.IndexOf('@') < emailAddress.IndexOf('.'))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        #endregion EmailIsCorrect

        #region StringIsPositiveNumeric

        /// <summary>
        /// Strings the is positive numeric. 
        /// </summary>
        /// <param name="numberToTest"> The number to test. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public static bool StringIsPositiveNumeric(string numberToTest)
        {
            if (!string.IsNullOrEmpty(numberToTest))
            {
                Regex objNotWholePattern = new Regex("[^0-9]");

                return !objNotWholePattern.IsMatch(numberToTest);
            }
            else
                return false;
        }

        #endregion StringIsPositiveNumeric

        #region StringIsNumeric

        /// <summary>
        /// Strings the is numeric. 
        /// </summary>
        /// <param name="numberToTest"> The number to test. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public static bool StringIsNumeric(string numberToTest)
        {
            if (!string.IsNullOrEmpty(numberToTest))
            {
                Regex objNotIntPattern = new Regex("[^0-9-]");
                Regex objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");

                return !objNotIntPattern.IsMatch(numberToTest) && objIntPattern.IsMatch(numberToTest);
            }
            else
                return false;
        }

        #endregion StringIsNumeric

        #region StringIsAlpha

        /// <summary>
        /// Strings the is alpha. 
        /// </summary>
        /// <param name="textToTest"> The text to test. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public static bool StringIsAlpha(string textToTest)
        {
            if (!string.IsNullOrEmpty(textToTest))
            {
                Regex objAlphaPattern = new Regex("[^a-zA-Z]");

                return !objAlphaPattern.IsMatch(textToTest);
            }
            else
                return false;
        }

        #endregion StringIsAlpha

        #region CheckStringIsAlphaNumeric

        /// <summary>
        /// Checks the string is alpha numeric. 
        /// </summary>
        /// <param name="textToTest"> The text to test. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public static bool CheckStringIsAlphaNumeric(string textToTest)
        {
            if (!string.IsNullOrEmpty(textToTest))
            {
                Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");

                return !objAlphaNumericPattern.IsMatch(textToTest);
            }
            else
                return false;
        }

        #endregion CheckStringIsAlphaNumeric
    }
}