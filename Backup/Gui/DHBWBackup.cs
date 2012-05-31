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
        }

        void ExListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ExplorerListItem item = e.Item as ExplorerListItem;
            if (item.Checked)
            {
                if (item.DirInfo != null)
                {
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
                    Controller.SelectedDirs.Remove(new BackupFileInfo(item.DirInfo));
                }
                else
                {
                    Controller.SelectedFiles.Remove(new BackupFileInfo(item.FileIn));
                }
            }
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
            backupWorker.RunWorkerAsync();
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
            RestoreBackup restoreWindow = new RestoreBackup();
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
            if (Controller.Destination != null)
            {
                Controller.startBackup(backupWorker);
            }
        }

        private void backupWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbStatus.Value = e.ProgressPercentage;
        }

        private void backupWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pgbStatus.Value = 0;
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

    }
}
