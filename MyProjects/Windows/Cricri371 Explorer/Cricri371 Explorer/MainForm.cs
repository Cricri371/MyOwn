using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using Cricri371Dll;
using Cricri371Dll.Gui;
using Cricri371Dll.Gui.FullMessageBox;
using Cricri371Dll.IO;

namespace Cricri371_Explorer
{
    public partial class MainForm
    {
        #region DriveType : Avoir le type de lecteur

        [DllImport("kernel32.dll")] public static extern DriveType GetDriveType(string drivename);

        public enum DriveType { Unknown = 0, NoRoot = 1, Removeable = 2, Fixed = 3, Remote = 4, Cdrom = 5, Ramdisk = 6 }

        #endregion DriveType : Avoir le type de lecteur

        private TreeNode openedFolderSource;
        private TreeNode openedFolderDestination;
        private Thread tCopy;
        private ArrayList lviCollectionSource, lviCollectionDestination;
        public string NewName;
        public string oldName;
        public string suppMessage;
        public bool renameCancel;
        public int response;
        private bool differentDirectory;

        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        #region MainForm

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion MainForm

        #region TSMIAboutClick

        private void TSMIAboutClick(object sender, System.EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        #endregion TSMIAboutClick

        #region TSMIQuitClick

        private void TSMIQuitClick(object sender, System.EventArgs e)
        {
            Close();
        }

        #endregion TSMIQuitClick

        #region TVSourceAfterSelect

        private void TVSourceAfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.openedFolderSource = e.Node;

            if (this.tVSource.SelectedNode.BackColor != Color.Red)
            {
                FillFilesListView(this.tVSource.SelectedNode, this.lVSource);
            }
            else
            {
                this.lVSource.Items.Clear();
                MessageBox.Show("Répertoire système protégé par windows");
            }
        }

        #endregion TVSourceAfterSelect

        #region TVSourceAfterExpand

        private void TVSourceAfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            FillFilesListView(e.Node, this.lVSource);

            FillDirectoryTreeView(e.Node);

            this.openedFolderSource = e.Node;
        }

        #endregion TVSourceAfterExpand

        #region TVSourceItemDrag

        private void TVSourceItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            if (this.tVSource.Nodes.Count == 0)
            {
                return;
            }

            var select = ((TreeNode)e.Item).FullPath;

            if (select.Length != 3)
            {
                ((TreeNode)e.Item).TreeView.SelectedNode = ((TreeNode)e.Item);

                this.tVSource.DoDragDrop(select, DragDropEffects.Copy);
            }
            else
            {
                MessageBox.Show("Vous ne pouvez pas déplacer un lecteur");
            }
        }

        #endregion TVSourceItemDrag

        #region TVDestinationAfterSelect

        private void TVDestinationAfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.openedFolderDestination = e.Node;

            if (this.tVDestination.SelectedNode.BackColor != Color.Red)
            {
                FillFilesListView(this.tVDestination.SelectedNode, this.lVDestination);
            }
            else
            {
                this.lVDestination.Items.Clear();
                MessageBox.Show("Répertoire système protégé par windows");
            }
        }

        #endregion TVDestinationAfterSelect

        #region TVDestinationAfterExpand

        private void TVDestinationAfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            FillFilesListView(e.Node, this.lVDestination);

            FillDirectoryTreeView(e.Node);

            this.openedFolderDestination = e.Node;
        }

        #endregion TVDestinationAfterExpand

        #region LVSourceSelectedIndexChanged

        private void LVSourceSelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.lviCollectionSource = new ArrayList();

                foreach (ListViewItem lvi in this.lVSource.SelectedItems)
                {
                    this.lviCollectionSource.Add(lvi.Text);
                }
            }
            catch (NotSupportedException nSE)
            {
                MessageBox.Show("(MainForm(LVSourceSelectedIndexChanged))NotSupportedException : " + nSE.Message);
            }
        }

        #endregion LVSourceSelectedIndexChanged

        #region LVDestinationSelectedIndexChanged

        private void LVDestinationSelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.lviCollectionDestination = new ArrayList();

                foreach (ListViewItem lvi in this.lVDestination.SelectedItems)
                {
                    this.lviCollectionDestination.Add(lvi.Text);
                }
            }
            catch (NotSupportedException nSE)
            {
                MessageBox.Show("(MainForm(LVDestinationSelectedIndexChanged))NotSupportedException : " + nSE.Message);
            }
        }

        #endregion LVDestinationSelectedIndexChanged

        #region LVSourceItemDrag

        private void LVSourceItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            if (this.lVSource.Items.Count == 0)
            {
                return;
            }

            var filename = ((ListViewItem)e.Item).Text;
            var select = this.openedFolderSource.FullPath + Path.DirectorySeparatorChar + filename;

            this.lVSource.DoDragDrop(select, DragDropEffects.Copy);
        }

        #endregion LVSourceItemDrag

        #region FillListView : Add files in listview with selected directory

        private bool FillFilesListView(TreeNode tNSelected, ListView lV)
        {
            lV.Items.Clear();

            try
            {
                var path = tNSelected.FullPath;

                if (!Directory.Exists(path))
                {
                    return false;
                }

                var dInfo = new DirectoryInfo(path);
                var Files = dInfo.GetFiles();

                foreach (var file in Files)
                {
                    var fileName = file.Name;
                    var taille = file.Length;
                    var date = file.LastWriteTime.ToString();

                    var lvi = new ListViewItem
                    {
                        Text = fileName
                    };

                    CalculateSize(file.Length);

                    var lvsiTaille = new ListViewItem.ListViewSubItem
                    {
                        Text = CalculateSize(taille)
                    };
                    lvi.SubItems.Add(lvsiTaille);

                    var lvsiDate = new ListViewItem.ListViewSubItem
                    {
                        Text = date
                    };
                    lvi.SubItems.Add(lvsiDate);

                    lV.Items.Add(lvi);
                }

                return true;
            }
            catch (SecurityException sE)
            {
                MessageBox.Show("(MainForm(FillFilesListView))SecurityException : " + sE.Message);
                return false;
            }
            catch (ArgumentNullException aNE)
            {
                MessageBox.Show("(MainForm(FillFilesListView))ArgumentNullException : " + aNE.Message);
                return false;
            }
            catch (ArgumentException aE)
            {
                MessageBox.Show("(MainForm(FillFilesListView))ArgumentException : " + aE.Message);
                return false;
            }
            catch (PathTooLongException pTLE)
            {
                MessageBox.Show("(MainForm(FillFilesListView))PathTooLongException : " + pTLE.Message);
                return false;
            }
            catch (DirectoryNotFoundException dNFE)
            {
                MessageBox.Show("(MainForm(FillFilesListView))DirectoryNotFoundException : " + dNFE.Message);
                return false;
            }
        }

        #endregion FillListView : Add files in listview with selected directory

        #region FillDrivesTreeView : Add drives in TreeViews

        private void FillDrivesTreeView(TreeView tVSource, TreeView tVDestination)
        {
            try
            {
                tVSource.Nodes.Clear();
                tVDestination.Nodes.Clear();

                var Drives = Environment.GetLogicalDrives();

                foreach (var drive in Drives)
                {
                    if (drive.CompareTo(@"A:\") != 0)
                    {
                        var tnDriveSource = new TreeNode(drive);
                        var tnDriveDestination = new TreeNode(drive);

                        switch (GetDriveType(drive))
                        {
                            case DriveType.Removeable:
                                tnDriveSource.ImageIndex = 3;
                                tnDriveSource.SelectedImageIndex = 3;
                                tnDriveDestination.ImageIndex = 3;
                                tnDriveDestination.SelectedImageIndex = 3;
                                break;

                            case DriveType.Fixed:
                                tnDriveSource.ImageIndex = 4;
                                tnDriveSource.SelectedImageIndex = 4;
                                tnDriveDestination.ImageIndex = 4;
                                tnDriveDestination.SelectedImageIndex = 4;
                                break;

                            case DriveType.Cdrom:
                                tnDriveSource.ImageIndex = 5;
                                tnDriveSource.SelectedImageIndex = 5;
                                tnDriveDestination.ImageIndex = 5;
                                tnDriveDestination.SelectedImageIndex = 5;
                                break;

                            default:
                                tnDriveSource.ImageIndex = 7;
                                tnDriveSource.SelectedImageIndex = 7;
                                tnDriveDestination.ImageIndex = 7;
                                tnDriveDestination.SelectedImageIndex = 7;
                                break;
                        }

                        tnDriveSource.Nodes.Add("");
                        tnDriveDestination.Nodes.Add("");

                        tVSource.Nodes.Add(tnDriveSource);
                        tVDestination.Nodes.Add(tnDriveDestination);
                    }
                }
            }
            catch (IOException iOE)
            {
                MessageBox.Show("(MainForm(FillDrivesTreeView))IOException : " + iOE.Message);
            }
            catch (SecurityException sE)
            {
                MessageBox.Show("(MainForm(FillDrivesTreeView))SecurityException : " + sE.Message);
            }
        }

        #endregion FillDrivesTreeView : Add drives in TreeViews

        #region FillDirectoryTreeView : Add directories in Treeview

        private bool FillDirectoryTreeView(TreeNode node)
        {
            try
            {
                node.Nodes.Clear();

                var path = node.FullPath;

                if (!Directory.Exists(path))
                {
                    return false;
                }

                var Folder = new DirectoryInfo(path);
                var subFolders = Folder.GetDirectories();

                foreach (var folder in subFolders)
                {
                    var directory = folder.Name;
                    directory = directory.ToUpper();

                    if (directory.CompareTo("RECYCLER") == 0 || directory.CompareTo("RECYCLED") == 0)
                    {
                        var tNFolder = new TreeNode(folder.Name, 2, 2)
                        {
                            BackColor = Color.Red
                        };

                        node.Nodes.Add(tNFolder);
                    }
                    else
                    {
                        var tNFolder = new TreeNode(folder.Name, 0, 1)
                        {
                            BackColor = Color.White
                        };

                        try
                        {
                            if (folder.GetDirectories().Length > 0)
                            {
                                tNFolder.Nodes.Add("");
                            }
                        }
                        catch (UnauthorizedAccessException)
                        {
                            tNFolder.BackColor = Color.Red;
                        }

                        node.Nodes.Add(tNFolder);
                    }
                }
                return true;
            }
            catch (SecurityException sE)
            {
                MessageBox.Show("(MainForm(FillDirectoryTreeView))SecurityException : " + sE.Message);
                return false;
            }
            catch (ArgumentNullException aNE)
            {
                MessageBox.Show("(MainForm(FillDirectoryTreeView))ArgumentNullException : " + aNE.Message);
                return false;
            }
            catch (ArgumentException aE)
            {
                MessageBox.Show("(MainForm(FillDirectoryTreeView))ArgumentException : " + aE.Message);
                return false;
            }
            catch (PathTooLongException pTLE)
            {
                MessageBox.Show("(MainForm(FillDirectoryTreeView))PathTooLongException : " + pTLE.Message);
                return false;
            }
            catch (DirectoryNotFoundException dNFE)
            {
                MessageBox.Show("(MainForm(FillDirectoryTreeView))DirectoryNotFoundException : " + dNFE.Message);
                return false;
            }
        }

        #endregion FillDirectoryTreeView : Add directories in Treeview

        #region CalculateSize : Calcul de la taille d'un fichier

        private string CalculateSize(long taille)
        {
            try
            {
                var tailleString = "";
                var tempModulo = "";
                var temp = "" + taille;
                long cptTaille;
                long modulo;
                var tailleNbre = temp.Length;
                int manquant;

                if (taille / 1000000000 > 0)
                {
                    cptTaille = taille / 1000000000;
                    tailleString = "" + cptTaille;

                    modulo = taille % 1000000000;
                    tempModulo = "" + modulo;

                    manquant = tailleNbre - tailleString.Length - tempModulo.Length;

                    for (var i = 0; i < manquant; i++)
                    {
                        tempModulo = tempModulo.Insert(0, "0");
                    }

                    if (tempModulo.Length > 3)
                    {
                        tempModulo = tempModulo.Substring(0, 3);
                    }

                    tailleString += "." + tempModulo + " Go";

                    return tailleString;
                }

                if (taille / 1000000 > 0)
                {
                    cptTaille = taille / 1000000;
                    tailleString = "" + cptTaille;

                    modulo = taille % 1000000;
                    tempModulo = "" + modulo;

                    manquant = tailleNbre - tailleString.Length - tempModulo.Length;

                    for (var i = 0; i < manquant; i++)
                    {
                        tempModulo = tempModulo.Insert(0, "0");
                    }

                    if (tempModulo.Length > 3)
                    {
                        tempModulo = tempModulo.Substring(0, 3);
                    }

                    tailleString += "." + tempModulo + " Mo";

                    return tailleString;
                }

                if (taille / 1000 > 0)
                {
                    cptTaille = taille / 1000;
                    tailleString = "" + cptTaille;

                    modulo = taille % 1000;
                    tempModulo = "" + modulo;

                    manquant = tailleNbre - tailleString.Length - tempModulo.Length;

                    for (var i = 0; i < manquant; i++)
                    {
                        tempModulo = tempModulo.Insert(0, "0");
                    }

                    if (tempModulo.Length > 3)
                    {
                        tempModulo = tempModulo.Substring(0, 3);
                    }

                    tailleString += "." + tempModulo + " Ko";

                    return tailleString;
                }

                tailleString = "" + taille + " octets";

                return tailleString;
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                MessageBox.Show("(MainForm(CalculateSize))ArgumentOutOfRangeException : " + aOORE.Message);
                return "";
            }
            catch (ArgumentNullException aNE)
            {
                MessageBox.Show("(MainForm(CalculateSize))ArgumentNullException : " + aNE.Message);
                return "";
            }
        }

        #endregion CalculateSize : Calcul de la taille d'un fichier

        #region MainFormLoad

        private void MainFormLoad(object sender, System.EventArgs e)
        {
            FillDrivesTreeView(this.tVSource, this.tVDestination);
        }

        #endregion MainFormLoad

        #region TVDestinationDragOver

        private void TVDestinationDragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        #endregion TVDestinationDragOver

        #region LVDestinationDragOver

        private void LVDestinationDragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        #endregion LVDestinationDragOver

        #region TVDestinationDragDrop

        private void TVDestinationDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                try
                {
                    if (this.openedFolderDestination != null)
                    {
                        var source = e.Data.GetData(DataFormats.StringFormat).ToString();
                        var destination = this.openedFolderDestination.FullPath;

                        this.Enabled = false;

                        this.tCopy = new Thread(new ThreadStart(FctThreadOccupation));
                        this.tCopy.Start();

                        FilesDirectoriesClass.Copy(source, destination, false);

                        this.tCopy.Abort();

                        this.Enabled = true;

                        FillFilesListView(this.openedFolderDestination, this.lVDestination);

                        if (this.openedFolderDestination.Parent != null)
                        {
                            this.openedFolderDestination.Parent.Collapse();
                            this.openedFolderDestination.Parent.Expand();
                        }
                        else
                        {
                            this.openedFolderDestination.Collapse();
                            this.openedFolderDestination.Expand();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez sélectionner un lecteur ou répertoire de destination");
                    }
                }
                catch (ArgumentNullException aNE)
                {
                    MessageBox.Show("(MainForm(TVDestinationDragDrop))ArgumentNullException : " + aNE.Message);
                }
                catch (ExceptionClass e371)
                {
                    MessageBox.Show("(MainForm(TVDestinationDragDrop)) : " + e371.Message);
                }
                catch (OutOfMemoryException oOME)
                {
                    MessageBox.Show("(MainForm(TVDestinationDragDrop))OutOfMemoryException : " + oOME.Message);
                }
                catch (SecurityException sE)
                {
                    MessageBox.Show("(MainForm(TVDestinationDragDrop))SecurityException : " + sE.Message);
                }
                catch (ThreadStateException tSE)
                {
                    MessageBox.Show("(MainForm(TVDestinationDragDrop))ThreadStateException : " + tSE.Message);
                }
            }
        }

        #endregion TVDestinationDragDrop

        #region LVDestinationDragDrop

        private void LVDestinationDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                try
                {
                    if (this.openedFolderDestination != null)
                    {
                        var source = e.Data.GetData(DataFormats.StringFormat).ToString();
                        var destination = this.openedFolderDestination.FullPath;

                        this.Enabled = false;

                        this.tCopy = new Thread(new ThreadStart(FctThreadOccupation));
                        this.tCopy.Start();

                        FilesDirectoriesClass.Copy(source, destination, false);

                        this.tCopy.Abort();

                        this.Enabled = true;

                        FillFilesListView(this.openedFolderDestination, this.lVDestination);

                        if (this.openedFolderDestination.Parent != null)
                        {
                            this.openedFolderDestination.Parent.Collapse();
                            this.openedFolderDestination.Parent.Expand();
                        }
                        else
                        {
                            this.openedFolderDestination.Collapse();
                            this.openedFolderDestination.Expand();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez sélectionner un lecteur ou répertoire de destination");
                    }
                }
                catch (ArgumentNullException aNE)
                {
                    MessageBox.Show("(MainForm(LVDestinationDragDrop))ArgumentNullException : " + aNE.Message);
                }
                catch (ExceptionClass e371)
                {
                    MessageBox.Show("(MainForm(LVDestinationDragDrop)) : " + e371.Message);
                }
                catch (OutOfMemoryException oOME)
                {
                    MessageBox.Show("(MainForm(LVDestinationDragDrop))OutOfMemoryException : " + oOME.Message);
                }
                catch (SecurityException sE)
                {
                    MessageBox.Show("(MainForm(LVDestinationDragDrop))SecurityException : " + sE.Message);
                }
                catch (ThreadStateException tSE)
                {
                    MessageBox.Show("(MainForm(LVDestinationDragDrop))ThreadStateException : " + tSE.Message);
                }
            }
        }

        #endregion LVDestinationDragDrop

        #region FctThreadOccupation

        private void FctThreadOccupation()
        {
            var occupation = new OccupationForm("Veuillez patienter copie en cours...");
            occupation.ShowDialog();
        }

        #endregion FctThreadOccupation

        #region DeleteFiles

        private void DeleteFiles(ArrayList lviCollectionFichiers, TreeNode openedPath, ListView listViewFichiers, TreeView treeViewRépertoires)
        {
            if (listViewFichiers.SelectedIndices.Count != 0)
            {
                var all = false;
                var noAll = false;

                foreach (string file in lviCollectionFichiers)
                {
                    var deleteFileName = treeViewRépertoires.SelectedNode.FullPath + Path.DirectorySeparatorChar + file;

                    try
                    {
                        if (!all)
                        {
                            this.suppMessage = "Fichier : " + deleteFileName;

                            var fMBRC = new FullMessageBoxResponseClass();
                            var fMBF = new FullMessageBoxForm("Etes-vous sûr de vouloir supprimer ce fichier?\r\nFichier : " + this.suppMessage, "Suppression de fichier", fMBRC);
                            fMBF.ShowDialog();

                            switch (fMBRC.Response)
                            {
                                case 0:
                                    FilesDirectoriesClass.Delete(deleteFileName);
                                    break;

                                case 2:
                                    all = true;
                                    FilesDirectoriesClass.Delete(deleteFileName);
                                    break;

                                case 3:
                                    noAll = true;
                                    break;
                            }
                            fMBF.Close();
                        }
                        else
                        {
                            FilesDirectoriesClass.Delete(deleteFileName);
                        }

                        if (noAll)
                        {
                            break;
                        }

                        FillFilesListView(openedPath, listViewFichiers);
                    }
                    catch (ExceptionClass e371)
                    {
                        MessageBox.Show("(MainForm(DeleteFiles) : " + e371.Message);
                    }
                }
            }
        }

        #endregion DeleteFiles

        #region RenameFiles

        private void RenameFiles(ListView listViewFichiers, ArrayList lviCollectionFichiers, TreeView treeViewRépertoires, TreeNode openedPath)
        {
            try
            {
                this.renameCancel = false;

                if (listViewFichiers.SelectedIndices.Count != 0)
                {
                    this.oldName = "" + lviCollectionFichiers[0];

                    var frename = new RenameForm(this);
                    frename.ShowDialog();

                    if (!this.renameCancel)
                    {
                        if (this.NewName.Length != 0)
                        {
                            var oldFileName = treeViewRépertoires.SelectedNode.FullPath + Path.DirectorySeparatorChar + lviCollectionFichiers[0];
                            var newFileName = treeViewRépertoires.SelectedNode.FullPath + Path.DirectorySeparatorChar + this.NewName;

                            FilesDirectoriesClass.Rename(oldFileName, newFileName);

                            FillFilesListView(openedPath, listViewFichiers);
                        }
                    }
                }
            }
            catch (ExceptionClass e371)
            {
                MessageBox.Show("(MainForm(RenameFiles) : " + e371.Message);
            }
        }

        #endregion RenameFiles

        #region RenameFileTSMISourceClick

        private void RenameFileTSMISourceClick(object sender, System.EventArgs e)
        {
            if (this.lviCollectionSource != null && this.lviCollectionSource.Count != 0 && this.lviCollectionSource.Count == 1)
            {
                RenameFiles(this.lVSource, this.lviCollectionSource, this.tVSource, this.openedFolderSource);
            }
        }

        #endregion RenameFileTSMISourceClick

        #region DeleteFileTSMISourceClick

        private void DeleteFileTSMISourceClick(object sender, System.EventArgs e)
        {
            if (this.lviCollectionSource != null && this.lviCollectionSource.Count != 0)
            {
                DeleteFiles(this.lviCollectionSource, this.openedFolderSource, this.lVSource, this.tVSource);
            }
        }

        #endregion DeleteFileTSMISourceClick

        #region RenameFileTSMIDestinationClick

        private void RenameFileTSMIDestinationClick(object sender, System.EventArgs e)
        {
            if (this.lviCollectionDestination != null && this.lviCollectionDestination.Count != 0 && this.lviCollectionDestination.Count == 1)
            {
                RenameFiles(this.lVDestination, this.lviCollectionDestination, this.tVDestination, this.openedFolderDestination);
            }
        }

        #endregion RenameFileTSMIDestinationClick

        #region DeleteFileTSMIDestinationClick

        private void DeleteFileTSMIDestinationClick(object sender, System.EventArgs e)
        {
            if (this.lviCollectionDestination != null && this.lviCollectionDestination.Count != 0)
            {
                DeleteFiles(this.lviCollectionDestination, this.openedFolderDestination, this.lVDestination, this.tVDestination);
            }
        }

        #endregion DeleteFileTSMIDestinationClick

        #region DeleteDirectories

        private void DeleteDirectories(TreeView treeViewRépertoires, TreeNode openedPath)
        {
            var deleteDirectoryName = treeViewRépertoires.SelectedNode.FullPath;

            if (deleteDirectoryName.Length != 3)
            {
                if (DialogResult.Yes == MessageBox.Show("Répertoire : " + deleteDirectoryName, "Voulez-vous supprimer ce répertoire ?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                {
                    try
                    {
                        FilesDirectoriesClass.Delete(deleteDirectoryName);
                    }
                    catch (ExceptionClass e371)
                    {
                        MessageBox.Show("(MainForm(DeleteDirectories) : " + e371.Message);
                    }

                    if (openedPath.Parent != null)
                    {
                        openedPath.Parent.Collapse();
                        openedPath.Parent.Expand();
                    }
                    else
                    {
                        openedPath.Collapse();
                        openedPath.Expand();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vous ne pouvez pas supprimer un lecteur");
            }
        }

        #endregion DeleteDirectories

        #region RenameDirectories

        private void RenameDirectories(TreeView treeViewRépertoires, ListView listViewFichiers, TreeNode openedPath)
        {
            this.renameCancel = false;

            var fullPathDirectory = treeViewRépertoires.SelectedNode.FullPath;

            this.oldName = fullPathDirectory.Substring(fullPathDirectory.LastIndexOf(@"\") + 1);

            if (fullPathDirectory.Length != 3)
            {
                var frename = new RenameForm(this);
                frename.ShowDialog();

                if (!this.renameCancel)
                {
                    if (this.NewName.Length != 0)
                    {
                        if (this.NewName.IndexOf(@".") == -1)
                        {
                            if (this.NewName.Length != 0)
                            {
                                try
                                {
                                    FilesDirectoriesClass.Rename(fullPathDirectory, this.NewName);
                                }
                                catch (ExceptionClass e371)
                                {
                                    MessageBox.Show("(MainForm(RenameDirectories) : " + e371.Message);
                                }

                                FillFilesListView(openedPath.Parent, listViewFichiers);

                                openedPath.Parent.Collapse();
                                openedPath.Parent.Expand();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vous ne pouvez pas mettre un point dans le nouveau nom de répertoire");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vous ne pouvez pas renommer un lecteur");
            }
        }

        #endregion RenameDirectories

        #region RenameDirectoryTSMISourceClick

        private void RenameDirectoryTSMISourceClick(object sender, System.EventArgs e)
        {
            if (this.tVSource.SelectedNode != null)
            {
                RenameDirectories(this.tVSource, this.lVSource, this.openedFolderSource);
            }
        }

        #endregion RenameDirectoryTSMISourceClick

        #region DeleteDirectoryTSMISourceClick

        private void DeleteDirectoryTSMISourceClick(object sender, System.EventArgs e)
        {
            if (this.tVSource.SelectedNode != null)
            {
                DeleteDirectories(this.tVSource, this.openedFolderSource);
            }
        }

        #endregion DeleteDirectoryTSMISourceClick

        #region RenameDirectoryTSMIDestinationClick

        private void RenameDirectoryTSMIDestinationClick(object sender, System.EventArgs e)
        {
            if (this.tVDestination.SelectedNode != null)
            {
                RenameDirectories(this.tVDestination, this.lVDestination, this.openedFolderDestination);
            }
        }

        #endregion RenameDirectoryTSMIDestinationClick

        #region DeleteDirectoryTSMIDestinationClick

        private void DeleteDirectoryTSMIDestinationClick(object sender, System.EventArgs e)
        {
            if (this.tVDestination.SelectedNode != null)
            {
                DeleteDirectories(this.tVDestination, this.openedFolderDestination);
            }
        }

        #endregion DeleteDirectoryTSMIDestinationClick

        #region MainFormFormClosed

        private void MainFormFormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if (this.tCopy != null)
            {
                this.tCopy.Abort();
            }
        }

        #endregion MainFormFormClosed

        #region CompareFiles

        private bool CompareFiles(string source, string destination)
        {
            var filessourcebrut = Directory.GetFiles(source);
            var filesdestinationbrut = Directory.GetFiles(destination);

            var filessource = "";
            var filesdestination = "";
            var fullPathDestination = "";

            long taillesource, tailledestination;

            DateTime fileSourceModif, fileDestinationModif;

            bool trouve;

            fullPathDestination = destination;

            foreach (var pathFileSource in filessourcebrut)
            {
                var fInfoSource = new FileInfo(pathFileSource);

                filessource = fInfoSource.Name;
                taillesource = fInfoSource.Length;
                fileSourceModif = fInfoSource.LastWriteTime;

                trouve = false;

                foreach (var pathFileDestination in filesdestinationbrut)
                {
                    var fInfoDestination = new FileInfo(pathFileDestination);

                    filesdestination = fInfoDestination.Name;
                    tailledestination = fInfoDestination.Length;
                    fileDestinationModif = fInfoDestination.LastWriteTime;

                    if (filessource.CompareTo(filesdestination) == 0)
                    {
                        if (taillesource == tailledestination)
                        {
                            if (fileSourceModif == fileDestinationModif)
                            {
                                trouve = true;

                                break;
                            }
                            else
                            {
                                if (DialogResult.Yes == MessageBox.Show("Voulez-vous écraser le fichier : \nNom : " + fullPathDestination + Path.DirectorySeparatorChar + filesdestination + "\nTaille : " + CalculateSize(tailledestination) + "\nDate de modification : " + fileDestinationModif + "\n\npar le fichier : \nNom : " + filessource + "\nTaille : " + CalculateSize(taillesource) + "\nDate de modification : " + fileSourceModif, "Différence de date", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                                {
                                    FilesDirectoriesClass.Copy(pathFileSource, fullPathDestination + Path.DirectorySeparatorChar + filessource, true);
                                }

                                trouve = true;

                                this.differentDirectory = true;

                                break;
                            }
                        }
                        else
                        {
                            if (DialogResult.Yes == MessageBox.Show("Voulez-vous écraser le fichier : \nNom : " + fullPathDestination + Path.DirectorySeparatorChar + filesdestination + "\nTaille : " + CalculateSize(tailledestination) + "\nDate de modification : " + fileDestinationModif + "\n\npar le fichier : \nNom : " + filessource + "\nTaille : " + CalculateSize(taillesource) + "\nDate de modification : " + fileSourceModif, "Différence de taille", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                            {
                                FilesDirectoriesClass.Copy(pathFileSource, fullPathDestination + Path.DirectorySeparatorChar + filessource, true);
                            }

                            this.differentDirectory = true;

                            trouve = true;

                            break;
                        }
                    }
                    else
                    {
                        trouve = false;
                    }
                }

                if (trouve == false)
                {
                    if (DialogResult.Yes == MessageBox.Show("Voulez-vous copier le fichier dont le nom est : " + filessource + "\n dans le répertoire : " + fullPathDestination, "Fichier inexistant", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                    {
                        FilesDirectoriesClass.Copy(pathFileSource, fullPathDestination + Path.DirectorySeparatorChar + filessource, true);
                    }

                    this.differentDirectory = true;
                }
            }

            return true;
        }

        #endregion CompareFiles

        #region CompareDirectories

        private void CompareDirectories(string pathDirectorySource, string pathDirectoryDestination)
        {
            CompareFiles(pathDirectorySource, pathDirectoryDestination);

            var subdirSource = Directory.GetDirectories(pathDirectorySource);

            foreach (var subdir in subdirSource)
            {
                var di = new DirectoryInfo(subdir);

                var source = pathDirectorySource + Path.DirectorySeparatorChar + di.Name;
                var destination = pathDirectoryDestination + Path.DirectorySeparatorChar + di.Name;

                if (Directory.Exists(destination))
                {
                    CompareDirectories(source, destination);
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Voulez-vous copier le répertoire dont le nom est : \n" + di.Name + "\n dans le répertoire : \n" + pathDirectoryDestination, "Répertoire inexistant", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                    {
                        FilesDirectoriesClass.CopyDirectory(source, destination);
                    }

                    this.differentDirectory = true;
                }
            }
        }

        #endregion CompareDirectories

        #region BCompareAfterCopyClick

        private void BCompareAfterCopyClick(object sender, System.EventArgs e)
        {
            if (this.openedFolderSource != null && this.openedFolderDestination != null)
            {
                var source = this.openedFolderSource.FullPath;
                var destination = this.openedFolderDestination.FullPath;

                if (source.Length != 3 && destination.Length != 3)
                {
                    this.differentDirectory = false;

                    CompareDirectories(source, destination);

                    FillFilesListView(this.openedFolderDestination, this.lVDestination);

                    if (!this.differentDirectory)
                    {
                        MessageBox.Show("Les répertoires sont identiques");
                    }
                    else
                    {
                        MessageBox.Show("Les répertoires comportaient des différences. Refaites une comparaison pour être sur qu'ils sont identiques maintenant");
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez sélectionner un répertoire et non un lecteur");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un répertoire de chaque coté pour la comparaison");
            }
        }

        #endregion BCompareAfterCopyClick

        #region BCompareBackupClick

        private void BCompareBackupClick(object sender, System.EventArgs e)
        {
            if (this.openedFolderSource != null && this.openedFolderDestination != null)
            {
                var source = this.openedFolderSource.FullPath;
                var destination = this.openedFolderDestination.FullPath;

                if (source.Length != 3 && destination.Length != 3)
                {
                    this.differentDirectory = false;

                    CompareDirectories(source, destination);
                    CompareDirectories(destination, source);

                    FillFilesListView(this.openedFolderSource, this.lVSource);
                    FillFilesListView(this.openedFolderDestination, this.lVDestination);

                    if (!this.differentDirectory)
                    {
                        MessageBox.Show("Les répertoires sont identiques");
                    }
                    else
                    {
                        MessageBox.Show("Les répertoires comportaient des différences. Refaites une comparaison pour être sur qu'ils sont identiques maintenant");
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez sélectionner un répertoire et non un lecteur");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un répertoire de chaque coté pour la comparaison");
            }
        }

        #endregion BCompareBackupClick

        #region CreateDirectory

        private void CreateDirectory(TreeView treeViewRépertoires, TreeNode openedPath)
        {
            try
            {
                var fcreate = new CreateForm(this);
                fcreate.ShowDialog();

                if (this.NewName.Length != 0)
                {
                    FilesDirectoriesClass.CreateDirectory(treeViewRépertoires.SelectedNode.FullPath + this.NewName);

                    if (openedPath.Parent != null)
                    {
                        openedPath.Parent.Collapse();
                        openedPath.Parent.Expand();
                    }
                    else
                    {
                        openedPath.Collapse();
                        openedPath.Expand();
                    }
                }
            }
            catch (ExceptionClass e371)
            {
                MessageBox.Show("(MainForm(createDirectory) : " + e371.Message);
            }
        }

        #endregion CreateDirectory

        #region CreateDirectoryTSMISourceClick

        private void CreateDirectoryTSMISourceClick(object sender, System.EventArgs e)
        {
            CreateDirectory(this.tVSource, this.openedFolderSource);
        }

        #endregion CreateDirectoryTSMISourceClick

        #region CreateDirectoryTSMIDestinationClick

        private void CreateDirectoryTSMIDestinationClick(object sender, System.EventArgs e)
        {
            CreateDirectory(this.tVDestination, this.openedFolderDestination);
        }

        #endregion CreateDirectoryTSMIDestinationClick

        #region BNumericRenameSourceClick

        private void BNumericRenameSourceClick(object sender, System.EventArgs e)
        {
            try
            {
                if (this.lVSource.SelectedIndices.Count != 0)
                {
                    if (this.tBNewNameSource.Text.Length != 0 && this.tBNewNameSource.Text.IndexOf("%") != -1)
                    {
                        var cpt = Convert.ToInt32(this.tBNumericSource.Text);

                        foreach (int index in this.lVSource.SelectedIndices)
                        {
                            var directory = this.tVSource.SelectedNode.FullPath;

                            var fileFullPath = directory + Path.DirectorySeparatorChar + this.lVSource.Items[index].Text;
                            string newfileFullPath;

                            var fileName = this.tBNewNameSource.Text;

                            var splitFileName = fileName.Split(@"%".ToCharArray());

                            newfileFullPath = directory + Path.DirectorySeparatorChar;

                            for (var i = 0; i < splitFileName.Length; i++)
                            {
                                if (i < splitFileName.Length - 1)
                                {
                                    newfileFullPath += splitFileName[i] + cpt;
                                }
                                else
                                {
                                    newfileFullPath += splitFileName[i];
                                }
                            }

                            FilesDirectoriesClass.Rename(fileFullPath, newfileFullPath);

                            cpt++;
                        }

                        this.tBNewNameSource.Text = "";
                        this.tBNumericSource.Text = "";

                        FillFilesListView(this.tVSource.SelectedNode, this.lVSource);
                    }
                    else
                    {
                        MessageBox.Show("Veuillez encoder le nouveau nom de fichier contenant un % pour le nombre");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner le ou les fichiers à renommer");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vous n'avez pas encondé un bon nombre de début");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Vous n'avez pas encondé un bon nombre de début");
            }
        }

        #endregion BNumericRenameSourceClick

        #region BNumericRenameDestinationClick

        private void BNumericRenameDestinationClick(object sender, System.EventArgs e)
        {
            try
            {
                if (this.lVDestination.SelectedIndices.Count != 0)
                {
                    if (this.tBNewNameDestination.Text.Length != 0 && this.tBNewNameDestination.Text.IndexOf("%") != -1)
                    {
                        var cpt = Convert.ToInt32(this.tBNumericDestination.Text);

                        foreach (int index in this.lVDestination.SelectedIndices)
                        {
                            var directory = this.tVDestination.SelectedNode.FullPath;

                            var fileFullPath = directory + Path.DirectorySeparatorChar + this.lVDestination.Items[index].Text;
                            string newfileFullPath;

                            var fileName = this.tBNewNameDestination.Text;

                            var splitFileName = fileName.Split(@"%".ToCharArray());

                            newfileFullPath = directory + Path.DirectorySeparatorChar;

                            for (var i = 0; i < splitFileName.Length; i++)
                            {
                                if (i < splitFileName.Length - 1)
                                {
                                    newfileFullPath += splitFileName[i] + cpt;
                                }
                                else
                                {
                                    newfileFullPath += splitFileName[i];
                                }
                            }

                            FilesDirectoriesClass.Rename(fileFullPath, newfileFullPath);

                            cpt++;
                        }

                        this.tBNewNameDestination.Text = "";
                        this.tBNumericDestination.Text = "";

                        FillFilesListView(this.tVDestination.SelectedNode, this.lVDestination);
                    }
                    else
                    {
                        MessageBox.Show("Veuillez encoder le nouveau nom de fichier contenant un % pour le nombre");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner le ou les fichiers à renommer");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vous n'avez pas encondé un bon nombre de début");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Vous n'avez pas encondé un bon nombre de début");
            }
        }

        #endregion BNumericRenameDestinationClick

        #region LVSourceKeyDown

        private void LVSourceKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (this.lviCollectionSource != null && this.lviCollectionSource.Count != 0 && this.lviCollectionSource.Count == 1)
                    {
                        RenameFiles(this.lVSource, this.lviCollectionSource, this.tVSource, this.openedFolderSource);
                    }

                    break;

                case Keys.Delete:
                    if (this.lviCollectionSource != null && this.lviCollectionSource.Count != 0)
                    {
                        DeleteFiles(this.lviCollectionSource, this.openedFolderSource, this.lVSource, this.tVSource);
                    }

                    break;

                default:
                    break;
            }
        }

        #endregion LVSourceKeyDown

        #region LVDestinationKeyDown

        private void LVDestinationKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (this.lviCollectionDestination != null && this.lviCollectionDestination.Count != 0 && this.lviCollectionDestination.Count == 1)
                    {
                        RenameFiles(this.lVDestination, this.lviCollectionDestination, this.tVDestination, this.openedFolderDestination);
                    }

                    break;

                case Keys.Delete:
                    if (this.lviCollectionDestination != null && this.lviCollectionDestination.Count != 0)
                    {
                        DeleteFiles(this.lviCollectionDestination, this.openedFolderDestination, this.lVDestination, this.tVDestination);
                    }

                    break;

                default:
                    break;
            }
        }

        #endregion LVDestinationKeyDown

        #region TVSourceKeyDown

        private void TVSourceKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (this.tVSource.SelectedNode != null)
                    {
                        RenameDirectories(this.tVSource, this.lVSource, this.openedFolderSource);
                    }

                    break;

                case Keys.Delete:
                    if (this.tVSource.SelectedNode != null)
                    {
                        DeleteDirectories(this.tVSource, this.openedFolderSource);
                    }

                    break;

                default:
                    break;
            }
        }

        #endregion TVSourceKeyDown

        #region TVDestinationKeyDown

        private void TVDestinationKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (this.tVDestination.SelectedNode != null)
                    {
                        RenameDirectories(this.tVDestination, this.lVDestination, this.openedFolderDestination);
                    }

                    break;

                case Keys.Delete:
                    if (this.tVDestination.SelectedNode != null)
                    {
                        DeleteDirectories(this.tVDestination, this.openedFolderDestination);
                    }

                    break;

                default:
                    break;
            }
        }

        #endregion TVDestinationKeyDown
    }
}