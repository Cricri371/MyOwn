namespace Cricri371_Explorer
{
	public partial class CreateForm
	{
		private MainForm mfNewNameDirectory;

        #region CreateForm
        public CreateForm(MainForm FMainForm)
		{
			InitializeComponent();
			
			mfNewNameDirectory=FMainForm;
        }
        #endregion

        #region BOkClick
        void BOkClick(object sender, System.EventArgs e)
		{
			mfNewNameDirectory.NewName=tBNewDirectoryName.Text;

			this.Close();
        }
        #endregion

        #region BCancelClick
        void BCancelClick(object sender, System.EventArgs e)
		{
			this.Close();
        }
        #endregion
    }
}
