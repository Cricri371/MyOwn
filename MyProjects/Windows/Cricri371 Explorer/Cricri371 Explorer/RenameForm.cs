using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cricri371_Explorer
{
	public partial class RenameForm
	{
		private MainForm mfNewName;

        #region RenameForm
        public RenameForm(MainForm FMainForm)
		{
			InitializeComponent();
			
			mfNewName=FMainForm;
			
			tBOldname.Text=mfNewName.oldName;
			
			mfNewName.NewName="";
        }
        #endregion

        #region BOKClick
        void BOKClick(object sender, System.EventArgs e)
		{
			mfNewName.NewName=tBNewName.Text;

			this.Close();
        }
        #endregion

        #region BCancelClick
        void BCancelClick(object sender, System.EventArgs e)
		{
			mfNewName.renameCancel=true;
			this.Close();
        }
        #endregion
    }
}
