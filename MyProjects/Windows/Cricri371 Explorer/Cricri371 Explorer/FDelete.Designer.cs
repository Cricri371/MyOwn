/*
 * Created by SharpDevelop.
 * User: Christophe Charanson
 * Date: 30/07/2006
 * Time: 22:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Cricri371_Explorer
{
	partial class FDelete : System.Windows.Forms.Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.controlMessageBox = new UCCricri371.UCMessageBoxFull();
			this.SuspendLayout();
			// 
			// controlMessageBox
			// 
			this.controlMessageBox.Location = new System.Drawing.Point(0, 0);
			this.controlMessageBox.Name = "controlMessageBox";
			this.controlMessageBox.Response = 0;
			this.controlMessageBox.Size = new System.Drawing.Size(426, 93);
			this.controlMessageBox.TabIndex = 0;
			this.controlMessageBox.EnabledChanged += new System.EventHandler(this.ControlMessageBoxEnabledChanged);
			// 
			// FDelete
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(427, 93);
			this.Controls.Add(this.controlMessageBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FDelete";
			this.ShowInTaskbar = false;
			this.Text = "Supprimer le(s) fichier(s)";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FDeleteFormClosed);
			this.Load += new System.EventHandler(this.FDeleteLoad);
			this.ResumeLayout(false);
		}
		private UCCricri371.UCMessageBoxFull controlMessageBox;
	}
}
