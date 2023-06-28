using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace Cricri371.Time.Manager.Views
{
    /// <summary>
    /// Class WindowExtensions.
    /// </summary>
    internal static class WindowExtensions
    {
        /// <summary>
        /// Sets the window long.
        /// </summary>
        /// <param name="hwnd">  The HWND. </param>
        /// <param name="index"> The index. </param>
        /// <param name="value"> The value. </param>
        /// <returns> System.Int32. </returns>
        [DllImport("user32.dll")]
        internal static extern int SetWindowLong(IntPtr hwnd, int index, int value);

        /// <summary>
        /// Gets the window long.
        /// </summary>
        /// <param name="hwnd">  The HWND. </param>
        /// <param name="index"> The index. </param>
        /// <returns> System.Int32. </returns>
        [DllImport("user32.dll")]
        internal static extern int GetWindowLong(IntPtr hwnd, int index);

        /// <summary>
        /// Disables the maximize button.
        /// </summary>
        /// <param name="window"> The window. </param>
        internal static void DisableMaximizeButton(this Window window)
        {
            const int GWL_STYLE = -16;
            var hwnd = new System.Windows.Interop.WindowInteropHelper(window).Handle;
            long value = GetWindowLong(hwnd, GWL_STYLE);
            SetWindowLong(hwnd, GWL_STYLE, (int)(value & -65537));
        }

        /// <summary>
        /// Disables the minimize button.
        /// </summary>
        /// <param name="window"> The window. </param>
        internal static void DisableMinimizeButton(this Window window)
        {
            const int GWL_STYLE = -16;
            var hwnd = new System.Windows.Interop.WindowInteropHelper(window).Handle;
            long value = GetWindowLong(hwnd, GWL_STYLE);
            SetWindowLong(hwnd, GWL_STYLE, (int)(value & -131073));
        }       
    }
}