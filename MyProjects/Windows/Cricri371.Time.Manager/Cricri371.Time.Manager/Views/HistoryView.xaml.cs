using System.Windows;
using System.Windows.Input;

using Cricri371.Time.Manager.ViewModel;

namespace Cricri371.Time.Manager.Views
{
    /// <summary>
    /// Description for HistoryView.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class HistoryView : Window
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the HistoryView class.
        /// </summary>
        public HistoryView()
        {
            InitializeComponent();

            SourceInitialized += (x, y) =>
            {
                this.DisableMinimizeButton();
            };
        }

        #endregion Constructor

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
            ViewModelLocator.HistoryViewModelStatic.ClearAll();
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