using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Backup.Core
{
    class FetchingService
    {
        public FetchingService()
        {

        }

        public List<DirectoryInfo> FetchDirectories(DirectoryInfo root)
        {
            List<DirectoryInfo> accessibleDirs = new List<DirectoryInfo>();
            foreach (DirectoryInfo dir in root.GetDirectories())
            {
                if (!IsAccessDenied(dir))
                {
                    accessibleDirs.Add(dir);
                }
            }
            return accessibleDirs;
        }

        public List<FileInfo> FetchFiles(DirectoryInfo root)
        {
            List<FileInfo> accessibleFiles = new List<FileInfo>();
            foreach (FileInfo file in root.GetFiles())
            {
                if (!IsAccessDenied(file))
                {
                    accessibleFiles.Add(file);
                }
            }
            return accessibleFiles;
        }

        private bool IsAccessDenied(FileInfo file)
        {
            return false;
        }

        private bool IsAccessDenied(DirectoryInfo dir)
        {
            try
            {
                int attr = (int)dir.Attributes;
                if (attr != 9238 && attr != 8211 && attr != 8214 && (attr != 22 || dir.Parent == null))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (UnauthorizedAccessException)
            {
                return true;
            }
        }
    }
}
