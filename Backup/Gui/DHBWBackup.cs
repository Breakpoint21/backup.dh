using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

        public DHBWBackup(BackupController controller)
        {
            Controller = controller;
            InitializeComponent();
            this.explorer1.ExplorerTreeV.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.ExplorerTreeV_NodeMouseClick);
            this.explorerList1.ExListView.ItemChecked += new ItemCheckedEventHandler(ExListView_ItemChecked);
        }

        void ExListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ExplorerListItem item = e.Item as ExplorerListItem;
            if (item.Checked)
            {
                Controller.SelectedDirs.Add(item.DirInfo);
            }
            else
            {
                Controller.SelectedDirs.Remove(item.DirInfo);
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
    }
}
