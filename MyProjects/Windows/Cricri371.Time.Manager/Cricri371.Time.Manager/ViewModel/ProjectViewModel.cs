using Cricri371.Time.Manager.Classes;
using Cricri371.Time.Manager.Dto;
using Cricri371.Time.Manager.Model;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Cricri371.Time.Manager.ViewModel
{
    /// <summary>
    /// Class ProjectViewModel.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    public class ProjectViewModel : ViewModelBase
    {
        #region Properties : Models

        /// <summary>
        /// Gets or sets the project model.
        /// </summary>
        /// <value> The project model. </value>
        public ProjectModel ProjectModel { get; set; }

        #endregion Properties : Models

        #region Properties : Objects to bind

        #region ProjectToUse

        /// <summary>
        /// The <see cref="ProjectToUse" /> property's name.
        /// </summary>
        public const string ProjectToUsePropertyName = "ProjectToUse";

        private ProjectDto _projectToUse = new ProjectDto();

        /// <summary>
        /// Gets or sets the project to use. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The project to use. </value>
        public ProjectDto ProjectToUse
        {
            get
            {
                return this._projectToUse;
            }

            set
            {
                if (this._projectToUse == value)
                {
                    return;
                }

                RaisePropertyChanging(ProjectToUsePropertyName);
                this._projectToUse = value;
                RaisePropertyChanged(ProjectToUsePropertyName);
            }
        }

        #endregion ProjectToUse

        #region SelectedProject

        /// <summary>
        /// The <see cref="SelectedProject" /> property's name.
        /// </summary>
        public const string SelectedProjectPropertyName = "SelectedProject";

        private ProjectDto _selectedProject = new ProjectDto();

        /// <summary>
        /// Gets or sets the selected project. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The selected project. </value>
        public ProjectDto SelectedProject
        {
            get
            {
                return this._selectedProject;
            }

            set
            {
                if (this._selectedProject == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedProjectPropertyName);
                this._selectedProject = value;
                RaisePropertyChanged(SelectedProjectPropertyName);

                this.ProjectToUse = new ProjectDto();

                if (value != null)
                {
                    this.ProjectToUse.ID = value.ID;
                    this.ProjectToUse.Name = value.Name;
                    this.ProjectToUse.ShortName = value.ShortName;
                    this.ProjectToUse.Application = value.Application;
                    this.ProjectToUse.Tasks = value.Tasks;
                }

                RaisePropertyChanged(ProjectToUsePropertyName);
            }
        }

        #endregion SelectedProject

        #region SelectedApplicationIndex

        /// <summary>
        /// The <see cref="SelectedApplicationIndex" /> property's name.
        /// </summary>
        public const string SelectedApplicationIndexPropertyName = "SelectedApplicationIndex";

        private int _selectedApplicationIndex = -1;

        /// <summary>
        /// Gets or sets the index of the selected application. Changes to that property's value
        /// raise the PropertyChanged event.
        /// </summary>
        /// <value> The index of the selected application. </value>
        public int SelectedApplicationIndex
        {
            get
            {
                return this._selectedApplicationIndex;
            }

            set
            {
                if (this._selectedApplicationIndex == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedApplicationIndexPropertyName);
                this._selectedApplicationIndex = value;
                RaisePropertyChanged(SelectedApplicationIndexPropertyName);
            }
        }

        #endregion SelectedApplicationIndex

        #region SelectedProjectIndex

        /// <summary>
        /// The <see cref="SelectedProjectIndex" /> property's name.
        /// </summary>
        public const string SelectedProjectIndexPropertyName = "SelectedProjectIndex";

        private int _selectedProjectIndex = -1;

        /// <summary>
        /// Gets or sets the index of the selected project. Changes to that property's value raise
        /// the PropertyChanged event.
        /// </summary>
        /// <value> The index of the selected project. </value>
        public int SelectedProjectIndex
        {
            get
            {
                return this._selectedProjectIndex;
            }

            set
            {
                if (this._selectedProjectIndex == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedProjectIndexPropertyName);
                this._selectedProjectIndex = value;
                RaisePropertyChanged(SelectedProjectIndexPropertyName);
            }
        }

        #endregion SelectedProjectIndex

        #region TaskRemoveFromProject

        /// <summary>
        /// The <see cref="TaskRemoveFromProject" /> property's name.
        /// </summary>
        public const string TaskRemoveFromProjectPropertyName = "TaskRemoveFromProject";

        private TaskDto _taskRemoveFromProject = new TaskDto();

        /// <summary>
        /// Gets or sets the task remove from project. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The task remove from project. </value>
        public TaskDto TaskRemoveFromProject
        {
            get
            {
                return this._taskRemoveFromProject;
            }

            set
            {
                if (this._taskRemoveFromProject == value)
                {
                    return;
                }

                RaisePropertyChanging(() => this.TaskRemoveFromProject);
                this._taskRemoveFromProject = value;
                RaisePropertyChanged(() => this.TaskRemoveFromProject);

                this._taskAddToProject = null;
                RaisePropertyChanged(() => this.TaskAddToProject);
            }
        }

        #endregion TaskRemoveFromProject

        #region TaskAddToProject

        /// <summary>
        /// The <see cref="TaskAddToProject" /> property's name.
        /// </summary>
        public const string TaskAddToProjectPropertyName = "TaskAddToProject";

        private TaskDto _taskAddToProject = new TaskDto();

        /// <summary>
        /// Gets or sets the task add to project. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The task add to project. </value>
        public TaskDto TaskAddToProject
        {
            get
            {
                return this._taskAddToProject;
            }

            set
            {
                if (this._taskAddToProject == value)
                {
                    return;
                }

                RaisePropertyChanging(() => this.TaskAddToProject);
                this._taskAddToProject = value;
                RaisePropertyChanged(() => this.TaskAddToProject);

                this._taskRemoveFromProject = null;
                RaisePropertyChanged(() => this.TaskRemoveFromProject);
            }
        }

        #endregion TaskAddToProject

        #endregion Properties : Objects to bind

        #region Properties : Commands

        #region AddProjectCommand

        private RelayCommand _addProjectCommand;

        /// <summary>
        /// Gets the AddProjectCommand.
        /// </summary>
        /// <value> The add project command. </value>
        public RelayCommand AddProjectCommand
        {
            get
            {
                return this._addProjectCommand
?? (this._addProjectCommand = new RelayCommand(
       AddProject,
       () => ViewModelLocator.CommonViewModelStatic.ApplicationList.Count != 0 && (this.ProjectToUse != null && this.ProjectToUse.ID == 0)));
            }
        }

        #endregion AddProjectCommand

        #region DeleteProjectCommand

        private RelayCommand _deleteProjectCommand;

        /// <summary>
        /// Gets the DeleteProjectCommand.
        /// </summary>
        /// <value> The delete project command. </value>
        public RelayCommand DeleteProjectCommand
        {
            get
            {
                return this._deleteProjectCommand
?? (this._deleteProjectCommand = new RelayCommand(
    DeleteProject,
    () => this.ProjectToUse != null && this.ProjectToUse.ID != 0));
            }
        }

        #endregion DeleteProjectCommand

        #region ModifyProjectCommand

        private RelayCommand _modifyProjectCommand;

        /// <summary>
        /// Gets the ModifyProjectCommand.
        /// </summary>
        /// <value> The modify project command. </value>
        public RelayCommand ModifyProjectCommand
        {
            get
            {
                return this._modifyProjectCommand
?? (this._modifyProjectCommand = new RelayCommand(
    ModifyProject,
    () => this.ProjectToUse != null && this.ProjectToUse.ID != 0));
            }
        }

        #endregion ModifyProjectCommand

        #region NewProjectCommand

        private RelayCommand _newProject;

        /// <summary>
        /// Gets the NewProjectCommand.
        /// </summary>
        /// <value> The new project command. </value>
        public RelayCommand NewProjectCommand
        {
            get
            {
                return this._newProject
?? (this._newProject = new RelayCommand(
       NewProject,
       () => ViewModelLocator.CommonViewModelStatic.ApplicationList.Count != 0));
            }
        }

        #endregion NewProjectCommand

        #region ManageApplicationCommand

        private RelayCommand _manageApplicationCommand;

        /// <summary>
        /// Gets the ManageApplicationCommand.
        /// </summary>
        /// <value> The manage application command. </value>
        public RelayCommand ManageApplicationCommand
        {
            get
            {
                return this._manageApplicationCommand
?? (this._manageApplicationCommand = new RelayCommand(
ManageApplication,
() => this.ProjectToUse == null || this.ProjectToUse.ID == 0));
            }
        }

        #endregion ManageApplicationCommand

        #region AddTaskToProjectCommand

        private RelayCommand _addTaskToProjectCommand;

        /// <summary>
        /// Gets the AddTaskToProjectCommand.
        /// </summary>
        /// <value> The add task to project command. </value>
        public RelayCommand AddTaskToProjectCommand
        {
            get
            {
                return this._addTaskToProjectCommand ?? (this._addTaskToProjectCommand = new RelayCommand(
AddTaskToProject,
() => (this.ProjectToUse != null && this.ProjectToUse.ID != 0) &&
(this.ProjectToUse != null && this.ProjectToUse.ID != 0) &&
(this.TaskAddToProject != null && this.TaskAddToProject.ID != 0)));
            }
        }

        #endregion AddTaskToProjectCommand

        #region RemoveTaskFromProjectCommand

        private RelayCommand _removeTaskFromProjectCommand;

        /// <summary>
        /// Gets the RemoveTaskFromProjectCommand.
        /// </summary>
        /// <value> The remove task from project command. </value>
        public RelayCommand RemoveTaskFromProjectCommand
        {
            get
            {
                return this._removeTaskFromProjectCommand ?? (this._removeTaskFromProjectCommand = new RelayCommand(
RemoveTaskFromProject,
() => this.TaskRemoveFromProject != null && this.TaskRemoveFromProject.ID != 0));
            }
        }

        #endregion RemoveTaskFromProjectCommand

        #region OpenTaskViewCommand

        private RelayCommand _openTaskViewCommand;

        /// <summary>
        /// Gets the OpenTaskViewCommand.
        /// </summary>
        /// <value> The open task view command. </value>
        public RelayCommand OpenTaskViewCommand
        {
            get
            {
                return this._openTaskViewCommand
?? (this._openTaskViewCommand = new RelayCommand(
     () =>
     {
         Messenger.Default.Send(new NotificationMessage(this, "OpenTaskView"));
     }));
            }
        }

        #endregion OpenTaskViewCommand

        #endregion Properties : Commands

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ProjectViewModel class.
        /// </summary>
        public ProjectViewModel()
        {
            this.ProjectModel = new ProjectModel();

            if (this.IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
            }
        }

        #endregion Constructor

        #region Functions

        #region ManageApplication

        /// <summary>
        /// Manages the application.
        /// </summary>
        public void ManageApplication()
        {
            Messenger.Default.Send(new NotificationMessage(this, "OpenApplicationView"));
        }

        #endregion ManageApplication

        #region NewProject

        /// <summary>
        /// News the project.
        /// </summary>
        public void NewProject()
        {
            Messenger.Default.Send(new NotificationMessage(this, "AutoSizeProjectGridViewColumns"));

            this.ProjectToUse = new ProjectDto();

            this.SelectedProjectIndex = -1;
            this.SelectedApplicationIndex = -1;

            this.SelectedProject = new ProjectDto();
        }

        #endregion NewProject

        #region AddProject

        /// <summary>
        /// Adds the project.
        /// </summary>
        public void AddProject()
        {
            if (string.IsNullOrEmpty(this.ProjectToUse.Name) || string.IsNullOrEmpty(this.ProjectToUse.ShortName))
            {
                Messenger.Default.Send(new NotificationMessage<ProjectErrors>(ProjectErrors.ProjectNameNull, ErrorMessages.ProjectNameNull));
            }
            else
            {
                if (this.ProjectToUse.Application == null || string.IsNullOrEmpty(this.ProjectToUse.Application.Name))
                {
                    Messenger.Default.Send(new NotificationMessage<ProjectErrors>(ProjectErrors.ApplicationNotSelected, ErrorMessages.ApplicationNotSelected));
                }
                else
                {
                    if (!this.ProjectModel.CheckProjectExists(this.ProjectToUse.Name, this.ProjectToUse.ShortName, this.ProjectToUse.Application.ID))
                    {
                        this.ProjectModel.AddProject(this.ProjectToUse);

                        ViewModelLocator.CommonViewModelStatic.GetProjects();

                        NewProject();
                    }
                    else
                    {
                        Messenger.Default.Send(new NotificationMessage<ProjectErrors>(ProjectErrors.ProjectAlreadyExists, ErrorMessages.ProjectAlreadyExists));
                    }
                }
            }
        }

        #endregion AddProject

        #region DeleteProject

        /// <summary>
        /// Deletes the project.
        /// </summary>
        public void DeleteProject()
        {
            if (!this.ProjectModel.CheckProjectIsUsed(this.ProjectToUse.ID))
            {
                this.ProjectModel.DeleteProject(this.ProjectToUse);

                ViewModelLocator.CommonViewModelStatic.GetProjects();

                NewProject();
            }
            else
            {
                Messenger.Default.Send(new NotificationMessage<ProjectErrors>(ProjectErrors.ProjectUsed, ErrorMessages.ProjectUsed));
            }
        }

        #endregion DeleteProject

        #region ModifyProject

        /// <summary>
        /// Modifies the project.
        /// </summary>
        public void ModifyProject()
        {
            if (string.IsNullOrEmpty(this.ProjectToUse.Name) || string.IsNullOrEmpty(this.ProjectToUse.ShortName))
            {
                Messenger.Default.Send(new NotificationMessage<ProjectErrors>(ProjectErrors.ProjectNameNull, ErrorMessages.ProjectNameNull));
            }
            else
            {
                if (this.ProjectToUse.Application == null || string.IsNullOrEmpty(this.ProjectToUse.Application.Name))
                {
                    Messenger.Default.Send(new NotificationMessage<ProjectErrors>(ProjectErrors.ApplicationNotSelected, ErrorMessages.ApplicationNotSelected));
                }
                else
                {
                    if (!this.ProjectModel.CheckProjectExists(this.ProjectToUse.ID, this.ProjectToUse.Name, this.ProjectToUse.ShortName, this.ProjectToUse.Application.ID))
                    {
                        var projectToUpdate = new ProjectDto
                        {
                            Application = this.ProjectToUse.Application,
                            ID = this.ProjectToUse.ID,
                            Name = this.ProjectToUse.Name,
                            ShortName = this.ProjectToUse.ShortName
                        };

                        this.ProjectModel.UpdateProject(projectToUpdate);

                        ViewModelLocator.CommonViewModelStatic.GetProjects();

                        NewProject();
                    }
                    else
                    {
                        Messenger.Default.Send(new NotificationMessage<ProjectErrors>(ProjectErrors.ProjectAlreadyExists, ErrorMessages.ProjectAlreadyExists));
                    }
                }
            }
        }

        #endregion ModifyProject

        #region AddTaskToProject

        /// <summary>
        /// Adds the task to project.
        /// </summary>
        private void AddTaskToProject()
        {
            if (!this.ProjectModel.CheckTaskAlreadyLinkedToProject(this.TaskAddToProject.ID, this.ProjectToUse.ID))
            {
                var backupSelectedProjectIndex = this.SelectedProjectIndex;

                this.ProjectModel.AddTaskToProject(this.ProjectToUse, this.TaskAddToProject);
                ViewModelLocator.CommonViewModelStatic.GetProjects();

                this.SelectedProjectIndex = backupSelectedProjectIndex;
            }
            else
            {
                Messenger.Default.Send(new NotificationMessage<ProjectErrors>(ProjectErrors.TaskAlreadyLinkedToProject, ErrorMessages.TaskAlreadyLinkedToProject));
            }
        }

        #endregion AddTaskToProject

        #region RemoveTaskFromProject

        /// <summary>
        /// Removes the task from project.
        /// </summary>
        private void RemoveTaskFromProject()
        {
            if (!this.ProjectModel.CheckTaskInProjectIsUsed(this.TaskRemoveFromProject.ID, this.ProjectToUse.ID))
            {
                var backupSelectedProjectIndex = this.SelectedProjectIndex;

                this.ProjectModel.RemoveTaskFromProject(this.ProjectToUse, this.TaskRemoveFromProject);
                ViewModelLocator.CommonViewModelStatic.GetProjects();

                this.SelectedProjectIndex = backupSelectedProjectIndex;
            }
            else
            {
                Messenger.Default.Send(new NotificationMessage<ProjectErrors>(ProjectErrors.TaskIsUsedInProject, ErrorMessages.TaskIsUsedInProject));
            }
        }

        #endregion RemoveTaskFromProject

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