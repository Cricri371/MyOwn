using Cricri371.Time.Manager.Classes;
using Cricri371.Time.Manager.Dto;
using Cricri371.Time.Manager.Model;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Cricri371.Time.Manager.ViewModel
{
    /// <summary>
    /// Class CompanyViewModel.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    public class CompanyViewModel : ViewModelBase
    {
        #region Properties : Models

        /// <summary>
        /// Gets or sets the company model.
        /// </summary>
        /// <value> The company model. </value>
        public CompanyModel CompanyModel { get; set; }

        #endregion Properties : Models

        #region Properties : Objects to bind

        #region CompanyToUse

        /// <summary>
        /// The <see cref="CompanyToUse" /> property's name.
        /// </summary>
        public const string CompanyToUsePropertyName = "CompanyToUse";

        private CompanyDto _companyToUse = new CompanyDto();

        /// <summary>
        /// Gets or sets the company to use. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The company to use. </value>
        public CompanyDto CompanyToUse
        {
            get
            {
                return this._companyToUse;
            }

            set
            {
                if (this._companyToUse == value)
                {
                    return;
                }

                RaisePropertyChanging(CompanyToUsePropertyName);
                this._companyToUse = value;
                RaisePropertyChanged(CompanyToUsePropertyName);
            }
        }

        #endregion CompanyToUse

        #region SelectedCompany

        /// <summary>
        /// The <see cref="SelectedCompany" /> property's name.
        /// </summary>
        public const string SelectedCompanyPropertyName = "SelectedCompany";

        private CompanyDto _selectedCompany = new CompanyDto();

        /// <summary>
        /// Gets or sets the selected company. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        /// <value> The selected company. </value>
        public CompanyDto SelectedCompany
        {
            get
            {
                return this._selectedCompany;
            }

            set
            {
                if (this._selectedCompany == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedCompanyPropertyName);
                this._selectedCompany = value;
                RaisePropertyChanged(SelectedCompanyPropertyName);

                this.CompanyToUse = new CompanyDto();

                if (value != null)
                {
                    this.CompanyToUse.ID = value.ID;
                    this.CompanyToUse.Name = value.Name;
                }

                RaisePropertyChanged(CompanyToUsePropertyName);
            }
        }

        #endregion SelectedCompany

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

        #region AddCompanyCommand

        private RelayCommand _addCompanyCommand;

        /// <summary>
        /// Gets the AddCompanyCommand.
        /// </summary>
        /// <value> The add company command. </value>
        public RelayCommand AddCompanyCommand
        {
            get
            {
                return this._addCompanyCommand
?? (this._addCompanyCommand = new RelayCommand(
       AddCompany,
       () => this.SelectedCompany != null && this.SelectedCompany.ID == 0));
            }
        }

        #endregion AddCompanyCommand

        #region DeleteCompanyCommand

        private RelayCommand _deleteCompanyCommand;

        /// <summary>
        /// Gets the DeleteCompanyCommand.
        /// </summary>
        /// <value> The delete company command. </value>
        public RelayCommand DeleteCompanyCommand
        {
            get
            {
                return this._deleteCompanyCommand
?? (this._deleteCompanyCommand = new RelayCommand(
    DeleteCompany,
    () => this.SelectedCompany != null && this.SelectedCompany.ID != 0));
            }
        }

        #endregion DeleteCompanyCommand

        #region ModifyCompanyCommand

        private RelayCommand _modifyCompanyCommand;

        /// <summary>
        /// Gets the ModifyCompanyCommand.
        /// </summary>
        /// <value> The modify company command. </value>
        public RelayCommand ModifyCompanyCommand
        {
            get
            {
                return this._modifyCompanyCommand
?? (this._modifyCompanyCommand = new RelayCommand(
    ModifyCompany,
    () => this.SelectedCompany != null && this.SelectedCompany.ID != 0));
            }
        }

        #endregion ModifyCompanyCommand

        #region NewCompanyCommand

        private RelayCommand _newCompanyCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        /// <value> The new company command. </value>
        public RelayCommand NewCompanyCommand
        {
            get
            {
                return this._newCompanyCommand
?? (this._newCompanyCommand = new RelayCommand(
       NewCompany,
       () => ViewModelLocator.CommonViewModelStatic.CompanyList.Count != 0));
            }
        }

        #endregion NewCompanyCommand

        #endregion Properties : Commands

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the CompanyViewModel class.
        /// </summary>
        public CompanyViewModel()
        {
            this.CompanyModel = new CompanyModel();

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

        #region NewCompany

        /// <summary>
        /// News the company.
        /// </summary>
        public void NewCompany()
        {
            Messenger.Default.Send(new NotificationMessage(this, "AutoSizeCompanyGridViewColumns"));

            this.CompanyToUse = new CompanyDto();

            this.SelectedCompanyIndex = -1;

            this.SelectedCompany = new CompanyDto();
        }

        #endregion NewCompany

        #region AddCompany

        /// <summary>
        /// Adds the company.
        /// </summary>
        public void AddCompany()
        {
            if (this.CompanyToUse == null || string.IsNullOrEmpty(this.CompanyToUse.Name))
            {
                Messenger.Default.Send(new NotificationMessage<CompanyErrors>(CompanyErrors.CompanyNameNull, ErrorMessages.CompanyNameNull));
            }
            else
            {
                if (!this.CompanyModel.CheckCompanyExists(this.CompanyToUse.Name))
                {
                    this.CompanyModel.AddCompany(this.CompanyToUse);

                    ViewModelLocator.CommonViewModelStatic.GetCompanies();

                    NewCompany();
                }
                else
                {
                    Messenger.Default.Send(new NotificationMessage<CompanyErrors>(CompanyErrors.CompanyAlreadyExists, ErrorMessages.CompanyAlreadyExists));
                }
            }
        }

        #endregion AddCompany

        #region DeleteCompany

        /// <summary>
        /// Deletes the company.
        /// </summary>
        public void DeleteCompany()
        {
            if (!this.CompanyModel.CheckCompanyIsUsed(this.CompanyToUse.ID))
            {
                this.CompanyModel.DeleteCompany(this.CompanyToUse);

                ViewModelLocator.CommonViewModelStatic.GetCompanies();

                NewCompany();
            }
            else
            {
                Messenger.Default.Send(new NotificationMessage<CompanyErrors>(CompanyErrors.CompanyUsed, ErrorMessages.CompanyUsed));
            }
        }

        #endregion DeleteCompany

        #region ModifyCompany

        /// <summary>
        /// Modifies the company.
        /// </summary>
        public void ModifyCompany()
        {
            if (this.CompanyToUse == null || string.IsNullOrEmpty(this.CompanyToUse.Name))
            {
                Messenger.Default.Send(new NotificationMessage<CompanyErrors>(CompanyErrors.CompanyNameNull, ErrorMessages.CompanyNameNull));
            }
            else
            {
                if (!this.CompanyModel.CheckCompanyExists(this.CompanyToUse.ID, this.CompanyToUse.Name))
                {
                    var companyToUpdate = new CompanyDto
                    {
                        ID = this.CompanyToUse.ID,
                        Name = this.CompanyToUse.Name
                    };

                    this.CompanyModel.UpdateCompany(companyToUpdate);

                    ViewModelLocator.CommonViewModelStatic.GetCompanies();

                    NewCompany();
                }
                else
                {
                    Messenger.Default.Send(new NotificationMessage<CompanyErrors>(CompanyErrors.CompanyAlreadyExists, ErrorMessages.CompanyAlreadyExists));
                }
            }
        }

        #endregion ModifyCompany

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