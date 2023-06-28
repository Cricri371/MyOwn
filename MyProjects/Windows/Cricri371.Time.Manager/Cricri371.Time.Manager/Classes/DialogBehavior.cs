using System.Windows;
using System.Windows.Interactivity;

using GalaSoft.MvvmLight.Messaging;

namespace Cricri371.Time.Manager.Classes
{
    /// <summary>
    /// Class DialogBehavior.
    /// </summary>
    /// <seealso cref="System.Windows.Interactivity.Behavior{System.Windows.FrameworkElement}" />
    public class DialogBehavior : Behavior<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value> The identifier. </value>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value> The caption. </value>
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value> The text. </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the buttons.
        /// </summary>
        /// <value> The buttons. </value>
        public MessageBoxButton Buttons { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value> The images. </value>
        public MessageBoxImage Images { get; set; }

        #region OnAttached

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks> Override this to hook up functionality to the AssociatedObject. </remarks>
        protected override void OnAttached()
        {
            base.OnAttached();

            Messenger.Default.Register<DialogMessage>(this, this.Identifier, ShowDialog);
        }

        #endregion OnAttached

        #region ShowDialog

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="dialogMessage"> The dialog message. </param>
        private void ShowDialog(DialogMessage dialogMessage)
        {
            var result = MessageBox.Show(this.Text, this.Caption, this.Buttons, this.Images);

            dialogMessage.Callback(result);
        }

        #endregion ShowDialog
    }
}