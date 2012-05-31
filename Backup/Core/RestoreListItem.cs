using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Backup.Core
{
    public class RestoreListItem : ListViewItem
    {
        private FileInfo backupFile;
        private long fileSize;

        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        public FileInfo BackupFile
        {
            get { return backupFile; }
            set { backupFile = value; }
        }

        public RestoreListItem(KeyValuePair<FileInfo, long> file)
        {
            BackupFile = file.Key;
            FileSize = file.Value;

            this.Text = BackupFile.FullName;
            if (FileSize > 1024)
            {
                this.SubItems.Add(string.Format("{0:n0} KB", (FileSize / 1024)));
            }
            else
            {
                this.SubItems.Add(string.Format("{0:n0} B", FileSize));
            }
        }
    }
}
