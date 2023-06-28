using Cricri371.Time.Manager.Classes;
using Cricri371.Time.Manager.Dto;
using Cricri371.Time.Manager.Model;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Cricri371.Time.Manager.ViewModel
{
    /// <summary>
    /// Class TaskViewModel.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    public class TaskViewModel : ViewModelBase
    {
        #region Properties : Models

        /// <summary>
        /// Gets or sets the task model.
        /// </summary>
        /// <value> The task model. </value>
        public TaskModel TaskModel { get; set; }

        #endregion Properties : Models

        #region Properties : Objects to bind

        #region TaskToUse

        /// <summary>
        /// The <see cref="TaskToUse" /> property's name.
        /// </summary>
        public const string TaskToUsePropertyName = "TaskToUse";

        private TaskDto _taskToUse = new TaskDto();

        /// <summary>
        /// Gets or sets the task to use. Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> The task to use. </value>
        public TaskDto TaskToUse
        {
            get
            {
                return this._taskToUse;
            }

            set
            {
                if (this._taskToUse == value)
                {
                    return;
                }

                RaisePropertyChanging(TaskToUsePropertyName);
                this._taskToUse = value;
                RaisePropertyChanged(TaskToUsePropertyName);
            }
        }

        #endregion TaskToUse

        #region SelectedTask

        /// <summary>
        /// The <see cref="SelectedTask" /> property's name.
        /// </summary>
        public const string SelectedTaskPropertyName = "SelectedTask";

        private TaskDto _selectedTaskDto = new TaskDto();

        /// <summary>
        /// Gets or sets the selected task. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The selected task. </value>
        public TaskDto SelectedTask
        {
            get
            {
                return this._selectedTaskDto;
            }

            set
            {
                if (this._selectedTaskDto == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedTaskPropertyName);
                this._selectedTaskDto = value;
                RaisePropertyChanged(SelectedTaskPropertyName);

                this.TaskToUse = new TaskDto();

                if (value != null)
                {
                    this.TaskToUse.ID = value.ID;
                    this.TaskToUse.Name = value.Name;
                }

                RaisePropertyChanged(TaskToUsePropertyName);
            }
        }

        #endregion SelectedTask

        #region SelectedTaskIndex

        /// <summary>
        /// The <see cref="SelectedTaskIndex" /> property's name.
        /// </summary>
        public const string SelectedTaskIndexPropertyName = "SelectedTaskIndex";

        private int _selectedTaskIndex = -1;

        /// <summary>
        /// Gets or sets the index of the selected task. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The index of the selected task. </value>
        public int SelectedTaskIndex
        {
            get
            {
                return this._selectedTaskIndex;
            }

            set
            {
                if (this._selectedTaskIndex == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedTaskIndexPropertyName);
                this._selectedTaskIndex = value;
                RaisePropertyChanged(SelectedTaskIndexPropertyName);
            }
        }

        #endregion SelectedTaskIndex

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

                RaisePropertyChanging(() => this.SelectedProjectIndex);
                this._selectedProjectIndex = value;
                RaisePropertyChanged(() => this.SelectedProjectIndex);
            }
        }

        #endregion SelectedProjectIndex

        #endregion Properties : Objects to bind

        #region Properties : Command

        #region AddTaskCommand

        private RelayCommand _addTaskCommand;

        /// <summary>
        /// Gets the AddTaskCommand.
        /// </summary>
        /// <value> The add task command. </value>
        public RelayCommand AddTaskCommand
        {
            get
            {
                return this._addTaskCommand
?? (this._addTaskCommand = new RelayCommand(
          AddTask,
          () => this.SelectedTask != null && this.SelectedTask.ID == 0));
            }
        }

        #endregion AddTaskCommand

        #region DeleteTaskCommand

        private RelayCommand _deleteTaskCommand;

        /// <summary>
        /// Gets the DeleteTaskCommand.
        /// </summary>
        /// <value> The delete task command. </value>
        public RelayCommand DeleteTaskCommand
        {
            get
            {
                return this._deleteTaskCommand
?? (this._deleteTaskCommand = new RelayCommand(
       DeleteTask,
       () => this.SelectedTask != null && this.SelectedTask.ID != 0));
            }
        }

        #endregion DeleteTaskCommand

        #region ModifyTaskCommand

        private RelayCommand _modifyTaskCommand;

        /// <summary>
        /// Gets the ModifyTaskCommand.
        /// </summary>
        /// <value> The modify task command. </value>
        public RelayCommand ModifyTaskCommand
        {
            get
            {
                return this._modifyTaskCommand
?? (this._modifyTaskCommand = new RelayCommand(
       ModifyTask,
       () => this.SelectedTask != null && this.SelectedTask.ID != 0));
            }
        }

        #endregion ModifyTaskCommand

        #region NewTaskCommand

        private RelayCommand _newTaskCommand;

        /// <summary>
        /// Gets the NewTaskCommand.
        /// </summary>
        /// <value> The new task command. </value>
        public RelayCommand NewTaskCommand
        {
            get
            {
                return this._newTaskCommand
?? (this._newTaskCommand = new RelayCommand(
          NewTask,
          () => ViewModelLocator.CommonViewModelStatic.TaskList.Count != 0));
            }
        }

        #endregion NewTaskCommand

        #endregion Properties : Command

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the TaskViewModel class.
        /// </summary>
        public TaskViewModel()
        {
            this.TaskModel = new TaskModel();

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

        #region NewTask

        /// <summary>
        /// News the task.
        /// </summary>
        public void NewTask()
        {
            Messenger.Default.Send(new NotificationMessage(this, "AutoSizeTaskGridViewColumns"));

            this.TaskToUse = new TaskDto();

            this.SelectedTaskIndex = -1;

            this.SelectedTask = new TaskDto();
        }

        #endregion NewTask

        #region AddTask

        /// <summary>
        /// Adds the task.
        /// </summary>
        public void AddTask()
        {
            if (this.TaskToUse == null || string.IsNullOrEmpty(this.TaskToUse.Name))
            {
                Messenger.Default.Send(new NotificationMessage<TaskErrors>(TaskErrors.TaskNameNull, ErrorMessages.TaskNameNull));
            }
            else
            {
                if (!this.TaskModel.CheckTaskExists(this.TaskToUse.Name))
                {
                    this.TaskModel.AddTask(this.TaskToUse);

                    ViewModelLocator.CommonViewModelStatic.GetTasks();

                    NewTask();
                }
                else
                {
                    Messenger.Default.Send(new NotificationMessage<TaskErrors>(TaskErrors.TaskAlreadyExists, ErrorMessages.TaskAlreadyExists));
                }
            }
        }

        #endregion AddTask

        #region DeleteTask

        /// <summary>
        /// Deletes the task.
        /// </summary>
        public void DeleteTask()
        {
            if (!this.TaskModel.CheckTaskIsUsed(this.TaskToUse.ID))
            {
                this.TaskModel.DeleteTask(this.TaskToUse);

                ViewModelLocator.CommonViewModelStatic.GetTasks();

                NewTask();
            }
            else
            {
                Messenger.Default.Send(new NotificationMessage<TaskErrors>(TaskErrors.TaskUsed, ErrorMessages.TaskUsed));
            }
        }

        #endregion DeleteTask

        #region ModifyTask

        /// <summary>
        /// Modifies the task.
        /// </summary>
        public void ModifyTask()
        {
            if (this.TaskToUse == null || string.IsNullOrEmpty(this.TaskToUse.Name))
            {
                Messenger.Default.Send(new NotificationMessage<TaskErrors>(TaskErrors.TaskNameNull, ErrorMessages.TaskNameNull));
            }
            else
            {
                if (!this.TaskModel.CheckTaskExists(this.TaskToUse.ID, this.TaskToUse.Name))
                {
                    var taskToUpdate = new TaskDto
                    {
                        ID = this.TaskToUse.ID,
                        Name = this.TaskToUse.Name
                    };

                    this.TaskModel.UpdateTask(taskToUpdate);

                    ViewModelLocator.CommonViewModelStatic.GetTasks();

                    NewTask();
                }
                else
                {
                    Messenger.Default.Send(new NotificationMessage<TaskErrors>(TaskErrors.TaskAlreadyExists, ErrorMessages.TaskAlreadyExists));
                }
            }
        }

        #endregion ModifyTask

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