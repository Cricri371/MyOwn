using Cricri371.Time.Manager.Classes;
using Cricri371.Time.Manager.Dto;
using Cricri371.Time.Manager.Model;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Cricri371.Time.Manager.ViewModel
{
    /// <summary>
    /// Class ApplicationViewModel.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    public class ApplicationViewModel : ViewModelBase
    {
        #region Properties : Models

        /// <summary>
        /// Gets or sets the application model.
        /// </summary>
        /// <value> The application model. </value>
        public ApplicationModel ApplicationModel { get; set; }

        #endregion Properties : Models

        #region Properties : Objects to bind

        #region ApplicationToUse

        /// <summary>
        /// The <see cref="ApplicationToUse" /> property's name.
        /// </summary>
        public const string ApplicationToUsePropertyName = "ApplicationToUse";

        private ApplicationDto _applicationToUse = new ApplicationDto();

        /// <summary>
        /// Gets or sets the application to use. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The application to use. </value>
        public ApplicationDto ApplicationToUse
        {
            get
            {
                return this._applicationToUse;
            }

            set
            {
                if (this._applicationToUse == value)
                {
                    return;
                }

                RaisePropertyChanging(ApplicationToUsePropertyName);
                this._applicationToUse = value;
                RaisePropertyChanged(ApplicationToUsePropertyName);
            }
        }

        #endregion ApplicationToUse

        #region SelectedApplication

        /// <summary>
        /// The <see cref="SelectedApplication" /> property's name.
        /// </summary>
        public const string SelectedApplicationPropertyName = "SelectedApplication";

        private ApplicationDto _selectedApplication = new ApplicationDto();

        /// <summary>
        /// Gets or sets the selected application. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The selected application. </value>
        public ApplicationDto SelectedApplication
        {
            get
            {
                return this._selectedApplication;
            }

            set
            {
                if (this._selectedApplication == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedApplicationPropertyName);
                this._selectedApplication = value;
                RaisePropertyChanged(SelectedApplicationPropertyName);

                this.ApplicationToUse = new ApplicationDto();

                if (value != null)
                {
                    this.ApplicationToUse.ID = value.ID;
                    this.ApplicationToUse.Name = value.Name;
                    this.ApplicationToUse.Company = value.Company;
                }

                RaisePropertyChanged(ApplicationToUsePropertyName);
            }
        }

        #endregion SelectedApplication

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

        #region SelectedCompanyIndex

        /// <summary>
        /// The <see cref="SelectedCompanyIndex" /> property's name.
        /// </summary>
        public const string SelectedCompanyIndexPropertyName = "SelectedCompanyIndex";

        private int _selectedCompanyIndex = -1;

        /// <summary>
        /// Gets or sets the index of the selected company. Changes to that property's value raise
        /// the PropertyChanged event.
        /// </summary>
        /// <value> The index of the selected company. </value>
        public int SelectedCompanyIndex
        {
            get
            {
                return this._selectedCompanyIndex;
            }

            set
            {
                if (this._selectedCompanyIndex == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedCompanyIndexPropertyName);
                this._selectedCompanyIndex = value;
                RaisePropertyChanged(SelectedCompanyIndexPropertyName);
            }
        }

        #endregion SelectedCompanyIndex

        #endregion Properties : Objects to bind

        #region Properties : Commands

        #region AddApplicationCommand

        private RelayCommand _addApplicationCommand;

        /// <summary>
        /// Gets the AddApplicationCommand.
        /// </summary>
        /// <value> The add application command. </value>
        public RelayCommand AddApplicationCommand
        {
            get
            {
                return this._addApplicationCommand
?? (this._addApplicationCommand = new RelayCommand(
   AddApplication,
   () => ViewModelLocator.CommonViewModelStatic.CompanyList.Count != 0 && (this.ApplicationToUse != null && this.ApplicationToUse.ID == 0)));
            }
        }

        #endregion AddApplicationCommand

        #region DeleteApplicationCommand

        private RelayCommand _deleteApplicationCommand;

        /// <summary>
        /// Gets the DeleteApplicationCommand.
        /// </summary>
        /// <value> The delete application command. </value>
        public RelayCommand DeleteApplicationCommand
        {
            get
            {
                return this._deleteApplicationCommand
?? (this._deleteApplicationCommand = new RelayCommand(
DeleteApplication,
() => this.ApplicationToUse != null && this.ApplicationToUse.ID != 0));
            }
        }

        #endregion DeleteApplicationCommand

        #region ModifyApplicationCommand

        private RelayCommand _modifyApplicationCommand;

        /// <summary>
        /// Gets the ModifyApplicationCommand.
        /// </summary>
        /// <value> The modify application command. </value>
        public RelayCommand ModifyApplicationCommand
        {
            get
            {
                return this._modifyApplicationCommand
?? (this._modifyApplicationCommand = new RelayCommand(
ModifyApplication,
() => this.ApplicationToUse != null && this.ApplicationToUse.ID != 0));
            }
        }

        #endregion ModifyApplicationCommand

        #region NewApplicationCommand

        private RelayCommand _newApplicationCommand;

        /// <summary>
        /// Gets the NewApplicationCommand.
        /// </summary>
        /// <value> The new application command. </value>
        public RelayCommand NewApplicationCommand
        {
            get
            {
                return this._newApplicationCommand
?? (this._newApplicationCommand = new RelayCommand(
   NewApplication,
   () => ViewModelLocator.CommonViewModelStatic.CompanyList.Count != 0));
            }
        }

        #endregion NewApplicationCommand

        #region ManageCompanyCommand

        private RelayCommand _manageCompanyCommand;

        /// <summary>
        /// Gets the ManageCompanyCommand.
        /// </summary>
        /// <value> The manage company command. </value>
        public RelayCommand ManageCompanyCommand
        {
            get
            {
                return this._manageCompanyCommand
?? (this._manageCompanyCommand = new RelayCommand(
    ManageCompany,
    () => this.ApplicationToUse == null || this.ApplicationToUse.ID == 0));
            }
        }

        #endregion ManageCompanyCommand

        #endregion Properties : Commands

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ApplicationViewModel class.
        /// </summary>
        public ApplicationViewModel()
        {
            this.ApplicationModel = new ApplicationModel();

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

        #region ManageCompany

        /// <summary>
        /// Manages the company.
        /// </summary>
        public void ManageCompany()
        {
            Messenger.Default.Send(new NotificationMessage(this, "OpenCompanyView"));
        }

        #endregion ManageCompany

        #region NewApplication

        /// <summary>
        /// News the application.
        /// </summary>
        public void NewApplication()
        {
            Messenger.Default.Send(new NotificationMessage(this, "AutoSizeApplicationGridViewColumns"));

            this.ApplicationToUse = new ApplicationDto();

            this.SelectedCompanyIndex = -1;
            this.SelectedApplicationIndex = -1;

            this.SelectedApplication = new ApplicationDto();
        }

        #endregion NewApplication

        #region AddApplication

        /// <summary>
        /// Adds the application.
        /// </summary>
        public void AddApplication()
        {
            if (string.IsNullOrEmpty(this.ApplicationToUse.Name))
            {
                Messenger.Default.Send(new NotificationMessage<ApplicationErrors>(ApplicationErrors.ApplicationNameNull, ErrorMessages.ApplicationNameNull));
            }
            else
            {
                if (this.ApplicationToUse.Company == null || string.IsNullOrEmpty(this.ApplicationToUse.Company.Name))
                {
                    Messenger.Default.Send(new NotificationMessage<ApplicationErrors>(ApplicationErrors.CompanyNotSelected, ErrorMessages.CompanyNotSelected));
                }
                else
                {
                    if (!this.ApplicationModel.CheckApplicationExists(this.ApplicationToUse.Name, this.ApplicationToUse.Company.ID))
                    {
                        this.ApplicationModel.AddApplication(this.ApplicationToUse);

                        ViewModelLocator.CommonViewModelStatic.GetApplications();

                        NewApplication();
                    }
                    else
                    {
                        Messenger.Default.Send(new NotificationMessage<ApplicationErrors>(ApplicationErrors.ApplicationAlreadyExists, ErrorMessages.ApplicationAlreadyExists));
                    }
                }
            }
        }

        #endregion AddApplication

        #region DeleteApplication

        /// <summary>
        /// Deletes the application.
        /// </summary>
        public void DeleteApplication()
        {
            if (!this.ApplicationModel.CheckApplicationIsUsed(this.ApplicationToUse.ID))
            {
                this.ApplicationModel.DeleteApplication(this.ApplicationToUse);

                ViewModelLocator.CommonViewModelStatic.GetApplications();

                NewApplication();
            }
            else
            {
                Messenger.Default.Send(new NotificationMessage<ApplicationErrors>(ApplicationErrors.ApplicationUsed, ErrorMessages.ApplicationUsed));
            }
        }

        #endregion DeleteApplication

        #region ModifyApplication

        /// <summary>
        /// Modifies the application.
        /// </summary>
        public void ModifyApplication()
        {
            if (string.IsNullOrEmpty(this.ApplicationToUse.Name))
            {
                Messenger.Default.Send(new NotificationMessage<ApplicationErrors>(ApplicationErrors.ApplicationNameNull, ErrorMessages.ApplicationNameNull));
            }
            else
            {
                if (this.ApplicationToUse.Company == null || string.IsNullOrEmpty(this.ApplicationToUse.Company.Name))
                {
                    Messenger.Default.Send(new NotificationMessage<ApplicationErrors>(ApplicationErrors.CompanyNotSelected, ErrorMessages.CompanyNotSelected));
                }
                else
                {
                    if (!this.ApplicationModel.CheckApplicationExists(this.ApplicationToUse.ID, this.ApplicationToUse.Name, this.ApplicationToUse.Company.ID))
                    {
                        var applicationToUpdate = new ApplicationDto
                        {
                            Company = this.ApplicationToUse.Company,
                            ID = this.ApplicationToUse.ID,
                            Name = this.ApplicationToUse.Name
                        };

                        this.ApplicationModel.UpdateApplication(applicationToUpdate);

                        ViewModelLocator.CommonViewModelStatic.GetApplications();

                        NewApplication();
                    }
                    else
                    {
                        Messenger.Default.Send(new NotificationMessage<ApplicationErrors>(ApplicationErrors.ApplicationAlreadyExists, ErrorMessages.ApplicationAlreadyExists));
                    }
                }
            }
        }

        #endregion ModifyApplication

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