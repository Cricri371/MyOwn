using Cricri371.Framework.Configuration.AppSettings;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Cricri371.Time.Manager.ViewModel
{
    /// <summary>
    /// Class ConfigurationViewModel.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    public class ConfigurationViewModel : ViewModelBase
    {
        #region Properties : Objects to bind

        #region AutoCloseMidnight

        /// <summary>
        /// The <see cref="AutoCloseMidnight" /> property's name.
        /// </summary>
        public const string AutoCloseMidnightPropertyName = "AutoCloseMidnight";

        private bool _autoCloseMidnight = false;

        /// <summary>
        /// Gets or sets a value indicating whether [automatic close midnight]. Changes to that
        /// property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if [automatic close midnight]; otherwise, <c> false </c>. </value>
        public bool AutoCloseMidnight
        {
            get
            {
                return this._autoCloseMidnight;
            }

            set
            {
                if (this._autoCloseMidnight == value)
                {
                    return;
                }

                this._autoCloseMidnight = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(AutoCloseMidnightPropertyName);
            }
        }

        #endregion AutoCloseMidnight

        #region AutoClosePrevious

        /// <summary>
        /// The <see cref="AutoClosePrevious" /> property's name.
        /// </summary>
        public const string AutoClosePreviousPropertyName = "AutoClosePrevious";

        private bool _autoClosePrevious = false;

        /// <summary>
        /// Gets or sets a value indicating whether [automatic close previous]. Changes to that
        /// property's value raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if [automatic close previous]; otherwise, <c> false </c>. </value>
        public bool AutoClosePrevious
        {
            get
            {
                return this._autoClosePrevious;
            }

            set
            {
                if (this._autoClosePrevious == value)
                {
                    return;
                }

                this._autoClosePrevious = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(AutoClosePreviousPropertyName);
            }
        }

        #endregion AutoClosePrevious

        #region MultiTask

        /// <summary>
        /// The <see cref="MultiTasks" /> property's name.
        /// </summary>
        public const string MultiTaskPropertyName = "MultiTask";

        private bool _multiTask = false;

        /// <summary>
        /// Gets or sets a value indicating whether [multi task]. Changes to that property's value
        /// raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if [multi task]; otherwise, <c> false </c>. </value>
        public bool MultiTask
        {
            get
            {
                return this._multiTask;
            }

            set
            {
                if (this._multiTask == value)
                {
                    return;
                }

                this._multiTask = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(MultiTaskPropertyName);
            }
        }

        #endregion MultiTask

        #region CloseOnExit

        /// <summary>
        /// The <see cref="CloseExit" /> property's name.
        /// </summary>
        public const string CloseOnExitPropertyName = "CloseOnExit";

        private bool _closeOnExit = false;

        /// <summary>
        /// Gets or sets a value indicating whether [close on exit]. Changes to that property's value
        /// raise the PropertyChanged event.
        /// </summary>
        /// <value> <c> true </c> if [close on exit]; otherwise, <c> false </c>. </value>
        public bool CloseOnExit
        {
            get
            {
                return this._closeOnExit;
            }

            set
            {
                if (this._closeOnExit == value)
                {
                    return;
                }

                this._closeOnExit = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(CloseOnExitPropertyName);
            }
        }

        #endregion CloseOnExit

        #endregion Properties : Objects to bind

        #region Properties : Commands

        private RelayCommand _saveConfigurationCommand;

        /// <summary>
        /// Gets the SaveConfigurationCommand.
        /// </summary>
        /// <value> The save configuration command. </value>
        public RelayCommand SaveConfigurationCommand
        {
            get
            {
                return this._saveConfigurationCommand
?? (this._saveConfigurationCommand = new RelayCommand(
SaveConfiguration));
            }
        }

        #endregion Properties : Commands

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ConfigurationViewModel class.
        /// </summary>
        public ConfigurationViewModel()
        {
            if (this.IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
                this.AutoCloseMidnight = AppSettingsSingleton.Instance.GetBooleanValue("AutoCloseAtMidnight");
                this.AutoClosePrevious = AppSettingsSingleton.Instance.GetBooleanValue("AutoCloseAddNew");
                this.MultiTask = AppSettingsSingleton.Instance.GetBooleanValue("MultiTask");
                this.CloseOnExit = AppSettingsSingleton.Instance.GetBooleanValue("CloseOnExit");
            }
        }

        #endregion Constructor

        #region Functions

        #region SaveConfiguration

        /// <summary>
        /// Saves the configuration.
        /// </summary>
        public void SaveConfiguration()
        {
            AppSettingsSingleton.Instance.Write("AutoCloseAtMidnight", this.AutoCloseMidnight);
            AppSettingsSingleton.Instance.Write("AutoCloseAddNew", this.AutoClosePrevious);
            AppSettingsSingleton.Instance.Write("MultiTask", this.MultiTask);
            AppSettingsSingleton.Instance.Write("CloseOnExit", this.CloseOnExit);

            AppSettingsSingleton.Instance.Save();

            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(this, "CloseConfigurationView"));
        }

        #endregion SaveConfiguration

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