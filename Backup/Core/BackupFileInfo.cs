using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Backup.Core
{
    public class BackupFileInfo : IEquatable<BackupFileInfo>
    {
        private FileInfo fileIn;

        public FileInfo FileIn
        {
            get { return fileIn; }
            set { fileIn = value; }
        }
        private DirectoryInfo dirInfo;

        public DirectoryInfo DirInfo
        {
            get { return dirInfo; }
            set { dirInfo = value; }
        }

        public BackupFileInfo(FileInfo fi)
        {
            this.FileIn = fi;
        }

        public BackupFileInfo(DirectoryInfo dirInfo)
        {
            this.DirInfo = dirInfo;
        }

        public bool Equals(BackupFileInfo obj)
        {
            FileInfo file = obj.FileIn;
            if (file != null)
	        {
                if (this.FileIn.FullName == file.FullName)
                {
                    return true;
                }
                return false;
	        }
            DirectoryInfo dir = obj.DirInfo;
            if (dir != null)
            {
                if (dir.FullName == this.DirInfo.FullName)
                {
                    return true;
                }
                return false;
            }
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
