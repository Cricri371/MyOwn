using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

using Cricri371.Time.Manager.Dto;
using Cricri371.Time.Manager.Model;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Cricri371.Time.Manager.ViewModel
{
    /// <summary>
    /// Class ConfigurationViewModel.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    public class HistoryViewModel : ViewModelBase
    {
        #region Properties : Models

        /// <summary>
        /// Gets or sets the passed time model.
        /// </summary>
        /// <value> The passed time model. </value>
        public PassedTimeModel PassedTimeModel { get; set; }

        #endregion Properties : Models

        #region Properties : Objects to bind

        #region BeginDateFilter

        /// <summary>
        /// The <see cref="BeginDateFilter" /> property's name.
        /// </summary>
        public const string BeginDateFilterPropertyName = "BeginDateFilter";

        private DateTime _beginDateFilter = DateTime.Now;

        /// <summary>
        /// Gets or sets the begin date filter. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The begin date filter. </value>
        public DateTime BeginDateFilter
        {
            get
            {
                return this._beginDateFilter;
            }

            set
            {
                if (this._beginDateFilter == value)
                {
                    return;
                }

                RaisePropertyChanging(BeginDateFilterPropertyName);
                this._beginDateFilter = value;
                RaisePropertyChanged(BeginDateFilterPropertyName);
            }
        }

        #endregion BeginDateFilter

        #region EndDateFilter

        /// <summary>
        /// The <see cref="EndDateFilter" /> property's name.
        /// </summary>
        public const string EndDateFilterPropertyName = "EndDateFilter";

        private DateTime _endDateFilter = DateTime.Now;

        /// <summary>
        /// Gets or sets the end date filter. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The end date filter. </value>
        public DateTime EndDateFilter
        {
            get
            {
                return this._endDateFilter;
            }

            set
            {
                if (this._endDateFilter == value)
                {
                    return;
                }

                RaisePropertyChanging(EndDateFilterPropertyName);
                this._endDateFilter = value;
                RaisePropertyChanged(EndDateFilterPropertyName);

                this._endDateEqualsToBeginDate = false;
                RaisePropertyChanged(EndDateEqualsToBeginDatePropertyName);
            }
        }

        #endregion EndDateFilter

        #region EndDateEqualsToBeginDate

        /// <summary>
        /// The <see cref="EndDateEqualsToBeginDate" /> property's name.
        /// </summary>
        public const string EndDateEqualsToBeginDatePropertyName = "EndDateEqualsToBeginDate";

        private bool _endDateEqualsToBeginDate = false;

        /// <summary>
        /// Gets or sets a value indicating whether [end date equals to begin date]. Changes to that
        /// property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if [end date equals to begin date]; otherwise, <c> false </c>. </value>
        public bool EndDateEqualsToBeginDate
        {
            get
            {
                return this._endDateEqualsToBeginDate;
            }

            set
            {
                if (this._endDateEqualsToBeginDate == value)
                {
                    return;
                }

                RaisePropertyChanging(EndDateEqualsToBeginDatePropertyName);

                this._endDateEqualsToBeginDate = value;

                if (value)
                {
                    this._endDateFilter = this.BeginDateFilter;
                    RaisePropertyChanged(EndDateFilterPropertyName);
                }

                RaisePropertyChanged(EndDateEqualsToBeginDatePropertyName);
            }
        }

        #endregion EndDateEqualsToBeginDate

        #region GroupByApplication

        /// <summary>
        /// The <see cref="GroupByApplication" /> property's name.
        /// </summary>
        public const string GroupByApplicationPropertyName = "GroupByApplication";

        private bool _groupByApplication = false;

        /// <summary>
        /// Gets or sets a value indicating whether [group by application]. Changes to that
        /// property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if [group by application]; otherwise, <c> false </c>. </value>
        public bool GroupByApplication
        {
            get
            {
                return this._groupByApplication;
            }

            set
            {
                if (this._groupByApplication == value)
                {
                    return;
                }

                RaisePropertyChanging(GroupByApplicationPropertyName);
                this._groupByApplication = value;
                RaisePropertyChanged(GroupByApplicationPropertyName);
            }
        }

        #endregion GroupByApplication

        #region GroupByDay

        /// <summary>
        /// The <see cref="GroupByDay" /> property's name.
        /// </summary>
        public const string GroupByDayPropertyName = "GroupByDay";

        private bool _groupByDay = false;

        /// <summary>
        /// Gets or sets a value indicating whether [group by day]. Changes to that property's value
        /// raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if [group by day]; otherwise, <c> false </c>. </value>
        public bool GroupByDay
        {
            get
            {
                return this._groupByDay;
            }

            set
            {
                if (this._groupByDay == value)
                {
                    return;
                }

                RaisePropertyChanging(GroupByDayPropertyName);
                this._groupByDay = value;
                RaisePropertyChanged(GroupByDayPropertyName);
            }
        }

        #endregion GroupByDay

        #region GroupByTask

        /// <summary>
        /// The <see cref="GroupByTask" /> property's name.
        /// </summary>
        public const string GroupByTaskPropertyName = "GroupByTask";

        private bool _groupByTask = false;

        /// <summary>
        /// Gets or sets a value indicating whether [group by task]. Changes to that property's value
        /// raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if [group by task]; otherwise, <c> false </c>. </value>
        public bool GroupByTask
        {
            get
            {
                return this._groupByTask;
            }

            set
            {
                if (this._groupByTask == value)
                {
                    return;
                }

                RaisePropertyChanging(GroupByTaskPropertyName);
                this._groupByTask = value;
                RaisePropertyChanged(GroupByTaskPropertyName);
            }
        }

        #endregion GroupByTask

        #region GroupByProject

        /// <summary>
        /// The <see cref="GroupByProject" /> property's name.
        /// </summary>
        public const string GroupByProjectPropertyName = "GroupByProject";

        private bool _groupByProject = false;

        /// <summary>
        /// Gets or sets a value indicating whether [group by project]. Changes to that property's
        /// value raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if [group by project]; otherwise, <c> false </c>. </value>
        public bool GroupByProject
        {
            get
            {
                return this._groupByProject;
            }

            set
            {
                if (this._groupByProject == value)
                {
                    return;
                }

                RaisePropertyChanging(GroupByProjectPropertyName);
                this._groupByProject = value;
                RaisePropertyChanged(GroupByProjectPropertyName);
            }
        }

        #endregion GroupByProject

        #region IsCsvFormat

        /// <summary>
        /// The <see cref="IsCsvFormat" /> property's name.
        /// </summary>
        public const string IsCsvFormatPropertyName = "IsCsvFormat";

        private bool _isCsvFormat = false;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is CSV format. Changes to that
        /// property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if this instance is CSV format; otherwise, <c> false </c>. </value>
        public bool IsCsvFormat
        {
            get
            {
                return this._isCsvFormat;
            }

            set
            {
                if (this._isCsvFormat == value)
                {
                    return;
                }

                RaisePropertyChanging(IsCsvFormatPropertyName);
                this._isCsvFormat = value;
                RaisePropertyChanged(IsCsvFormatPropertyName);
            }
        }

        #endregion IsCsvFormat

        #region IsExcelFormat

        /// <summary>
        /// The <see cref="IsExcelFormat" /> property's name.
        /// </summary>
        public const string IsExcelFormatPropertyName = "IsExcelFormat";

        private bool _isExcelFormat = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is excel format. Changes to that
        /// property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if this instance is excel format; otherwise, <c> false </c>. </value>
        public bool IsExcelFormat
        {
            get
            {
                return this._isExcelFormat;
            }

            set
            {
                if (this._isExcelFormat == value)
                {
                    return;
                }

                RaisePropertyChanging(IsExcelFormatPropertyName);
                this._isExcelFormat = value;
                RaisePropertyChanged(IsExcelFormatPropertyName);
            }
        }

        #endregion IsExcelFormat

        #region IsHorizontalTime

        /// <summary>
        /// The <see cref="IsHorizontalTime" /> property's name.
        /// </summary>
        public const string IsHorizontalTimePropertyName = "IsHorizontalTime";

        private bool _isHorizontalTime = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is horizontal time. Changes to that
        /// property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if this instance is horizontal time; otherwise, <c> false </c>. </value>
        public bool IsHorizontalTime
        {
            get
            {
                return this._isHorizontalTime;
            }

            set
            {
                if (this._isHorizontalTime == value)
                {
                    return;
                }

                RaisePropertyChanging(IsHorizontalTimePropertyName);
                this._isHorizontalTime = value;
                RaisePropertyChanged(IsHorizontalTimePropertyName);
            }
        }

        #endregion IsHorizontalTime

        #region IsVerticalTime

        /// <summary>
        /// The <see cref="IsVerticalTime" /> property's name.
        /// </summary>
        public const string IsVerticalTimePropertyName = "IsVerticalTime";

        private bool _isVerticalTime = false;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is vertical time. Changes to that
        /// property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if this instance is vertical time; otherwise, <c> false </c>. </value>
        public bool IsVerticalTime
        {
            get
            {
                return this._isVerticalTime;
            }

            set
            {
                if (this._isVerticalTime == value)
                {
                    return;
                }

                RaisePropertyChanging(IsVerticalTimePropertyName);
                this._isVerticalTime = value;
                RaisePropertyChanged(IsVerticalTimePropertyName);
            }
        }

        #endregion IsVerticalTime

        #region FilteredPassedTimes

        /// <summary>
        /// The <see cref="FilteredPassedTimes" /> property's name.
        /// </summary>
        public const string FilteredPassedTimesPropertyName = "FilteredPassedTimes";

        private ListCollectionView _filteredPassedTimes = null;

        /// <summary>
        /// Gets or sets the filtered passed times. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The filtered passed times. </value>
        public ListCollectionView FilteredPassedTimes
        {
            get
            {
                return this._filteredPassedTimes;
            }

            set
            {
                if (this._filteredPassedTimes == value)
                {
                    return;
                }

                RaisePropertyChanging(FilteredPassedTimesPropertyName);
                this._filteredPassedTimes = value;
                RaisePropertyChanged(FilteredPassedTimesPropertyName);
            }
        }

        #endregion FilteredPassedTimes

        #region SelectedApplicationFilter

        /// <summary>
        /// The <see cref="SelectedApplicationFilter" /> property's name.
        /// </summary>
        public const string SelectedApplicationFilterPropertyName = "SelectedApplicationFilter";

        private ApplicationDto _selectedApplicationFilter = new ApplicationDto();

        /// <summary>
        /// Gets or sets the selected application filter. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The selected application filter. </value>
        public ApplicationDto SelectedApplicationFilter
        {
            get
            {
                return this._selectedApplicationFilter;
            }

            set
            {
                if (this._selectedApplicationFilter == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedApplicationFilterPropertyName);
                this._selectedApplicationFilter = value;
                RaisePropertyChanged(SelectedApplicationFilterPropertyName);
            }
        }

        #endregion SelectedApplicationFilter

        #region SelectedApplicationIndexFilter

        /// <summary>
        /// The <see cref="SelectedApplicationIndexFilter" /> property's name.
        /// </summary>
        public const string SelectedApplicationIndexFilterPropertyName = "SelectedApplicationIndexFilter";

        private int _selectedApplicationIndexFilter = -1;

        /// <summary>
        /// Gets or sets the selected application index filter. Changes to that property's value
        /// raise the PropertyChanged event.
        /// </summary>
        /// <value> The selected application index filter. </value>
        public int SelectedApplicationIndexFilter
        {
            get
            {
                return this._selectedApplicationIndexFilter;
            }

            set
            {
                if (this._selectedApplicationIndexFilter == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedApplicationIndexFilterPropertyName);
                this._selectedApplicationIndexFilter = value;
                RaisePropertyChanged(SelectedApplicationIndexFilterPropertyName);
            }
        }

        #endregion SelectedApplicationIndexFilter

        #region SelectedTaskFilter

        /// <summary>
        /// The <see cref="SelectedTaskFilter" /> property's name.
        /// </summary>
        public const string SelectedTaskFilterPropertyName = "SelectedTaskFilter";

        private TaskDto _selectedTaskFilter = new TaskDto();

        /// <summary>
        /// Gets or sets the selected task filter. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The selected task filter. </value>
        public TaskDto SelectedTaskFilter
        {
            get
            {
                return this._selectedTaskFilter;
            }

            set
            {
                if (this._selectedTaskFilter == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedTaskFilterPropertyName);
                this._selectedTaskFilter = value;
                RaisePropertyChanged(SelectedTaskFilterPropertyName);
            }
        }

        #endregion SelectedTaskFilter

        #region SelectedTaskIndexFilter

        /// <summary>
        /// The <see cref="SelectedTaskIndexFilter" /> property's name.
        /// </summary>
        public const string SelectedTaskIndexFilterPropertyName = "SelectedTaskIndexFilter";

        private int _selectedTaskIndexFilter = -1;

        /// <summary>
        /// Gets or sets the selected task index filter. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The selected task index filter. </value>
        public int SelectedTaskIndexFilter
        {
            get
            {
                return this._selectedTaskIndexFilter;
            }

            set
            {
                if (this._selectedTaskIndexFilter == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedTaskIndexFilterPropertyName);
                this._selectedTaskIndexFilter = value;
                RaisePropertyChanged(SelectedTaskIndexFilterPropertyName);
            }
        }

        #endregion SelectedTaskIndexFilter

        #region SelectedProjectFilter

        /// <summary>
        /// The <see cref="SelectedProjectFilter" /> property's name.
        /// </summary>
        public const string SelectedProjectFilterPropertyName = "SelectedProjectFilter";

        private ProjectDto _selectedProjectFilter = new ProjectDto();

        /// <summary>
        /// Gets or sets the selected project filter. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The selected project filter. </value>
        public ProjectDto SelectedProjectFilter
        {
            get
            {
                return this._selectedProjectFilter;
            }

            set
            {
                if (this._selectedProjectFilter == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedProjectFilterPropertyName);
                this._selectedProjectFilter = value;
                RaisePropertyChanged(SelectedProjectFilterPropertyName);
            }
        }

        #endregion SelectedProjectFilter

        #region SelectedProjectIndexFilter

        /// <summary>
        /// The <see cref="SelectedTaskIndexFilter" /> property's name.
        /// </summary>
        public const string SelectedProjectIndexFilterPropertyName = "SelectedProjectIndexFilter";

        private int _selectedProjectIndexFilter = -1;

        /// <summary>
        /// Gets or sets the selected project index filter. Changes to that property's value raise
        /// the PropertyChanged event.
        /// </summary>
        /// <value> The selected project index filter. </value>
        public int SelectedProjectIndexFilter
        {
            get
            {
                return this._selectedProjectIndexFilter;
            }

            set
            {
                if (this._selectedProjectIndexFilter == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedProjectIndexFilterPropertyName);
                this._selectedProjectIndexFilter = value;
                RaisePropertyChanged(SelectedProjectIndexFilterPropertyName);
            }
        }

        #endregion SelectedProjectIndexFilter

        #region SelectedCompanyFilter

        /// <summary>
        /// The <see cref="SelectedCompanyFilter" /> property's name.
        /// </summary>
        public const string SelectedCompanyFilterPropertyName = "SelectedCompanyFilter";

        private CompanyDto _selectedCompanyFilter = new CompanyDto();

        /// <summary>
        /// Gets or sets the selected company filter. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The selected company filter. </value>
        public CompanyDto SelectedCompanyFilter
        {
            get
            {
                return this._selectedCompanyFilter;
            }

            set
            {
                if (this._selectedCompanyFilter == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedCompanyFilterPropertyName);
                this._selectedCompanyFilter = value;
                RaisePropertyChanged(SelectedCompanyFilterPropertyName);
            }
        }

        #endregion SelectedCompanyFilter

        #region SelectedCompanyIndexFilter

        /// <summary>
        /// The <see cref="SelectedCompanyIndexFilter" /> property's name.
        /// </summary>
        public const string SelectedCompanyIndexFilterPropertyName = "SelectedCompanyIndexFilter";

        private int _selectedCompanyIndexFilter = -1;

        /// <summary>
        /// Gets or sets the selected company index filter. Changes to that property's value raise
        /// the PropertyChanged event.
        /// </summary>
        /// <value> The selected company index filter. </value>
        public int SelectedCompanyIndexFilter
        {
            get
            {
                return this._selectedCompanyIndexFilter;
            }

            set
            {
                if (this._selectedCompanyIndexFilter == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedCompanyIndexFilterPropertyName);
                this._selectedCompanyIndexFilter = value;
                RaisePropertyChanged(SelectedCompanyIndexFilterPropertyName);
            }
        }

        #endregion SelectedCompanyIndexFilter

        #endregion Properties : Objects to bind

        #region Properties : Commands

        #region FilterCommand

        private RelayCommand _filterCommand;

        /// <summary>
        /// Gets the FilterCommand.
        /// </summary>
        /// <value> The filter command. </value>
        public RelayCommand FilterCommand
        {
            get
            {
                return this._filterCommand
?? (this._filterCommand = new RelayCommand(
           Filter));
            }
        }

        #endregion FilterCommand

        #region ClearFilterCommand

        private RelayCommand _clearFilterCommand;

        /// <summary>
        /// Gets the ClearFilterCommand.
        /// </summary>
        /// <value> The clear filter command. </value>
        public RelayCommand ClearFilterCommand
        {
            get
            {
                return this._clearFilterCommand
?? (this._clearFilterCommand = new RelayCommand(
      ClearFilter));
            }
        }

        #endregion ClearFilterCommand

        #region ClearAllCommand

        private RelayCommand _clearAllCommand;

        /// <summary>
        /// Gets the ClearAllCommand.
        /// </summary>
        /// <value> The clear all command. </value>
        public RelayCommand ClearAllCommand
        {
            get
            {
                return this._clearAllCommand
?? (this._clearAllCommand = new RelayCommand(
         ClearAll));
            }
        }

        #endregion ClearAllCommand

        #region ExportCommand

        private RelayCommand _exportCommand;

        /// <summary>
        /// Gets the ExportCommand.
        /// </summary>
        /// <value> The export command. </value>
        public RelayCommand ExportCommand
        {
            get
            {
                return this._exportCommand
?? (this._exportCommand = new RelayCommand(
           Export));
            }
        }

        #endregion ExportCommand

        #region ClearExportCommand

        private RelayCommand _clearExportCommand;

        /// <summary>
        /// Gets the ClearExportCommand.
        /// </summary>
        /// <value> The clear export command. </value>
        public RelayCommand ClearExportCommand
        {
            get
            {
                return this._clearExportCommand
?? (this._clearExportCommand = new RelayCommand(
      ClearExport));
            }
        }

        #endregion ClearExportCommand

        #endregion Properties : Commands

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the HistoryViewModel class.
        /// </summary>
        public HistoryViewModel()
        {
            this.PassedTimeModel = new PassedTimeModel();

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

        #region Filter

        /// <summary>
        /// Filters this instance.
        /// </summary>
        public void Filter()
        {
            var endDate = DateTime.Now;
            if (this.BeginDateFilter.Date == this.EndDateFilter.Date)
            {
                endDate = this.BeginDateFilter.Date.AddDays(1).AddSeconds(-1);
            }
            else
            {
                endDate = this.EndDateFilter.Date.AddDays(1).AddSeconds(-1);
            }

            int? companyId = null;
            if (this.SelectedCompanyFilter.ID != 0)
            {
                companyId = this.SelectedCompanyFilter.ID;
            }

            int? taskId = null;
            if (this.SelectedTaskFilter.ID != 0)
            {
                taskId = this.SelectedTaskFilter.ID;
            }

            int? projectId = null;
            if (this.SelectedProjectFilter.ID != 0)
            {
                projectId = this.SelectedProjectFilter.ID;
            }

            int? applicationId = null;
            if (this.SelectedApplicationFilter.ID != 0)
            {
                applicationId = this.SelectedApplicationFilter.ID;
            }

            var filteredData = this.PassedTimeModel.GetFilteredPassedTimes(
                this.BeginDateFilter.Date,
                endDate,
                taskId,
                applicationId,
                projectId,
                companyId);

            var groupedFilteredData = new ListCollectionView(filteredData.ToList());

            if (this.GroupByDay)
            {
                groupedFilteredData.GroupDescriptions.Add(new PropertyGroupDescription("TargetDateTimeString"));
            }

            if (this.GroupByApplication)
            {
                groupedFilteredData.GroupDescriptions.Add(new PropertyGroupDescription("Project.Application.Name"));
            }

            if (this.GroupByProject)
            {
                groupedFilteredData.GroupDescriptions.Add(new PropertyGroupDescription("Project.Name"));
            }

            if (this.GroupByTask)
            {
                groupedFilteredData.GroupDescriptions.Add(new PropertyGroupDescription("Task.Name"));
            }

            this.FilteredPassedTimes = groupedFilteredData;
        }

        #endregion Filter

        #region ClearFilter

        /// <summary>
        /// Clears the filter.
        /// </summary>
        public void ClearFilter()
        {
            this.EndDateEqualsToBeginDate = false;
            this.EndDateFilter = DateTime.Now;
            this.BeginDateFilter = DateTime.Now;
            this.GroupByApplication = false;
            this.GroupByDay = false;
            this.GroupByTask = false;
            this.GroupByProject = false;
            this.SelectedCompanyIndexFilter = -1;
            this.SelectedCompanyFilter = new CompanyDto();
            this.SelectedApplicationIndexFilter = -1;
            this.SelectedApplicationFilter = new ApplicationDto();
            this.SelectedProjectIndexFilter = -1;
            this.SelectedProjectFilter = new ProjectDto();
            this.SelectedTaskIndexFilter = -1;
            this.SelectedTaskFilter = new TaskDto();
        }

        #endregion ClearFilter

        #region ClearAll

        /// <summary>
        /// Clears all.
        /// </summary>
        public void ClearAll()
        {
            ClearFilter();
            this.FilteredPassedTimes = new ListCollectionView(new List<PassedTimeDto>());
        }

        #endregion ClearAll

        #region Export

        /// <summary>
        /// Exports this instance.
        /// </summary>
        /// <exception cref="NotImplementedException"> Exception when not known. </exception>
        public void Export()
        {
            throw new NotImplementedException();

            // ClearExport();
        }

        #endregion Export

        #region ClearExport

        /// <summary>
        /// Clears the export.
        /// </summary>
        public void ClearExport()
        {
            this.IsCsvFormat = false;
            this.IsExcelFormat = true;
            this.IsHorizontalTime = true;
            this.IsVerticalTime = false;
        }

        #endregion ClearExport

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