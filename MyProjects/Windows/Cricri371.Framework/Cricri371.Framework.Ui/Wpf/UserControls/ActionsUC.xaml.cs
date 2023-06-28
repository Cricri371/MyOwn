using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cricri371.Framework.UI.Wpf.UserControls
{
    /// <summary>
    /// Class ActionsUC. 
    /// </summary>
    /// <seealso cref="System.Windows.Controls.UserControl" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class ActionsUC : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionsUC" /> class. 
        /// </summary>
        public ActionsUC()
        {
            InitializeComponent();
        }

        #region NewCommand

        /// <summary>
        /// The <see cref="NewCommand" /> dependency property's name. 
        /// </summary>
        public const string NewCommandPropertyName = "NewCommand";

        /// <summary>
        /// Gets or sets the value of the <see cref="NewCommand" /> property. This is a dependency property. 
        /// </summary>
        /// <value> The new command. </value>
        public ICommand NewCommand
        {
            get { return (ICommand)GetValue(NewCommandProperty); }
            set { SetValue(NewCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="NewCommand" /> dependency property. 
        /// </summary>
        public static readonly DependencyProperty NewCommandProperty =
            DependencyProperty.Register(NewCommandPropertyName, typeof(ICommand), typeof(ActionsUC), new UIPropertyMetadata(null));

        #endregion NewCommand

        #region AddCommand

        /// <summary>
        /// Gets or sets the add command. 
        /// </summary>
        /// <value> The add command. </value>
        public ICommand AddCommand
        {
            get { return (ICommand)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }

        /// <summary>
        /// The add command property 
        /// </summary>
        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(ActionsUC), new UIPropertyMetadata(null));

        #endregion AddCommand

        #region ModifyCommand

        /// <summary>
        /// Gets or sets the modify command. 
        /// </summary>
        /// <value> The modify command. </value>
        public ICommand ModifyCommand
        {
            get { return (ICommand)GetValue(ModifyCommandProperty); }
            set { SetValue(ModifyCommandProperty, value); }
        }

        /// <summary>
        /// The modify command property 
        /// </summary>
        public static readonly DependencyProperty ModifyCommandProperty =
            DependencyProperty.Register("ModifyCommand", typeof(ICommand), typeof(ActionsUC), new UIPropertyMetadata(null));

        #endregion ModifyCommand

        #region DeleteCommand

        /// <summary>
        /// Gets or sets the delete command. 
        /// </summary>
        /// <value> The delete command. </value>
        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }

        /// <summary>
        /// The delete command property 
        /// </summary>
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(ActionsUC), new UIPropertyMetadata(null));

        #endregion DeleteCommand
    }
}