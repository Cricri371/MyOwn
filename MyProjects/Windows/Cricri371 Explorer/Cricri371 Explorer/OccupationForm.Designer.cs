/*
 * Created by SharpDevelop.
 * User: Christophe Charanson
 * Date: 30/07/2006
 * Time: 21:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Cricri371_Explorer
{
	partial class OccupationForm : System.Windows.Forms.Form
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
			this.components = new System.ComponentModel.Container();
			this.lOccupation = new System.Windows.Forms.Label();
			this.pBarOccupation = new System.Windows.Forms.ProgressBar();
			this.timerOccupation = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// lOccupation
			// 
			this.lOccupation.Location = new System.Drawing.Point(0, 0);
			this.lOccupation.Name = "lOccupation";
			this.lOccupation.Size = new System.Drawing.Size(280, 56);
			this.lOccupation.TabIndex = 0;
			// 
			// pBarOccupation
			// 
			this.pBarOccupation.Location = new System.Drawing.Point(0, 56);
			this.pBarOccupation.Name = "pBarOccupation";
			this.pBarOccupation.Size = new System.Drawing.Size(280, 23);
			this.pBarOccupation.TabIndex = 1;
			// 
			// timerOccupation
			// 
			this.timerOccupation.Enabled = true;
			this.timerOccupation.Interval = 50;
			this.timerOccupation.Tick += new System.EventHandler(this.TimerOccupationTick);
			// 
			// FOccupation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(280, 80);
			this.Controls.Add(this.pBarOccupation);
			this.Controls.Add(this.lOccupation);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FOccupation";
			this.ShowInTaskbar = false;
			this.Text = "Patienter";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FOccupationFormClosed);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Timer timerOccupation;
		private System.Windows.Forms.ProgressBar pBarOccupation;
		private System.Windows.Forms.Label lOccupation;
	}
}
