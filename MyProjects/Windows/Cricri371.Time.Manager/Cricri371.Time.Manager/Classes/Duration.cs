using System;

namespace Cricri371.Time.Manager.Classes
{
    public static class Duration
    {
        #region GetDuration

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>The duration.</returns>
        public static TimeSpan GetDuration(DateTime start, DateTime end)
        {
            TimeSpan? ts = null;
            if (end != DateTime.MaxValue.Date)
            {
                ts = end.Subtract(start);
            }
            else
            {
                ts = DateTime.Now.Subtract(start);
            }

            return ts.Value;
        }

        #endregion GetDuration

        #region GetDurationInString

        /// <summary>
        /// Gets the duration in string.
        /// </summary>
        /// <param name="ts">The ts.</param>
        /// <returns>The duration in string.</returns>
        public static string GetDurationInString(TimeSpan ts)
        {
            var duration = string.Empty;

            var days = ts.Days;
            if (days > 0)
            {
                duration += days + " d ";
            }

            var hours = ts.Hours;
            if (hours > 0 || !string.IsNullOrEmpty(duration))
            {
                duration += AppendZeroToHaveTwoDigits(days, hours) + " h ";
            }

            var minutes = ts.Minutes;
            if (minutes > 0 || !string.IsNullOrEmpty(duration))
            {
                duration += AppendZeroToHaveTwoDigits(hours, minutes) + " min ";
            }

            var seconds = ts.Seconds;
            if (seconds > 0 || !string.IsNullOrEmpty(duration))
            {
                duration += AppendZeroToHaveTwoDigits(minutes, seconds) + " sec ";
            }

            return duration;
        }

        #endregion GetDurationInString

        #region AppendZeroToHaveTwoDigits

        /// <summary>
        /// Appends the zero to have two digits.
        /// </summary>
        /// <param name="previousTime">The previous time.</param>
        /// <param name="time">The time.</param>
        /// <returns>The well formated two digits time.</returns>
        private static string AppendZeroToHaveTwoDigits(int previousTime, int time)
        {
            if ((time >= 0 && time <= 9) && previousTime > 0)
            {
                return "0" + time;
            }
            else
            {
                return time.ToString();
            }
        }

        #endregion AppendZeroToHaveTwoDigits
    }
}