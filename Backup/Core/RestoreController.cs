using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace Backup.Core
{
    public class RestoreController
    {
        private static RestoreController instance;
        private FileInfo backupFile;
        private Dictionary<FileInfo, long> selectedFiles = new Dictionary<FileInfo,long>();
        private Dictionary<FileInfo, long> index = null;
        private string summary;

        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        public Dictionary<FileInfo, long> Index
        {
            get { return index; }
            set { index = value; }
        }

        public Dictionary<FileInfo, long> SelectedFiles
        {
            get { return selectedFiles; }
            set { selectedFiles = value; }
        }

        public FileInfo BackupFile
        {
            get { return backupFile; }
            set { backupFile = value; }
        }
        private DirectoryInfo restoreDestination;

        public DirectoryInfo RestoreDestination
        {
            get { return restoreDestination; }
            set { restoreDestination = value; }
        }

        private RestoreController()
        {

        }

        public static RestoreController getInstance()
        {
            if (instance == null)
	        {
		        instance = new RestoreController();
	        }
            return instance;
        }

        internal bool RestoreBackup(BackgroundWorker worker)
        {
            RestoreBuilder builder = new RestoreBuilder();
            if (RestoreDestination != null && BackupFile != null)
            {
                return builder.RestoreBackup(BackupFile.FullName, RestoreDestination, worker);
            }
            return false;
        }

        internal Dictionary<FileInfo, long> BuildIndex()
        {
            Index = new Dictionary<FileInfo, long>();
            RestoreBuilder builder = new RestoreBuilder();
            if (BackupFile != null)
            {
                Index = builder.createIndex(BackupFile.FullName);
            }
            return Index;
        }

        internal bool RestoreSelectedFiles(BackgroundWorker worker)
        {
            RestoreBuilder builder = new RestoreBuilder();
            if (BackupFile != null && RestoreDestination != null)
            {
                return builder.RestoreSelectedFiles(BackupFile, RestoreDestination, SelectedFiles, worker);
            }
            return false;
        }

        internal string BuildSummary()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Restoring the Backup was successfully completed");
            builder.AppendLine();
            builder.AppendLine("The following files have been restored: ");
            builder.Append(Summary);
            builder.AppendLine();
            Logger.SummaryLog(Summary, RestoreDestination);
            return builder.ToString(); ;
        }
    }
}
