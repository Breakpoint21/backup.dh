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
        private Dictionary<int, string> selected = new Dictionary<int, string>();
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
            foreach (KeyValuePair<int,string> item in Selected)
            {
                backupFiles.Add(new FileInfo(item.Value));
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
                foreach (string file in Directory.GetFiles(directoryInfo.FullName, "*", SearchOption.AllDirectories))
                {
                    this.Selected.Add(file.GetHashCode(), file);
                }
                foreach (string dir in Directory.GetDirectories(directoryInfo.FullName, "*", SearchOption.AllDirectories))
                {
                    this.SelectedDirs.Add(new BackupFileInfo(new DirectoryInfo(dir)));
                }
            }
        }

        internal void RemoveDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo.Root.FullName != directoryInfo.FullName)
            {
                string[] files = Directory.GetFiles(directoryInfo.FullName, "*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    this.Selected.Remove(file.GetHashCode());
                }
                string[] dirs = Directory.GetDirectories(directoryInfo.FullName, "*", SearchOption.AllDirectories);
                foreach (string dir in dirs)
                {
                    this.SelectedDirs.Remove(new BackupFileInfo(new DirectoryInfo(dir)));
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

        public Dictionary<int, string> Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        #endregion
    }
}
