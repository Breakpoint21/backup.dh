using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Backup.Core;

namespace Backup.Gui
{
    public partial class DHBWBackup : Form
    {
        private BackupController controller;

        public BackupController Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        public DHBWBackup()
        {
            Controller = BackupController.getInstance();
            InitializeComponent();
            this.cbxFilter.SelectedIndex = 0;
            this.explorer1.ExplorerTreeV.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.ExplorerTreeV_NodeMouseClick);
            this.explorerList1.ExListView.ItemChecked += new ItemCheckedEventHandler(ExListView_ItemChecked);
            this.explorerList1.PropertyChanged += new PropertyChangedEventHandler(currentDirectoryChanged);
        }

        void currentDirectoryChanged(object sender, PropertyChangedEventArgs e)
        {
            this.txtExplorerPath.Text = explorerList1.CurrentDir.FullName;
        }

        void ExListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ExplorerListItem item = e.Item as ExplorerListItem;
            if (item.Checked)
            {
                if (item.DirInfo != null)
                {
                    //Controller.AddDirectory(item.DirInfo);
                    Controller.SelectedDirs.Add(new BackupFileInfo(item.DirInfo));    
                }
                else
                {
                    Controller.SelectedFiles.Add(new BackupFileInfo(item.FileIn));
                }
            }
            else
            {
                if (item.DirInfo != null)
                {
                    //Controller.RemoveDirectory(item.DirInfo);
                    Controller.SelectedDirs.Remove(new BackupFileInfo(item.DirInfo));
                }
                else
                {
                    Controller.SelectedFiles.Remove(new BackupFileInfo(item.FileIn));
                }
            }
            UpdateSelectedItemsLabel();
        }

        private void UpdateSelectedItemsLabel()
        {
            int selected = 0;
            selected += Controller.SelectedFiles.Count;
            //FetchingService service = new FetchingService();
            //foreach (BackupFileInfo dir in Controller.SelectedDirs)
            //{
            //    selected += service.FetchAllFiles(dir.DirInfo).Count;
            //}
            lblNumbSel.Text = selected.ToString();
        }
        
        private void ExplorerTreeV_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ExplorerTreeNode node = (ExplorerTreeNode)e.Node;
            this.explorerList1.fillListView(node.Directory);
        }

        private void menuButtonBack_Click(object sender, EventArgs e)
        {
            this.explorerList1.DirectoryBack();
        }

        private void startBackupLabel_Click(object sender, EventArgs e)
        {
            if (Controller.Destination != null)
            {
                backupWorker.RunWorkerAsync();   
            }
            else
            {
                dstToolTip.SetToolTip(toolStrip1, "");
                dstToolTip.Show("Please select a Destination first", toolStrip1, 1000);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog dia = new SaveFileDialog();
            dia.Title = "Backup Destination";
            dia.DefaultExt = "dhbw";
            DialogResult result = dia.ShowDialog();
            if (result == DialogResult.OK)
            {
                Controller.Destination = new FileInfo(dia.FileName);
                txtBackupDestination.Text = dia.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            RestoreBackup restoreWindow;
            if (Controller.Destination != null)
            {
                restoreWindow = new RestoreBackup(Controller.Destination.FullName);
            }
            else
            {
                restoreWindow = new RestoreBackup(string.Empty);
            }
            restoreWindow.Show(this);
        }

        private void DHBWBackup_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void DHBWBackup_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = e.Data.GetData(DataFormats.FileDrop) as string[];
            foreach (string file in fileNames)
            {
                Controller.SelectedFiles.Add(new BackupFileInfo(new FileInfo(file)));
            }
        }

        private void backupWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Controller.startBackup(backupWorker);
        }

        private void backupWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbStatus.Value = e.ProgressPercentage;
        }

        private void backupWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool result = (bool)e.Result;
            pgbStatus.Value = 0;
            if (result)
            {
                MessageBox.Show(Controller.BuildSummary(), "Backup Completed", MessageBoxButtons.OK);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchController srchCtrl = new SearchController();
                List<ExplorerListItem> matches = srchCtrl.Search(explorerList1.CurrentDir, txtSearch.Text ,(SearchController.SearchModus)cbxFilter.SelectedIndex);
                explorerList1.fillListView(matches);
            }
        }

        private void txtBackupDestination_Click(object sender, EventArgs e)
        {
            btnBrowse_Click(null, EventArgs.Empty);
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.SelectionLength == 0)
            {
                txtSearch.SelectAll();  
            }
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.Filter = "Backup Files|*.dhbw";
            DialogResult result = dia.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                RestoreBackup restore = new RestoreBackup(dia.FileName);
                restore.Show();
            }
        }
    }
}
