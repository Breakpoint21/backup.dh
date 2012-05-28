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
            Controller.startBackup();
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

    }
}
