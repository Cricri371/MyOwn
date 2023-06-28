/*
 * Created by SharpDevelop.
 * User: Christophe Charanson
 * Date: 26/12/2005
 * Time: 22:49
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace Cricri371CryptDecrypt
{
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tBOutput;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Button bCrypter;
		private System.Windows.Forms.Button bClear;
		private System.Windows.Forms.TextBox tBInput;
		private System.Windows.Forms.Button bDecrypter;
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Run(new MainForm());
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.bDecrypter = new System.Windows.Forms.Button();
			this.tBInput = new System.Windows.Forms.TextBox();
			this.bClear = new System.Windows.Forms.Button();
			this.bCrypter = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tBOutput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// bDecrypter
			// 
			this.bDecrypter.Location = new System.Drawing.Point(384, 256);
			this.bDecrypter.Name = "bDecrypter";
			this.bDecrypter.Size = new System.Drawing.Size(376, 40);
			this.bDecrypter.TabIndex = 2;
			this.bDecrypter.Text = "Décryptage";
			this.bDecrypter.Click += new System.EventHandler(this.BDecrypterClick);
			// 
			// tBInput
			// 
			this.tBInput.Location = new System.Drawing.Point(8, 32);
			this.tBInput.MaxLength = 0;
			this.tBInput.Multiline = true;
			this.tBInput.Name = "tBInput";
			this.tBInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tBInput.Size = new System.Drawing.Size(752, 200);
			this.tBInput.TabIndex = 0;
			this.tBInput.Text = "";
			// 
			// bClear
			// 
			this.bClear.Location = new System.Drawing.Point(184, 296);
			this.bClear.Name = "bClear";
			this.bClear.Size = new System.Drawing.Size(384, 40);
			this.bClear.TabIndex = 7;
			this.bClear.Text = "Effacer";
			this.bClear.Click += new System.EventHandler(this.BClearClick);
			// 
			// bCrypter
			// 
			this.bCrypter.Location = new System.Drawing.Point(8, 256);
			this.bCrypter.Name = "bCrypter";
			this.bCrypter.Size = new System.Drawing.Size(376, 40);
			this.bCrypter.TabIndex = 1;
			this.bCrypter.Text = "Cryptage";
			this.bCrypter.Click += new System.EventHandler(this.BCrypterClick);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 545);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(770, 22);
			this.statusBar1.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 4;
			this.label1.Text = "Entrée :";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 320);
			this.label2.Name = "label2";
			this.label2.TabIndex = 5;
			this.label2.Text = "Sortie :";
			// 
			// tBOutput
			// 
			this.tBOutput.Location = new System.Drawing.Point(8, 344);
			this.tBOutput.MaxLength = 0;
			this.tBOutput.Multiline = true;
			this.tBOutput.Name = "tBOutput";
			this.tBOutput.ReadOnly = true;
			this.tBOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tBOutput.Size = new System.Drawing.Size(752, 200);
			this.tBOutput.TabIndex = 3;
			this.tBOutput.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(770, 567);
			this.Controls.Add(this.bClear);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tBOutput);
			this.Controls.Add(this.bDecrypter);
			this.Controls.Add(this.bCrypter);
			this.Controls.Add(this.tBInput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Cricri371 cryptage/décryptage en hexa";
			this.ResumeLayout(false);
		}
		#endregion
		
		byte[] bytes;
		
		void BCrypterClick(object sender, System.EventArgs e)
		{
			if(tBInput.Text.Length!=0)
			{
				int cpt=0;
				
				bytes=new byte[4];
				
				foreach(char c in tBInput.Text)
				{
					bytes[cpt]=Convert.ToByte(c);
	
					Encryptage(bytes);
					
					cpt=0;
				}
			}
			else
				MessageBox.Show("Vous n'avez rien encodé pour crypter dans la zone Entrée");
		}
		
		void BDecrypterClick(object sender, System.EventArgs e)
		{
			if(tBInput.Text.Length!=0)
			{
				string[] splitHex=tBInput.Text.Split('%');
				
				bool first=true;
				
				foreach(string hex in splitHex)
				{
					if(!first)
					{
						Decryptage(hex);
					}
					else
						first=false;
				}
			}
			else
				MessageBox.Show("Vous n'avez rien encodé pour décrypter dans la zone Entrée");
		}
		
		char[] hexDigits={'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};
 		
		void Encryptage(byte[] bytes)
		{		
			for (int i=0;i<bytes.Length;i++) 
			{
				char[] chars=new char[bytes.Length*2];
				
				int b=bytes[i];
				
				chars[i]='%';
				chars[i+1]=hexDigits[b>>4];
			    chars[i+2]=hexDigits[b&0xF];
							    
			    tBOutput.Text+=new string(chars);
	       	}
		}
		
		
		void Decryptage(string nbreHex)
		{
			int nbreDeci=0;
			
			for(int i=0;i<nbreHex.Length;i++)
			{
				char caracHex=nbreHex[nbreHex.Length-i-1];
				
				switch(caracHex)
				{
					case '0':
						nbreDeci+=0*Convert.ToInt16(Math.Pow(16,i));
						break;
					case '1':
						nbreDeci+=1*Convert.ToInt16(Math.Pow(16,i));
						break;
					case '2':
						nbreDeci+=2*Convert.ToInt16(Math.Pow(16,i));
						break;
					case '3':
						nbreDeci+=3*Convert.ToInt16(Math.Pow(16,i));
						break;
					case '4':
						nbreDeci+=4*Convert.ToInt16(Math.Pow(16,i));
						break;
					case '5':
						nbreDeci+=5*Convert.ToInt16(Math.Pow(16,i));
						break;
					case '6':
						nbreDeci+=6*Convert.ToInt16(Math.Pow(16,i));
						break;
					case '7':
						nbreDeci+=7*Convert.ToInt16(Math.Pow(16,i));
						break;
					case '8':
						nbreDeci+=8*Convert.ToInt16(Math.Pow(16,i));
						break;
					case '9':
						nbreDeci+=9*Convert.ToInt16(Math.Pow(16,i));
						break;
					case 'A':
						nbreDeci+=10*Convert.ToInt16(Math.Pow(16,i));
						break;
					case 'B':
						nbreDeci+=11*Convert.ToInt16(Math.Pow(16,i));
						break;
					case 'C':
						nbreDeci+=12*Convert.ToInt16(Math.Pow(16,i));
						break;
					case 'D':
						nbreDeci+=13*Convert.ToInt16(Math.Pow(16,i));
						break;
					case 'E':
						nbreDeci+=14*Convert.ToInt16(Math.Pow(16,i));
						break;
					case 'F':
						nbreDeci+=15*Convert.ToInt16(Math.Pow(16,i));
						break;
					default:
						break;
				}
			}
			tBOutput.Text+=""+(char)nbreDeci;
        }
		
		void BClearClick(object sender, System.EventArgs e)
		{
			tBInput.Text="";
			tBOutput.Text="";
		}
		
	}
}
