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
            FetchingService fetchServ = new FetchingService();
            foreach (ExplorerTreeNode treeNode in explorerTreeView.Nodes)
            {
                foreach (DirectoryInfo dir in fetchServ.FetchDirectories(treeNode.Directory))
                {
                    if (!treeNode.Nodes.ContainsKey(dir.FullName))
                    {
                        treeNode.Nodes.Add(new ExplorerTreeNode(dir));
                    }
                }
            }
        }

        private void FetchSubDirectorys(ExplorerTreeNode treeNode)
        {
            try
            {
                int attr = (int)treeNode.Directory.Attributes;
                if (attr != 9238 && attr != 8211 && attr != 8214 && (attr != 22 || treeNode.Directory.Parent == null))
                {
                    DirectoryInfo[] directorys = treeNode.Directory.GetDirectories("*", SearchOption.TopDirectoryOnly);
                    if (directorys.Length > 0)
                    {
                        foreach (DirectoryInfo _dir in directorys)
                        {
                            if (!treeNode.Nodes.ContainsKey(_dir.FullName))
                            {
                                int att = (int)_dir.Attributes;
                                if (att != 9238 && att != 8211 && att != 8214 && (att != 22 || _dir.Parent == null))
                                {
                                    treeNode.Nodes.Add(new ExplorerTreeNode(_dir));
                                }
                            }
                        }
                    }
                }
                
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Access denied " + treeNode.Directory.Name);
            }
            
        }

        private void explorerTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //ExplorerTreeNode selectedNode = (ExplorerTreeNode)e.Node;
            //foreach (ExplorerTreeNode subNode in selectedNode.Nodes)
            //{
            //    FetchSubDirectorys(subNode);
            //}
            //FetchSubDirectorys(selectedNode);
            //listView1.Items.Clear();
            //DirectoryInfo nodeDirInfo = new DirectoryInfo(newSelected.FilePath);
            //ListViewItem.ListViewSubItem[] subItems;
            //ListViewItem item = null;

            //foreach (DirectoryInfo _dir in selectedNode.Directory.GetDirectories())
            //{
            //    if (!selectedNode.Nodes.ContainsKey(_dir.FullName))
            //    {
            //        selectedNode.Nodes.Add(new ExplorerTreeNode(_dir));
            //    }
                
                //item = new ListViewItem(_dir.Name, 0);
                //subItems = new ListViewItem.ListViewSubItem[]
                //    {new ListViewItem.ListViewSubItem(item, "Directory"), 
                //     new ListViewItem.ListViewSubItem(item, _dir.LastAccessTime.ToShortDateString())};
                //item.SubItems.AddRange(subItems);
                //listView1.Items.Add(item);
            //}
            //foreach (FileInfo file in nodeDirInfo.GetFiles())
            //{
            //    item = new ListViewItem(file.Name, 1);
            //    subItems = new ListViewItem.ListViewSubItem[]
            //        { new ListViewItem.ListViewSubItem(item, "File"), 
            //         new ListViewItem.ListViewSubItem(item, 
            //            file.LastAccessTime.ToShortDateString())};

            //    item.SubItems.AddRange(subItems);
            //    listView1.Items.Add(item);
            //}

            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void explorerTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            ExplorerTreeNode selectedNode = (ExplorerTreeNode)e.Node;
            foreach (ExplorerTreeNode subNode in selectedNode.Nodes)
            {
                FetchSubDirectorys(subNode);
            }
        }


    }
}
