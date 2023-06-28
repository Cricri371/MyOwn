using System;

namespace Cricri371.Time.Manager.Dto
{
    /// <summary>
    /// Class PassedTimeDto.
    /// </summary>
    public class PassedTimeDto
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value> The project. </value>
        public ProjectDto Project { get; set; }

        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value> The task. </value>
        public TaskDto Task { get; set; }

        /// <summary>
        /// Gets or sets the start datetime.
        /// </summary>
        /// <value> The start datetime. </value>
        public DateTime StartDatetime { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets the start date time string.
        /// </summary>
        /// <value> The start date time string. </value>
        public string StartDateTimeString
        {
            get
            {
                return (this.EndDateTime == DateTime.MinValue.Date) ? string.Empty : this.StartDatetime.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the end date time.
        /// </summary>
        /// <value> The end date time. </value>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Gets the end date time string.
        /// </summary>
        /// <value> The end date time string. </value>
        public string EndDateTimeString
        {
            get
            {
                return (this.EndDateTime == DateTime.MaxValue.Date) ? string.Empty : (this.EndDateTime == DateTime.MinValue.Date) ? string.Empty : this.EndDateTime.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value> The comment. </value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <value> The duration. </value>
        public string Duration
        {
            get
            {
                return GetDuration();
            }
        }

        /// <summary>
        /// Gets the target date time string.
        /// </summary>
        /// <value> The target date time string. </value>
        public string TargetDateTimeString
        {
            get
            {
                if (this.StartDatetime.Date == this.EndDateTime.Date)
                {
                    return this.StartDatetime.Date.ToString("dd/MM/yyyy");
                }
                else
                {
                    return string.Format("{0} - {1}", this.StartDatetime.Date.ToString("dd/MM/yyyy"), this.EndDateTime.Date.ToString("dd/MM/yyyy"));
                }
            }
        }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PassedTimeDto" /> class.
        /// </summary>
        public PassedTimeDto()
        {
            this.Project = new ProjectDto();
            this.Task = new TaskDto();
        }

        #endregion Constructor

        #region GetDuration

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <returns> The duration in String. </returns>
        private string GetDuration()
        {
            var duration = Cricri371.Time.Manager.Classes.Duration.GetDuration(this.StartDatetime, this.EndDateTime);
            return Cricri371.Time.Manager.Classes.Duration.GetDurationInString(duration);
        }

        #endregion GetDuration
    }
}