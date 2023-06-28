using System;
using System.Security.Cryptography;

namespace Cricri371.Framework.Security
{
    /// <summary>
    /// Class CodeGenerator. This class cannot be inherited. 
    /// </summary>
    public sealed class CodeGenerator
    {
        #region GenerateCode

        /// <summary>
        /// Generates the code. 
        /// </summary>
        /// <returns> The code. </returns>
        public static string GenerateCode()
        {
            return GenerateCode(null);
        }

        /// <summary>
        /// Generates the code. 
        /// </summary>
        /// <param name="passKey"> The pass key. </param>
        /// <returns> The code. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string GenerateCode(string passKey)
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);

            try
            {
                var random = BitConverter.ToUInt32(bytes, 0) % 100000000;

                var characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#";
                if (!string.IsNullOrEmpty(passKey))
                    characters = passKey;

                var ticks = DateTime.UtcNow.Ticks.ToString();
                var code = string.Empty;
                for (var i = 0; i < characters.Length; i += 2)
                {
                    if ((i + 2) <= ticks.Length)
                    {
                        var number = int.Parse(ticks.Substring(i, 2));
                        if (number > characters.Length - 1)
                        {
                            var one = double.Parse(number.ToString().Substring(0, 1));
                            var two = double.Parse(number.ToString().Substring(1, 1));
                            code += characters[Convert.ToInt32(one)];
                            code += characters[Convert.ToInt32(two)];
                        }
                        else
                            code += characters[number];
                    }
                }

                return code + string.Format("{0:D8}", random);
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
            catch (FormatException fE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fE, true));
            }
            catch (OverflowException oE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(oE, true));
            }
        }

        #endregion GenerateCode
    }
}