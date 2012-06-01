using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Backup.Core
{
    class ExplorerListItem : ListViewItem
    {
        private DirectoryInfo dirInfo;
        private FileInfo fileIn;
        private DirectoryInfo parentDir;

        private BackupController controller = BackupController.getInstance();
        
        public ExplorerListItem(DriveInfo driveInfo)
        {
            DirInfo = driveInfo.RootDirectory;
            ParentDir = driveInfo.RootDirectory;
            if (driveInfo.IsReady)
            {
                this.Text = driveInfo.Name;
                this.ImageIndex = 2;
            }
            this.SubItems.Add("");
            this.SubItems.Add(string.Format("{0:0.0} GB", ((double)driveInfo.TotalSize / (double)(1024 * 1024 * 1024))));
        }

        public ExplorerListItem(DirectoryInfo dirInfo)
        {
            if (controller.SelectedDirs.Contains(new BackupFileInfo(dirInfo)))
            {
                this.Checked = true;
            }
            this.ParentDir = dirInfo.Parent;
            this.DirInfo = dirInfo;
            this.Text = dirInfo.Name;
            
            this.SubItems.Add("Directory");
            this.SubItems.Add(string.Empty);
            this.SubItems.Add(dirInfo.LastWriteTime.ToShortDateString());
        }

        public ExplorerListItem(FileInfo file)
        {
            ParentDir = file.Directory;
            this.FileIn = file;
            this.Text = file.Name;
            if (controller.Selected.ContainsKey(file.FullName.GetHashCode()))
            {
                this.Checked = true;
            }

            this.SubItems.Add(file.Extension);
            long size = file.Length;
            if (size > 1024)
            {
                this.SubItems.Add(string.Format("{0:n0} KB", (size/ 1024)));    
            }
            else
            {
                this.SubItems.Add(string.Format("{0:n0} B", size));    
            }
            
            this.SubItems.Add(file.LastWriteTime.ToShortDateString());
        }

        #region properties
        public DirectoryInfo ParentDir
        {
            get { return parentDir; }
            set { parentDir = value; }
        }

        public DirectoryInfo DirInfo
        {
            get { return dirInfo; }
            set { dirInfo = value; }
        }

        public FileInfo FileIn
        {
            get { return fileIn; }
            set { fileIn = value; }
        }
        #endregion
    }
}
