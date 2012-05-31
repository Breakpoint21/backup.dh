using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace Backup.Core
{
    public class BackupController
    {
        private List<BackupFileInfo> selectedDirs = new List<BackupFileInfo>();
        private List<BackupFileInfo> selectedFiles = new List<BackupFileInfo>();
        private FileInfo destination = null;
        private string summary;

        private static BackupController instance;

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

        public bool startBackup(BackgroundWorker worker)
        {
            BackupBuilder builder = new BackupBuilder();
            //Add Dirs to the Files List
            List<FileInfo> backupFiles = new List<FileInfo>();
            foreach (BackupFileInfo dir in SelectedDirs)
            {
                backupFiles.AddRange(dir.DirInfo.GetFiles("*", SearchOption.AllDirectories));
            }
            foreach (BackupFileInfo file in SelectedFiles)
            {
                backupFiles.Add(file.FileIn);
            }
            builder.Worker = worker;
            if (Destination != null)
            {
                return builder.BuildBackup(backupFiles, Destination);    
            }
            else
            {
                return false;
            }
        }

        internal string BuildSummary()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("The Backup was successfully finsihed!");
            builder.AppendLine();
            builder.AppendLine("The following Files have been saved:");
            builder.Append(Summary);
            Logger.SummaryLog(Summary, Destination.Directory);
            return builder.ToString();
        }

        internal void AddDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo.FullName != directoryInfo.Root.FullName)
            {
                FetchingService service = new FetchingService();
                foreach (FileInfo file in service.FetchAllFiles(directoryInfo))
                {
                    this.SelectedFiles.Add(new BackupFileInfo(file));
                }
            }
        }

        internal void RemoveDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo.Root.FullName != directoryInfo.FullName)
            {
                FetchingService service = new FetchingService();
                foreach (FileInfo file in service.FetchAllFiles(directoryInfo))
                {
                    this.SelectedFiles.Remove(new BackupFileInfo(file));
                }
            }
        }

        #region properties
        private static BackupController Instance
        {
            get { return instance; }
            set { instance = value; }
        }

        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

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
        #endregion
    }
}
