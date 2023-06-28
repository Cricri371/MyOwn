using System;
using System.Windows;
using System.Windows.Controls;

using Cricri371.Time.Manager.Classes;
using Cricri371.Time.Manager.ViewModel;
using Cricri371.Time.Manager.Views;

using GalaSoft.MvvmLight.Messaging;

namespace Cricri371.Time.Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            Messenger.Default.Register<NotificationMessage>(this, MainViewMessenger);
            Messenger.Default.Register<NotificationMessage<MainViewErrors>>(this, DisplayError);
        }

        #endregion Constructor

        #region MainViewMessenger

        /// <summary>
        /// Mains the view messenger.
        /// </summary>
        /// <param name="notificationMessage">The notification message.</param>
        private void MainViewMessenger(NotificationMessage notificationMessage)
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

                        ((MainViewModel)this.DataContext).Refresh();
                        break;

                    case "OpenApplicationView":
                        var applicationView = new ApplicationView
                        {
                            Owner = this
                        };
                        applicationView.ShowDialog();

                        ((MainViewModel)this.DataContext).Refresh();
                        break;

                    case "OpenProjectView":
                        var projectView = new ProjectView
                        {
                            Owner = this
                        };
                        projectView.ShowDialog();

                        ((MainViewModel)this.DataContext).Refresh();
                        break;

                    case "OpenTaskView":
                        var taskView = new TaskView
                        {
                            Owner = this
                        };
                        taskView.ShowDialog();

                        ((MainViewModel)this.DataContext).Refresh();
                        break;

                    case "OpenUpdateLineView":
                        var updateLineView = new UpdateLineView
                        {
                            Owner = this
                        };
                        updateLineView.ShowDialog();

                        ((MainViewModel)this.DataContext).Refresh();
                        break;

                    case "OpenSplitLineView":
                        var splitLineView = new SplitLineView
                        {
                            Owner = this
                        };
                        splitLineView.ShowDialog();

                        ((MainViewModel)this.DataContext).Refresh();
                        break;

                    case "OpenConfigurationView":
                        var configurationView = new ConfigurationView
                        {
                            Owner = this
                        };
                        configurationView.ShowDialog();
                        break;

                    case "OpenHistoryView":
                        var historyView = new HistoryView
                        {
                            Owner = this
                        };
                        historyView.ShowDialog();
                        break;

                    case "AutoSizeGridViewColumns":
                        AutoSizeGridViewColumns();
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion MainViewMessenger

        #region DisplayError

        /// <summary>
        /// Displays the error.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void DisplayError(NotificationMessage<MainViewErrors> msg)
        {
            switch (msg.Content)
            {
                case MainViewErrors.NoMultiTask:
                case MainViewErrors.StartMustBeSmallerThanEnd:
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
            this.tBIcon.Dispose();

            ViewModelLocator.MainViewModelStatic.CloseOnExit();

            Messenger.Default.Unregister<NotificationMessage<MainViewErrors>>(this, DisplayError);
            Messenger.Default.Unregister<NotificationMessage>(this, MainViewMessenger);

            ViewModelLocator.Cleanup();
        }

        #endregion Window_Closing

        #region Window_StateChanged

        /// <summary>
        /// Handles the StateChanged event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Window_StateChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Normal:
                case WindowState.Maximized:
                    this.ShowInTaskbar = true;
                    this.tBIcon.Visibility = Visibility.Hidden;

                    ViewModelLocator.MainViewModelStatic.Refresh();
                    break;

                case WindowState.Minimized:
                    this.ShowInTaskbar = false;
                    this.tBIcon.Visibility = Visibility.Visible;
                    break;
            }
        }

        #endregion Window_StateChanged

        #region mItemMaximize_Click

        /// <summary>
        /// Handles the Click event of the mItemMaximize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void mItemMaximize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        #endregion mItemMaximize_Click

        #region mItemClose_Click

        /// <summary>
        /// Handles the Click event of the mItemClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void mItemClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion mItemClose_Click

        #region tBIcon_TrayMouseDoubleClick

        /// <summary>
        /// Handles the TrayMouseDoubleClick event of the tBIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void tBIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        #endregion tBIcon_TrayMouseDoubleClick

        #region AutoSizeGridViewColumns

        /// <summary>
        /// Automatics the size grid view columns.
        /// </summary>
        private void AutoSizeGridViewColumns()
        {
            var gridView = this.lVPassedTime.View as GridView;
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
    }
}