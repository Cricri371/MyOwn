using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;

using Cricri371.Framework.Configuration.AppSettings;
using Cricri371.Time.Manager.Classes;
using Cricri371.Time.Manager.Dto;
using Cricri371.Time.Manager.Model;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Cricri371.Time.Manager.ViewModel
{
    /// <summary>
    /// Class MainViewModel.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    public class MainViewModel : ViewModelBase
    {
        private readonly DispatcherTimer _timer;

        /// <summary>
        /// Gets or sets the current date.
        /// </summary>
        /// <value> The current date. </value>
        public DateTime CurrentDate { get; set; }

        #region Properties : Models

        /// <summary>
        /// Gets or sets the passed time model.
        /// </summary>
        /// <value> The passed time model. </value>
        public PassedTimeModel PassedTimeModel { get; set; }

        #endregion Properties : Models

        #region Properties : Objects to bind

        #region TargetDate

        /// <summary>
        /// The <see cref="TargetDate" /> property's name.
        /// </summary>
        public const string TargetDatePropertyName = "TargetDate";

        private DateTime _targetDate = DateTime.Now.Date;

        /// <summary>
        /// Gets or sets the target date. Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> The target date. </value>
        public DateTime TargetDate
        {
            get
            {
                return this._targetDate;
            }

            set
            {
                if (this._targetDate == value)
                {
                    return;
                }

                this._targetDate = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(TargetDatePropertyName);
            }
        }

        #endregion TargetDate

        #region PassedTimeList

        /// <summary>
        /// The <see cref="PassedTimeList" /> property's name.
        /// </summary>
        public const string PassedTimeListPropertyName = "PassedTimeList";

        private ObservableCollection<PassedTimeDto> _passedTimeList = new ObservableCollection<PassedTimeDto>();

        /// <summary>
        /// Gets or sets the passed time list. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The passed time list. </value>
        public ObservableCollection<PassedTimeDto> PassedTimeList
        {
            get
            {
                return this._passedTimeList;
            }

            set
            {
                if (this._passedTimeList == value)
                {
                    return;
                }

                this._passedTimeList = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(PassedTimeListPropertyName);
            }
        }

        #endregion PassedTimeList

        #region SelectedPassedTime

        /// <summary>
        /// The <see cref="SelectedPassedTime" /> property's name.
        /// </summary>
        public const string SelectedPassedTimePropertyName = "SelectedPassedTime";

        private PassedTimeDto _passedTime = new PassedTimeDto();

        /// <summary>
        /// Gets or sets the selected passed time. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The selected passed time. </value>
        public PassedTimeDto SelectedPassedTime
        {
            get
            {
                return this._passedTime;
            }

            set
            {
                if (this._passedTime == value)
                {
                    return;
                }

                this._passedTime = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(SelectedPassedTimePropertyName);

                this.PassedTimeToUpdate = new PassedTimeDto();

                if (value != null)
                {
                    this.PassedTimeToUpdate.ID = value.ID;
                    this.PassedTimeToUpdate.Comment = value.Comment;
                    this.PassedTimeToUpdate.StartDatetime = value.StartDatetime;
                    this.PassedTimeToUpdate.EndDateTime = value.EndDateTime;
                    this.PassedTimeToUpdate.Project = value.Project;
                    this.PassedTimeToUpdate.Task = value.Task;
                }

                RaisePropertyChanged(PassedTimeToUpdatePropertyName);

                if (this._passedTime != null)
                {
                    if (this._passedTime.EndDateTime != DateTime.MaxValue.Date)
                    {
                        this.EnableUpdateMenuEntries = true;
                    }
                    else
                    {
                        this.EnableUpdateMenuEntries = false;
                    }
                }
                else
                {
                    this.EnableUpdateMenuEntries = false;
                }
            }
        }

        #endregion SelectedPassedTime

        #region PassedTimeToUpdate

        /// <summary>
        /// The <see cref="PassedTimeToUpdate" /> property's name.
        /// </summary>
        public const string PassedTimeToUpdatePropertyName = "PassedTimeToUpdate";

        private PassedTimeDto _passedTimeToUpdate = new PassedTimeDto();

        /// <summary>
        /// Gets or sets the passed time to update. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The passed time to update. </value>
        public PassedTimeDto PassedTimeToUpdate
        {
            get
            {
                return this._passedTimeToUpdate;
            }

            set
            {
                if (this._passedTimeToUpdate == value)
                {
                    return;
                }

                this._passedTimeToUpdate = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(PassedTimeToUpdatePropertyName);
            }
        }

        #endregion PassedTimeToUpdate

        #region SelectedProjectIndexPassedTime

        /// <summary>
        /// The <see cref="SelectedProjectIndexPassedTime" /> property's name.
        /// </summary>
        public const string SelectedProjectIndexPassedTimePropertyName = "SelectedProjectIndexPassedTime";

        private int _selectedProjectIndexPassedTime = -1;

        /// <summary>
        /// Gets or sets the selected project index passed time. Changes to that property's value
        /// raise the PropertyChanged event.
        /// </summary>
        /// <value> The selected project index passed time. </value>
        public int SelectedProjectIndexPassedTime
        {
            get
            {
                return this._selectedProjectIndexPassedTime;
            }

            set
            {
                if (this._selectedProjectIndexPassedTime == value)
                {
                    return;
                }

                this._selectedProjectIndexPassedTime = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(SelectedProjectIndexPassedTimePropertyName);
            }
        }

        #endregion SelectedProjectIndexPassedTime

        #region SelectedProjectIndexPassedTimeToUpdate

        /// <summary>
        /// The <see cref="SelectedProjectIndexPassedTimeToUpdate" /> property's name.
        /// </summary>
        public const string SelectedProjectIndexPassedTimeToUpdatePropertyName = "SelectedProjectIndexPassedTimeToUpdate";

        private int _selectedProjectIndexPassedTimeToUpdate = -1;

        /// <summary>
        /// Gets or sets the selected project index passed time to update. Changes to that property's
        /// value raise the PropertyChanged event.
        /// </summary>
        /// <value> The selected project index passed time to update. </value>
        public int SelectedProjectIndexPassedTimeToUpdate
        {
            get
            {
                return this._selectedProjectIndexPassedTimeToUpdate;
            }

            set
            {
                if (this._selectedProjectIndexPassedTimeToUpdate == value)
                {
                    return;
                }

                this._selectedProjectIndexPassedTimeToUpdate = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(SelectedProjectIndexPassedTimeToUpdatePropertyName);
            }
        }

        #endregion SelectedProjectIndexPassedTimeToUpdate

        #region SelectedTaskIndexPassedTime

        /// <summary>
        /// The <see cref="SelectedTaskIndexPassedTime" /> property's name.
        /// </summary>
        public const string SelectedTaskIndexPassedTimePropertyName = "SelectedTaskIndexPassedTime";

        private int _selectedTaskIndexPassedTime = -1;

        /// <summary>
        /// Gets or sets the selected task index passed time. Changes to that property's value raise
        /// the PropertyChanged event.
        /// </summary>
        /// <value> The selected task index passed time. </value>
        public int SelectedTaskIndexPassedTime
        {
            get
            {
                return this._selectedTaskIndexPassedTime;
            }

            set
            {
                if (this._selectedTaskIndexPassedTime == value)
                {
                    return;
                }

                this._selectedTaskIndexPassedTime = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(SelectedTaskIndexPassedTimePropertyName);
            }
        }

        #endregion SelectedTaskIndexPassedTime

        #region SelectedTaskIndexPassedTimeToUpdate

        /// <summary>
        /// The <see cref="SelectedTaskIndexPassedTimeToUpdate" /> property's name.
        /// </summary>
        public const string SelectedTaskIndexPassedTimeToUpdatePropertyName = "SelectedTaskIndexPassedTimeToUpdate";

        private int _selectedTaskIndexPassedTimeToUpdate = -1;

        /// <summary>
        /// Gets or sets the selected task index passed time to update. Changes to that property's
        /// value raise the PropertyChanged event.
        /// </summary>
        /// <value> The selected task index passed time to update. </value>
        public int SelectedTaskIndexPassedTimeToUpdate
        {
            get
            {
                return this._selectedTaskIndexPassedTimeToUpdate;
            }

            set
            {
                if (this._selectedTaskIndexPassedTimeToUpdate == value)
                {
                    return;
                }

                this._selectedTaskIndexPassedTimeToUpdate = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(SelectedTaskIndexPassedTimeToUpdatePropertyName);
            }
        }

        #endregion SelectedTaskIndexPassedTimeToUpdate

        #region StartPastFutureDateTime

        /// <summary>
        /// The <see cref="StartPastFutureDateTime" /> property's name.
        /// </summary>
        public const string StartPastFutureDateTimePropertyName = "StartPastFutureDateTime";

        private DateTime? _startPastFutureDateTime = null;

        /// <summary>
        /// Gets or sets the start past future date time. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The start past future date time. </value>
        public DateTime? StartPastFutureDateTime
        {
            get
            {
                return this._startPastFutureDateTime;
            }

            set
            {
                if (this._startPastFutureDateTime == value)
                {
                    return;
                }

                this._startPastFutureDateTime = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(StartPastFutureDateTimePropertyName);
            }
        }

        #endregion StartPastFutureDateTime

        #region EndPastFutureDateTime

        /// <summary>
        /// The <see cref="EndPastFutureDateTime" /> property's name.
        /// </summary>
        public const string EndPastFutureDateTimePropertyName = "EndPastFutureDateTime";

        private DateTime? _endPastFutureDateTime = null;

        /// <summary>
        /// Gets or sets the end past future date time. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The end past future date time. </value>
        public DateTime? EndPastFutureDateTime
        {
            get
            {
                return this._endPastFutureDateTime;
            }

            set
            {
                if (this._endPastFutureDateTime == value)
                {
                    return;
                }

                this._endPastFutureDateTime = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(EndPastFutureDateTimePropertyName);
            }
        }

        #endregion EndPastFutureDateTime

        #region EnableUpdateMenuEntries

        /// <summary>
        /// The <see cref="EnableUpdateMenuEntries" /> property's name.
        /// </summary>
        public const string EnableUpdateMenuEntriesPropertyName = "EnableUpdateMenuEntries";

        private bool _enableUpdateMenuEntries = false;

        /// <summary>
        /// Gets or sets a value indicating whether [enable update menu entries]. Changes to that
        /// property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if [enable update menu entries]; otherwise, <c> false </c>. </value>
        public bool EnableUpdateMenuEntries
        {
            get
            {
                return this._enableUpdateMenuEntries;
            }

            set
            {
                if (this._enableUpdateMenuEntries == value)
                {
                    return;
                }

                this._enableUpdateMenuEntries = value;

                RaisePropertyChanged(EnableUpdateMenuEntriesPropertyName);
            }
        }

        #endregion EnableUpdateMenuEntries

        #region DurationCurrentDate

        /// <summary>
        /// The <see cref="DurationCurrentDate" /> property's name.
        /// </summary>
        public const string DurationCurrentDatePropertyName = "DurationCurrentDate";

        private string _durationCurrentDate = string.Empty;

        /// <summary>
        /// Gets or sets the duration current date. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The duration current date. </value>
        public string DurationCurrentDate
        {
            get
            {
                return this._durationCurrentDate;
            }

            set
            {
                if (this._durationCurrentDate == value)
                {
                    return;
                }

                RaisePropertyChanging(() => this.DurationCurrentDate);
                this._durationCurrentDate = value;
                RaisePropertyChanged(() => this.DurationCurrentDate);
            }
        }

        #endregion DurationCurrentDate

        #region SecondPassedTimeToUpdate

        /// <summary>
        /// The <see cref="SecondPassedTimeToUpdate" /> property's name.
        /// </summary>
        public const string SecondPassedTimeToUpdatePropertyName = "SecondPassedTimeToUpdate";

        private PassedTimeDto _secondPassedTimeToUpdate = new PassedTimeDto();

        /// <summary>
        /// Gets or sets the second passed time to update. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The second passed time to update. </value>
        public PassedTimeDto SecondPassedTimeToUpdate
        {
            get
            {
                return this._secondPassedTimeToUpdate;
            }

            set
            {
                if (this._secondPassedTimeToUpdate == value)
                {
                    return;
                }

                this._secondPassedTimeToUpdate = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(SecondPassedTimeToUpdatePropertyName);
            }
        }

        #endregion SecondPassedTimeToUpdate

        #region SelectedProjectIndexSecondPassedTime

        /// <summary>
        /// The <see cref="SelectedProjectIndexSecondPassedTime" /> property's name.
        /// </summary>
        public const string SelectedProjectIndexSecondPassedTimePropertyName = "SelectedProjectIndexSecondPassedTime";

        private int _selectedProjectIndexSecondPassedTime = -1;

        /// <summary>
        /// Gets or sets the selected project index second passed time. Changes to that property's
        /// value raise the PropertyChanged event.
        /// </summary>
        /// <value> The selected project index second passed time. </value>
        public int SelectedProjectIndexSecondPassedTime
        {
            get
            {
                return this._selectedProjectIndexSecondPassedTime;
            }

            set
            {
                if (this._selectedProjectIndexSecondPassedTime == value)
                {
                    return;
                }

                this._selectedProjectIndexSecondPassedTime = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(SelectedProjectIndexSecondPassedTimePropertyName);
            }
        }

        #endregion SelectedProjectIndexSecondPassedTime

        #region SelectedProjectIndexSecondPassedTimeToUpdate

        /// <summary>
        /// The <see cref="SelectedProjectIndexSecondPassedTimeToUpdate" /> property's name.
        /// </summary>
        public const string SelectedProjectIndexSecondPassedTimeToUpdatePropertyName = "SelectedProjectIndexSecondPassedTimeToUpdate";

        private int _selectedProjectIndexSecondPassedTimeToUpdate = -1;

        /// <summary>
        /// Gets or sets the selected project index second passed time to update. Changes to that
        /// property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> The selected project index second passed time to update. </value>
        public int SelectedProjectIndexSecondPassedTimeToUpdate
        {
            get
            {
                return this._selectedProjectIndexSecondPassedTimeToUpdate;
            }

            set
            {
                if (this._selectedProjectIndexSecondPassedTimeToUpdate == value)
                {
                    return;
                }

                this._selectedProjectIndexSecondPassedTimeToUpdate = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(SelectedProjectIndexSecondPassedTimeToUpdatePropertyName);
            }
        }

        #endregion SelectedProjectIndexSecondPassedTimeToUpdate

        #region SelectedTaskIndexSecondPassedTime

        /// <summary>
        /// The <see cref="SelectedTaskIndexSecondPassedTime" /> property's name.
        /// </summary>
        public const string SelectedTaskIndexSecondPassedTimePropertyName = "SelectedTaskIndexSecondPassedTime";

        private int _selectedTaskIndexSecondPassedTime = -1;

        /// <summary>
        /// Gets or sets the selected task index second passed time. Changes to that property's value
        /// raise the PropertyChanged event.
        /// </summary>
        /// <value> The selected task index second passed time. </value>
        public int SelectedTaskIndexSecondPassedTime
        {
            get
            {
                return this._selectedTaskIndexSecondPassedTime;
            }

            set
            {
                if (this._selectedTaskIndexSecondPassedTime == value)
                {
                    return;
                }

                this._selectedTaskIndexSecondPassedTime = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(SelectedTaskIndexSecondPassedTimePropertyName);
            }
        }

        #endregion SelectedTaskIndexSecondPassedTime

        #region SelectedTaskIndexSecondPassedTimeToUpdate

        /// <summary>
        /// The <see cref="SelectedTaskIndexSecondPassedTimeToUpdate" /> property's name.
        /// </summary>
        public const string SelectedTaskIndexSecondPassedTimeToUpdatePropertyName = "SelectedTaskIndexSecondPassedTimeToUpdate";

        private int _selectedTaskIndexSecondPassedTimeToUpdate = -1;

        /// <summary>
        /// Gets or sets the selected task index second passed time to update. Changes to that
        /// property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> The selected task index second passed time to update. </value>
        public int SelectedTaskIndexSecondPassedTimeToUpdate
        {
            get
            {
                return this._selectedTaskIndexSecondPassedTimeToUpdate;
            }

            set
            {
                if (this._selectedTaskIndexSecondPassedTimeToUpdate == value)
                {
                    return;
                }

                this._selectedTaskIndexSecondPassedTimeToUpdate = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(SelectedTaskIndexSecondPassedTimeToUpdatePropertyName);
            }
        }

        #endregion SelectedTaskIndexSecondPassedTimeToUpdate

        #region ValueSlider

        private readonly double _valueSlider = 0;

        /// <summary>
        /// Gets the value slider.
        /// </summary>
        /// <value>The value slider.</value>
        public double ValueSlider
        {
            get
            {
                return this._valueSlider;
            }

            set
            {
                this.ValueSlider = this.PassedTimeToUpdate.EndDateTime.Subtract(this.PassedTimeToUpdate.EndDateTime).TotalMinutes;
            }
        }

        #endregion ValueSlider

        #region SplitDateTime

        /// <summary>
        /// The <see cref="SplitDateTime" /> property's name.
        /// </summary>
        public const string SplitDateTimePropertyName = "SplitDateTime";

        private DateTime? _splitDateTime = null;

        /// <summary>
        /// Sets and gets the SplitDateTime property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public DateTime? SplitDateTime
        {
            get
            {
                return this._splitDateTime;
            }

            set
            {
                if (this._splitDateTime == value)
                {
                    return;
                }

                this._splitDateTime = value;
                RaisePropertyChanged(SplitDateTimePropertyName);
            }
        }

        #endregion SplitDateTime

        #endregion Properties : Objects to bind

        #region Properties : Commands

        #region AddPastFuturePassedTimeCommand

        private RelayCommand _addPastFuturePassedTimeCommand;

        /// <summary>
        /// Gets the AddPastFuturePassedTimeCommand.
        /// </summary>
        /// <value> The add past future passed time command. </value>
        public RelayCommand AddPastFuturePassedTimeCommand
        {
            get
            {
                return this._addPastFuturePassedTimeCommand
?? (this._addPastFuturePassedTimeCommand = new RelayCommand(
AddPastFuturePassedTime, ExistData));
            }
        }

        #endregion AddPastFuturePassedTimeCommand

        #region StartPassedTimeCommand

        private RelayCommand _startPassedTimeCommand;

        /// <summary>
        /// Gets the StartPassedTimeCommand.
        /// </summary>
        /// <value> The start passed time command. </value>
        public RelayCommand StartPassedTimeCommand
        {
            get
            {
                return this._startPassedTimeCommand
?? (this._startPassedTimeCommand = new RelayCommand(
  StartPassedTime, ExistData));
            }
        }

        #endregion StartPassedTimeCommand

        #region StopPassedTimeCommand

        private RelayCommand _stopPassedTimeCommand;

        /// <summary>
        /// Gets the StopPassedTimeCommand.
        /// </summary>
        /// <value> The stop passed time command. </value>
        public RelayCommand StopPassedTimeCommand
        {
            get
            {
                return this._stopPassedTimeCommand
?? (this._stopPassedTimeCommand = new RelayCommand(
   StopPassedTime,
   () => (this.PassedTimeToUpdate != null && this.PassedTimeToUpdate.EndDateTime == DateTime.MaxValue.Date)));
            }
        }

        #endregion StopPassedTimeCommand

        #region ResetPassedTimeCommand

        private RelayCommand _resetPassedTimeCommand;

        /// <summary>
        /// Gets the ResetPassedTimeCommand.
        /// </summary>
        /// <value> The reset passed time command. </value>
        public RelayCommand ResetPassedTimeCommand
        {
            get
            {
                return this._resetPassedTimeCommand
?? (this._resetPassedTimeCommand = new RelayCommand(
  ResetPassedTime, ExistData));
            }
        }

        #endregion ResetPassedTimeCommand

        #region CurrentDayRefreshCommand

        private RelayCommand _currentDayRefreshCommand;

        /// <summary>
        /// Gets the CurrentDayRefreshCommand.
        /// </summary>
        /// <value> The current day refresh command. </value>
        public RelayCommand CurrentDayRefreshCommand
        {
            get
            {
                return this._currentDayRefreshCommand
?? (this._currentDayRefreshCommand = new RelayCommand(
CurrentDayRefresh));
            }
        }

        #endregion CurrentDayRefreshCommand

        #region TargetDateRefreshCommand

        private RelayCommand _targetDateRefreshCommand;

        /// <summary>
        /// Gets the TargetDateRefreshCommand.
        /// </summary>
        /// <value> The target date refresh command. </value>
        public RelayCommand TargetDateRefreshCommand
        {
            get
            {
                return this._targetDateRefreshCommand
?? (this._targetDateRefreshCommand = new RelayCommand(
TargetDateRefresh));
            }
        }

        #endregion TargetDateRefreshCommand

        #region UpdateLineCommand

        private RelayCommand _updateLineCommand;

        /// <summary>
        /// Gets the UpdateLineCommand.
        /// </summary>
        /// <value> The update line command. </value>
        public RelayCommand UpdateLineCommand
        {
            get
            {
                return this._updateLineCommand
?? (this._updateLineCommand = new RelayCommand(
       UpdatePassedTime));
            }
        }

        #endregion UpdateLineCommand

        private RelayCommand splitLineCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand MyCommand
        {
            get
            {
                return this.splitLineCommand
                    ?? (this.splitLineCommand = new RelayCommand(
                    (SplitPassedTime)));
            }
        }

        #region OpenViewUpdateLineCommand

        private RelayCommand _openViewUpdateLineCommand;

        /// <summary>
        /// Gets the OpenViewUpdateLineCommand.
        /// </summary>
        /// <value> The open view update line command. </value>
        public RelayCommand OpenViewUpdateLineCommand
        {
            get
            {
                return this._openViewUpdateLineCommand
?? (this._openViewUpdateLineCommand = new RelayCommand(
() =>
{
    Messenger.Default.Send(new NotificationMessage(this, "OpenUpdateLineView"));
}));
            }
        }

        #endregion OpenViewUpdateLineCommand

        #region OpenViewSplitLineCommand

        private RelayCommand _openViewSplitLineCommand;

        /// <summary>
        /// Gets the OpenViewSplitLineCommand.
        /// </summary>
        /// <value> The open view split line command. </value>
        public RelayCommand OpenViewSplitLineCommand
        {
            get
            {
                return this._openViewSplitLineCommand
?? (this._openViewSplitLineCommand = new RelayCommand(
() =>
{
    Messenger.Default.Send(new NotificationMessage(this, "OpenSplitLineView"));
}));
            }
        }

        #endregion OpenViewSplitLineCommand

        #region DeletePassedTimeCommand

        private RelayCommand _deletePassedTimeCommand;

        /// <summary>
        /// Gets the DeletePassedTimeCommand.
        /// </summary>
        /// <value> The delete passed time command. </value>
        public RelayCommand DeletePassedTimeCommand
        {
            get
            {
                return this._deletePassedTimeCommand
?? (this._deletePassedTimeCommand = new RelayCommand(
 DeletePassedTime));
            }
        }

        #endregion DeletePassedTimeCommand

        #region ClosePreviousTasksCommand

        private RelayCommand _closePreviousTasksCommand;

        /// <summary>
        /// Gets the ClosePreviousTasksCommand.
        /// </summary>
        /// <value> The close previous tasks command. </value>
        public RelayCommand ClosePreviousTasksCommand
        {
            get
            {
                return this._closePreviousTasksCommand
?? (this._closePreviousTasksCommand = new RelayCommand(
ClosePreviousTasks));
            }
        }

        #endregion ClosePreviousTasksCommand

        #region CloseOpenedTasksCommand

        private RelayCommand _closeOpenedTasksCommand;

        /// <summary>
        /// Gets the CloseOpenedTasksCommand.
        /// </summary>
        /// <value> The close opened tasks command. </value>
        public RelayCommand CloseOpenedTasksCommand
        {
            get
            {
                return this._closeOpenedTasksCommand
?? (this._closeOpenedTasksCommand = new RelayCommand(
 CloseOpenedTasks));
            }
        }

        #endregion CloseOpenedTasksCommand

        #region OpenCompanyViewCommand

        private RelayCommand _openCompanyViewCommand;

        /// <summary>
        /// Gets the OpenCompanyViewCommand.
        /// </summary>
        /// <value> The open company view command. </value>
        public RelayCommand OpenCompanyViewCommand
        {
            get
            {
                return this._openCompanyViewCommand
?? (this._openCompanyViewCommand = new RelayCommand(
  () =>
  {
      Messenger.Default.Send(new NotificationMessage(this, "OpenCompanyView"));
  }));
            }
        }

        #endregion OpenCompanyViewCommand

        #region OpenApplicationViewCommand

        private RelayCommand _openApplicationViewCommand;

        /// <summary>
        /// Gets the OpenApplicationViewCommand.
        /// </summary>
        /// <value> The open application view command. </value>
        public RelayCommand OpenApplicationViewCommand
        {
            get
            {
                return this._openApplicationViewCommand
?? (this._openApplicationViewCommand = new RelayCommand(
() =>
{
    Messenger.Default.Send(new NotificationMessage(this, "OpenApplicationView"));
}));
            }
        }

        #endregion OpenApplicationViewCommand

        #region OpenProjectViewCommand

        private RelayCommand _openProjectViewCommand;

        /// <summary>
        /// Gets the OpenProjectViewCommand.
        /// </summary>
        /// <value> The open project view command. </value>
        public RelayCommand OpenProjectViewCommand
        {
            get
            {
                return this._openProjectViewCommand
?? (this._openProjectViewCommand = new RelayCommand(
  () =>
  {
      Messenger.Default.Send(new NotificationMessage(this, "OpenProjectView"));
  }));
            }
        }

        #endregion OpenProjectViewCommand

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

        #region OpenConfigurationViewCommand

        private RelayCommand _openConfigurationViewCommand;

        /// <summary>
        /// Gets the OpenConfigurationViewCommand.
        /// </summary>
        /// <value> The open configuration view command. </value>
        public RelayCommand OpenConfigurationViewCommand
        {
            get
            {
                return this._openConfigurationViewCommand
?? (this._openConfigurationViewCommand = new RelayCommand(
() =>
{
    Messenger.Default.Send(new NotificationMessage(this, "OpenConfigurationView"));
}));
            }
        }

        #endregion OpenConfigurationViewCommand

        #region OpenHistoryViewCommand

        private RelayCommand _openHistoryViewCommand;

        /// <summary>
        /// Gets the OpenHistoryViewCommand.
        /// </summary>
        /// <value> The open history view command. </value>
        public RelayCommand OpenHistoryViewCommand
        {
            get
            {
                return this._openHistoryViewCommand
?? (this._openHistoryViewCommand = new RelayCommand(
  () =>
  {
      Messenger.Default.Send(new NotificationMessage(this, "OpenHistoryView"));
  }));
            }
        }

        #endregion OpenHistoryViewCommand

        #region ValueChangedCommand

        private RelayCommand<double> _valueChangedCommand;

        /// <summary>
        /// Gets the ValueChangedCommand.
        /// </summary>
        public RelayCommand<double> ValueChangedCommand
        {
            get
            {
                return this._valueChangedCommand
?? (this._valueChangedCommand = new RelayCommand<double>(ExecuteValueChangedCommand));
            }
        }

        #endregion ValueChangedCommand

        #endregion Properties : Commands

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.PassedTimeModel = new PassedTimeModel();

            this.TargetDate = DateTime.Now.Date;
            this.CurrentDate = DateTime.Now.Date;

            if (this.IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                AutoCloseAtMidnight();

                this._timer = new DispatcherTimer();
                this._timer.Tick += Timer_Tick;
                this._timer.Interval = new TimeSpan(0, 0, 1);
                this._timer.Start();

                // Code runs "for real"
                CurrentDayRefresh();
            }
        }

        #endregion Constructor

        #region Functions

        #region ExistData

        /// <summary>
        /// Exists the data.
        /// </summary>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool ExistData()
        {
            return (ViewModelLocator.CommonViewModelStatic.ApplicationList.Count > 0 && ViewModelLocator.CommonViewModelStatic.TaskList.Count > 0)
                && (this.PassedTimeToUpdate != null && this.PassedTimeToUpdate.Project != null && this.PassedTimeToUpdate.Project.Tasks.Count > 0);
        }

        #endregion ExistData

        #region AddPastFuturePassedTime

        /// <summary>
        /// Adds the past future passed time.
        /// </summary>
        public void AddPastFuturePassedTime()
        {
            if (this.StartPastFutureDateTime != null)
            {
                if (this.EndPastFutureDateTime != null)
                {
                    if (this.SelectedProjectIndexPassedTime != -1)
                    {
                        if (this.SelectedTaskIndexPassedTime != -1)
                        {
                            if (this.StartPastFutureDateTime.Value < this.EndPastFutureDateTime.Value)
                            {
                                this.PassedTimeModel.AddPassedTimePastAndFuture(this.StartPastFutureDateTime.Value, this.EndPastFutureDateTime.Value, this.PassedTimeToUpdate.Comment, this.PassedTimeToUpdate.Project, this.PassedTimeToUpdate.Task, "OverridePassedTimes");

                                Refresh();
                            }
                            else
                            {
                                Messenger.Default.Send(new NotificationMessage<MainViewErrors>(MainViewErrors.StartMustBeSmallerThanEnd, ErrorMessages.StartMustBeSmallerThanEnd));
                            }
                        }
                    }
                }
            }
        }

        #endregion AddPastFuturePassedTime

        #region StartPassedTime

        /// <summary>
        /// Starts the passed time.
        /// </summary>
        public void StartPassedTime()
        {
            if (this.SelectedProjectIndexPassedTime != -1)
            {
                if (this.SelectedTaskIndexPassedTime != -1)
                {
                    var inError = false;
                    if (!AppSettingsSingleton.Instance.GetBooleanValue("MultiTask"))
                    {
                        if (AppSettingsSingleton.Instance.GetBooleanValue("AutoCloseAddNew"))
                        {
                            this.PassedTimeModel.AutoCloseTasks(this.CurrentDate, DateTime.Now);
                        }
                        else
                        {
                            if (this.PassedTimeModel.CheckActiveTasksExist())
                            {
                                inError = true;
                            }
                        }
                    }

                    if (!inError)
                    {
                        var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                        this.PassedTimeModel.AddPassedTime(startDate, DateTime.MaxValue.Date, this.PassedTimeToUpdate.Comment, this.PassedTimeToUpdate.Project, this.PassedTimeToUpdate.Task);
                    }
                    else
                    {
                        Messenger.Default.Send(new NotificationMessage<MainViewErrors>(MainViewErrors.NoMultiTask, ErrorMessages.NoMultiTask));
                    }
                }
            }

            Refresh();
        }

        #endregion StartPassedTime

        #region StopPassedTime

        /// <summary>
        /// Stops the passed time.
        /// </summary>
        public void StopPassedTime()
        {
            if (this.PassedTimeToUpdate.ID != 0)
            {
                this.PassedTimeModel.ClosePassedTime(this.PassedTimeToUpdate, this.PassedTimeToUpdate.Comment);
            }

            Refresh();
        }

        #endregion StopPassedTime

        #region ResetPassedTime

        /// <summary>
        /// Resets the passed time.
        /// </summary>
        public void ResetPassedTime()
        {
            this.StartPastFutureDateTime = null;
            this.EndPastFutureDateTime = null;
            this.EnableUpdateMenuEntries = false;
        }

        #endregion ResetPassedTime

        #region CurrentDayRefresh

        /// <summary>
        /// Currents the day refresh.
        /// </summary>
        public void CurrentDayRefresh()
        {
            this.SelectedProjectIndexPassedTime = -1;
            this.SelectedTaskIndexPassedTime = -1;
            this.StartPastFutureDateTime = null;
            this.EndPastFutureDateTime = null;
            this.TargetDate = DateTime.Now.Date;
            var endTargetDate = this.TargetDate.AddDays(1).AddSeconds(-1);

            this.PassedTimeList = new ObservableCollection<PassedTimeDto>(this.PassedTimeModel.GetPassedTimes(this.TargetDate, endTargetDate));

            this.SelectedPassedTime = new PassedTimeDto();
            this.PassedTimeToUpdate = new PassedTimeDto();

            this.EnableUpdateMenuEntries = false;

            SetDuration();

            Messenger.Default.Send(new NotificationMessage(this, "AutoSizeGridViewColumns"));
        }

        #endregion CurrentDayRefresh

        #region TargetDateRefresh

        /// <summary>
        /// Targets the date refresh.
        /// </summary>
        public void TargetDateRefresh()
        {
            this.SelectedProjectIndexPassedTime = -1;
            this.SelectedTaskIndexPassedTime = -1;
            this.StartPastFutureDateTime = null;
            this.EndPastFutureDateTime = null;
            var endTargetDate = this.TargetDate.AddDays(1).AddSeconds(-1);

            this.PassedTimeList = new ObservableCollection<PassedTimeDto>(this.PassedTimeModel.GetPassedTimes(this.TargetDate, endTargetDate));

            this.PassedTimeToUpdate = new PassedTimeDto();
            this.SelectedPassedTime = new PassedTimeDto();

            this.EnableUpdateMenuEntries = false;

            SetDuration();

            Messenger.Default.Send(new NotificationMessage(this, "AutoSizeGridViewColumns"));
        }

        #endregion TargetDateRefresh

        #region SetDuration

        /// <summary>
        /// Sets the duration.
        /// </summary>
        private void SetDuration()
        {
            var ts = new TimeSpan();
            var firstPass = true;
            foreach (var passedTime in this.PassedTimeList)
            {
                if (firstPass)
                {
                    ts = Duration.GetDuration(passedTime.StartDatetime, passedTime.EndDateTime);
                    firstPass = false;
                }
                else
                {
                    ts = ts.Add(Duration.GetDuration(passedTime.StartDatetime, passedTime.EndDateTime));
                }
            }

            this.DurationCurrentDate = Duration.GetDurationInString(ts);
        }

        #endregion SetDuration

        #region UpdatePassedTime

        /// <summary>
        /// Updates the passed time.
        /// </summary>
        private void UpdatePassedTime()
        {
            if (this.PassedTimeToUpdate.StartDatetime < this.PassedTimeToUpdate.EndDateTime)
            {
                var inError = false;

                if (!inError)
                {
                    this.PassedTimeModel.UpdatePassedTime(this.PassedTimeToUpdate);

                    this.PassedTimeToUpdate = new PassedTimeDto();

                    this.EnableUpdateMenuEntries = false;

                    Messenger.Default.Send(new NotificationMessage(this, "CloseUpdateLineView"));

                    this.PassedTimeToUpdate = new PassedTimeDto();

                    Refresh();
                }
                else
                {
                    Messenger.Default.Send(new NotificationMessage<MainViewErrors>(MainViewErrors.NoMultiTask, ErrorMessages.NoMultiTask));
                }
            }
            else
            {
                Messenger.Default.Send(new NotificationMessage<UpdateViewErrors>(UpdateViewErrors.StartMustBeSmallerThanEnd, ErrorMessages.StartMustBeSmallerThanEnd));
            }
        }

        #endregion UpdatePassedTime

        #region SplitPassedTime

        /// <summary>
        /// Splits the passed time.
        /// </summary>
        private void SplitPassedTime()
        {
        }

        #endregion SplitPassedTime

        #region DeletePassedTime

        /// <summary>
        /// Deletes the passed time.
        /// </summary>
        private void DeletePassedTime()
        {
            Messenger.Default.Send(
                new DialogMessage(
                    string.Empty,
                    res =>
                    {
                        if (res == System.Windows.MessageBoxResult.Yes)
                        {
                            this.PassedTimeModel.DeletePassedTime(this.PassedTimeToUpdate.ID);

                            Refresh();

                            this.EnableUpdateMenuEntries = false;
                        }
                    }),
                "DeletePassedTime");
        }

        #endregion DeletePassedTime

        #region CloseOnExit

        /// <summary>
        /// Closes the on exit.
        /// </summary>
        public void CloseOnExit()
        {
            if (this._timer != null)
            {
                this._timer.Stop();
            }

            if (AppSettingsSingleton.Instance.GetBooleanValue("CloseOnExit"))
            {
                this.PassedTimeModel.AutoCloseTasks(this.TargetDate, DateTime.Now);
            }
        }

        #endregion CloseOnExit

        #region ClosePreviousTasks

        /// <summary>
        /// Closes the previous tasks.
        /// </summary>
        public void ClosePreviousTasks()
        {
            this.PassedTimeModel.ClosePreviousTasks(this.TargetDate);
            Refresh();
        }

        #endregion ClosePreviousTasks

        #region CloseOpenedTasks

        /// <summary>
        /// Closes the opened tasks.
        /// </summary>
        public void CloseOpenedTasks()
        {
            this.PassedTimeModel.AutoCloseTasks(this.TargetDate, DateTime.Now);
            Refresh();
        }

        #endregion CloseOpenedTasks

        #region AutoCloseAtMidnight

        /// <summary>
        /// Automatics the close at midnight.
        /// </summary>
        public void AutoCloseAtMidnight()
        {
            var actualDate = DateTime.Now.Date;

            if (AppSettingsSingleton.Instance.GetBooleanValue("AutoCloseAtMidnight"))
            {
                this.PassedTimeModel.ClosePreviousTasks(actualDate);
            }
        }

        #endregion AutoCloseAtMidnight

        #region Timer_Tick

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e">      The <see cref="EventArgs" /> instance containing the event data. </param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.CurrentDate = DateTime.Now.Date;

            AutoCloseAtMidnight();
        }

        #endregion Timer_Tick

        #region Refresh

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            if (this.TargetDate == this.CurrentDate)
            {
                CurrentDayRefresh();
            }
            else
            {
                TargetDateRefresh();
            }
        }

        #endregion Refresh

        #region ExecuteValueChangedCommand

        /// <summary>
        /// Executes the value changed command.
        /// </summary>
        /// <param name="sliderValue">The slider value.</param>
        private void ExecuteValueChangedCommand(double sliderValue)
        {
        }

        #endregion ExecuteValueChangedCommand

        #endregion Functions

        #region Cleanup

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        public override void Cleanup()
        {
            // Clean up if needed
            base.Cleanup();
        }

        #endregion Cleanup
    }
}