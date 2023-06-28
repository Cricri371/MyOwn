using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;

namespace Cricri371.Time.Manager.Dto
{
    /// <summary>
    /// Class ProjectDto.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ObservableObject" />
    public class ProjectDto : ObservableObject
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value> The name. </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value> The short name. </value>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value> The application. </value>
        public ApplicationDto Application { get; set; }

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value> The tasks. </value>
        public ObservableCollection<TaskDto> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the short name of the application project.
        /// </summary>
        /// <value> The short name of the application project. </value>
        public string ApplicationProjectShortName
        {
            get
            {
                return string.Format("{0} : {1}", this.Application.Name, this.ShortName);
            }

            set
            {
                RaisePropertyChanged("ApplicationProjectShortName");
            }
        }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectDto" /> class.
        /// </summary>
        public ProjectDto()
        {
            this.Application = new ApplicationDto();
            this.Tasks = new ObservableCollection<TaskDto>();
        }

        #endregion Constructor
    }
}