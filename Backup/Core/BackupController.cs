using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Backup.Core
{
    public class BackupController
    {
        List<DirectoryInfo> selectedDirs = new List<DirectoryInfo>();
        List<FileInfo> selectedFiles = new List<FileInfo>();

        public List<FileInfo> SelectedFiles
        {
            get { return selectedFiles; }
            set { selectedFiles = value; }
        }

        public List<DirectoryInfo> SelectedDirs
        {
            get { return selectedDirs; }
            set { selectedDirs = value; }
        } 

        public BackupController()
        {

        }
    }
}
