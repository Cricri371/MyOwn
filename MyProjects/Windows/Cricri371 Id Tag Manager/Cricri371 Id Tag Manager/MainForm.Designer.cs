/*
 * Created by SharpDevelop.
 * User: Christophe Charanson
 * Date: 30/04/2007
 * Time: 20:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Cricri371_Id_Tag_Manager
{
	partial class MainForm
	{
		private System.Windows.Forms.ToolStripMenuItem tSMIAbout;
		private System.Windows.Forms.MenuStrip mSMainform;
		private System.Windows.Forms.GroupBox gBDetailsTagV2;
		private System.Windows.Forms.TextBox tBDetailsYearV2;
		private System.Windows.Forms.TextBox tbDetailsCommentV2;
		private System.Windows.Forms.TextBox tBDetailsTrackV2;
		private System.Windows.Forms.TextBox tBDetailsAlbumV2;
		private System.Windows.Forms.TextBox tBDetailsArtistV2;
		private System.Windows.Forms.TextBox tBDetailsTitleV2;
		private System.Windows.Forms.ComboBox cBDetailsGenreV1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.GroupBox gBDetailsTagV1;
		private System.Windows.Forms.TextBox tBDetailsYearV1;
		private System.Windows.Forms.TextBox tbDetailsCommentV1;
		private System.Windows.Forms.TextBox tBDetailsTrackV1;
		private System.Windows.Forms.TextBox tBDetailsAlbumV1;
		private System.Windows.Forms.TextBox tBDetailsArtistV1;
		private System.Windows.Forms.TextBox tBDetailsTitleV1;
		private System.Windows.Forms.ComboBox cBDetailsGenreV2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView lVFilesDetails;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TabPage tPTagsDetails;
		private System.Windows.Forms.TextBox tBDirectory;
		private System.Windows.Forms.ColumnHeader cHCleanFiles;
		private System.Windows.Forms.ColumnHeader cHFiles;
		private System.Windows.Forms.Panel pArtistClean;
		private System.Windows.Forms.Panel pTitleClean;
		private System.Windows.Forms.Panel pTrackClean;
		private System.Windows.Forms.Panel pAlbumClean;
		private System.Windows.Forms.Panel pYearClean;
		private System.Windows.Forms.Panel pCommentClean;
		private System.Windows.Forms.Panel pGenreClean;
		private System.Windows.Forms.Panel pTitleRename;
		private System.Windows.Forms.Panel pArtistRename;
		private System.Windows.Forms.Panel pAlbumRename;
		private System.Windows.Forms.Panel pTrackRename;
		private System.Windows.Forms.Panel pYearRename;
		private System.Windows.Forms.Panel pCommentRename;
		private System.Windows.Forms.Panel pGenreRename;
		private System.Windows.Forms.FolderBrowserDialog fBDWorkingDirectory;
		private System.Windows.Forms.Button bDeleteFilesFromLVFiles;
		private System.Windows.Forms.CheckBox cBDeleteTitle;
		private System.Windows.Forms.CheckBox cBDeleteArtist;
		private System.Windows.Forms.CheckBox cBDeleteAlbum;
		private System.Windows.Forms.CheckBox cBDeleteTrack;
		private System.Windows.Forms.CheckBox cBDeleteComment;
		private System.Windows.Forms.CheckBox cBDeleteGenre;
		private System.Windows.Forms.CheckBox cBDeleteYear;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rBDeleteTitle1;
		private System.Windows.Forms.RadioButton rBDeleteTitle2;
		private System.Windows.Forms.RadioButton rBDeleteTitle3;
		private System.Windows.Forms.RadioButton rBDeleteArtist1;
		private System.Windows.Forms.RadioButton rBDeleteArtist2;
		private System.Windows.Forms.RadioButton rBDeleteArtist3;
		private System.Windows.Forms.RadioButton rBDeleteAlbum1;
		private System.Windows.Forms.RadioButton rBDeleteAlbum2;
		private System.Windows.Forms.RadioButton rBDeleteAlbum3;
		private System.Windows.Forms.RadioButton rBDeleteTrack1;
		private System.Windows.Forms.RadioButton rBDeleteTrack2;
		private System.Windows.Forms.RadioButton rBDeleteTrack3;
		private System.Windows.Forms.RadioButton rBDeleteComment1;
		private System.Windows.Forms.RadioButton rBDeleteComment2;
		private System.Windows.Forms.RadioButton rBDeleteComment3;
		private System.Windows.Forms.RadioButton rBDeleteGenre1;
		private System.Windows.Forms.RadioButton rBDeleteGenre2;
		private System.Windows.Forms.RadioButton rBDeleteGenre3;
		private System.Windows.Forms.RadioButton rBDeleteTitle4;
		private System.Windows.Forms.RadioButton rBDeleteArtist4;
		private System.Windows.Forms.RadioButton rBDeleteAlbum4;
		private System.Windows.Forms.RadioButton rBDeleteTrack4;
		private System.Windows.Forms.RadioButton rBDeleteComment4;
		private System.Windows.Forms.RadioButton rBDeleteGenre4;
		private System.Windows.Forms.RadioButton rBDeleteYear1;
		private System.Windows.Forms.RadioButton rBDeleteYear2;
		private System.Windows.Forms.RadioButton rBDeleteYear3;
		private System.Windows.Forms.RadioButton rBDeleteYear4;
		private System.Windows.Forms.Button bCleanAllFiles;
		private System.Windows.Forms.Button bCleanSelectedFiles;
		private System.Windows.Forms.ListView lVFilesToClean;
		private System.Windows.Forms.TabPage tPCleanFiles;
		private System.Windows.Forms.ListView lVFiles;
		private System.Windows.Forms.RadioButton rBRenameYear1;
		private System.Windows.Forms.RadioButton rBRenameYear2;
		private System.Windows.Forms.RadioButton rBRenameYear3;
		private System.Windows.Forms.RadioButton rBRenameYear4;
		private System.Windows.Forms.TabControl tCManipulations;
		private System.Windows.Forms.ComboBox comboBRenameGenre;
		private System.Windows.Forms.RadioButton rBRenameGenre3;
		private System.Windows.Forms.RadioButton rBRenameGenre2;
		private System.Windows.Forms.RadioButton rBRenameGenre1;
		private System.Windows.Forms.RadioButton rBRenameComment3;
		private System.Windows.Forms.RadioButton rBRenameComment2;
		private System.Windows.Forms.RadioButton rBRenameComment1;
		private System.Windows.Forms.RadioButton rBRenameTrack3;
		private System.Windows.Forms.RadioButton rBRenameTrack2;
		private System.Windows.Forms.RadioButton rBRenameTrack1;
		private System.Windows.Forms.RadioButton rBRenameAlbum3;
		private System.Windows.Forms.RadioButton rBRenameAlbum2;
		private System.Windows.Forms.RadioButton rBRenameAlbum1;
		private System.Windows.Forms.RadioButton rBRenameArtist3;
		private System.Windows.Forms.RadioButton rBRenameArtist2;
		private System.Windows.Forms.RadioButton rBRenameArtist1;
		private System.Windows.Forms.RadioButton rBRenameTitle3;
		private System.Windows.Forms.RadioButton rBRenameTitle2;
		private System.Windows.Forms.RadioButton rBRenameTitle1;
		private System.Windows.Forms.CheckBox cBRenameYear;
		private System.Windows.Forms.CheckBox cBRenameGenre;
		private System.Windows.Forms.CheckBox cBRenameComment;
		private System.Windows.Forms.CheckBox cBRenameTrack;
		private System.Windows.Forms.CheckBox cBRenameAlbum;
		private System.Windows.Forms.CheckBox cBRenameArtist;
		private System.Windows.Forms.CheckBox cBRenameTitle;
		private System.Windows.Forms.RadioButton rBRenameGenre4;
		private System.Windows.Forms.RadioButton rBRenameComment4;
		private System.Windows.Forms.RadioButton rBRenameTrack4;
		private System.Windows.Forms.RadioButton rBRenameAlbum4;
		private System.Windows.Forms.RadioButton rBRenameArtist4;
		private System.Windows.Forms.RadioButton rBRenameTitle4;
		private System.Windows.Forms.TextBox tBRenameYear;
		private System.Windows.Forms.TextBox tBRenameComment;
		private System.Windows.Forms.TextBox tBRenameTrack;
		private System.Windows.Forms.TextBox tBRenameAlbum;
		private System.Windows.Forms.TextBox tBRenameArtist;
		private System.Windows.Forms.TextBox tBRenameTitle;
		private System.Windows.Forms.TabPage tPListFiles;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tPMassRename;
		private System.Windows.Forms.Button bBrowse;
		private System.Windows.Forms.GroupBox gBDirectory;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.gBDirectory = new System.Windows.Forms.GroupBox();
			this.bBrowse = new System.Windows.Forms.Button();
			this.tBDirectory = new System.Windows.Forms.TextBox();
			this.tCManipulations = new System.Windows.Forms.TabControl();
			this.tPListFiles = new System.Windows.Forms.TabPage();
			this.bDeleteFilesFromLVFiles = new System.Windows.Forms.Button();
			this.lVFiles = new System.Windows.Forms.ListView();
			this.cHFiles = new System.Windows.Forms.ColumnHeader();
			this.tPMassRename = new System.Windows.Forms.TabPage();
			this.pGenreRename = new System.Windows.Forms.Panel();
			this.rBRenameGenre1 = new System.Windows.Forms.RadioButton();
			this.rBRenameGenre2 = new System.Windows.Forms.RadioButton();
			this.rBRenameGenre3 = new System.Windows.Forms.RadioButton();
			this.rBRenameGenre4 = new System.Windows.Forms.RadioButton();
			this.pCommentRename = new System.Windows.Forms.Panel();
			this.rBRenameComment1 = new System.Windows.Forms.RadioButton();
			this.rBRenameComment2 = new System.Windows.Forms.RadioButton();
			this.rBRenameComment3 = new System.Windows.Forms.RadioButton();
			this.rBRenameComment4 = new System.Windows.Forms.RadioButton();
			this.pYearRename = new System.Windows.Forms.Panel();
			this.rBRenameYear1 = new System.Windows.Forms.RadioButton();
			this.rBRenameYear2 = new System.Windows.Forms.RadioButton();
			this.rBRenameYear3 = new System.Windows.Forms.RadioButton();
			this.rBRenameYear4 = new System.Windows.Forms.RadioButton();
			this.pTrackRename = new System.Windows.Forms.Panel();
			this.rBRenameTrack1 = new System.Windows.Forms.RadioButton();
			this.rBRenameTrack2 = new System.Windows.Forms.RadioButton();
			this.rBRenameTrack3 = new System.Windows.Forms.RadioButton();
			this.rBRenameTrack4 = new System.Windows.Forms.RadioButton();
			this.pAlbumRename = new System.Windows.Forms.Panel();
			this.rBRenameAlbum1 = new System.Windows.Forms.RadioButton();
			this.rBRenameAlbum2 = new System.Windows.Forms.RadioButton();
			this.rBRenameAlbum3 = new System.Windows.Forms.RadioButton();
			this.rBRenameAlbum4 = new System.Windows.Forms.RadioButton();
			this.pArtistRename = new System.Windows.Forms.Panel();
			this.rBRenameArtist1 = new System.Windows.Forms.RadioButton();
			this.rBRenameArtist2 = new System.Windows.Forms.RadioButton();
			this.rBRenameArtist3 = new System.Windows.Forms.RadioButton();
			this.rBRenameArtist4 = new System.Windows.Forms.RadioButton();
			this.pTitleRename = new System.Windows.Forms.Panel();
			this.rBRenameTitle1 = new System.Windows.Forms.RadioButton();
			this.rBRenameTitle2 = new System.Windows.Forms.RadioButton();
			this.rBRenameTitle3 = new System.Windows.Forms.RadioButton();
			this.rBRenameTitle4 = new System.Windows.Forms.RadioButton();
			this.comboBRenameGenre = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tBRenameYear = new System.Windows.Forms.TextBox();
			this.cBRenameYear = new System.Windows.Forms.CheckBox();
			this.tBRenameComment = new System.Windows.Forms.TextBox();
			this.cBRenameGenre = new System.Windows.Forms.CheckBox();
			this.cBRenameComment = new System.Windows.Forms.CheckBox();
			this.cBRenameTrack = new System.Windows.Forms.CheckBox();
			this.cBRenameAlbum = new System.Windows.Forms.CheckBox();
			this.cBRenameArtist = new System.Windows.Forms.CheckBox();
			this.cBRenameTitle = new System.Windows.Forms.CheckBox();
			this.tBRenameTrack = new System.Windows.Forms.TextBox();
			this.tBRenameAlbum = new System.Windows.Forms.TextBox();
			this.tBRenameArtist = new System.Windows.Forms.TextBox();
			this.tBRenameTitle = new System.Windows.Forms.TextBox();
			this.tPCleanFiles = new System.Windows.Forms.TabPage();
			this.pTrackClean = new System.Windows.Forms.Panel();
			this.rBDeleteTrack4 = new System.Windows.Forms.RadioButton();
			this.rBDeleteTrack1 = new System.Windows.Forms.RadioButton();
			this.rBDeleteTrack3 = new System.Windows.Forms.RadioButton();
			this.rBDeleteTrack2 = new System.Windows.Forms.RadioButton();
			this.pArtistClean = new System.Windows.Forms.Panel();
			this.rBDeleteArtist4 = new System.Windows.Forms.RadioButton();
			this.rBDeleteArtist1 = new System.Windows.Forms.RadioButton();
			this.rBDeleteArtist3 = new System.Windows.Forms.RadioButton();
			this.rBDeleteArtist2 = new System.Windows.Forms.RadioButton();
			this.pGenreClean = new System.Windows.Forms.Panel();
			this.rBDeleteGenre2 = new System.Windows.Forms.RadioButton();
			this.rBDeleteGenre1 = new System.Windows.Forms.RadioButton();
			this.rBDeleteGenre3 = new System.Windows.Forms.RadioButton();
			this.rBDeleteGenre4 = new System.Windows.Forms.RadioButton();
			this.pCommentClean = new System.Windows.Forms.Panel();
			this.rBDeleteComment1 = new System.Windows.Forms.RadioButton();
			this.rBDeleteComment2 = new System.Windows.Forms.RadioButton();
			this.rBDeleteComment3 = new System.Windows.Forms.RadioButton();
			this.rBDeleteComment4 = new System.Windows.Forms.RadioButton();
			this.pYearClean = new System.Windows.Forms.Panel();
			this.rBDeleteYear1 = new System.Windows.Forms.RadioButton();
			this.rBDeleteYear2 = new System.Windows.Forms.RadioButton();
			this.rBDeleteYear3 = new System.Windows.Forms.RadioButton();
			this.rBDeleteYear4 = new System.Windows.Forms.RadioButton();
			this.pAlbumClean = new System.Windows.Forms.Panel();
			this.rBDeleteAlbum1 = new System.Windows.Forms.RadioButton();
			this.rBDeleteAlbum2 = new System.Windows.Forms.RadioButton();
			this.rBDeleteAlbum3 = new System.Windows.Forms.RadioButton();
			this.rBDeleteAlbum4 = new System.Windows.Forms.RadioButton();
			this.pTitleClean = new System.Windows.Forms.Panel();
			this.rBDeleteTitle4 = new System.Windows.Forms.RadioButton();
			this.rBDeleteTitle1 = new System.Windows.Forms.RadioButton();
			this.rBDeleteTitle2 = new System.Windows.Forms.RadioButton();
			this.rBDeleteTitle3 = new System.Windows.Forms.RadioButton();
			this.cBDeleteYear = new System.Windows.Forms.CheckBox();
			this.lVFilesToClean = new System.Windows.Forms.ListView();
			this.cHCleanFiles = new System.Windows.Forms.ColumnHeader();
			this.bCleanSelectedFiles = new System.Windows.Forms.Button();
			this.bCleanAllFiles = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.cBDeleteGenre = new System.Windows.Forms.CheckBox();
			this.cBDeleteComment = new System.Windows.Forms.CheckBox();
			this.cBDeleteTrack = new System.Windows.Forms.CheckBox();
			this.cBDeleteAlbum = new System.Windows.Forms.CheckBox();
			this.cBDeleteArtist = new System.Windows.Forms.CheckBox();
			this.cBDeleteTitle = new System.Windows.Forms.CheckBox();
			this.tPTagsDetails = new System.Windows.Forms.TabPage();
			this.gBDetailsTagV2 = new System.Windows.Forms.GroupBox();
			this.tBDetailsYearV2 = new System.Windows.Forms.TextBox();
			this.tbDetailsCommentV2 = new System.Windows.Forms.TextBox();
			this.tBDetailsTrackV2 = new System.Windows.Forms.TextBox();
			this.tBDetailsAlbumV2 = new System.Windows.Forms.TextBox();
			this.tBDetailsArtistV2 = new System.Windows.Forms.TextBox();
			this.tBDetailsTitleV2 = new System.Windows.Forms.TextBox();
			this.cBDetailsGenreV1 = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.gBDetailsTagV1 = new System.Windows.Forms.GroupBox();
			this.tBDetailsYearV1 = new System.Windows.Forms.TextBox();
			this.tbDetailsCommentV1 = new System.Windows.Forms.TextBox();
			this.tBDetailsTrackV1 = new System.Windows.Forms.TextBox();
			this.tBDetailsAlbumV1 = new System.Windows.Forms.TextBox();
			this.tBDetailsArtistV1 = new System.Windows.Forms.TextBox();
			this.tBDetailsTitleV1 = new System.Windows.Forms.TextBox();
			this.cBDetailsGenreV2 = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lVFilesDetails = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.fBDWorkingDirectory = new System.Windows.Forms.FolderBrowserDialog();
			this.mSMainform = new System.Windows.Forms.MenuStrip();
			this.tSMIAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.gBDirectory.SuspendLayout();
			this.tCManipulations.SuspendLayout();
			this.tPListFiles.SuspendLayout();
			this.tPMassRename.SuspendLayout();
			this.pGenreRename.SuspendLayout();
			this.pCommentRename.SuspendLayout();
			this.pYearRename.SuspendLayout();
			this.pTrackRename.SuspendLayout();
			this.pAlbumRename.SuspendLayout();
			this.pArtistRename.SuspendLayout();
			this.pTitleRename.SuspendLayout();
			this.tPCleanFiles.SuspendLayout();
			this.pTrackClean.SuspendLayout();
			this.pArtistClean.SuspendLayout();
			this.pGenreClean.SuspendLayout();
			this.pCommentClean.SuspendLayout();
			this.pYearClean.SuspendLayout();
			this.pAlbumClean.SuspendLayout();
			this.pTitleClean.SuspendLayout();
			this.tPTagsDetails.SuspendLayout();
			this.gBDetailsTagV2.SuspendLayout();
			this.gBDetailsTagV1.SuspendLayout();
			this.mSMainform.SuspendLayout();
			this.SuspendLayout();
			// 
			// gBDirectory
			// 
			this.gBDirectory.Controls.Add(this.bBrowse);
			this.gBDirectory.Controls.Add(this.tBDirectory);
			this.gBDirectory.Location = new System.Drawing.Point(8, 32);
			this.gBDirectory.Name = "gBDirectory";
			this.gBDirectory.Size = new System.Drawing.Size(712, 56);
			this.gBDirectory.TabIndex = 1;
			this.gBDirectory.TabStop = false;
			this.gBDirectory.Text = "Last working directory";
			// 
			// bBrowse
			// 
			this.bBrowse.Location = new System.Drawing.Point(624, 24);
			this.bBrowse.Name = "bBrowse";
			this.bBrowse.Size = new System.Drawing.Size(75, 23);
			this.bBrowse.TabIndex = 1;
			this.bBrowse.Text = "Browse";
			this.bBrowse.UseVisualStyleBackColor = true;
			this.bBrowse.Click += new System.EventHandler(this.BBrowseClick);
			// 
			// tBDirectory
			// 
			this.tBDirectory.Location = new System.Drawing.Point(16, 24);
			this.tBDirectory.Name = "tBDirectory";
			this.tBDirectory.Size = new System.Drawing.Size(600, 20);
			this.tBDirectory.TabIndex = 0;
			// 
			// tCManipulations
			// 
			this.tCManipulations.Controls.Add(this.tPListFiles);
			this.tCManipulations.Controls.Add(this.tPMassRename);
			this.tCManipulations.Controls.Add(this.tPCleanFiles);
			this.tCManipulations.Controls.Add(this.tPTagsDetails);
			this.tCManipulations.Location = new System.Drawing.Point(8, 96);
			this.tCManipulations.Name = "tCManipulations";
			this.tCManipulations.SelectedIndex = 0;
			this.tCManipulations.Size = new System.Drawing.Size(720, 248);
			this.tCManipulations.TabIndex = 2;
			// 
			// tPListFiles
			// 
			this.tPListFiles.Controls.Add(this.bDeleteFilesFromLVFiles);
			this.tPListFiles.Controls.Add(this.lVFiles);
			this.tPListFiles.Location = new System.Drawing.Point(4, 22);
			this.tPListFiles.Name = "tPListFiles";
			this.tPListFiles.Padding = new System.Windows.Forms.Padding(3);
			this.tPListFiles.Size = new System.Drawing.Size(712, 222);
			this.tPListFiles.TabIndex = 1;
			this.tPListFiles.Text = "List of the files in directory";
			this.tPListFiles.UseVisualStyleBackColor = true;
			// 
			// bDeleteFilesFromLVFiles
			// 
			this.bDeleteFilesFromLVFiles.Location = new System.Drawing.Point(248, 192);
			this.bDeleteFilesFromLVFiles.Name = "bDeleteFilesFromLVFiles";
			this.bDeleteFilesFromLVFiles.Size = new System.Drawing.Size(216, 23);
			this.bDeleteFilesFromLVFiles.TabIndex = 1;
			this.bDeleteFilesFromLVFiles.Text = "Effacer les fichiers sélectionnés de la liste";
			this.bDeleteFilesFromLVFiles.UseVisualStyleBackColor = true;
			// 
			// lVFiles
			// 
			this.lVFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.cHFiles});
			this.lVFiles.HideSelection = false;
			this.lVFiles.Location = new System.Drawing.Point(8, 8);
			this.lVFiles.Name = "lVFiles";
			this.lVFiles.Size = new System.Drawing.Size(696, 176);
			this.lVFiles.TabIndex = 0;
			this.lVFiles.UseCompatibleStateImageBehavior = false;
			this.lVFiles.View = System.Windows.Forms.View.Details;
			this.lVFiles.SelectedIndexChanged += new System.EventHandler(this.LVFilesSelectedIndexChanged);
			// 
			// cHFiles
			// 
			this.cHFiles.Text = "Nom de fichiers";
			this.cHFiles.Width = 673;
			// 
			// tPMassRename
			// 
			this.tPMassRename.Controls.Add(this.pGenreRename);
			this.tPMassRename.Controls.Add(this.pCommentRename);
			this.tPMassRename.Controls.Add(this.pYearRename);
			this.tPMassRename.Controls.Add(this.pTrackRename);
			this.tPMassRename.Controls.Add(this.pAlbumRename);
			this.tPMassRename.Controls.Add(this.pArtistRename);
			this.tPMassRename.Controls.Add(this.pTitleRename);
			this.tPMassRename.Controls.Add(this.comboBRenameGenre);
			this.tPMassRename.Controls.Add(this.label1);
			this.tPMassRename.Controls.Add(this.tBRenameYear);
			this.tPMassRename.Controls.Add(this.cBRenameYear);
			this.tPMassRename.Controls.Add(this.tBRenameComment);
			this.tPMassRename.Controls.Add(this.cBRenameGenre);
			this.tPMassRename.Controls.Add(this.cBRenameComment);
			this.tPMassRename.Controls.Add(this.cBRenameTrack);
			this.tPMassRename.Controls.Add(this.cBRenameAlbum);
			this.tPMassRename.Controls.Add(this.cBRenameArtist);
			this.tPMassRename.Controls.Add(this.cBRenameTitle);
			this.tPMassRename.Controls.Add(this.tBRenameTrack);
			this.tPMassRename.Controls.Add(this.tBRenameAlbum);
			this.tPMassRename.Controls.Add(this.tBRenameArtist);
			this.tPMassRename.Controls.Add(this.tBRenameTitle);
			this.tPMassRename.Location = new System.Drawing.Point(4, 22);
			this.tPMassRename.Name = "tPMassRename";
			this.tPMassRename.Padding = new System.Windows.Forms.Padding(3);
			this.tPMassRename.Size = new System.Drawing.Size(712, 222);
			this.tPMassRename.TabIndex = 0;
			this.tPMassRename.Text = "Rename mass of files";
			this.tPMassRename.UseVisualStyleBackColor = true;
			// 
			// pGenreRename
			// 
			this.pGenreRename.Controls.Add(this.rBRenameGenre1);
			this.pGenreRename.Controls.Add(this.rBRenameGenre2);
			this.pGenreRename.Controls.Add(this.rBRenameGenre3);
			this.pGenreRename.Controls.Add(this.rBRenameGenre4);
			this.pGenreRename.Enabled = false;
			this.pGenreRename.Location = new System.Drawing.Point(440, 176);
			this.pGenreRename.Name = "pGenreRename";
			this.pGenreRename.Size = new System.Drawing.Size(120, 24);
			this.pGenreRename.TabIndex = 51;
			// 
			// rBRenameGenre1
			// 
			this.rBRenameGenre1.Location = new System.Drawing.Point(0, 0);
			this.rBRenameGenre1.Name = "rBRenameGenre1";
			this.rBRenameGenre1.Size = new System.Drawing.Size(16, 24);
			this.rBRenameGenre1.TabIndex = 30;
			this.rBRenameGenre1.UseVisualStyleBackColor = true;
			// 
			// rBRenameGenre2
			// 
			this.rBRenameGenre2.Location = new System.Drawing.Point(32, 0);
			this.rBRenameGenre2.Name = "rBRenameGenre2";
			this.rBRenameGenre2.Size = new System.Drawing.Size(16, 24);
			this.rBRenameGenre2.TabIndex = 31;
			this.rBRenameGenre2.UseVisualStyleBackColor = true;
			// 
			// rBRenameGenre3
			// 
			this.rBRenameGenre3.Location = new System.Drawing.Point(64, 0);
			this.rBRenameGenre3.Name = "rBRenameGenre3";
			this.rBRenameGenre3.Size = new System.Drawing.Size(16, 24);
			this.rBRenameGenre3.TabIndex = 32;
			this.rBRenameGenre3.UseVisualStyleBackColor = true;
			// 
			// rBRenameGenre4
			// 
			this.rBRenameGenre4.Location = new System.Drawing.Point(104, 0);
			this.rBRenameGenre4.Name = "rBRenameGenre4";
			this.rBRenameGenre4.Size = new System.Drawing.Size(16, 24);
			this.rBRenameGenre4.TabIndex = 39;
			this.rBRenameGenre4.UseVisualStyleBackColor = true;
			// 
			// pCommentRename
			// 
			this.pCommentRename.Controls.Add(this.rBRenameComment1);
			this.pCommentRename.Controls.Add(this.rBRenameComment2);
			this.pCommentRename.Controls.Add(this.rBRenameComment3);
			this.pCommentRename.Controls.Add(this.rBRenameComment4);
			this.pCommentRename.Enabled = false;
			this.pCommentRename.Location = new System.Drawing.Point(440, 152);
			this.pCommentRename.Name = "pCommentRename";
			this.pCommentRename.Size = new System.Drawing.Size(120, 24);
			this.pCommentRename.TabIndex = 50;
			// 
			// rBRenameComment1
			// 
			this.rBRenameComment1.Location = new System.Drawing.Point(0, 0);
			this.rBRenameComment1.Name = "rBRenameComment1";
			this.rBRenameComment1.Size = new System.Drawing.Size(16, 24);
			this.rBRenameComment1.TabIndex = 27;
			this.rBRenameComment1.UseVisualStyleBackColor = true;
			// 
			// rBRenameComment2
			// 
			this.rBRenameComment2.Location = new System.Drawing.Point(32, 0);
			this.rBRenameComment2.Name = "rBRenameComment2";
			this.rBRenameComment2.Size = new System.Drawing.Size(16, 24);
			this.rBRenameComment2.TabIndex = 28;
			this.rBRenameComment2.UseVisualStyleBackColor = true;
			// 
			// rBRenameComment3
			// 
			this.rBRenameComment3.Location = new System.Drawing.Point(64, 0);
			this.rBRenameComment3.Name = "rBRenameComment3";
			this.rBRenameComment3.Size = new System.Drawing.Size(16, 24);
			this.rBRenameComment3.TabIndex = 29;
			this.rBRenameComment3.UseVisualStyleBackColor = true;
			// 
			// rBRenameComment4
			// 
			this.rBRenameComment4.Location = new System.Drawing.Point(104, 0);
			this.rBRenameComment4.Name = "rBRenameComment4";
			this.rBRenameComment4.Size = new System.Drawing.Size(16, 24);
			this.rBRenameComment4.TabIndex = 38;
			this.rBRenameComment4.UseVisualStyleBackColor = true;
			// 
			// pYearRename
			// 
			this.pYearRename.Controls.Add(this.rBRenameYear1);
			this.pYearRename.Controls.Add(this.rBRenameYear2);
			this.pYearRename.Controls.Add(this.rBRenameYear3);
			this.pYearRename.Controls.Add(this.rBRenameYear4);
			this.pYearRename.Enabled = false;
			this.pYearRename.Location = new System.Drawing.Point(440, 128);
			this.pYearRename.Name = "pYearRename";
			this.pYearRename.Size = new System.Drawing.Size(120, 24);
			this.pYearRename.TabIndex = 49;
			// 
			// rBRenameYear1
			// 
			this.rBRenameYear1.Location = new System.Drawing.Point(0, 0);
			this.rBRenameYear1.Name = "rBRenameYear1";
			this.rBRenameYear1.Size = new System.Drawing.Size(16, 24);
			this.rBRenameYear1.TabIndex = 40;
			this.rBRenameYear1.UseVisualStyleBackColor = true;
			// 
			// rBRenameYear2
			// 
			this.rBRenameYear2.Location = new System.Drawing.Point(32, 0);
			this.rBRenameYear2.Name = "rBRenameYear2";
			this.rBRenameYear2.Size = new System.Drawing.Size(16, 24);
			this.rBRenameYear2.TabIndex = 41;
			this.rBRenameYear2.UseVisualStyleBackColor = true;
			// 
			// rBRenameYear3
			// 
			this.rBRenameYear3.Location = new System.Drawing.Point(64, 0);
			this.rBRenameYear3.Name = "rBRenameYear3";
			this.rBRenameYear3.Size = new System.Drawing.Size(16, 24);
			this.rBRenameYear3.TabIndex = 42;
			this.rBRenameYear3.UseVisualStyleBackColor = true;
			// 
			// rBRenameYear4
			// 
			this.rBRenameYear4.Location = new System.Drawing.Point(104, 0);
			this.rBRenameYear4.Name = "rBRenameYear4";
			this.rBRenameYear4.Size = new System.Drawing.Size(16, 24);
			this.rBRenameYear4.TabIndex = 43;
			this.rBRenameYear4.UseVisualStyleBackColor = true;
			// 
			// pTrackRename
			// 
			this.pTrackRename.Controls.Add(this.rBRenameTrack1);
			this.pTrackRename.Controls.Add(this.rBRenameTrack2);
			this.pTrackRename.Controls.Add(this.rBRenameTrack3);
			this.pTrackRename.Controls.Add(this.rBRenameTrack4);
			this.pTrackRename.Enabled = false;
			this.pTrackRename.Location = new System.Drawing.Point(440, 104);
			this.pTrackRename.Name = "pTrackRename";
			this.pTrackRename.Size = new System.Drawing.Size(120, 24);
			this.pTrackRename.TabIndex = 48;
			// 
			// rBRenameTrack1
			// 
			this.rBRenameTrack1.Location = new System.Drawing.Point(0, 0);
			this.rBRenameTrack1.Name = "rBRenameTrack1";
			this.rBRenameTrack1.Size = new System.Drawing.Size(16, 24);
			this.rBRenameTrack1.TabIndex = 24;
			this.rBRenameTrack1.UseVisualStyleBackColor = true;
			// 
			// rBRenameTrack2
			// 
			this.rBRenameTrack2.Location = new System.Drawing.Point(32, 0);
			this.rBRenameTrack2.Name = "rBRenameTrack2";
			this.rBRenameTrack2.Size = new System.Drawing.Size(16, 24);
			this.rBRenameTrack2.TabIndex = 25;
			this.rBRenameTrack2.UseVisualStyleBackColor = true;
			// 
			// rBRenameTrack3
			// 
			this.rBRenameTrack3.Location = new System.Drawing.Point(64, 0);
			this.rBRenameTrack3.Name = "rBRenameTrack3";
			this.rBRenameTrack3.Size = new System.Drawing.Size(16, 24);
			this.rBRenameTrack3.TabIndex = 26;
			this.rBRenameTrack3.UseVisualStyleBackColor = true;
			// 
			// rBRenameTrack4
			// 
			this.rBRenameTrack4.Location = new System.Drawing.Point(104, 0);
			this.rBRenameTrack4.Name = "rBRenameTrack4";
			this.rBRenameTrack4.Size = new System.Drawing.Size(16, 24);
			this.rBRenameTrack4.TabIndex = 37;
			this.rBRenameTrack4.UseVisualStyleBackColor = true;
			// 
			// pAlbumRename
			// 
			this.pAlbumRename.Controls.Add(this.rBRenameAlbum1);
			this.pAlbumRename.Controls.Add(this.rBRenameAlbum2);
			this.pAlbumRename.Controls.Add(this.rBRenameAlbum3);
			this.pAlbumRename.Controls.Add(this.rBRenameAlbum4);
			this.pAlbumRename.Enabled = false;
			this.pAlbumRename.Location = new System.Drawing.Point(440, 80);
			this.pAlbumRename.Name = "pAlbumRename";
			this.pAlbumRename.Size = new System.Drawing.Size(120, 24);
			this.pAlbumRename.TabIndex = 47;
			// 
			// rBRenameAlbum1
			// 
			this.rBRenameAlbum1.Location = new System.Drawing.Point(0, 0);
			this.rBRenameAlbum1.Name = "rBRenameAlbum1";
			this.rBRenameAlbum1.Size = new System.Drawing.Size(16, 24);
			this.rBRenameAlbum1.TabIndex = 21;
			this.rBRenameAlbum1.UseVisualStyleBackColor = true;
			// 
			// rBRenameAlbum2
			// 
			this.rBRenameAlbum2.Location = new System.Drawing.Point(32, 0);
			this.rBRenameAlbum2.Name = "rBRenameAlbum2";
			this.rBRenameAlbum2.Size = new System.Drawing.Size(16, 24);
			this.rBRenameAlbum2.TabIndex = 22;
			this.rBRenameAlbum2.UseVisualStyleBackColor = true;
			// 
			// rBRenameAlbum3
			// 
			this.rBRenameAlbum3.Location = new System.Drawing.Point(64, 0);
			this.rBRenameAlbum3.Name = "rBRenameAlbum3";
			this.rBRenameAlbum3.Size = new System.Drawing.Size(16, 24);
			this.rBRenameAlbum3.TabIndex = 23;
			this.rBRenameAlbum3.UseVisualStyleBackColor = true;
			// 
			// rBRenameAlbum4
			// 
			this.rBRenameAlbum4.Location = new System.Drawing.Point(104, 0);
			this.rBRenameAlbum4.Name = "rBRenameAlbum4";
			this.rBRenameAlbum4.Size = new System.Drawing.Size(16, 24);
			this.rBRenameAlbum4.TabIndex = 36;
			this.rBRenameAlbum4.UseVisualStyleBackColor = true;
			// 
			// pArtistRename
			// 
			this.pArtistRename.Controls.Add(this.rBRenameArtist1);
			this.pArtistRename.Controls.Add(this.rBRenameArtist2);
			this.pArtistRename.Controls.Add(this.rBRenameArtist3);
			this.pArtistRename.Controls.Add(this.rBRenameArtist4);
			this.pArtistRename.Enabled = false;
			this.pArtistRename.Location = new System.Drawing.Point(440, 56);
			this.pArtistRename.Name = "pArtistRename";
			this.pArtistRename.Size = new System.Drawing.Size(120, 24);
			this.pArtistRename.TabIndex = 46;
			// 
			// rBRenameArtist1
			// 
			this.rBRenameArtist1.Location = new System.Drawing.Point(0, 0);
			this.rBRenameArtist1.Name = "rBRenameArtist1";
			this.rBRenameArtist1.Size = new System.Drawing.Size(16, 24);
			this.rBRenameArtist1.TabIndex = 18;
			this.rBRenameArtist1.UseVisualStyleBackColor = true;
			// 
			// rBRenameArtist2
			// 
			this.rBRenameArtist2.Location = new System.Drawing.Point(32, 0);
			this.rBRenameArtist2.Name = "rBRenameArtist2";
			this.rBRenameArtist2.Size = new System.Drawing.Size(16, 24);
			this.rBRenameArtist2.TabIndex = 19;
			this.rBRenameArtist2.UseVisualStyleBackColor = true;
			// 
			// rBRenameArtist3
			// 
			this.rBRenameArtist3.Location = new System.Drawing.Point(64, 0);
			this.rBRenameArtist3.Name = "rBRenameArtist3";
			this.rBRenameArtist3.Size = new System.Drawing.Size(16, 24);
			this.rBRenameArtist3.TabIndex = 20;
			this.rBRenameArtist3.UseVisualStyleBackColor = true;
			// 
			// rBRenameArtist4
			// 
			this.rBRenameArtist4.Location = new System.Drawing.Point(104, 0);
			this.rBRenameArtist4.Name = "rBRenameArtist4";
			this.rBRenameArtist4.Size = new System.Drawing.Size(16, 24);
			this.rBRenameArtist4.TabIndex = 35;
			this.rBRenameArtist4.UseVisualStyleBackColor = true;
			// 
			// pTitleRename
			// 
			this.pTitleRename.Controls.Add(this.rBRenameTitle1);
			this.pTitleRename.Controls.Add(this.rBRenameTitle2);
			this.pTitleRename.Controls.Add(this.rBRenameTitle3);
			this.pTitleRename.Controls.Add(this.rBRenameTitle4);
			this.pTitleRename.Enabled = false;
			this.pTitleRename.Location = new System.Drawing.Point(440, 32);
			this.pTitleRename.Name = "pTitleRename";
			this.pTitleRename.Size = new System.Drawing.Size(120, 24);
			this.pTitleRename.TabIndex = 44;
			// 
			// rBRenameTitle1
			// 
			this.rBRenameTitle1.Location = new System.Drawing.Point(0, 0);
			this.rBRenameTitle1.Name = "rBRenameTitle1";
			this.rBRenameTitle1.Size = new System.Drawing.Size(16, 24);
			this.rBRenameTitle1.TabIndex = 15;
			this.rBRenameTitle1.UseVisualStyleBackColor = true;
			// 
			// rBRenameTitle2
			// 
			this.rBRenameTitle2.Location = new System.Drawing.Point(32, 0);
			this.rBRenameTitle2.Name = "rBRenameTitle2";
			this.rBRenameTitle2.Size = new System.Drawing.Size(16, 24);
			this.rBRenameTitle2.TabIndex = 16;
			this.rBRenameTitle2.UseVisualStyleBackColor = true;
			// 
			// rBRenameTitle3
			// 
			this.rBRenameTitle3.Location = new System.Drawing.Point(64, 0);
			this.rBRenameTitle3.Name = "rBRenameTitle3";
			this.rBRenameTitle3.Size = new System.Drawing.Size(16, 24);
			this.rBRenameTitle3.TabIndex = 17;
			this.rBRenameTitle3.UseVisualStyleBackColor = true;
			// 
			// rBRenameTitle4
			// 
			this.rBRenameTitle4.Location = new System.Drawing.Point(104, 0);
			this.rBRenameTitle4.Name = "rBRenameTitle4";
			this.rBRenameTitle4.Size = new System.Drawing.Size(16, 24);
			this.rBRenameTitle4.TabIndex = 34;
			this.rBRenameTitle4.UseVisualStyleBackColor = true;
			// 
			// comboBRenameGenre
			// 
			this.comboBRenameGenre.Enabled = false;
			this.comboBRenameGenre.FormattingEnabled = true;
			this.comboBRenameGenre.Location = new System.Drawing.Point(224, 176);
			this.comboBRenameGenre.Name = "comboBRenameGenre";
			this.comboBRenameGenre.Size = new System.Drawing.Size(208, 21);
			this.comboBRenameGenre.TabIndex = 33;
			this.comboBRenameGenre.Text = "Selectionnez un genre ...";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(432, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 23);
			this.label1.TabIndex = 14;
			this.label1.Text = "None    V1     V2    V1  and V2";
			// 
			// tBRenameYear
			// 
			this.tBRenameYear.Enabled = false;
			this.tBRenameYear.Location = new System.Drawing.Point(224, 128);
			this.tBRenameYear.Name = "tBRenameYear";
			this.tBRenameYear.Size = new System.Drawing.Size(40, 20);
			this.tBRenameYear.TabIndex = 13;
			// 
			// cBRenameYear
			// 
			this.cBRenameYear.Location = new System.Drawing.Point(136, 128);
			this.cBRenameYear.Name = "cBRenameYear";
			this.cBRenameYear.Size = new System.Drawing.Size(64, 24);
			this.cBRenameYear.TabIndex = 12;
			this.cBRenameYear.Text = "Année";
			this.cBRenameYear.UseVisualStyleBackColor = true;
			this.cBRenameYear.CheckedChanged += new System.EventHandler(this.CBRenameYearCheckedChanged);
			// 
			// tBRenameComment
			// 
			this.tBRenameComment.Enabled = false;
			this.tBRenameComment.Location = new System.Drawing.Point(224, 152);
			this.tBRenameComment.Name = "tBRenameComment";
			this.tBRenameComment.Size = new System.Drawing.Size(208, 20);
			this.tBRenameComment.TabIndex = 10;
			// 
			// cBRenameGenre
			// 
			this.cBRenameGenre.Location = new System.Drawing.Point(136, 176);
			this.cBRenameGenre.Name = "cBRenameGenre";
			this.cBRenameGenre.Size = new System.Drawing.Size(72, 24);
			this.cBRenameGenre.TabIndex = 9;
			this.cBRenameGenre.Text = "Genre";
			this.cBRenameGenre.UseVisualStyleBackColor = true;
			this.cBRenameGenre.CheckedChanged += new System.EventHandler(this.CBRenameGenreCheckedChanged);
			// 
			// cBRenameComment
			// 
			this.cBRenameComment.Location = new System.Drawing.Point(136, 152);
			this.cBRenameComment.Name = "cBRenameComment";
			this.cBRenameComment.Size = new System.Drawing.Size(88, 24);
			this.cBRenameComment.TabIndex = 8;
			this.cBRenameComment.Text = "Commentaire";
			this.cBRenameComment.UseVisualStyleBackColor = true;
			this.cBRenameComment.CheckedChanged += new System.EventHandler(this.CBRenameCommentCheckedChanged);
			// 
			// cBRenameTrack
			// 
			this.cBRenameTrack.Location = new System.Drawing.Point(136, 104);
			this.cBRenameTrack.Name = "cBRenameTrack";
			this.cBRenameTrack.Size = new System.Drawing.Size(72, 24);
			this.cBRenameTrack.TabIndex = 7;
			this.cBRenameTrack.Text = "Piste";
			this.cBRenameTrack.UseVisualStyleBackColor = true;
			this.cBRenameTrack.CheckedChanged += new System.EventHandler(this.CBRenameTrackCheckedChanged);
			// 
			// cBRenameAlbum
			// 
			this.cBRenameAlbum.Location = new System.Drawing.Point(136, 80);
			this.cBRenameAlbum.Name = "cBRenameAlbum";
			this.cBRenameAlbum.Size = new System.Drawing.Size(72, 24);
			this.cBRenameAlbum.TabIndex = 6;
			this.cBRenameAlbum.Text = "Album";
			this.cBRenameAlbum.UseVisualStyleBackColor = true;
			this.cBRenameAlbum.CheckedChanged += new System.EventHandler(this.CBRenameAlbumCheckedChanged);
			// 
			// cBRenameArtist
			// 
			this.cBRenameArtist.Location = new System.Drawing.Point(136, 56);
			this.cBRenameArtist.Name = "cBRenameArtist";
			this.cBRenameArtist.Size = new System.Drawing.Size(72, 24);
			this.cBRenameArtist.TabIndex = 5;
			this.cBRenameArtist.Text = "Artiste";
			this.cBRenameArtist.UseVisualStyleBackColor = true;
			this.cBRenameArtist.CheckedChanged += new System.EventHandler(this.CBRenameArtistCheckedChanged);
			// 
			// cBRenameTitle
			// 
			this.cBRenameTitle.Location = new System.Drawing.Point(136, 32);
			this.cBRenameTitle.Name = "cBRenameTitle";
			this.cBRenameTitle.Size = new System.Drawing.Size(72, 24);
			this.cBRenameTitle.TabIndex = 4;
			this.cBRenameTitle.Text = "Titre";
			this.cBRenameTitle.UseVisualStyleBackColor = true;
			this.cBRenameTitle.CheckedChanged += new System.EventHandler(this.CBRenameTitleCheckedChanged);
			// 
			// tBRenameTrack
			// 
			this.tBRenameTrack.Enabled = false;
			this.tBRenameTrack.Location = new System.Drawing.Point(224, 104);
			this.tBRenameTrack.Name = "tBRenameTrack";
			this.tBRenameTrack.Size = new System.Drawing.Size(40, 20);
			this.tBRenameTrack.TabIndex = 3;
			// 
			// tBRenameAlbum
			// 
			this.tBRenameAlbum.Enabled = false;
			this.tBRenameAlbum.Location = new System.Drawing.Point(224, 80);
			this.tBRenameAlbum.Name = "tBRenameAlbum";
			this.tBRenameAlbum.Size = new System.Drawing.Size(208, 20);
			this.tBRenameAlbum.TabIndex = 2;
			// 
			// tBRenameArtist
			// 
			this.tBRenameArtist.Enabled = false;
			this.tBRenameArtist.Location = new System.Drawing.Point(224, 56);
			this.tBRenameArtist.Name = "tBRenameArtist";
			this.tBRenameArtist.Size = new System.Drawing.Size(208, 20);
			this.tBRenameArtist.TabIndex = 1;
			// 
			// tBRenameTitle
			// 
			this.tBRenameTitle.Enabled = false;
			this.tBRenameTitle.Location = new System.Drawing.Point(224, 32);
			this.tBRenameTitle.Name = "tBRenameTitle";
			this.tBRenameTitle.Size = new System.Drawing.Size(208, 20);
			this.tBRenameTitle.TabIndex = 0;
			// 
			// tPCleanFiles
			// 
			this.tPCleanFiles.Controls.Add(this.pTrackClean);
			this.tPCleanFiles.Controls.Add(this.pArtistClean);
			this.tPCleanFiles.Controls.Add(this.pGenreClean);
			this.tPCleanFiles.Controls.Add(this.pCommentClean);
			this.tPCleanFiles.Controls.Add(this.pYearClean);
			this.tPCleanFiles.Controls.Add(this.pAlbumClean);
			this.tPCleanFiles.Controls.Add(this.pTitleClean);
			this.tPCleanFiles.Controls.Add(this.cBDeleteYear);
			this.tPCleanFiles.Controls.Add(this.lVFilesToClean);
			this.tPCleanFiles.Controls.Add(this.bCleanSelectedFiles);
			this.tPCleanFiles.Controls.Add(this.bCleanAllFiles);
			this.tPCleanFiles.Controls.Add(this.label2);
			this.tPCleanFiles.Controls.Add(this.cBDeleteGenre);
			this.tPCleanFiles.Controls.Add(this.cBDeleteComment);
			this.tPCleanFiles.Controls.Add(this.cBDeleteTrack);
			this.tPCleanFiles.Controls.Add(this.cBDeleteAlbum);
			this.tPCleanFiles.Controls.Add(this.cBDeleteArtist);
			this.tPCleanFiles.Controls.Add(this.cBDeleteTitle);
			this.tPCleanFiles.Location = new System.Drawing.Point(4, 22);
			this.tPCleanFiles.Name = "tPCleanFiles";
			this.tPCleanFiles.Size = new System.Drawing.Size(712, 222);
			this.tPCleanFiles.TabIndex = 2;
			this.tPCleanFiles.Text = "Clean files";
			this.tPCleanFiles.UseVisualStyleBackColor = true;
			// 
			// pTrackClean
			// 
			this.pTrackClean.Controls.Add(this.rBDeleteTrack4);
			this.pTrackClean.Controls.Add(this.rBDeleteTrack1);
			this.pTrackClean.Controls.Add(this.rBDeleteTrack3);
			this.pTrackClean.Controls.Add(this.rBDeleteTrack2);
			this.pTrackClean.Enabled = false;
			this.pTrackClean.Location = new System.Drawing.Point(96, 104);
			this.pTrackClean.Name = "pTrackClean";
			this.pTrackClean.Size = new System.Drawing.Size(120, 24);
			this.pTrackClean.TabIndex = 93;
			// 
			// rBDeleteTrack4
			// 
			this.rBDeleteTrack4.Location = new System.Drawing.Point(104, 0);
			this.rBDeleteTrack4.Name = "rBDeleteTrack4";
			this.rBDeleteTrack4.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteTrack4.TabIndex = 99;
			this.rBDeleteTrack4.UseVisualStyleBackColor = true;
			// 
			// rBDeleteTrack1
			// 
			this.rBDeleteTrack1.Location = new System.Drawing.Point(0, 0);
			this.rBDeleteTrack1.Name = "rBDeleteTrack1";
			this.rBDeleteTrack1.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteTrack1.TabIndex = 96;
			this.rBDeleteTrack1.UseVisualStyleBackColor = true;
			// 
			// rBDeleteTrack3
			// 
			this.rBDeleteTrack3.Location = new System.Drawing.Point(64, 0);
			this.rBDeleteTrack3.Name = "rBDeleteTrack3";
			this.rBDeleteTrack3.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteTrack3.TabIndex = 98;
			this.rBDeleteTrack3.UseVisualStyleBackColor = true;
			// 
			// rBDeleteTrack2
			// 
			this.rBDeleteTrack2.Location = new System.Drawing.Point(32, 0);
			this.rBDeleteTrack2.Name = "rBDeleteTrack2";
			this.rBDeleteTrack2.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteTrack2.TabIndex = 97;
			this.rBDeleteTrack2.UseVisualStyleBackColor = true;
			// 
			// pArtistClean
			// 
			this.pArtistClean.Controls.Add(this.rBDeleteArtist4);
			this.pArtistClean.Controls.Add(this.rBDeleteArtist1);
			this.pArtistClean.Controls.Add(this.rBDeleteArtist3);
			this.pArtistClean.Controls.Add(this.rBDeleteArtist2);
			this.pArtistClean.Enabled = false;
			this.pArtistClean.Location = new System.Drawing.Point(96, 56);
			this.pArtistClean.Name = "pArtistClean";
			this.pArtistClean.Size = new System.Drawing.Size(120, 24);
			this.pArtistClean.TabIndex = 92;
			// 
			// rBDeleteArtist4
			// 
			this.rBDeleteArtist4.Location = new System.Drawing.Point(104, 0);
			this.rBDeleteArtist4.Name = "rBDeleteArtist4";
			this.rBDeleteArtist4.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteArtist4.TabIndex = 99;
			this.rBDeleteArtist4.UseVisualStyleBackColor = true;
			// 
			// rBDeleteArtist1
			// 
			this.rBDeleteArtist1.Location = new System.Drawing.Point(0, 0);
			this.rBDeleteArtist1.Name = "rBDeleteArtist1";
			this.rBDeleteArtist1.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteArtist1.TabIndex = 96;
			this.rBDeleteArtist1.UseVisualStyleBackColor = true;
			// 
			// rBDeleteArtist3
			// 
			this.rBDeleteArtist3.Location = new System.Drawing.Point(64, 0);
			this.rBDeleteArtist3.Name = "rBDeleteArtist3";
			this.rBDeleteArtist3.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteArtist3.TabIndex = 98;
			this.rBDeleteArtist3.UseVisualStyleBackColor = true;
			// 
			// rBDeleteArtist2
			// 
			this.rBDeleteArtist2.Location = new System.Drawing.Point(32, 0);
			this.rBDeleteArtist2.Name = "rBDeleteArtist2";
			this.rBDeleteArtist2.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteArtist2.TabIndex = 97;
			this.rBDeleteArtist2.UseVisualStyleBackColor = true;
			// 
			// pGenreClean
			// 
			this.pGenreClean.Controls.Add(this.rBDeleteGenre2);
			this.pGenreClean.Controls.Add(this.rBDeleteGenre1);
			this.pGenreClean.Controls.Add(this.rBDeleteGenre3);
			this.pGenreClean.Controls.Add(this.rBDeleteGenre4);
			this.pGenreClean.Enabled = false;
			this.pGenreClean.Location = new System.Drawing.Point(96, 176);
			this.pGenreClean.Name = "pGenreClean";
			this.pGenreClean.Size = new System.Drawing.Size(120, 24);
			this.pGenreClean.TabIndex = 95;
			// 
			// rBDeleteGenre2
			// 
			this.rBDeleteGenre2.Location = new System.Drawing.Point(32, 0);
			this.rBDeleteGenre2.Name = "rBDeleteGenre2";
			this.rBDeleteGenre2.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteGenre2.TabIndex = 70;
			this.rBDeleteGenre2.UseVisualStyleBackColor = true;
			// 
			// rBDeleteGenre1
			// 
			this.rBDeleteGenre1.Location = new System.Drawing.Point(0, 0);
			this.rBDeleteGenre1.Name = "rBDeleteGenre1";
			this.rBDeleteGenre1.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteGenre1.TabIndex = 69;
			this.rBDeleteGenre1.UseVisualStyleBackColor = true;
			// 
			// rBDeleteGenre3
			// 
			this.rBDeleteGenre3.Location = new System.Drawing.Point(64, 0);
			this.rBDeleteGenre3.Name = "rBDeleteGenre3";
			this.rBDeleteGenre3.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteGenre3.TabIndex = 71;
			this.rBDeleteGenre3.UseVisualStyleBackColor = true;
			// 
			// rBDeleteGenre4
			// 
			this.rBDeleteGenre4.Location = new System.Drawing.Point(104, 0);
			this.rBDeleteGenre4.Name = "rBDeleteGenre4";
			this.rBDeleteGenre4.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteGenre4.TabIndex = 78;
			this.rBDeleteGenre4.UseVisualStyleBackColor = true;
			// 
			// pCommentClean
			// 
			this.pCommentClean.Controls.Add(this.rBDeleteComment1);
			this.pCommentClean.Controls.Add(this.rBDeleteComment2);
			this.pCommentClean.Controls.Add(this.rBDeleteComment3);
			this.pCommentClean.Controls.Add(this.rBDeleteComment4);
			this.pCommentClean.Enabled = false;
			this.pCommentClean.Location = new System.Drawing.Point(96, 152);
			this.pCommentClean.Name = "pCommentClean";
			this.pCommentClean.Size = new System.Drawing.Size(120, 24);
			this.pCommentClean.TabIndex = 94;
			// 
			// rBDeleteComment1
			// 
			this.rBDeleteComment1.Location = new System.Drawing.Point(0, 0);
			this.rBDeleteComment1.Name = "rBDeleteComment1";
			this.rBDeleteComment1.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteComment1.TabIndex = 66;
			this.rBDeleteComment1.UseVisualStyleBackColor = true;
			// 
			// rBDeleteComment2
			// 
			this.rBDeleteComment2.Location = new System.Drawing.Point(32, 0);
			this.rBDeleteComment2.Name = "rBDeleteComment2";
			this.rBDeleteComment2.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteComment2.TabIndex = 67;
			this.rBDeleteComment2.UseVisualStyleBackColor = true;
			// 
			// rBDeleteComment3
			// 
			this.rBDeleteComment3.Location = new System.Drawing.Point(64, 0);
			this.rBDeleteComment3.Name = "rBDeleteComment3";
			this.rBDeleteComment3.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteComment3.TabIndex = 68;
			this.rBDeleteComment3.UseVisualStyleBackColor = true;
			// 
			// rBDeleteComment4
			// 
			this.rBDeleteComment4.Location = new System.Drawing.Point(104, 0);
			this.rBDeleteComment4.Name = "rBDeleteComment4";
			this.rBDeleteComment4.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteComment4.TabIndex = 77;
			this.rBDeleteComment4.UseVisualStyleBackColor = true;
			// 
			// pYearClean
			// 
			this.pYearClean.Controls.Add(this.rBDeleteYear1);
			this.pYearClean.Controls.Add(this.rBDeleteYear2);
			this.pYearClean.Controls.Add(this.rBDeleteYear3);
			this.pYearClean.Controls.Add(this.rBDeleteYear4);
			this.pYearClean.Enabled = false;
			this.pYearClean.Location = new System.Drawing.Point(96, 128);
			this.pYearClean.Name = "pYearClean";
			this.pYearClean.Size = new System.Drawing.Size(120, 24);
			this.pYearClean.TabIndex = 93;
			// 
			// rBDeleteYear1
			// 
			this.rBDeleteYear1.Location = new System.Drawing.Point(0, 0);
			this.rBDeleteYear1.Name = "rBDeleteYear1";
			this.rBDeleteYear1.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteYear1.TabIndex = 87;
			this.rBDeleteYear1.UseVisualStyleBackColor = true;
			// 
			// rBDeleteYear2
			// 
			this.rBDeleteYear2.Location = new System.Drawing.Point(32, 0);
			this.rBDeleteYear2.Name = "rBDeleteYear2";
			this.rBDeleteYear2.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteYear2.TabIndex = 88;
			this.rBDeleteYear2.UseVisualStyleBackColor = true;
			// 
			// rBDeleteYear3
			// 
			this.rBDeleteYear3.Location = new System.Drawing.Point(64, 0);
			this.rBDeleteYear3.Name = "rBDeleteYear3";
			this.rBDeleteYear3.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteYear3.TabIndex = 89;
			this.rBDeleteYear3.UseVisualStyleBackColor = true;
			// 
			// rBDeleteYear4
			// 
			this.rBDeleteYear4.Location = new System.Drawing.Point(104, 0);
			this.rBDeleteYear4.Name = "rBDeleteYear4";
			this.rBDeleteYear4.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteYear4.TabIndex = 90;
			this.rBDeleteYear4.UseVisualStyleBackColor = true;
			// 
			// pAlbumClean
			// 
			this.pAlbumClean.Controls.Add(this.rBDeleteAlbum1);
			this.pAlbumClean.Controls.Add(this.rBDeleteAlbum2);
			this.pAlbumClean.Controls.Add(this.rBDeleteAlbum3);
			this.pAlbumClean.Controls.Add(this.rBDeleteAlbum4);
			this.pAlbumClean.Enabled = false;
			this.pAlbumClean.Location = new System.Drawing.Point(96, 80);
			this.pAlbumClean.Name = "pAlbumClean";
			this.pAlbumClean.Size = new System.Drawing.Size(120, 24);
			this.pAlbumClean.TabIndex = 92;
			// 
			// rBDeleteAlbum1
			// 
			this.rBDeleteAlbum1.Location = new System.Drawing.Point(0, 0);
			this.rBDeleteAlbum1.Name = "rBDeleteAlbum1";
			this.rBDeleteAlbum1.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteAlbum1.TabIndex = 60;
			this.rBDeleteAlbum1.UseVisualStyleBackColor = true;
			// 
			// rBDeleteAlbum2
			// 
			this.rBDeleteAlbum2.Location = new System.Drawing.Point(32, 0);
			this.rBDeleteAlbum2.Name = "rBDeleteAlbum2";
			this.rBDeleteAlbum2.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteAlbum2.TabIndex = 61;
			this.rBDeleteAlbum2.UseVisualStyleBackColor = true;
			// 
			// rBDeleteAlbum3
			// 
			this.rBDeleteAlbum3.Location = new System.Drawing.Point(64, 0);
			this.rBDeleteAlbum3.Name = "rBDeleteAlbum3";
			this.rBDeleteAlbum3.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteAlbum3.TabIndex = 62;
			this.rBDeleteAlbum3.UseVisualStyleBackColor = true;
			// 
			// rBDeleteAlbum4
			// 
			this.rBDeleteAlbum4.Location = new System.Drawing.Point(104, 0);
			this.rBDeleteAlbum4.Name = "rBDeleteAlbum4";
			this.rBDeleteAlbum4.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteAlbum4.TabIndex = 75;
			this.rBDeleteAlbum4.UseVisualStyleBackColor = true;
			// 
			// pTitleClean
			// 
			this.pTitleClean.Controls.Add(this.rBDeleteTitle4);
			this.pTitleClean.Controls.Add(this.rBDeleteTitle1);
			this.pTitleClean.Controls.Add(this.rBDeleteTitle2);
			this.pTitleClean.Controls.Add(this.rBDeleteTitle3);
			this.pTitleClean.Enabled = false;
			this.pTitleClean.Location = new System.Drawing.Point(96, 32);
			this.pTitleClean.Name = "pTitleClean";
			this.pTitleClean.Size = new System.Drawing.Size(120, 24);
			this.pTitleClean.TabIndex = 91;
			// 
			// rBDeleteTitle4
			// 
			this.rBDeleteTitle4.Location = new System.Drawing.Point(104, 0);
			this.rBDeleteTitle4.Name = "rBDeleteTitle4";
			this.rBDeleteTitle4.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteTitle4.TabIndex = 73;
			this.rBDeleteTitle4.UseVisualStyleBackColor = true;
			// 
			// rBDeleteTitle1
			// 
			this.rBDeleteTitle1.Location = new System.Drawing.Point(0, 0);
			this.rBDeleteTitle1.Name = "rBDeleteTitle1";
			this.rBDeleteTitle1.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteTitle1.TabIndex = 54;
			this.rBDeleteTitle1.UseVisualStyleBackColor = true;
			// 
			// rBDeleteTitle2
			// 
			this.rBDeleteTitle2.Location = new System.Drawing.Point(32, 0);
			this.rBDeleteTitle2.Name = "rBDeleteTitle2";
			this.rBDeleteTitle2.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteTitle2.TabIndex = 55;
			this.rBDeleteTitle2.UseVisualStyleBackColor = true;
			// 
			// rBDeleteTitle3
			// 
			this.rBDeleteTitle3.Location = new System.Drawing.Point(64, 0);
			this.rBDeleteTitle3.Name = "rBDeleteTitle3";
			this.rBDeleteTitle3.Size = new System.Drawing.Size(16, 24);
			this.rBDeleteTitle3.TabIndex = 56;
			this.rBDeleteTitle3.UseVisualStyleBackColor = true;
			// 
			// cBDeleteYear
			// 
			this.cBDeleteYear.Location = new System.Drawing.Point(8, 128);
			this.cBDeleteYear.Name = "cBDeleteYear";
			this.cBDeleteYear.Size = new System.Drawing.Size(64, 24);
			this.cBDeleteYear.TabIndex = 86;
			this.cBDeleteYear.Text = "Année";
			this.cBDeleteYear.UseVisualStyleBackColor = true;
			this.cBDeleteYear.CheckedChanged += new System.EventHandler(this.CBDeleteYearCheckedChanged);
			// 
			// lVFilesToClean
			// 
			this.lVFilesToClean.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.cHCleanFiles});
			this.lVFilesToClean.HideSelection = false;
			this.lVFilesToClean.Location = new System.Drawing.Point(240, 24);
			this.lVFilesToClean.Name = "lVFilesToClean";
			this.lVFilesToClean.Size = new System.Drawing.Size(464, 160);
			this.lVFilesToClean.TabIndex = 85;
			this.lVFilesToClean.UseCompatibleStateImageBehavior = false;
			this.lVFilesToClean.View = System.Windows.Forms.View.Details;
			this.lVFilesToClean.SelectedIndexChanged += new System.EventHandler(this.LVFilesToCleanSelectedIndexChanged);
			// 
			// cHCleanFiles
			// 
			this.cHCleanFiles.Text = "Nom de fichier";
			this.cHCleanFiles.Width = 442;
			// 
			// bCleanSelectedFiles
			// 
			this.bCleanSelectedFiles.Location = new System.Drawing.Point(240, 192);
			this.bCleanSelectedFiles.Name = "bCleanSelectedFiles";
			this.bCleanSelectedFiles.Size = new System.Drawing.Size(115, 23);
			this.bCleanSelectedFiles.TabIndex = 84;
			this.bCleanSelectedFiles.Text = "Clean selected file(s)";
			this.bCleanSelectedFiles.UseVisualStyleBackColor = true;
			this.bCleanSelectedFiles.Click += new System.EventHandler(this.BCleanSelectedFilesClick);
			// 
			// bCleanAllFiles
			// 
			this.bCleanAllFiles.Location = new System.Drawing.Point(616, 192);
			this.bCleanAllFiles.Name = "bCleanAllFiles";
			this.bCleanAllFiles.Size = new System.Drawing.Size(83, 23);
			this.bCleanAllFiles.TabIndex = 83;
			this.bCleanAllFiles.Text = "Clean all files";
			this.bCleanAllFiles.UseVisualStyleBackColor = true;
			this.bCleanAllFiles.Click += new System.EventHandler(this.BCleanAllFilesClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(88, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 23);
			this.label2.TabIndex = 53;
			this.label2.Text = "None    V1     V2    V1  and V2";
			// 
			// cBDeleteGenre
			// 
			this.cBDeleteGenre.Location = new System.Drawing.Point(8, 176);
			this.cBDeleteGenre.Name = "cBDeleteGenre";
			this.cBDeleteGenre.Size = new System.Drawing.Size(72, 27);
			this.cBDeleteGenre.TabIndex = 49;
			this.cBDeleteGenre.Text = "Genre";
			this.cBDeleteGenre.UseVisualStyleBackColor = true;
			this.cBDeleteGenre.CheckedChanged += new System.EventHandler(this.CBDeleteGenreCheckedChanged);
			// 
			// cBDeleteComment
			// 
			this.cBDeleteComment.Location = new System.Drawing.Point(8, 152);
			this.cBDeleteComment.Name = "cBDeleteComment";
			this.cBDeleteComment.Size = new System.Drawing.Size(88, 27);
			this.cBDeleteComment.TabIndex = 48;
			this.cBDeleteComment.Text = "Commentaire";
			this.cBDeleteComment.UseVisualStyleBackColor = true;
			this.cBDeleteComment.CheckedChanged += new System.EventHandler(this.CBDeleteCommentCheckedChanged);
			// 
			// cBDeleteTrack
			// 
			this.cBDeleteTrack.Location = new System.Drawing.Point(8, 104);
			this.cBDeleteTrack.Name = "cBDeleteTrack";
			this.cBDeleteTrack.Size = new System.Drawing.Size(72, 27);
			this.cBDeleteTrack.TabIndex = 47;
			this.cBDeleteTrack.Text = "Piste";
			this.cBDeleteTrack.UseVisualStyleBackColor = true;
			this.cBDeleteTrack.CheckedChanged += new System.EventHandler(this.CBDeleteTrackCheckedChanged);
			// 
			// cBDeleteAlbum
			// 
			this.cBDeleteAlbum.Location = new System.Drawing.Point(8, 80);
			this.cBDeleteAlbum.Name = "cBDeleteAlbum";
			this.cBDeleteAlbum.Size = new System.Drawing.Size(72, 27);
			this.cBDeleteAlbum.TabIndex = 46;
			this.cBDeleteAlbum.Text = "Album";
			this.cBDeleteAlbum.UseVisualStyleBackColor = true;
			this.cBDeleteAlbum.CheckedChanged += new System.EventHandler(this.CBDeleteAlbumCheckedChanged);
			// 
			// cBDeleteArtist
			// 
			this.cBDeleteArtist.Location = new System.Drawing.Point(8, 56);
			this.cBDeleteArtist.Name = "cBDeleteArtist";
			this.cBDeleteArtist.Size = new System.Drawing.Size(72, 27);
			this.cBDeleteArtist.TabIndex = 45;
			this.cBDeleteArtist.Text = "Artiste";
			this.cBDeleteArtist.UseVisualStyleBackColor = true;
			this.cBDeleteArtist.CheckedChanged += new System.EventHandler(this.CBDeleteArtistCheckedChanged);
			// 
			// cBDeleteTitle
			// 
			this.cBDeleteTitle.Location = new System.Drawing.Point(8, 32);
			this.cBDeleteTitle.Name = "cBDeleteTitle";
			this.cBDeleteTitle.Size = new System.Drawing.Size(72, 27);
			this.cBDeleteTitle.TabIndex = 44;
			this.cBDeleteTitle.Text = "Titre";
			this.cBDeleteTitle.UseVisualStyleBackColor = true;
			this.cBDeleteTitle.CheckedChanged += new System.EventHandler(this.CBDeleteTitleCheckedChanged);
			// 
			// tPTagsDetails
			// 
			this.tPTagsDetails.Controls.Add(this.gBDetailsTagV2);
			this.tPTagsDetails.Controls.Add(this.gBDetailsTagV1);
			this.tPTagsDetails.Controls.Add(this.lVFilesDetails);
			this.tPTagsDetails.Location = new System.Drawing.Point(4, 22);
			this.tPTagsDetails.Name = "tPTagsDetails";
			this.tPTagsDetails.Size = new System.Drawing.Size(712, 222);
			this.tPTagsDetails.TabIndex = 3;
			this.tPTagsDetails.Text = "Détail des tags";
			this.tPTagsDetails.UseVisualStyleBackColor = true;
			// 
			// gBDetailsTagV2
			// 
			this.gBDetailsTagV2.Controls.Add(this.tBDetailsYearV2);
			this.gBDetailsTagV2.Controls.Add(this.tbDetailsCommentV2);
			this.gBDetailsTagV2.Controls.Add(this.tBDetailsTrackV2);
			this.gBDetailsTagV2.Controls.Add(this.tBDetailsAlbumV2);
			this.gBDetailsTagV2.Controls.Add(this.tBDetailsArtistV2);
			this.gBDetailsTagV2.Controls.Add(this.tBDetailsTitleV2);
			this.gBDetailsTagV2.Controls.Add(this.cBDetailsGenreV1);
			this.gBDetailsTagV2.Controls.Add(this.label10);
			this.gBDetailsTagV2.Controls.Add(this.label11);
			this.gBDetailsTagV2.Controls.Add(this.label12);
			this.gBDetailsTagV2.Controls.Add(this.label13);
			this.gBDetailsTagV2.Controls.Add(this.label14);
			this.gBDetailsTagV2.Controls.Add(this.label15);
			this.gBDetailsTagV2.Controls.Add(this.label16);
			this.gBDetailsTagV2.Location = new System.Drawing.Point(464, 8);
			this.gBDetailsTagV2.Name = "gBDetailsTagV2";
			this.gBDetailsTagV2.Size = new System.Drawing.Size(240, 208);
			this.gBDetailsTagV2.TabIndex = 120;
			this.gBDetailsTagV2.TabStop = false;
			this.gBDetailsTagV2.Text = "IdTag V2";
			// 
			// tBDetailsYearV2
			// 
			this.tBDetailsYearV2.Enabled = false;
			this.tBDetailsYearV2.Location = new System.Drawing.Point(88, 113);
			this.tBDetailsYearV2.Name = "tBDetailsYearV2";
			this.tBDetailsYearV2.Size = new System.Drawing.Size(40, 20);
			this.tBDetailsYearV2.TabIndex = 132;
			// 
			// tbDetailsCommentV2
			// 
			this.tbDetailsCommentV2.Enabled = false;
			this.tbDetailsCommentV2.Location = new System.Drawing.Point(88, 137);
			this.tbDetailsCommentV2.Name = "tbDetailsCommentV2";
			this.tbDetailsCommentV2.Size = new System.Drawing.Size(144, 20);
			this.tbDetailsCommentV2.TabIndex = 131;
			// 
			// tBDetailsTrackV2
			// 
			this.tBDetailsTrackV2.Enabled = false;
			this.tBDetailsTrackV2.Location = new System.Drawing.Point(88, 89);
			this.tBDetailsTrackV2.Name = "tBDetailsTrackV2";
			this.tBDetailsTrackV2.Size = new System.Drawing.Size(40, 20);
			this.tBDetailsTrackV2.TabIndex = 130;
			// 
			// tBDetailsAlbumV2
			// 
			this.tBDetailsAlbumV2.Enabled = false;
			this.tBDetailsAlbumV2.Location = new System.Drawing.Point(88, 65);
			this.tBDetailsAlbumV2.Name = "tBDetailsAlbumV2";
			this.tBDetailsAlbumV2.Size = new System.Drawing.Size(144, 20);
			this.tBDetailsAlbumV2.TabIndex = 129;
			// 
			// tBDetailsArtistV2
			// 
			this.tBDetailsArtistV2.Enabled = false;
			this.tBDetailsArtistV2.Location = new System.Drawing.Point(88, 41);
			this.tBDetailsArtistV2.Name = "tBDetailsArtistV2";
			this.tBDetailsArtistV2.Size = new System.Drawing.Size(144, 20);
			this.tBDetailsArtistV2.TabIndex = 128;
			// 
			// tBDetailsTitleV2
			// 
			this.tBDetailsTitleV2.Enabled = false;
			this.tBDetailsTitleV2.Location = new System.Drawing.Point(88, 17);
			this.tBDetailsTitleV2.Name = "tBDetailsTitleV2";
			this.tBDetailsTitleV2.Size = new System.Drawing.Size(144, 20);
			this.tBDetailsTitleV2.TabIndex = 127;
			// 
			// cBDetailsGenreV1
			// 
			this.cBDetailsGenreV1.Enabled = false;
			this.cBDetailsGenreV1.FormattingEnabled = true;
			this.cBDetailsGenreV1.Location = new System.Drawing.Point(88, 169);
			this.cBDetailsGenreV1.Name = "cBDetailsGenreV1";
			this.cBDetailsGenreV1.Size = new System.Drawing.Size(144, 21);
			this.cBDetailsGenreV1.TabIndex = 126;
			this.cBDetailsGenreV1.Text = "Selectionnez un genre ...";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 169);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 23);
			this.label10.TabIndex = 125;
			this.label10.Text = "Genre :";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 145);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 23);
			this.label11.TabIndex = 124;
			this.label11.Text = "Commentaire :";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 121);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(72, 23);
			this.label12.TabIndex = 123;
			this.label12.Text = "Année :";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 97);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(72, 23);
			this.label13.TabIndex = 122;
			this.label13.Text = "Piste :";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 73);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 23);
			this.label14.TabIndex = 121;
			this.label14.Text = "Album :";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 49);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(72, 23);
			this.label15.TabIndex = 120;
			this.label15.Text = "Artiste :";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(8, 25);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(80, 23);
			this.label16.TabIndex = 119;
			this.label16.Text = "Titre : ";
			// 
			// gBDetailsTagV1
			// 
			this.gBDetailsTagV1.Controls.Add(this.tBDetailsYearV1);
			this.gBDetailsTagV1.Controls.Add(this.tbDetailsCommentV1);
			this.gBDetailsTagV1.Controls.Add(this.tBDetailsTrackV1);
			this.gBDetailsTagV1.Controls.Add(this.tBDetailsAlbumV1);
			this.gBDetailsTagV1.Controls.Add(this.tBDetailsArtistV1);
			this.gBDetailsTagV1.Controls.Add(this.tBDetailsTitleV1);
			this.gBDetailsTagV1.Controls.Add(this.cBDetailsGenreV2);
			this.gBDetailsTagV1.Controls.Add(this.label9);
			this.gBDetailsTagV1.Controls.Add(this.label8);
			this.gBDetailsTagV1.Controls.Add(this.label7);
			this.gBDetailsTagV1.Controls.Add(this.label6);
			this.gBDetailsTagV1.Controls.Add(this.label5);
			this.gBDetailsTagV1.Controls.Add(this.label4);
			this.gBDetailsTagV1.Controls.Add(this.label3);
			this.gBDetailsTagV1.Location = new System.Drawing.Point(224, 8);
			this.gBDetailsTagV1.Name = "gBDetailsTagV1";
			this.gBDetailsTagV1.Size = new System.Drawing.Size(232, 208);
			this.gBDetailsTagV1.TabIndex = 119;
			this.gBDetailsTagV1.TabStop = false;
			this.gBDetailsTagV1.Text = "IdTag V1";
			// 
			// tBDetailsYearV1
			// 
			this.tBDetailsYearV1.Enabled = false;
			this.tBDetailsYearV1.Location = new System.Drawing.Point(84, 113);
			this.tBDetailsYearV1.Name = "tBDetailsYearV1";
			this.tBDetailsYearV1.Size = new System.Drawing.Size(40, 20);
			this.tBDetailsYearV1.TabIndex = 118;
			// 
			// tbDetailsCommentV1
			// 
			this.tbDetailsCommentV1.Enabled = false;
			this.tbDetailsCommentV1.Location = new System.Drawing.Point(84, 137);
			this.tbDetailsCommentV1.Name = "tbDetailsCommentV1";
			this.tbDetailsCommentV1.Size = new System.Drawing.Size(144, 20);
			this.tbDetailsCommentV1.TabIndex = 117;
			// 
			// tBDetailsTrackV1
			// 
			this.tBDetailsTrackV1.Enabled = false;
			this.tBDetailsTrackV1.Location = new System.Drawing.Point(84, 89);
			this.tBDetailsTrackV1.Name = "tBDetailsTrackV1";
			this.tBDetailsTrackV1.Size = new System.Drawing.Size(40, 20);
			this.tBDetailsTrackV1.TabIndex = 116;
			// 
			// tBDetailsAlbumV1
			// 
			this.tBDetailsAlbumV1.Enabled = false;
			this.tBDetailsAlbumV1.Location = new System.Drawing.Point(84, 65);
			this.tBDetailsAlbumV1.Name = "tBDetailsAlbumV1";
			this.tBDetailsAlbumV1.Size = new System.Drawing.Size(144, 20);
			this.tBDetailsAlbumV1.TabIndex = 115;
			// 
			// tBDetailsArtistV1
			// 
			this.tBDetailsArtistV1.Enabled = false;
			this.tBDetailsArtistV1.Location = new System.Drawing.Point(84, 41);
			this.tBDetailsArtistV1.Name = "tBDetailsArtistV1";
			this.tBDetailsArtistV1.Size = new System.Drawing.Size(144, 20);
			this.tBDetailsArtistV1.TabIndex = 114;
			// 
			// tBDetailsTitleV1
			// 
			this.tBDetailsTitleV1.Enabled = false;
			this.tBDetailsTitleV1.Location = new System.Drawing.Point(84, 17);
			this.tBDetailsTitleV1.Name = "tBDetailsTitleV1";
			this.tBDetailsTitleV1.Size = new System.Drawing.Size(144, 20);
			this.tBDetailsTitleV1.TabIndex = 113;
			// 
			// cBDetailsGenreV2
			// 
			this.cBDetailsGenreV2.Enabled = false;
			this.cBDetailsGenreV2.FormattingEnabled = true;
			this.cBDetailsGenreV2.Location = new System.Drawing.Point(80, 168);
			this.cBDetailsGenreV2.Name = "cBDetailsGenreV2";
			this.cBDetailsGenreV2.Size = new System.Drawing.Size(144, 21);
			this.cBDetailsGenreV2.TabIndex = 112;
			this.cBDetailsGenreV2.Text = "Selectionnez un genre ...";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(4, 169);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 23);
			this.label9.TabIndex = 111;
			this.label9.Text = "Genre :";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(4, 145);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 23);
			this.label8.TabIndex = 110;
			this.label8.Text = "Commentaire :";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(4, 121);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 23);
			this.label7.TabIndex = 109;
			this.label7.Text = "Année :";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(4, 97);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 23);
			this.label6.TabIndex = 108;
			this.label6.Text = "Piste :";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(4, 73);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 107;
			this.label5.Text = "Album :";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 106;
			this.label4.Text = "Artiste :";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 105;
			this.label3.Text = "Titre : ";
			// 
			// lVFilesDetails
			// 
			this.lVFilesDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1});
			this.lVFilesDetails.HideSelection = false;
			this.lVFilesDetails.Location = new System.Drawing.Point(8, 24);
			this.lVFilesDetails.MultiSelect = false;
			this.lVFilesDetails.Name = "lVFilesDetails";
			this.lVFilesDetails.Size = new System.Drawing.Size(208, 176);
			this.lVFilesDetails.TabIndex = 86;
			this.lVFilesDetails.UseCompatibleStateImageBehavior = false;
			this.lVFilesDetails.View = System.Windows.Forms.View.Details;
			this.lVFilesDetails.SelectedIndexChanged += new System.EventHandler(this.LVFilesDetailsSelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Nom de fichier";
			this.columnHeader1.Width = 187;
			// 
			// mSMainform
			// 
			this.mSMainform.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tSMIAbout});
			this.mSMainform.Location = new System.Drawing.Point(0, 0);
			this.mSMainform.Name = "mSMainform";
			this.mSMainform.Size = new System.Drawing.Size(733, 24);
			this.mSMainform.TabIndex = 3;
			this.mSMainform.Text = "menuStrip1";
			// 
			// tSMIAbout
			// 
			this.tSMIAbout.Name = "tSMIAbout";
			this.tSMIAbout.Size = new System.Drawing.Size(95, 20);
			this.tSMIAbout.Text = "A propos de ...";
			this.tSMIAbout.Click += new System.EventHandler(this.TSMIAboutClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(733, 349);
			this.Controls.Add(this.tCManipulations);
			this.Controls.Add(this.gBDirectory);
			this.Controls.Add(this.mSMainform);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mSMainform;
			this.MinimumSize = new System.Drawing.Size(494, 362);
			this.Name = "MainForm";
			this.Text = "Cricri371 Id Tag Manager";
			this.gBDirectory.ResumeLayout(false);
			this.gBDirectory.PerformLayout();
			this.tCManipulations.ResumeLayout(false);
			this.tPListFiles.ResumeLayout(false);
			this.tPMassRename.ResumeLayout(false);
			this.tPMassRename.PerformLayout();
			this.pGenreRename.ResumeLayout(false);
			this.pCommentRename.ResumeLayout(false);
			this.pYearRename.ResumeLayout(false);
			this.pTrackRename.ResumeLayout(false);
			this.pAlbumRename.ResumeLayout(false);
			this.pArtistRename.ResumeLayout(false);
			this.pTitleRename.ResumeLayout(false);
			this.tPCleanFiles.ResumeLayout(false);
			this.pTrackClean.ResumeLayout(false);
			this.pArtistClean.ResumeLayout(false);
			this.pGenreClean.ResumeLayout(false);
			this.pCommentClean.ResumeLayout(false);
			this.pYearClean.ResumeLayout(false);
			this.pAlbumClean.ResumeLayout(false);
			this.pTitleClean.ResumeLayout(false);
			this.tPTagsDetails.ResumeLayout(false);
			this.gBDetailsTagV2.ResumeLayout(false);
			this.gBDetailsTagV2.PerformLayout();
			this.gBDetailsTagV1.ResumeLayout(false);
			this.gBDetailsTagV1.PerformLayout();
			this.mSMainform.ResumeLayout(false);
			this.mSMainform.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
