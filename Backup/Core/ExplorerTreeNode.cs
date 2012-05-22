using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Backup.Core
{
    class ExplorerTreeNode : TreeNode, IEquatable<ExplorerTreeNode>
    {
        private DirectoryInfo directory;

        public DirectoryInfo Directory
        {
            get { return directory; }
            set { directory = value; }
        }

        public ExplorerTreeNode (DirectoryInfo directory)
        {
            Directory = directory;
            this.Text = directory.Name;
            this.Name = directory.FullName;
            if (directory.Parent == null)
            {
                this.ImageKey = "Hard_Drive.png";
            }
            else
            {
                this.ImageKey = "FolderOpen_16x16_72.png";
            }
            this.SelectedImageKey = this.ImageKey;
        }

        public bool Equals(ExplorerTreeNode otherNode)
        {
            if (this.Directory.FullName == otherNode.Directory.FullName && this.Text == otherNode.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
