/*
 * Created by SharpDevelop.
 * User: Christophe Charanson
 * Date: 30/05/2006
 * Time: 19:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Cricri371_Explorer
{
	partial class MainForm : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.tSMIFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.gBSource = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tVSource = new System.Windows.Forms.TreeView();
            this.cMSTVSource = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createDirectoryTSMISource = new System.Windows.Forms.ToolStripMenuItem();
            this.renameDirectoryTSMISource = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDirectoryTSMISource = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.lVSource = new System.Windows.Forms.ListView();
            this.cHSourceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHSourceSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHSourceDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cMSLVSource = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameFileTSMISource = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileTSMISource = new System.Windows.Forms.ToolStripMenuItem();
            this.gBActions = new System.Windows.Forms.GroupBox();
            this.bCompareBackup = new System.Windows.Forms.Button();
            this.bCompareAfterCopy = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.gBDestination = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tVDestination = new System.Windows.Forms.TreeView();
            this.cMSTVDestination = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createDirectoryTSMIDestination = new System.Windows.Forms.ToolStripMenuItem();
            this.renameDirectoryTSMIDestination = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDirectoryTSMIDestination = new System.Windows.Forms.ToolStripMenuItem();
            this.lVDestination = new System.Windows.Forms.ListView();
            this.cHDestinationName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHDestinationSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHDestinationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cMSLVDestination = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameFileTSMIDestination = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileTSMIDestination = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSource = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBNewNameSource = new System.Windows.Forms.TextBox();
            this.tBNumericSource = new System.Windows.Forms.TextBox();
            this.bNumericRenameSource = new System.Windows.Forms.Button();
            this.panelDestination = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBNewNameDestination = new System.Windows.Forms.TextBox();
            this.tBNumericDestination = new System.Windows.Forms.TextBox();
            this.bNumericRenameDestination = new System.Windows.Forms.Button();
            this.menuStripMain.SuspendLayout();
            this.gBSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cMSTVSource.SuspendLayout();
            this.cMSLVSource.SuspendLayout();
            this.gBActions.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.gBDestination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.cMSTVDestination.SuspendLayout();
            this.cMSLVDestination.SuspendLayout();
            this.panelSource.SuspendLayout();
            this.panelDestination.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIFile,
            this.TSMIAbout});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(792, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // tSMIFile
            // 
            this.tSMIFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIQuit});
            this.tSMIFile.Name = "tSMIFile";
            this.tSMIFile.Size = new System.Drawing.Size(54, 20);
            this.tSMIFile.Text = "Fichier";
            // 
            // TSMIQuit
            // 
            this.TSMIQuit.Name = "TSMIQuit";
            this.TSMIQuit.Size = new System.Drawing.Size(111, 22);
            this.TSMIQuit.Text = "Quitter";
            this.TSMIQuit.Click += new System.EventHandler(this.TSMIQuitClick);
            // 
            // TSMIAbout
            // 
            this.TSMIAbout.Name = "TSMIAbout";
            this.TSMIAbout.Size = new System.Drawing.Size(83, 20);
            this.TSMIAbout.Text = "A propos de";
            this.TSMIAbout.Click += new System.EventHandler(this.TSMIAboutClick);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Location = new System.Drawing.Point(0, 551);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(792, 22);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // gBSource
            // 
            this.gBSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBSource.Controls.Add(this.splitContainer1);
            this.gBSource.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBSource.Location = new System.Drawing.Point(3, 3);
            this.gBSource.Name = "gBSource";
            this.gBSource.Size = new System.Drawing.Size(788, 176);
            this.gBSource.TabIndex = 0;
            this.gBSource.TabStop = false;
            this.gBSource.Text = "Source";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 23);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tVSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lVSource);
            this.splitContainer1.Size = new System.Drawing.Size(782, 150);
            this.splitContainer1.SplitterDistance = 227;
            this.splitContainer1.TabIndex = 0;
            // 
            // tVSource
            // 
            this.tVSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tVSource.ContextMenuStrip = this.cMSTVSource;
            this.tVSource.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tVSource.HideSelection = false;
            this.tVSource.ImageIndex = 0;
            this.tVSource.ImageList = this.imageListMain;
            this.tVSource.Location = new System.Drawing.Point(1, 0);
            this.tVSource.Name = "tVSource";
            this.tVSource.SelectedImageIndex = 0;
            this.tVSource.Size = new System.Drawing.Size(226, 150);
            this.tVSource.TabIndex = 0;
            this.tVSource.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.TVSourceAfterExpand);
            this.tVSource.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TVSourceItemDrag);
            this.tVSource.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TVSourceAfterSelect);
            this.tVSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TVSourceKeyDown);
            // 
            // cMSTVSource
            // 
            this.cMSTVSource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDirectoryTSMISource,
            this.renameDirectoryTSMISource,
            this.deleteDirectoryTSMISource});
            this.cMSTVSource.Name = "contextMenuStrip1";
            this.cMSTVSource.Size = new System.Drawing.Size(200, 70);
            // 
            // createDirectoryTSMISource
            // 
            this.createDirectoryTSMISource.Name = "createDirectoryTSMISource";
            this.createDirectoryTSMISource.Size = new System.Drawing.Size(199, 22);
            this.createDirectoryTSMISource.Text = "Créer un répertoire";
            this.createDirectoryTSMISource.Click += new System.EventHandler(this.CreateDirectoryTSMISourceClick);
            // 
            // renameDirectoryTSMISource
            // 
            this.renameDirectoryTSMISource.Name = "renameDirectoryTSMISource";
            this.renameDirectoryTSMISource.Size = new System.Drawing.Size(199, 22);
            this.renameDirectoryTSMISource.Text = "Renommer le répertoire";
            this.renameDirectoryTSMISource.Click += new System.EventHandler(this.RenameDirectoryTSMISourceClick);
            // 
            // deleteDirectoryTSMISource
            // 
            this.deleteDirectoryTSMISource.Name = "deleteDirectoryTSMISource";
            this.deleteDirectoryTSMISource.Size = new System.Drawing.Size(199, 22);
            this.deleteDirectoryTSMISource.Text = "Supprimer le répertoire";
            this.deleteDirectoryTSMISource.Click += new System.EventHandler(this.DeleteDirectoryTSMISourceClick);
            // 
            // imageListMain
            // 
            this.imageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMain.ImageStream")));
            this.imageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMain.Images.SetKeyName(0, "FolderClose.bmp");
            this.imageListMain.Images.SetKeyName(1, "FolderOpen.bmp");
            this.imageListMain.Images.SetKeyName(2, "Recycle.gif");
            this.imageListMain.Images.SetKeyName(3, "Floppy.gif");
            this.imageListMain.Images.SetKeyName(4, "Hardrive.gif");
            this.imageListMain.Images.SetKeyName(5, "Cdrom.gif");
            this.imageListMain.Images.SetKeyName(6, "Postedetravail.gif");
            this.imageListMain.Images.SetKeyName(7, "UsbDrive.gif");
            // 
            // lVSource
            // 
            this.lVSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lVSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cHSourceName,
            this.cHSourceSize,
            this.cHSourceDate});
            this.lVSource.ContextMenuStrip = this.cMSLVSource;
            this.lVSource.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVSource.FullRowSelect = true;
            this.lVSource.GridLines = true;
            this.lVSource.HideSelection = false;
            this.lVSource.Location = new System.Drawing.Point(2, 0);
            this.lVSource.Name = "lVSource";
            this.lVSource.Size = new System.Drawing.Size(549, 150);
            this.lVSource.TabIndex = 0;
            this.lVSource.UseCompatibleStateImageBehavior = false;
            this.lVSource.View = System.Windows.Forms.View.Details;
            this.lVSource.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.LVSourceItemDrag);
            this.lVSource.SelectedIndexChanged += new System.EventHandler(this.LVSourceSelectedIndexChanged);
            this.lVSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LVSourceKeyDown);
            // 
            // cHSourceName
            // 
            this.cHSourceName.Text = "Nom";
            this.cHSourceName.Width = 284;
            // 
            // cHSourceSize
            // 
            this.cHSourceSize.Text = "Taille";
            this.cHSourceSize.Width = 77;
            // 
            // cHSourceDate
            // 
            this.cHSourceDate.Text = "Date de modification";
            this.cHSourceDate.Width = 183;
            // 
            // cMSLVSource
            // 
            this.cMSLVSource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameFileTSMISource,
            this.deleteFileTSMISource});
            this.cMSLVSource.Name = "cMSLVSource";
            this.cMSLVSource.Size = new System.Drawing.Size(182, 48);
            // 
            // renameFileTSMISource
            // 
            this.renameFileTSMISource.Name = "renameFileTSMISource";
            this.renameFileTSMISource.Size = new System.Drawing.Size(181, 22);
            this.renameFileTSMISource.Text = "Renommer le fichier";
            this.renameFileTSMISource.Click += new System.EventHandler(this.RenameFileTSMISourceClick);
            // 
            // deleteFileTSMISource
            // 
            this.deleteFileTSMISource.Name = "deleteFileTSMISource";
            this.deleteFileTSMISource.Size = new System.Drawing.Size(181, 22);
            this.deleteFileTSMISource.Text = "Supprimer le fichier";
            this.deleteFileTSMISource.Click += new System.EventHandler(this.DeleteFileTSMISourceClick);
            // 
            // gBActions
            // 
            this.gBActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBActions.Controls.Add(this.bCompareBackup);
            this.gBActions.Controls.Add(this.bCompareAfterCopy);
            this.gBActions.Location = new System.Drawing.Point(3, 471);
            this.gBActions.Name = "gBActions";
            this.gBActions.Size = new System.Drawing.Size(788, 47);
            this.gBActions.TabIndex = 3;
            this.gBActions.TabStop = false;
            this.gBActions.Text = "Actions";
            // 
            // bCompareBackup
            // 
            this.bCompareBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bCompareBackup.Location = new System.Drawing.Point(433, 14);
            this.bCompareBackup.Name = "bCompareBackup";
            this.bCompareBackup.Size = new System.Drawing.Size(347, 27);
            this.bCompareBackup.TabIndex = 1;
            this.bCompareBackup.Text = "Comparer répertoire de backup";
            this.bCompareBackup.UseVisualStyleBackColor = true;
            this.bCompareBackup.Click += new System.EventHandler(this.BCompareBackupClick);
            // 
            // bCompareAfterCopy
            // 
            this.bCompareAfterCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bCompareAfterCopy.Location = new System.Drawing.Point(9, 14);
            this.bCompareAfterCopy.Name = "bCompareAfterCopy";
            this.bCompareAfterCopy.Size = new System.Drawing.Size(347, 27);
            this.bCompareAfterCopy.TabIndex = 0;
            this.bCompareAfterCopy.Text = "Comparer après copie";
            this.bCompareAfterCopy.UseVisualStyleBackColor = true;
            this.bCompareAfterCopy.Click += new System.EventHandler(this.BCompareAfterCopyClick);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.Controls.Add(this.gBActions, 0, 4);
            this.tableLayoutPanelMain.Controls.Add(this.gBDestination, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.gBSource, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelSource, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.panelDestination, 0, 3);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 5;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(791, 521);
            this.tableLayoutPanelMain.TabIndex = 2;
            // 
            // gBDestination
            // 
            this.gBDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBDestination.Controls.Add(this.splitContainer2);
            this.gBDestination.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBDestination.Location = new System.Drawing.Point(3, 237);
            this.gBDestination.Name = "gBDestination";
            this.gBDestination.Size = new System.Drawing.Size(788, 176);
            this.gBDestination.TabIndex = 1;
            this.gBDestination.TabStop = false;
            this.gBDestination.Text = "Destination";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 23);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tVDestination);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lVDestination);
            this.splitContainer2.Size = new System.Drawing.Size(782, 150);
            this.splitContainer2.SplitterDistance = 226;
            this.splitContainer2.TabIndex = 0;
            // 
            // tVDestination
            // 
            this.tVDestination.AllowDrop = true;
            this.tVDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tVDestination.ContextMenuStrip = this.cMSTVDestination;
            this.tVDestination.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tVDestination.HideSelection = false;
            this.tVDestination.ImageIndex = 0;
            this.tVDestination.ImageList = this.imageListMain;
            this.tVDestination.Location = new System.Drawing.Point(1, 0);
            this.tVDestination.Name = "tVDestination";
            this.tVDestination.SelectedImageIndex = 0;
            this.tVDestination.Size = new System.Drawing.Size(226, 150);
            this.tVDestination.TabIndex = 1;
            this.tVDestination.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.TVDestinationAfterExpand);
            this.tVDestination.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TVDestinationAfterSelect);
            this.tVDestination.DragDrop += new System.Windows.Forms.DragEventHandler(this.TVDestinationDragDrop);
            this.tVDestination.DragOver += new System.Windows.Forms.DragEventHandler(this.TVDestinationDragOver);
            this.tVDestination.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TVDestinationKeyDown);
            // 
            // cMSTVDestination
            // 
            this.cMSTVDestination.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDirectoryTSMIDestination,
            this.renameDirectoryTSMIDestination,
            this.deleteDirectoryTSMIDestination});
            this.cMSTVDestination.Name = "contextMenuStrip1";
            this.cMSTVDestination.Size = new System.Drawing.Size(200, 70);
            // 
            // createDirectoryTSMIDestination
            // 
            this.createDirectoryTSMIDestination.Name = "createDirectoryTSMIDestination";
            this.createDirectoryTSMIDestination.Size = new System.Drawing.Size(199, 22);
            this.createDirectoryTSMIDestination.Text = "Créer un répertoire";
            this.createDirectoryTSMIDestination.Click += new System.EventHandler(this.CreateDirectoryTSMIDestinationClick);
            // 
            // renameDirectoryTSMIDestination
            // 
            this.renameDirectoryTSMIDestination.Name = "renameDirectoryTSMIDestination";
            this.renameDirectoryTSMIDestination.Size = new System.Drawing.Size(199, 22);
            this.renameDirectoryTSMIDestination.Text = "Renommer le répertoire";
            this.renameDirectoryTSMIDestination.Click += new System.EventHandler(this.RenameDirectoryTSMIDestinationClick);
            // 
            // deleteDirectoryTSMIDestination
            // 
            this.deleteDirectoryTSMIDestination.Name = "deleteDirectoryTSMIDestination";
            this.deleteDirectoryTSMIDestination.Size = new System.Drawing.Size(199, 22);
            this.deleteDirectoryTSMIDestination.Text = "Supprimer le répertoire";
            this.deleteDirectoryTSMIDestination.Click += new System.EventHandler(this.DeleteDirectoryTSMIDestinationClick);
            // 
            // lVDestination
            // 
            this.lVDestination.AllowDrop = true;
            this.lVDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lVDestination.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cHDestinationName,
            this.cHDestinationSize,
            this.cHDestinationDate});
            this.lVDestination.ContextMenuStrip = this.cMSLVDestination;
            this.lVDestination.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVDestination.FullRowSelect = true;
            this.lVDestination.GridLines = true;
            this.lVDestination.HideSelection = false;
            this.lVDestination.Location = new System.Drawing.Point(3, 0);
            this.lVDestination.Name = "lVDestination";
            this.lVDestination.Size = new System.Drawing.Size(549, 150);
            this.lVDestination.TabIndex = 1;
            this.lVDestination.UseCompatibleStateImageBehavior = false;
            this.lVDestination.View = System.Windows.Forms.View.Details;
            this.lVDestination.SelectedIndexChanged += new System.EventHandler(this.LVDestinationSelectedIndexChanged);
            this.lVDestination.DragDrop += new System.Windows.Forms.DragEventHandler(this.LVDestinationDragDrop);
            this.lVDestination.DragOver += new System.Windows.Forms.DragEventHandler(this.LVDestinationDragOver);
            this.lVDestination.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LVDestinationKeyDown);
            // 
            // cHDestinationName
            // 
            this.cHDestinationName.Text = "Nom";
            this.cHDestinationName.Width = 281;
            // 
            // cHDestinationSize
            // 
            this.cHDestinationSize.Text = "Taille";
            this.cHDestinationSize.Width = 80;
            // 
            // cHDestinationDate
            // 
            this.cHDestinationDate.Text = "Date de modification";
            this.cHDestinationDate.Width = 183;
            // 
            // cMSLVDestination
            // 
            this.cMSLVDestination.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameFileTSMIDestination,
            this.deleteFileTSMIDestination});
            this.cMSLVDestination.Name = "contextMenuStrip1";
            this.cMSLVDestination.Size = new System.Drawing.Size(182, 48);
            // 
            // renameFileTSMIDestination
            // 
            this.renameFileTSMIDestination.Name = "renameFileTSMIDestination";
            this.renameFileTSMIDestination.Size = new System.Drawing.Size(181, 22);
            this.renameFileTSMIDestination.Text = "Renommer le fichier";
            this.renameFileTSMIDestination.Click += new System.EventHandler(this.RenameFileTSMIDestinationClick);
            // 
            // deleteFileTSMIDestination
            // 
            this.deleteFileTSMIDestination.Name = "deleteFileTSMIDestination";
            this.deleteFileTSMIDestination.Size = new System.Drawing.Size(181, 22);
            this.deleteFileTSMIDestination.Text = "Supprimer le fichier";
            this.deleteFileTSMIDestination.Click += new System.EventHandler(this.DeleteFileTSMIDestinationClick);
            // 
            // panelSource
            // 
            this.panelSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSource.Controls.Add(this.label3);
            this.panelSource.Controls.Add(this.label1);
            this.panelSource.Controls.Add(this.tBNewNameSource);
            this.panelSource.Controls.Add(this.tBNumericSource);
            this.panelSource.Controls.Add(this.bNumericRenameSource);
            this.panelSource.Location = new System.Drawing.Point(3, 185);
            this.panelSource.Name = "panelSource";
            this.panelSource.Size = new System.Drawing.Size(788, 46);
            this.panelSource.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(377, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nouveau nom principal : ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(161, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre du début : ";
            // 
            // tBNewNameSource
            // 
            this.tBNewNameSource.Location = new System.Drawing.Point(511, 5);
            this.tBNewNameSource.Name = "tBNewNameSource";
            this.tBNewNameSource.Size = new System.Drawing.Size(163, 20);
            this.tBNewNameSource.TabIndex = 2;
            // 
            // tBNumericSource
            // 
            this.tBNumericSource.Location = new System.Drawing.Point(267, 5);
            this.tBNumericSource.Name = "tBNumericSource";
            this.tBNumericSource.Size = new System.Drawing.Size(56, 20);
            this.tBNumericSource.TabIndex = 1;
            // 
            // bNumericRenameSource
            // 
            this.bNumericRenameSource.Location = new System.Drawing.Point(9, 3);
            this.bNumericRenameSource.Name = "bNumericRenameSource";
            this.bNumericRenameSource.Size = new System.Drawing.Size(128, 23);
            this.bNumericRenameSource.TabIndex = 0;
            this.bNumericRenameSource.Text = "Renommer en masse";
            this.bNumericRenameSource.UseVisualStyleBackColor = true;
            this.bNumericRenameSource.Click += new System.EventHandler(this.BNumericRenameSourceClick);
            // 
            // panelDestination
            // 
            this.panelDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDestination.Controls.Add(this.label4);
            this.panelDestination.Controls.Add(this.label2);
            this.panelDestination.Controls.Add(this.tBNewNameDestination);
            this.panelDestination.Controls.Add(this.tBNumericDestination);
            this.panelDestination.Controls.Add(this.bNumericRenameDestination);
            this.panelDestination.Location = new System.Drawing.Point(3, 419);
            this.panelDestination.Name = "panelDestination";
            this.panelDestination.Size = new System.Drawing.Size(788, 46);
            this.panelDestination.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(377, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nouveau nom principal : ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(161, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre du début : ";
            // 
            // tBNewNameDestination
            // 
            this.tBNewNameDestination.Location = new System.Drawing.Point(514, 5);
            this.tBNewNameDestination.Name = "tBNewNameDestination";
            this.tBNewNameDestination.Size = new System.Drawing.Size(160, 20);
            this.tBNewNameDestination.TabIndex = 3;
            // 
            // tBNumericDestination
            // 
            this.tBNumericDestination.Location = new System.Drawing.Point(267, 5);
            this.tBNumericDestination.Name = "tBNumericDestination";
            this.tBNumericDestination.Size = new System.Drawing.Size(64, 20);
            this.tBNumericDestination.TabIndex = 2;
            // 
            // bNumericRenameDestination
            // 
            this.bNumericRenameDestination.Location = new System.Drawing.Point(9, 3);
            this.bNumericRenameDestination.Name = "bNumericRenameDestination";
            this.bNumericRenameDestination.Size = new System.Drawing.Size(128, 23);
            this.bNumericRenameDestination.TabIndex = 1;
            this.bNumericRenameDestination.Text = "Renommer en masse";
            this.bNumericRenameDestination.UseVisualStyleBackColor = true;
            this.bNumericRenameDestination.Click += new System.EventHandler(this.BNumericRenameDestinationClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Cricri371 Explorer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.gBSource.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cMSTVSource.ResumeLayout(false);
            this.cMSLVSource.ResumeLayout(false);
            this.gBActions.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.gBDestination.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cMSTVDestination.ResumeLayout(false);
            this.cMSLVDestination.ResumeLayout(false);
            this.panelSource.ResumeLayout(false);
            this.panelSource.PerformLayout();
            this.panelDestination.ResumeLayout(false);
            this.panelDestination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.TextBox tBNumericDestination;
		private System.Windows.Forms.TextBox tBNumericSource;
		private System.Windows.Forms.Button bNumericRenameDestination;
		private System.Windows.Forms.TextBox tBNewNameDestination;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button bNumericRenameSource;
		private System.Windows.Forms.TextBox tBNewNameSource;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolStripMenuItem createDirectoryTSMIDestination;
		private System.Windows.Forms.ToolStripMenuItem createDirectoryTSMISource;
		private System.Windows.Forms.ToolStripMenuItem deleteFileTSMIDestination;
		private System.Windows.Forms.ToolStripMenuItem renameFileTSMIDestination;
		private System.Windows.Forms.ToolStripMenuItem deleteFileTSMISource;
		private System.Windows.Forms.ToolStripMenuItem renameFileTSMISource;
		private System.Windows.Forms.ToolStripMenuItem deleteDirectoryTSMIDestination;
		private System.Windows.Forms.ToolStripMenuItem renameDirectoryTSMIDestination;
		private System.Windows.Forms.ToolStripMenuItem deleteDirectoryTSMISource;
		private System.Windows.Forms.ToolStripMenuItem renameDirectoryTSMISource;
		private System.Windows.Forms.ColumnHeader cHDestinationDate;
		private System.Windows.Forms.ColumnHeader cHDestinationSize;
		private System.Windows.Forms.ColumnHeader cHDestinationName;
		private System.Windows.Forms.ColumnHeader cHSourceDate;
		private System.Windows.Forms.ColumnHeader cHSourceSize;
		private System.Windows.Forms.ColumnHeader cHSourceName;
		private System.Windows.Forms.ContextMenuStrip cMSLVDestination;
		private System.Windows.Forms.ContextMenuStrip cMSTVDestination;
		private System.Windows.Forms.ContextMenuStrip cMSLVSource;
		private System.Windows.Forms.ContextMenuStrip cMSTVSource;
		private System.Windows.Forms.ImageList imageListMain;
		private System.Windows.Forms.Panel panelDestination;
		private System.Windows.Forms.Panel panelSource;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
		private System.Windows.Forms.Button bCompareAfterCopy;
		private System.Windows.Forms.Button bCompareBackup;
		private System.Windows.Forms.ListView lVSource;
		private System.Windows.Forms.TreeView tVSource;
		private System.Windows.Forms.ListView lVDestination;
		private System.Windows.Forms.TreeView tVDestination;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ToolStripMenuItem TSMIAbout;
		private System.Windows.Forms.ToolStripMenuItem TSMIQuit;
		private System.Windows.Forms.ToolStripMenuItem tSMIFile;
		private System.Windows.Forms.GroupBox gBActions;
		private System.Windows.Forms.GroupBox gBSource;
		private System.Windows.Forms.GroupBox gBDestination;
		private System.Windows.Forms.StatusStrip statusStripMain;
		private System.Windows.Forms.MenuStrip menuStripMain;
	}
}
