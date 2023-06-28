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
    /// Description for ApplicationView.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class ProjectView : Window
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectView" /> class.
        /// </summary>
        public ProjectView()
        {
            InitializeComponent();

            SourceInitialized += (x, y) =>
            {
                this.DisableMinimizeButton();
            };

            Messenger.Default.Register<NotificationMessage<ProjectErrors>>(this, DisplayError);
            Messenger.Default.Register<NotificationMessage>(this, ManageProjectView);
        }

        #endregion Constructor

        #region ManageApplicationView

        /// <summary>
        /// Manages the project view.
        /// </summary>
        /// <param name="notificationMessage"> The notification message. </param>
        private void ManageProjectView(NotificationMessage notificationMessage)
        {
            if (notificationMessage.Sender == this.DataContext)
            {
                switch (notificationMessage.Notification)
                {
                    case "OpenApplicationView":
                        var applicationView = new ApplicationView
                        {
                            Owner = this
                        };
                        applicationView.ShowDialog();
                        break;

                    case "OpenTaskView":
                        var taskView = new TaskView
                        {
                            Owner = this
                        };
                        taskView.ShowDialog();
                        break;

                    case "AutoSizeProjectGridViewColumns":
                        AutoSizeGridViewColumns();
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion ManageApplicationView

        #region DisplayError

        /// <summary>
        /// Displays the error.
        /// </summary>
        /// <param name="msg"> The MSG. </param>
        /// <exception cref="NotImplementedException"> Exception when not known. </exception>
        private void DisplayError(NotificationMessage<ProjectErrors> msg)
        {
            switch (msg.Content)
            {
                case ProjectErrors.ProjectAlreadyExists:
                case ProjectErrors.ProjectNameNull:
                case ProjectErrors.ApplicationNotSelected:
                case ProjectErrors.ProjectUsed:
                case ProjectErrors.TaskIsUsedInProject:
                case ProjectErrors.TaskAlreadyLinkedToProject:
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
            ViewModelLocator.ProjectViewModelStatic.NewProject();

            Messenger.Default.Unregister<NotificationMessage<ProjectErrors>>(this, DisplayError);
            Messenger.Default.Unregister<NotificationMessage>(this, ManageProjectView);
        }

        #endregion Window_Closing

        #region AutoSizeGridViewColumns

        /// <summary>
        /// Automatics the size grid view columns.
        /// </summary>
        private void AutoSizeGridViewColumns()
        {
            var gridView = this.lVProjects.View as GridView;
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
        /// Handles the PreviewKeyDown event of the window control.
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