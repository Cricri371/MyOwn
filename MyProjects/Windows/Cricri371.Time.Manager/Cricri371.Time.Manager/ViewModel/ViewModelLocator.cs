/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Cricri371.Time.Manager.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>

  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  OR (WPF only):

  xmlns:vm="clr-namespace:Cricri371.Time.Manager.ViewModel"
  DataContext="{Binding Source={x:Static vm:ViewModelLocatorTemplate.ViewModelNameStatic}}"
*/

namespace Cricri371.Time.Manager.ViewModel
{
    /// <summary>
    /// Class ViewModelLocator.
    /// </summary>
    public class ViewModelLocator
    {
        private static ConfigurationViewModel _configurationViewModel;
        private static CommonViewModel _commonViewModel;
        private static MainViewModel _mainViewModel;
        private static ApplicationViewModel _applicationViewModel;
        private static TaskViewModel _taskViewModel;
        private static CompanyViewModel _companyViewModel;
        private static HistoryViewModel _historyViewModel;
        private static ProjectViewModel _projectViewModel;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            // if (ViewModelBase.IsInDesignModeStatic)
            // {
            //    Create design time view models
            // }
            // else
            // {
            //    Create run time view models
            // }

            CreateConfigurationViewModel();
            CreateCommonViewModel();
            CreateMainViewModel();
            CreateApplicationViewModel();
            CreateCompanyViewModel();
            CreateTaskViewModel();
            CreateHistoryViewModel();
            CreateProjectViewModel();
        }

        #endregion Constructor

        #region CommonViewModel

        /// <summary>
        /// Gets the CommonViewModel property.
        /// </summary>
        /// <value> The common view model static. </value>
        public static CommonViewModel CommonViewModelStatic
        {
            get
            {
                if (_commonViewModel == null)
                {
                    CreateCommonViewModel();
                }

                return _commonViewModel;
            }
        }

        /// <summary>
        /// Gets the CommonViewModel property.
        /// </summary>
        /// <value> The common view model. </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public CommonViewModel CommonViewModel
        {
            get
            {
                return CommonViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the CommonViewModel property.
        /// </summary>
        public static void ClearCommonViewModel()
        {
            _commonViewModel.Cleanup();
            _commonViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the CommonViewModel property.
        /// </summary>
        public static void CreateCommonViewModel()
        {
            if (_commonViewModel == null)
            {
                _commonViewModel = new CommonViewModel();
            }
        }

        #endregion CommonViewModel

        #region MainViewModel

        /// <summary>
        /// Gets the MainViewModel property.
        /// </summary>
        /// <value> The main view model static. </value>
        public static MainViewModel MainViewModelStatic
        {
            get
            {
                if (_mainViewModel == null)
                {
                    CreateMainViewModel();
                }

                return _mainViewModel;
            }
        }

        /// <summary>
        /// Gets the MainViewModel property.
        /// </summary>
        /// <value> The main view model. </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel MainViewModel
        {
            get
            {
                return MainViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the MainViewModel property.
        /// </summary>
        public static void ClearMainViewModel()
        {
            _mainViewModel.Cleanup();
            _mainViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the MainViewModel property.
        /// </summary>
        public static void CreateMainViewModel()
        {
            if (_mainViewModel == null)
            {
                _mainViewModel = new MainViewModel();
            }
        }

        #endregion MainViewModel

        #region ApplicationViewModel

        /// <summary>
        /// Gets the ApplicationViewModel property.
        /// </summary>
        /// <value> The application view model static. </value>
        public static ApplicationViewModel ApplicationViewModelStatic
        {
            get
            {
                if (_applicationViewModel == null)
                {
                    CreateApplicationViewModel();
                }

                return _applicationViewModel;
            }
        }

        /// <summary>
        /// Gets the ApplicationViewModel property.
        /// </summary>
        /// <value> The application view model. </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ApplicationViewModel ApplicationViewModel
        {
            get
            {
                return ApplicationViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the ApplicationViewModel property.
        /// </summary>
        public static void ClearApplicationViewModel()
        {
            _applicationViewModel.Cleanup();
            _applicationViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the ApplicationViewModel property.
        /// </summary>
        public static void CreateApplicationViewModel()
        {
            if (_applicationViewModel == null)
            {
                _applicationViewModel = new ApplicationViewModel();
            }
        }

        #endregion ApplicationViewModel

        #region TaskViewModel

        /// <summary>
        /// Gets the TaskViewModel property.
        /// </summary>
        /// <value> The task view model static. </value>
        public static TaskViewModel TaskViewModelStatic
        {
            get
            {
                if (_taskViewModel == null)
                {
                    CreateTaskViewModel();
                }

                return _taskViewModel;
            }
        }

        /// <summary>
        /// Gets the TaskViewModel property.
        /// </summary>
        /// <value> The task view model. </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TaskViewModel TaskViewModel
        {
            get
            {
                return TaskViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the TaskViewModel property.
        /// </summary>
        public static void ClearTaskViewModel()
        {
            _taskViewModel.Cleanup();
            _taskViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the TaskViewModel property.
        /// </summary>
        public static void CreateTaskViewModel()
        {
            if (_taskViewModel == null)
            {
                _taskViewModel = new TaskViewModel();
            }
        }

        #endregion TaskViewModel

        #region CompanyViewModel

        /// <summary>
        /// Gets the CompanyViewModel property.
        /// </summary>
        /// <value> The company view model static. </value>
        public static CompanyViewModel CompanyViewModelStatic
        {
            get
            {
                if (_companyViewModel == null)
                {
                    CreateCompanyViewModel();
                }

                return _companyViewModel;
            }
        }

        /// <summary>
        /// Gets the CompanyViewModel property.
        /// </summary>
        /// <value> The company view model. </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public CompanyViewModel CompanyViewModel
        {
            get
            {
                return CompanyViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the CompanyViewModel property.
        /// </summary>
        public static void ClearCompanyViewModel()
        {
            _companyViewModel.Cleanup();
            _companyViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the CompanyViewModel property.
        /// </summary>
        public static void CreateCompanyViewModel()
        {
            if (_companyViewModel == null)
            {
                _companyViewModel = new CompanyViewModel();
            }
        }

        #endregion CompanyViewModel

        #region HistoryViewModel

        /// <summary>
        /// Gets the HistoryViewModel property.
        /// </summary>
        /// <value> The history view model static. </value>
        public static HistoryViewModel HistoryViewModelStatic
        {
            get
            {
                if (_historyViewModel == null)
                {
                    CreateHistoryViewModel();
                }

                return _historyViewModel;
            }
        }

        /// <summary>
        /// Gets the HistoryViewModel property.
        /// </summary>
        /// <value> The history view model. </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public HistoryViewModel HistoryViewModel
        {
            get
            {
                return HistoryViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the HistoryViewModel property.
        /// </summary>
        public static void ClearHistoryViewModel()
        {
            _historyViewModel.Cleanup();
            _historyViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the HistoryViewModel property.
        /// </summary>
        public static void CreateHistoryViewModel()
        {
            if (_historyViewModel == null)
            {
                _historyViewModel = new HistoryViewModel();
            }
        }

        #endregion HistoryViewModel

        #region ConfigurationViewModel

        /// <summary>
        /// Gets the ConfigurationViewModel property.
        /// </summary>
        /// <value> The configuration view model static. </value>
        public static ConfigurationViewModel ConfigurationViewModelStatic
        {
            get
            {
                if (_configurationViewModel == null)
                {
                    CreateConfigurationViewModel();
                }

                return _configurationViewModel;
            }
        }

        /// <summary>
        /// Gets the ConfigurationViewModel property.
        /// </summary>
        /// <value> The configuration view model. </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ConfigurationViewModel ConfigurationViewModel
        {
            get
            {
                return ConfigurationViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the ConfigurationViewModel property.
        /// </summary>
        public static void ClearConfigurationViewModel()
        {
            _configurationViewModel.Cleanup();
            _configurationViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the ConfigurationViewModel property.
        /// </summary>
        public static void CreateConfigurationViewModel()
        {
            if (_configurationViewModel == null)
            {
                _configurationViewModel = new ConfigurationViewModel();
            }
        }

        #endregion ConfigurationViewModel

        #region ProjectViewModel

        /// <summary>
        /// Gets the ProjectViewModel property.
        /// </summary>
        /// <value> The project view model static. </value>
        public static ProjectViewModel ProjectViewModelStatic
        {
            get
            {
                if (_projectViewModel == null)
                {
                    CreateProjectViewModel();
                }

                return _projectViewModel;
            }
        }

        /// <summary>
        /// Gets the ConfigurationViewModel property.
        /// </summary>
        /// <value> The project view model. </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ProjectViewModel ProjectViewModel
        {
            get
            {
                return ProjectViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the ProjectViewModel property.
        /// </summary>
        public static void ClearProjectViewModel()
        {
            _projectViewModel.Cleanup();
            _projectViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the ProjectViewModel property.
        /// </summary>
        public static void CreateProjectViewModel()
        {
            if (_projectViewModel == null)
            {
                _projectViewModel = new ProjectViewModel();
            }
        }

        #endregion ProjectViewModel

        #region Cleanup

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            ClearConfigurationViewModel();
            ClearCommonViewModel();
            ClearMainViewModel();
            ClearApplicationViewModel();
            ClearTaskViewModel();
            ClearCompanyViewModel();
            ClearHistoryViewModel();
            ClearProjectViewModel();
        }

        #endregion Cleanup
    }
}