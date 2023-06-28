using System;
using System.Windows;
using System.Windows.Input;

using Cricri371.Time.Manager.Classes;

using GalaSoft.MvvmLight.Messaging;

namespace Cricri371.Time.Manager.Views
{
    /// <summary>
    /// Description for SplitLineView.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class SplitLineView : Window
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the SplitLineView class.
        /// </summary>
        public SplitLineView()
        {
            InitializeComponent();

            Messenger.Default.Register<NotificationMessage>(this, SplitLineViewMessenger);
            Messenger.Default.Register<NotificationMessage<SplitLineViewErrors>>(this, DisplayError);
        }

        #endregion Constructor

        #region UpdateLineViewMessenger

        /// <summary>
        /// Splits the line view messenger.
        /// </summary>
        /// <param name="notificationMessage"> The notification message. </param>
        private void SplitLineViewMessenger(NotificationMessage notificationMessage)
        {
            if (notificationMessage.Notification == "CloseSplitLineView")
            {
                if (notificationMessage.Sender == this.DataContext)
                {
                    Close();
                }
            }
        }

        #endregion UpdateLineViewMessenger

        #region DisplayError

        /// <summary>
        /// Displays the error.
        /// </summary>
        /// <param name="msg"> The MSG. </param>
        /// <exception cref="NotImplementedException"> Exception when not known. </exception>
        private void DisplayError(NotificationMessage<SplitLineViewErrors> msg)
        {
            switch (msg.Content)
            {
                case SplitLineViewErrors.StartMustBeSmallerThanEnd:
                    MessageBox.Show(msg.Notification, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        #endregion DisplayError

        #region Window_Closing

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister<NotificationMessage<SplitLineViewErrors>>(this, DisplayError);
            Messenger.Default.Unregister<NotificationMessage>(this, SplitLineViewMessenger);
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