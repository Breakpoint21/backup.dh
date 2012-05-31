using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Backup.Core
{
    public class RestoreController
    {
        private static RestoreController instance;
        private FileInfo backupFile;
        private Dictionary<FileInfo, long> selectedFiles = new Dictionary<FileInfo,long>();

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

        internal void RestoreBackup()
        {
            RestoreBuilder builder = new RestoreBuilder();
            if (RestoreDestination != null && BackupFile != null)
            {
                builder.RestoreBackup(BackupFile.FullName, RestoreDestination);
            }
        }

        internal Dictionary<FileInfo, long> BuildIndex()
        {
            Dictionary<FileInfo, long> ret = new Dictionary<FileInfo, long>();
            RestoreBuilder builder = new RestoreBuilder();
            if (BackupFile != null)
            {
                ret = builder.createIndex(BackupFile.FullName);
            }
            return ret;
        }

        internal void RestoreSelectedFiles()
        {
            RestoreBuilder builder = new RestoreBuilder();
            if (BackupFile != null && RestoreDestination != null)
            {
                builder.RestoreSelectedFiles(BackupFile, RestoreDestination, SelectedFiles);
            }
        }
    }
}
