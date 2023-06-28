/*
 * Created by SharpDevelop.
 * User: Christophe Charanson
 * Date: 21/07/2005
 * Time: 1:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cricri371MotCodé
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tBPhrase;
		private System.Windows.Forms.Button bRemplacerLettresNbres;
		private System.Windows.Forms.TextBox tbNombre;
		private System.Windows.Forms.ColumnHeader cHNombres;
		private System.Windows.Forms.ColumnHeader cHLettres;
		private System.Windows.Forms.Label lConversNum;
		private System.Windows.Forms.GroupBox gBSolution;
		private System.Windows.Forms.TextBox tBNombres;
		private System.Windows.Forms.Button bRemplacer;
		private System.Windows.Forms.TextBox tBLettre;
		private System.Windows.Forms.ListView lVNbresLettres;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button bCorresp;
		private System.Windows.Forms.Button bConversNum;
		private System.Windows.Forms.TextBox tBMotConvert;

		private System.Windows.Forms.ListViewItem lvi;
		private System.Windows.Forms.ListViewItem.ListViewSubItem lvsi;
		
		#region Variables
		private string[,] LettresNbres=new string[26,2];
		private char[] lettres={'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
		#endregion

		#region Main
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			for(int i=0;i<26;i++)
			{	
				LettresNbres[i,0]=lettres[i].ToString();
				LettresNbres[i,1]="";
			}
				
			remplir();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Run(new MainForm());			
		}
		#endregion
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.tBMotConvert = new System.Windows.Forms.TextBox();
			this.bConversNum = new System.Windows.Forms.Button();
			this.bCorresp = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lVNbresLettres = new System.Windows.Forms.ListView();
			this.tBLettre = new System.Windows.Forms.TextBox();
			this.bRemplacer = new System.Windows.Forms.Button();
			this.tBNombres = new System.Windows.Forms.TextBox();
			this.gBSolution = new System.Windows.Forms.GroupBox();
			this.lConversNum = new System.Windows.Forms.Label();
			this.cHLettres = new System.Windows.Forms.ColumnHeader();
			this.cHNombres = new System.Windows.Forms.ColumnHeader();
			this.tbNombre = new System.Windows.Forms.TextBox();
			this.bRemplacerLettresNbres = new System.Windows.Forms.Button();
			this.tBPhrase = new System.Windows.Forms.TextBox();
			this.gBSolution.SuspendLayout();
			this.SuspendLayout();
			// 
			// tBMotConvert
			// 
			this.tBMotConvert.Location = new System.Drawing.Point(16, 59);
			this.tBMotConvert.Name = "tBMotConvert";
			this.tBMotConvert.Size = new System.Drawing.Size(176, 21);
			this.tBMotConvert.TabIndex = 1;
			this.tBMotConvert.Text = "";
			// 
			// bConversNum
			// 
			this.bConversNum.Location = new System.Drawing.Point(216, 74);
			this.bConversNum.Name = "bConversNum";
			this.bConversNum.Size = new System.Drawing.Size(136, 30);
			this.bConversNum.TabIndex = 5;
			this.bConversNum.Text = "Conversion numérique";
			this.bConversNum.Click += new System.EventHandler(this.BConversNumClick);
			// 
			// bCorresp
			// 
			this.bCorresp.Location = new System.Drawing.Point(736, 30);
			this.bCorresp.Name = "bCorresp";
			this.bCorresp.Size = new System.Drawing.Size(32, 21);
			this.bCorresp.TabIndex = 12;
			this.bCorresp.Text = "=";
			this.bCorresp.Click += new System.EventHandler(this.BCorrespClick);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 149);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(176, 21);
			this.label4.TabIndex = 9;
			this.label4.Text = "Phrase en fonction des nombres :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(616, 7);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 22);
			this.label5.TabIndex = 18;
			this.label5.Text = "Lettre";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(784, 7);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 22);
			this.label6.TabIndex = 19;
			this.label6.Text = "Nombre";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 21);
			this.label1.TabIndex = 3;
			this.label1.Text = "Mot à convertir";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(176, 21);
			this.label2.TabIndex = 4;
			this.label2.Text = "Conversion numérique";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 37);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(552, 21);
			this.label3.TabIndex = 8;
			this.label3.Text = "Encodez les nombres :  (Mettre un / pour séparer les nombres et une * pour les es" +
"paces entre les nombres)";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lVNbresLettres
			// 
			this.lVNbresLettres.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
						this.cHLettres,
						this.cHNombres});
			this.lVNbresLettres.FullRowSelect = true;
			this.lVNbresLettres.GridLines = true;
			this.lVNbresLettres.LabelWrap = false;
			this.lVNbresLettres.Location = new System.Drawing.Point(688, 59);
			this.lVNbresLettres.MultiSelect = false;
			this.lVNbresLettres.Name = "lVNbresLettres";
			this.lVNbresLettres.Scrollable = false;
			this.lVNbresLettres.Size = new System.Drawing.Size(120, 357);
			this.lVNbresLettres.TabIndex = 11;
			this.lVNbresLettres.View = System.Windows.Forms.View.Details;
			// 
			// tBLettre
			// 
			this.tBLettre.Location = new System.Drawing.Point(616, 30);
			this.tBLettre.MaxLength = 1;
			this.tBLettre.Name = "tBLettre";
			this.tBLettre.TabIndex = 13;
			this.tBLettre.Text = "";
			// 
			// bRemplacer
			// 
			this.bRemplacer.Location = new System.Drawing.Point(8, 97);
			this.bRemplacer.Name = "bRemplacer";
			this.bRemplacer.Size = new System.Drawing.Size(208, 29);
			this.bRemplacer.TabIndex = 0;
			this.bRemplacer.Text = "Remplacer les nombres par les lettres";
			this.bRemplacer.Click += new System.EventHandler(this.BRemplacerNbresLettresClick);
			// 
			// tBNombres
			// 
			this.tBNombres.Location = new System.Drawing.Point(8, 67);
			this.tBNombres.Name = "tBNombres";
			this.tBNombres.Size = new System.Drawing.Size(552, 21);
			this.tBNombres.TabIndex = 7;
			this.tBNombres.Text = "";
			// 
			// gBSolution
			// 
			this.gBSolution.Controls.Add(this.tBMotConvert);
			this.gBSolution.Controls.Add(this.label1);
			this.gBSolution.Controls.Add(this.label2);
			this.gBSolution.Controls.Add(this.bConversNum);
			this.gBSolution.Controls.Add(this.lConversNum);
			this.gBSolution.Location = new System.Drawing.Point(8, 215);
			this.gBSolution.Name = "gBSolution";
			this.gBSolution.Size = new System.Drawing.Size(368, 164);
			this.gBSolution.TabIndex = 16;
			this.gBSolution.TabStop = false;
			this.gBSolution.Text = "Solution";
			// 
			// lConversNum
			// 
			this.lConversNum.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.lConversNum.ForeColor = System.Drawing.Color.Red;
			this.lConversNum.Location = new System.Drawing.Point(16, 134);
			this.lConversNum.Name = "lConversNum";
			this.lConversNum.Size = new System.Drawing.Size(176, 21);
			this.lConversNum.TabIndex = 10;
			this.lConversNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cHLettres
			// 
			this.cHLettres.Text = "Lettres";
			// 
			// cHNombres
			// 
			this.cHNombres.Text = "Nombres";
			// 
			// tbNombre
			// 
			this.tbNombre.Location = new System.Drawing.Point(784, 30);
			this.tbNombre.MaxLength = 2;
			this.tbNombre.Name = "tbNombre";
			this.tbNombre.TabIndex = 14;
			this.tbNombre.Text = "";
			// 
			// bRemplacerLettresNbres
			// 
			this.bRemplacerLettresNbres.Location = new System.Drawing.Point(352, 97);
			this.bRemplacerLettresNbres.Name = "bRemplacerLettresNbres";
			this.bRemplacerLettresNbres.Size = new System.Drawing.Size(208, 29);
			this.bRemplacerLettresNbres.TabIndex = 15;
			this.bRemplacerLettresNbres.Text = "Remplacer les lettres par les nombres";
			this.bRemplacerLettresNbres.Click += new System.EventHandler(this.BRemplacerLettresNbresClick);
			// 
			// tBPhrase
			// 
			this.tBPhrase.Location = new System.Drawing.Point(8, 178);
			this.tBPhrase.Name = "tBPhrase";
			this.tBPhrase.Size = new System.Drawing.Size(552, 21);
			this.tBPhrase.TabIndex = 17;
			this.tBPhrase.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(912, 420);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tBPhrase);
			this.Controls.Add(this.gBSolution);
			this.Controls.Add(this.bRemplacerLettresNbres);
			this.Controls.Add(this.tbNombre);
			this.Controls.Add(this.tBLettre);
			this.Controls.Add(this.bCorresp);
			this.Controls.Add(this.lVNbresLettres);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tBNombres);
			this.Controls.Add(this.bRemplacer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Cricri371MotCodé";
			this.gBSolution.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion
		
		#region BRemplacerNbresLettresClick : Remplacement des nombres par les lettres correspondantes
		void BRemplacerNbresLettresClick(object sender, System.EventArgs e)
		{
			string[] hashLettres;
			string[] hashEspaces;
			
			tBPhrase.Text="";
			
			hashEspaces=tBNombres.Text.Split('*');
			
			for(int i=0;i<hashEspaces.Length;i++)
			{
				hashLettres=hashEspaces[i].Split('/');
				
				for(int j=0;j<hashLettres.Length;j++)
				{
					int k;
					for(k=0;k<26;k++)
					{
						if(hashLettres[j].CompareTo(lVNbresLettres.Items[k].SubItems[1].Text)==0)
						{
							tBPhrase.Text+=lVNbresLettres.Items[k].SubItems[0].Text;
							break;
						}
					}
					
					if(k==26)
						tBPhrase.Text+="?";
					
				}
				if(i<hashEspaces.Length-1)
					tBPhrase.Text+=" ";
			}
		}
		#endregion
		
		#region remplir : Remplissage liste
		void remplir()
		{
			lVNbresLettres.Items.Clear();
			for(int i=0;i<26;i++)
			{	
				lvi=new ListViewItem();

				lvi.Text=LettresNbres[i,0];
				
				lvsi=new ListViewItem.ListViewSubItem();			
				lvsi.Text=LettresNbres[i,1];
				lvi.SubItems.Add(lvsi);

				lVNbresLettres.Items.Add(lvi);
			}
		}
		#endregion		
		
		#region BRemplacerLettresNbresClick : Mettre les nombres correspondant aux lettres dans le tableau
		void BRemplacerLettresNbresClick(object sender, System.EventArgs e)
		{
			string[] DecoupageEtoiletbNombres=tBNombres.Text.Split('*');
			string[] DecoupageEspacetBPhrase=tBPhrase.Text.Split(' ');
			
			string[] DecoupageSlashtBNombres;

			for(int i=0;i<DecoupageEspacetBPhrase.Length;i++)
			{
				DecoupageSlashtBNombres=DecoupageEtoiletbNombres[i].Split('/');
				
				for(int j=0;j<DecoupageEspacetBPhrase[i].Length;j++)
				{
					if(DecoupageEspacetBPhrase[i][j]!='?')
					{						
						for(int k=0;k<26;k++)
						{
							if(DecoupageEspacetBPhrase[i][j].ToString()==LettresNbres[k,0].ToString())
							{
								LettresNbres[k,1]=DecoupageSlashtBNombres[j];
								k=26;
							}
						}
					}
						
				}
			}
			
			remplir();
		}
		#endregion
		
		#region BCorrespClick : Ajout dans le tableau de la correspondance entre une lettre et un nombre
		void BCorrespClick(object sender, System.EventArgs e)
		{			
			bool Correct=false;
			
			for(int i=0;i<26;i++)
			{
				if(tBLettre.Text.ToUpper()==LettresNbres[i,0])
				{
					LettresNbres[i,1]=tbNombre.Text;
					remplir();
					Correct=true;
					break;
				}
			}
			
			if(Correct==false)
				MessageBox.Show("Vous n'avez pas entré une lettre de l'alphabet");
			
			tbNombre.Text="";
			tBLettre.Text="";
		}
		#endregion
		
		#region BConversNumClick : Conversion pour le mot caché en un nombre
		void BConversNumClick(object sender, System.EventArgs e)
		{
			lConversNum.Text="";
			int j;
			
			for(int i=0;i<tBMotConvert.Text.Length;i++)
			{
				
				for(j=0;j<26;j++)
				{	
					if(tBMotConvert.Text[i].ToString()==LettresNbres[j,0].ToString())
					{
						if(LettresNbres[j,1].Length!=0)
							lConversNum.Text+=LettresNbres[j,1];
						else
							lConversNum.Text+="?";		
						break;
					}
												
				}
			}
		}
		#endregion
	}
}
