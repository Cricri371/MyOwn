using System.Windows;
using System.Windows.Input;

using GalaSoft.MvvmLight.Messaging;

namespace Cricri371.Time.Manager.Views
{
    /// <summary>
    /// Description for ConfigurationView.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class ConfigurationView : Window
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ConfigurationView class.
        /// </summary>
        public ConfigurationView()
        {
            InitializeComponent();

            Messenger.Default.Register<NotificationMessage>(this, ConfigurationViewMessenger);
        }

        #endregion Constructor

        #region ConfigurationViewMessenger

        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="notificationMessage"> The notification message. </param>
        private void ConfigurationViewMessenger(NotificationMessage notificationMessage)
        {
            if (notificationMessage.Notification == "CloseConfigurationView")
            {
                if (notificationMessage.Sender == this.DataContext)
                {
                    Close();
                }
            }
        }

        #endregion ConfigurationViewMessenger

        #region Window_Closing

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e">
        /// The <see cref="System.ComponentModel.CancelEventArgs" /> instance containing the event data.
        /// </param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister<NotificationMessage>(this, ConfigurationViewMessenger);
        }

        #endregion Window_Closing

        #region Window_PreviewKeyDown

        /// <summary>
        /// Handles the PreviewKeyDown event of the Window control.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e">
        /// The <see cref="System.Windows.Input.KeyEventArgs" /> instance containing the event data.
        /// </param>
        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        #endregion Window_PreviewKeyDown
    }
}