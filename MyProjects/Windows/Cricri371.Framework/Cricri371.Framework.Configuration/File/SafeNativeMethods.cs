using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Cricri371.Framework.Configuration.File
{
    /// <summary>
    /// Class SafeNativeMethods. 
    /// </summary>
    [SuppressUnmanagedCodeSecurityAttribute]
    internal static class SafeNativeMethods
    {
        /// <summary>
        /// Writes the private profile string. 
        /// </summary>
        /// <param name="section">  The section. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="fileName"> Name of the file. </param>
        /// <returns> System.Int32. </returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int WritePrivateProfileString(string section, string key, string value, string fileName);

        /// <summary>
        /// Writes the private profile string. 
        /// </summary>
        /// <param name="section">  The section. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="fileName"> Name of the file. </param>
        /// <returns> System.Int32. </returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int WritePrivateProfileString(string section, string key, IntPtr value, string fileName);

        /// <summary>
        /// Writes the private profile string. 
        /// </summary>
        /// <param name="section">  The section. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="fileName"> Name of the file. </param>
        /// <returns> System.Int32. </returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int WritePrivateProfileString(string section, IntPtr key, string value, string fileName);

        /// <summary>
        /// Gets the private profile string. 
        /// </summary>
        /// <param name="section">      The section. </param>
        /// <param name="key">          The key. </param>
        /// <param name="defaultValue"> The default value. </param>
        /// <param name="result">       The result. </param>
        /// <param name="size">         The size. </param>
        /// <param name="fileName">     Name of the file. </param>
        /// <returns> System.Int32. </returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        internal static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder result, int size, string fileName);

        /// <summary>
        /// Gets the private profile string. 
        /// </summary>
        /// <param name="section">      The section. </param>
        /// <param name="key">          The key. </param>
        /// <param name="defaultValue"> The default value. </param>
        /// <param name="result">       The result. </param>
        /// <param name="size">         The size. </param>
        /// <param name="fileName">     Name of the file. </param>
        /// <returns> System.Int32. </returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        internal static extern int GetPrivateProfileString(string section, IntPtr key, string defaultValue, [MarshalAs(UnmanagedType.LPArray)] byte[] result, int size, string fileName);

        /// <summary>
        /// Gets the private profile string. 
        /// </summary>
        /// <param name="section">      The section. </param>
        /// <param name="key">          The key. </param>
        /// <param name="defaultValue"> The default value. </param>
        /// <param name="result">       The result. </param>
        /// <param name="size">         The size. </param>
        /// <param name="fileName">     Name of the file. </param>
        /// <returns> System.Int32. </returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        internal static extern int GetPrivateProfileString(IntPtr section, string key, string defaultValue, [MarshalAs(UnmanagedType.LPArray)] byte[] result, int size, string fileName);
    }
}