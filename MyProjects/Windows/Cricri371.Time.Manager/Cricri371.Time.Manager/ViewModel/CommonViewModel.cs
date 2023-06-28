using System.Collections.ObjectModel;

using Cricri371.Time.Manager.Dto;
using Cricri371.Time.Manager.Model;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Cricri371.Time.Manager.ViewModel
{
    /// <summary>
    /// Class CommonViewModel.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    public class CommonViewModel : ViewModelBase
    {
        #region Properties : Models

        /// <summary>
        /// Gets or sets the application model.
        /// </summary>
        /// <value> The application model. </value>
        public ApplicationModel ApplicationModel { get; set; }

        /// <summary>
        /// Gets or sets the company model.
        /// </summary>
        /// <value> The company model. </value>
        public CompanyModel CompanyModel { get; set; }

        /// <summary>
        /// Gets or sets the task model.
        /// </summary>
        /// <value> The task model. </value>
        public TaskModel TaskModel { get; set; }

        /// <summary>
        /// Gets or sets the project model.
        /// </summary>
        /// <value> The project model. </value>
        public ProjectModel ProjectModel { get; set; }

        #endregion Properties : Models

        #region Properties : Objects to bind

        #region CompanyList

        /// <summary>
        /// The <see cref="CompanyList" /> property's name.
        /// </summary>
        public const string CompanyListPropertyName = "CompanyList";

        private ObservableCollection<CompanyDto> _companyList = new ObservableCollection<CompanyDto>();

        /// <summary>
        /// Gets or sets the company list. Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> The company list. </value>
        public ObservableCollection<CompanyDto> CompanyList
        {
            get
            {
                return this._companyList;
            }

            set
            {
                if (this._companyList == value)
                {
                    return;
                }

                this._companyList = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(CompanyListPropertyName);
            }
        }

        #endregion CompanyList

        #region ApplicationList

        /// <summary>
        /// The <see cref="ApplicationList" /> property's name.
        /// </summary>
        public const string ApplicationListPropertyName = "ApplicationList";

        private ObservableCollection<ApplicationDto> _applicationList = new ObservableCollection<ApplicationDto>();

        /// <summary>
        /// Gets or sets the application list. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The application list. </value>
        public ObservableCollection<ApplicationDto> ApplicationList
        {
            get
            {
                return this._applicationList;
            }

            set
            {
                if (this._applicationList == value)
                {
                    return;
                }

                this._applicationList = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ApplicationListPropertyName);
            }
        }

        #endregion ApplicationList

        #region TaskList

        /// <summary>
        /// The <see cref="TaskList" /> property's name.
        /// </summary>
        public const string TaskListPropertyName = "TaskList";

        private ObservableCollection<TaskDto> _taskList = new ObservableCollection<TaskDto>();

        /// <summary>
        /// Gets or sets the task list. Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> The task list. </value>
        public ObservableCollection<TaskDto> TaskList
        {
            get
            {
                return this._taskList;
            }

            set
            {
                if (this._taskList == value)
                {
                    return;
                }

                this._taskList = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(TaskListPropertyName);
            }
        }

        #endregion TaskList

        #region ProjectList

        /// <summary>
        /// The <see cref="ProjectList" /> property's name.
        /// </summary>
        public const string ProjectListPropertyName = "ProjectList";

        private ObservableCollection<ProjectDto> _projectList = new ObservableCollection<ProjectDto>();

        /// <summary>
        /// Gets or sets the project list. Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> The project list. </value>
        public ObservableCollection<ProjectDto> ProjectList
        {
            get
            {
                return this._projectList;
            }

            set
            {
                if (this._projectList == value)
                {
                    return;
                }

                this._projectList = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ProjectListPropertyName);
            }
        }

        #endregion ProjectList

        #endregion Properties : Objects to bind

        #region Properties : Commands

        #region GetApplicationsCommand

        private RelayCommand _getApplicationsCommand;

        /// <summary>
        /// Gets the GetApplicationsCommand.
        /// </summary>
        /// <value> The get applications command. </value>
        public RelayCommand GetApplicationsCommand
        {
            get
            {
                return this._getApplicationsCommand
?? (this._getApplicationsCommand = new RelayCommand(GetApplications));
            }
        }

        #endregion GetApplicationsCommand

        #region GetCompaniesCommand

        private RelayCommand _getCompaniesCommand;

        /// <summary>
        /// Gets the GetCompaniesCommand.
        /// </summary>
        /// <value> The get companies command. </value>
        public RelayCommand GetCompaniesCommand
        {
            get
            {
                return this._getCompaniesCommand
?? (this._getCompaniesCommand = new RelayCommand(GetCompanies));
            }
        }

        #endregion GetCompaniesCommand

        #region GetTasksCommand

        private RelayCommand _getTasksCommand;

        /// <summary>
        /// Gets the GetTasksCommand.
        /// </summary>
        /// <value> The get tasks command. </value>
        public RelayCommand GetTasksCommand
        {
            get
            {
                return this._getTasksCommand
?? (this._getTasksCommand = new RelayCommand(GetTasks));
            }
        }

        #endregion GetTasksCommand

        #region GetProjectsCommand

        private RelayCommand _getProjectsCommand;

        /// <summary>
        /// Gets the GetProjectsCommand.
        /// </summary>
        /// <value> The get projects command. </value>
        public RelayCommand GetProjectsCommand
        {
            get
            {
                return this._getProjectsCommand
?? (this._getProjectsCommand = new RelayCommand(GetProjects));
            }
        }

        #endregion GetProjectsCommand

        #endregion Properties : Commands

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the CommonViewModel class.
        /// </summary>
        public CommonViewModel()
        {
            this.ApplicationModel = new ApplicationModel();
            this.CompanyModel = new CompanyModel();
            this.TaskModel = new TaskModel();
            this.ProjectModel = new ProjectModel();

            if (this.IsInDesignMode)
            {
            }
            else
            {
                GetApplications();
                GetCompanies();
                GetTasks();
                GetProjects();
            }
        }

        #endregion Constructor

        #region Functions

        #region GetApplications

        /// <summary>
        /// Gets the applications.
        /// </summary>
        public void GetApplications()
        {
            this.ApplicationList = new ObservableCollection<ApplicationDto>(this.ApplicationModel.GetApplications());
        }

        #endregion GetApplications

        #region GetTasks

        /// <summary>
        /// Gets the tasks.
        /// </summary>
        public void GetTasks()
        {
            this.TaskList = new ObservableCollection<TaskDto>(this.TaskModel.GetTasks());
        }

        #endregion GetTasks

        #region GetCompanies

        /// <summary>
        /// Gets the companies.
        /// </summary>
        public void GetCompanies()
        {
            this.CompanyList = new ObservableCollection<CompanyDto>(this.CompanyModel.GetCompanies());
        }

        #endregion GetCompanies

        #region GetProjects

        /// <summary>
        /// Gets the projects.
        /// </summary>
        public void GetProjects()
        {
            this.ProjectList = new ObservableCollection<ProjectDto>(this.ProjectModel.GetProjects());
        }

        #endregion GetProjects

        #endregion Functions

        #region Cleanup

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        public override void Cleanup()
        {
            // Clean own resources if needed
            base.Cleanup();
        }

        #endregion Cleanup
    }
}