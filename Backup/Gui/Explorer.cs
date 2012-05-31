using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Backup.Core;

namespace Backup.Gui
{
    public partial class Explorer : UserControl
    {
        private TreeView explorerTreeV = null;

        public TreeView ExplorerTreeV
        {
            get { return explorerTreeV; }
            set { explorerTreeV = value; }
        }
        
        public Explorer()
        {
            InitializeComponent();
            prepareTreeView();
        }

        private void prepareTreeView()
        {
            ExplorerTreeV = explorerTreeView;
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType != DriveType.CDRom && drive.DriveType != DriveType.Ram && drive.DriveType != DriveType.Unknown)
                {
                    explorerTreeView.Nodes.Add(new ExplorerTreeNode(drive.RootDirectory));
                }
            }
            DirectoryInfo user = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            explorerTreeView.Nodes.Add(new ExplorerTreeNode(user));
            DirectoryInfo docs = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            explorerTreeView.Nodes.Add(new ExplorerTreeNode(docs));
            foreach (ExplorerTreeNode treeNode in explorerTreeView.Nodes)
            {
                FetchSubDirectorys(treeNode);
            }
        }

        private void FetchSubDirectorys(ExplorerTreeNode selectedNode)
        {
            FetchingService fetchServ = new FetchingService();
            foreach (DirectoryInfo dir in fetchServ.FetchDirectories(selectedNode.Directory))
            {
                if (!selectedNode.Nodes.ContainsKey(dir.FullName))
                {
                    selectedNode.Nodes.Add(new ExplorerTreeNode(dir));
                }
            }
        }

        private void explorerTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            ExplorerTreeNode selectedNode = (ExplorerTreeNode)e.Node;
            foreach (ExplorerTreeNode treeNode in selectedNode.Nodes)
            {
                FetchSubDirectorys(selectedNode);
            }
        }
    }
}
