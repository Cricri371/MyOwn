/*
 * Created by SharpDevelop.
 * User: Christophe Charanson
 * Date: 30/04/2007
 * Time: 20:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Cricri371Dll;
using Cricri371Dll.Gui;

namespace Cricri371_Id_Tag_Manager
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		ArrayList listOfMp3;
		ListView.SelectedIndexCollection indexFiles,indexFilesToClean,indexFilesDetails;
		Mp3File mp3File;
		
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			listOfMp3=new ArrayList();
		}
		
		#region CBRename
		void CBRenameTitleCheckedChanged(object sender, EventArgs e)
		{
			if(cBRenameTitle.Checked)
			{
				tBRenameTitle.Enabled=true;
				pTitleRename.Enabled=true;
			}
			else
			{
				tBRenameTitle.Enabled=false;
				pTitleRename.Enabled=false;
			}
		}
		
		void CBRenameArtistCheckedChanged(object sender, EventArgs e)
		{
			if(cBRenameArtist.Checked)
			{
				tBRenameArtist.Enabled=true;
				pArtistRename.Enabled=true;
			}
			else
			{
				tBRenameArtist.Enabled=false;
				pArtistRename.Enabled=false;
			}
		}
		
		void CBRenameAlbumCheckedChanged(object sender, EventArgs e)
		{
			if(cBRenameAlbum.Checked)
			{
				tBRenameAlbum.Enabled=true;
				pAlbumRename.Enabled=true;
			}
			else
			{
				tBRenameAlbum.Enabled=false;
				pAlbumRename.Enabled=false;
			}
		}
		
		void CBRenameTrackCheckedChanged(object sender, EventArgs e)
		{
			if(cBRenameTrack.Checked)
			{
				tBRenameTrack.Enabled=true;
				pTrackRename.Enabled=true;
			}
			else
			{
				tBRenameTrack.Enabled=false;
				pTrackRename.Enabled=false;
			}
		}
		
		void CBRenameYearCheckedChanged(object sender, EventArgs e)
		{
			if(cBRenameYear.Checked)
			{
				tBRenameYear.Enabled=true;
				pYearRename.Enabled=true;
			}
			else
			{
				tBRenameYear.Enabled=false;
				pYearRename.Enabled=false;
			}
		}
		
		void CBRenameCommentCheckedChanged(object sender, EventArgs e)
		{
			if(cBRenameComment.Checked)
			{
				tBRenameComment.Enabled=true;
				pCommentRename.Enabled=true;
			}
			else
			{
				tBRenameComment.Enabled=false;
				pCommentRename.Enabled=false;
			}
		}
		
		void CBRenameGenreCheckedChanged(object sender, EventArgs e)
		{
			if(cBRenameGenre.Checked)
			{
				comboBRenameGenre.Enabled=true;
				pGenreRename.Enabled=true;
			}
			else
			{
				comboBRenameGenre.Enabled=false;
				pGenreRename.Enabled=false;
			}
		}
		#endregion
		
		#region CBDelete
		void CBDeleteTitleCheckedChanged(object sender, EventArgs e)
		{
			if(cBDeleteTitle.Checked)
				pTitleClean.Enabled=true;
			else
				pTitleClean.Enabled=false;
		}
		
		void CBDeleteArtistCheckedChanged(object sender, EventArgs e)
		{
			if(cBDeleteArtist.Checked)
				pArtistClean.Enabled=true;
			else
				pArtistClean.Enabled=false;
		}
		
		void CBDeleteAlbumCheckedChanged(object sender, EventArgs e)
		{
			if(cBDeleteAlbum.Checked)
				pAlbumClean.Enabled=true;
			else
				pAlbumClean.Enabled=false;
		}
		
		void CBDeleteTrackCheckedChanged(object sender, EventArgs e)
		{
			if(cBDeleteTrack.Checked)
				pTrackClean.Enabled=true;
			else
				pTrackClean.Enabled=false;
		}
		
		void CBDeleteYearCheckedChanged(object sender, EventArgs e)
		{
			if(cBDeleteYear.Checked)
				pYearClean.Enabled=true;
			else
				pYearClean.Enabled=false;
		}
		
		void CBDeleteCommentCheckedChanged(object sender, EventArgs e)
		{
			if(cBDeleteComment.Checked)
				pCommentClean.Enabled=true;
			else
				pCommentClean.Enabled=false;
		}
		
		void CBDeleteGenreCheckedChanged(object sender, EventArgs e)
		{
			if(cBDeleteGenre.Checked)
				pGenreClean.Enabled=true;
			else
				pGenreClean.Enabled=false;
		}
		#endregion
		
		#region BBrowseClick
		void BBrowseClick(object sender, EventArgs e)
		{
			if(DialogResult.OK==fBDWorkingDirectory.ShowDialog())
			{
				if(fBDWorkingDirectory.SelectedPath.Length!=0)
				{
					if(lVFiles.Items.Count!=0)
					{
						if(MessageBox.Show("Ajouter les fichiers du répertoire à la liste existante?","Ajout à la liste", MessageBoxButtons.YesNo)==DialogResult.No)
						{
							listOfMp3.Clear();
							lVFiles.Items.Clear();
							lVFilesToClean.Items.Clear();
							lVFilesDetails.Items.Clear();
						}
					}
					
					string[] files=Directory.GetFiles(fBDWorkingDirectory.SelectedPath,"*.mp3");
					
					foreach(string file in files)
					{
						listOfMp3.Add(file);
						string[] splitted=file.Split(@"\".ToCharArray());
						int length=splitted.Length;
						lVFiles.Items.Add(splitted[length-1]);
						lVFilesToClean.Items.Add(splitted[length-1]);
						lVFilesDetails.Items.Add(splitted[length-1]);
					}
				}
				
				tBDirectory.Text=fBDWorkingDirectory.SelectedPath;
			}
		}
		#endregion
		
		#region LVFilesSelectedIndexChanged
		void LVFilesSelectedIndexChanged(object sender, EventArgs e)
		{
			indexFiles=lVFiles.SelectedIndices;
		}
		#endregion
		
		#region LVFilesToCleanSelectedIndexChanged
		void LVFilesToCleanSelectedIndexChanged(object sender, EventArgs e)
		{
			indexFilesToClean=lVFilesToClean.SelectedIndices;
		}
		#endregion
		
		#region LVFilesDetailsSelectedIndexChanged
		void LVFilesDetailsSelectedIndexChanged(object sender, EventArgs e)
		{	
			indexFilesDetails=lVFilesDetails.SelectedIndices;
			
			foreach(int index in indexFilesDetails)
			{
				mp3File=new Mp3File();
				
				mp3File.ClearProperties();
				
				mp3File.ReadV1(listOfMp3[index].ToString());
				
				tBDetailsAlbumV1.Text=mp3File.Album;
				tBDetailsArtistV1.Text=mp3File.Artist;
				tbDetailsCommentV1.Text=mp3File.Comment;
				tBDetailsTitleV1.Text=mp3File.Title;
				tBDetailsTrackV1.Text=mp3File.Track.ToString();
				tBDetailsYearV1.Text=mp3File.Track.ToString();
				
				mp3File.ClearProperties();
				
				mp3File.ReadV2(listOfMp3[index].ToString());
				
				tBDetailsAlbumV2.Text=mp3File.Album;
				tBDetailsArtistV2.Text=mp3File.Artist;
				tbDetailsCommentV2.Text=mp3File.Comment;
				tBDetailsTitleV2.Text=mp3File.Title;
				tBDetailsTrackV2.Text=mp3File.Track.ToString();
				tBDetailsYearV2.Text=mp3File.Track.ToString();
			}
		}
		#endregion
		
		#region BCleanSelectedFilesClick
		void BCleanSelectedFilesClick(object sender, EventArgs e)
		{
			foreach(int index in indexFilesToClean)
			{
				mp3File.CleanV1(listOfMp3[index].ToString());
				mp3File.CleanV2(listOfMp3[index].ToString());
			}
		}
		#endregion
		
		#region BCleanAllFilesClick
		void BCleanAllFilesClick(object sender, EventArgs e)
		{
			foreach(string path in listOfMp3)
			{
				mp3File.CleanV1(path);
				mp3File.CleanV2(path);
			}
		}
		#endregion
		
		#region TSMIAboutClick
		void TSMIAboutClick(object sender, EventArgs e)
		{
			try
			{
				AboutForm aForm=new AboutForm();
				aForm.ShowDialog();
			}
			catch(ExceptionClass e371)
			{
				MessageBox.Show(e371.Message);
			}
		}
		#endregion
	}
}
