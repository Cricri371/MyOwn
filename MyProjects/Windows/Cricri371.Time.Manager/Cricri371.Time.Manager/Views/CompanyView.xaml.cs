using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Cricri371.Time.Manager.Classes;
using Cricri371.Time.Manager.ViewModel;

using GalaSoft.MvvmLight.Messaging;

namespace Cricri371.Time.Manager.Views
{
    /// <summary>
    /// Description for CompanyView.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class CompanyView : Window
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the CompanyView class.
        /// </summary>
        public CompanyView()
        {
            InitializeComponent();

            Messenger.Default.Register<NotificationMessage<CompanyErrors>>(this, DisplayError);
            Messenger.Default.Register<NotificationMessage>(this, ManageCompanyView);
        }

        #endregion Constructor

        #region ManageCompanyView

        /// <summary>
        /// Manages the company view.
        /// </summary>
        /// <param name="notificationMessage"> The notification message. </param>
        private void ManageCompanyView(NotificationMessage notificationMessage)
        {
            if (notificationMessage.Sender == this.DataContext)
            {
                switch (notificationMessage.Notification)
                {
                    case "OpenCompanyView":
                        var companyView = new CompanyView
                        {
                            Owner = this
                        };
                        companyView.ShowDialog();
                        break;

                    case "AutoSizeCompanyGridViewColumns":
                        AutoSizeGridViewColumns();
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion ManageCompanyView

        #region DisplayError

        /// <summary>
        /// Displays the error.
        /// </summary>
        /// <param name="msg"> The MSG. </param>
        /// <exception cref="NotImplementedException"> Exception when not known. </exception>
        private void DisplayError(NotificationMessage<CompanyErrors> msg)
        {
            switch (msg.Content)
            {
                case CompanyErrors.CompanyAlreadyExists:
                case CompanyErrors.CompanyNameNull:
                case CompanyErrors.CompanyUsed:
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
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e">
        /// The <see cref="System.ComponentModel.CancelEventArgs" /> instance containing the event data.
        /// </param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModelLocator.CompanyViewModelStatic.NewCompany();

            Messenger.Default.Unregister<NotificationMessage<CompanyErrors>>(this, DisplayError);
            Messenger.Default.Unregister<NotificationMessage>(this, ManageCompanyView);
        }

        #endregion Window_Closing

        #region AutoSizeGridViewColumns

        /// <summary>
        /// Automatics the size grid view columns.
        /// </summary>
        private void AutoSizeGridViewColumns()
        {
            var gridView = this.lVCompany.View as GridView;
            if (gridView != null)
            {
                foreach (var column in gridView.Columns)
                {
                    if (double.IsNaN(column.Width))
                    {
                        column.Width = column.ActualWidth;
                    }

                    column.Width = double.NaN;
                }
            }
        }

        #endregion AutoSizeGridViewColumns

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