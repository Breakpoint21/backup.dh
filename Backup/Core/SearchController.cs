using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Backup.Core
{
    public class SearchController
    {
        public enum SearchModus
        {
            NAME, EXTENSION, REGEX, NAMEMATCH, EXTMATCH, REGEXMATCH
        }

        internal List<ExplorerListItem> Search(DirectoryInfo selectedDir, string searchExpression, SearchModus searchModus)
        {
            List<ExplorerListItem> ret = null;
            switch (searchModus)
            {
                case SearchModus.NAME:
                    ret = SearchByName(selectedDir, searchExpression);
                    break;
                case SearchModus.EXTENSION:
                    ret = SearchByExtension(selectedDir, searchExpression);
                    break;
                case SearchModus.REGEX:
                    ret = SearchByRegex(selectedDir, searchExpression);
                    break;
                case SearchModus.NAMEMATCH:
                    ret = MatchName(selectedDir, searchExpression);
                    break;
                case SearchModus.EXTMATCH:
                    ret = MatchExtension(selectedDir, searchExpression);
                    break;
                case SearchModus.REGEXMATCH:
                    ret = MatchRegex(selectedDir, searchExpression);
                    break;
                default:
                    break;
            }
            return ret;
        }

        private List<ExplorerListItem> MatchRegex(DirectoryInfo selectedDir, string searchExpression)
        {
            throw new NotImplementedException();
        }

        private List<ExplorerListItem> MatchExtension(DirectoryInfo selectedDir, string searchExpression)
        {
            List<ExplorerListItem> ret = new List<ExplorerListItem>();
            FileInfo[] files = selectedDir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Extension == searchExpression)
                {
                    ret.Add(new ExplorerListItem(file));
                }
            }
            
            return ret;
        }

        private List<ExplorerListItem> MatchName(DirectoryInfo selectedDir, string searchExpression)
        {
            List<ExplorerListItem> ret = new List<ExplorerListItem>();
            FileInfo[] files = selectedDir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Name == searchExpression)
                {
                    ret.Add(new ExplorerListItem(file));
                }
            }
            DirectoryInfo[] dirs = selectedDir.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                if (dir.Name == searchExpression)
                {
                    ret.Add(new ExplorerListItem(dir));
                }
            }
            return ret;
        }

        private List<ExplorerListItem> SearchByRegex(DirectoryInfo selectedDir, string searchExpression)
        {
            List<ExplorerListItem> ret = new List<ExplorerListItem>();
            FileInfo[] files = selectedDir.GetFiles();
            foreach (FileInfo file in files)
            {
                bool contains = false;
                if (Regex.IsMatch(file.Name, searchExpression))
                {
                    contains = true;
                }
                if (Regex.IsMatch(file.Extension, searchExpression))
                {
                    contains = true;
                }
                if (Regex.IsMatch(file.LastWriteTime.ToString(), searchExpression))
                {
                    contains = true;
                }
                if (contains)
                {
                    ret.Add(new ExplorerListItem(file));
                }
            }
            DirectoryInfo[] dirs = selectedDir.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                bool contains = false;
                if (Regex.IsMatch(dir.Name, searchExpression))
                {
                    contains = true;
                }
                if (Regex.IsMatch(dir.Extension, searchExpression))
                {
                    contains = true;
                }
                if (Regex.IsMatch(dir.LastWriteTime.ToString(), searchExpression))
                {
                    contains = true;
                }
                if (contains)
                {
                    ret.Add(new ExplorerListItem(dir));
                }
            }
            return ret;
        }

        private List<ExplorerListItem> SearchByExtension(DirectoryInfo selectedDir, string searchExpression)
        {
            List<ExplorerListItem> ret = new List<ExplorerListItem>();
            FileInfo[] files = selectedDir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Extension.Contains(searchExpression))
                {
                    ret.Add(new ExplorerListItem(file));
                }
            }
            return ret;
        }

        private List<ExplorerListItem> SearchByName(DirectoryInfo selectedDir, string searchExpression)
        {
            List<ExplorerListItem> ret = new List<ExplorerListItem>();
            FileInfo[] files = selectedDir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Name.Contains(searchExpression))
                {
                    ret.Add(new ExplorerListItem(file));
                }
            }
            DirectoryInfo[] dirs = selectedDir.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                if (dir.Name.Contains(searchExpression))
                {
                    ret.Add(new ExplorerListItem(dir));
                }
            }
            return ret;
        }


    }
}
