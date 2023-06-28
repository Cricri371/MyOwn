using System;
using System.Globalization;
using System.Windows.Data;

using Cricri371.Time.Manager.Dto;

namespace Cricri371.Time.Manager.Classes
{
    /// <summary>
    /// Class SumTimeConverter.
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class SumTimeConverter : IValueConverter
    {
        #region IValueConverter Members

        #region Convert

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">      The value produced by the binding source. </param>
        /// <param name="targetType"> The type of the binding target property. </param>
        /// <param name="parameter">  The converter parameter to use. </param>
        /// <param name="culture">    The culture to use in the converter. </param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var group = value as CollectionViewGroup;

            var ts = new TimeSpan();
            var firstPass = true;
            for (var j = 0; j < group.Items.Count; j++)
            {
                GetPassedTime(group.Items[j], ref firstPass, ref ts);
            }

            return Duration.GetDurationInString(ts);
        }

        #endregion Convert

        #region ConvertBack

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">      The value that is produced by the binding target. </param>
        /// <param name="targetType"> The type to convert to. </param>
        /// <param name="parameter">  The converter parameter to use. </param>
        /// <param name="culture">    The culture to use in the converter. </param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <exception cref="NotImplementedException">Thrown when not implemented.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion ConvertBack

        #endregion IValueConverter Members

        #region GetPassedTime

        /// <summary>
        /// Gets the passed time.
        /// </summary>
        /// <param name="group">     The group. </param>
        /// <param name="firstPass"> if set to <c> true </c> [first pass]. </param>
        /// <param name="ts">        The ts. </param>
        private void GetPassedTime(object group, ref bool firstPass, ref TimeSpan ts)
        {
            if (group is PassedTimeDto)
            {
                if (firstPass)
                {
                    ts = Duration.GetDuration(((PassedTimeDto)group).StartDatetime, ((PassedTimeDto)group).EndDateTime);
                    firstPass = false;
                }
                else
                {
                    ts = ts.Add(Duration.GetDuration(((PassedTimeDto)group).StartDatetime, ((PassedTimeDto)group).EndDateTime));
                }

                return;
            }

            foreach (var g in (group as CollectionViewGroup).Items)
            {
                GetPassedTime(g, ref firstPass, ref ts);
            }
        }

        #endregion GetPassedTime
    }
}