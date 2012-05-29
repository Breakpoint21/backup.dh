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
                builder.createIndex(BackupFile.FullName);
                //builder.RestoreBackup(BackupFile.FullName, RestoreDestination);
            }
        }

        internal List<string> BuildIndex()
        {
            List<string> ret = new List<string>();
            RestoreBuilder builder = new RestoreBuilder();
            if (BackupFile != null)
            {
                ret = builder.createIndex(BackupFile.FullName);
            }
            return ret;
        }
    }
}
