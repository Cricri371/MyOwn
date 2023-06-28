/*
 * Created by SharpDevelop.
 * User: Christophe Charanson
 * Date: 30/07/2006
 * Time: 22:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using UCCricri371;

namespace Cricri371_Explorer
{
	/// <summary>
	/// Description of FDelete.
	/// </summary>
	public partial class FDelete
	{
		private MainForm mF;
		
		public FDelete(MainForm mForm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			mF=mForm;
		}
		
		void FDeleteLoad(object sender, System.EventArgs e)
		{
			controlMessageBox.Message=mF.suppMessage;
		}
		
		void FDeleteFormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			mF.response=controlMessageBox.Response;
		}
		
		void ControlMessageBoxEnabledChanged(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
