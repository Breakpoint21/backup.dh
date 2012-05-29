using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Backup.Core
{
    public class BackupController
    {
        private List<BackupFileInfo> selectedDirs = new List<BackupFileInfo>();
        private List<BackupFileInfo> selectedFiles = new List<BackupFileInfo>();
        private FileInfo destination = null;

        public FileInfo Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public List<BackupFileInfo> SelectedFiles
        {
            get { return selectedFiles; }
            set { selectedFiles = value; }
        }

        public List<BackupFileInfo> SelectedDirs
        {
            get { return selectedDirs; }
            set { selectedDirs = value; }
        }

        private static BackupController instance;

        private static BackupController Instance
        {
            get { return instance; }
            set { instance = value; }
        }

        public static BackupController getInstance()
        {
            if (Instance == null)
            {
                Instance = new BackupController();
            }
            return Instance;
        }

        private BackupController()
        {

        }

        public void startBackup()
        {
            BackupBuilder builder = new BackupBuilder();
            //Add Dirs to the Files List
            List<FileInfo> backupFiles = new List<FileInfo>();
            foreach (BackupFileInfo dir in SelectedDirs)
            {
                backupFiles.AddRange(dir.DirInfo.GetFiles());
            }
            foreach (BackupFileInfo file in SelectedFiles)
            {
                backupFiles.Add(file.FileIn);
            }
            if (Destination != null)
            {
                builder.BuildBackup(backupFiles, Destination);    
            }
            
        }
    }
}
