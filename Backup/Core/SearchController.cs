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
            FetchingService fetch = new FetchingService();
            List<ExplorerListItem> ret = new List<ExplorerListItem>();
            foreach (FileInfo file in fetch.FetchFiles(selectedDir))
            {
                bool contains = false;
                if (Regex.Match(file.Name, searchExpression).Length == file.Name.Length)
                {
                    contains = true;
                }
                if (Regex.Match(file.Extension, searchExpression).Length == file.Extension.Length)
                {
                    contains = true;
                }
                if (Regex.Match(file.LastWriteTime.ToShortDateString(), searchExpression).Length == file.LastWriteTime.ToShortDateString().Length)
                {
                    contains = true;
                }
                if (contains)
                {
                    ret.Add(new ExplorerListItem(file));
                }
            }
            foreach (DirectoryInfo dir in fetch.FetchDirectories(selectedDir))
            {
                bool contains = false;
                if (Regex.Match(dir.Name, searchExpression).Length == dir.Name.Length)
                {
                    contains = true;
                }
                if (Regex.Match(dir.LastWriteTime.ToShortDateString(), searchExpression).Length == dir.LastWriteTime.ToShortDateString().Length)
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

        private List<ExplorerListItem> MatchExtension(DirectoryInfo selectedDir, string searchExpression)
        {
            FetchingService fetch = new FetchingService();
            List<ExplorerListItem> ret = new List<ExplorerListItem>();
            foreach (FileInfo file in fetch.FetchFiles(selectedDir))
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
            FetchingService fetch = new FetchingService();
            List<ExplorerListItem> ret = new List<ExplorerListItem>();
            foreach (FileInfo file in fetch.FetchFiles(selectedDir))
            {
                if (file.Name == searchExpression)
                {
                    ret.Add(new ExplorerListItem(file));
                }
            }
            foreach (DirectoryInfo dir in fetch.FetchDirectories(selectedDir))
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
            FetchingService fetch = new FetchingService();
            List<ExplorerListItem> ret = new List<ExplorerListItem>();
            foreach (FileInfo file in fetch.FetchFiles(selectedDir))
            {
                bool contains = false;
                if (Regex.IsMatch(file.Name, searchExpression, RegexOptions.IgnoreCase))
                {
                    contains = true;
                }
                if (Regex.IsMatch(file.Extension, searchExpression, RegexOptions.IgnoreCase))
                {
                    contains = true;
                }
                if (Regex.IsMatch(file.LastWriteTime.ToString(), searchExpression, RegexOptions.IgnoreCase))
                {
                    contains = true;
                }
                if (contains)
                {
                    ret.Add(new ExplorerListItem(file));
                }
            }
            foreach (DirectoryInfo dir in fetch.FetchDirectories(selectedDir))
            {
                bool contains = false;
                if (Regex.IsMatch(dir.Name, searchExpression, RegexOptions.IgnoreCase))
                {
                    contains = true;
                }
                if (Regex.IsMatch(dir.LastWriteTime.ToString(), searchExpression, RegexOptions.IgnoreCase))
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
            FetchingService fetch = new FetchingService();
            List<ExplorerListItem> ret = new List<ExplorerListItem>();
            foreach (FileInfo file in fetch.FetchFiles(selectedDir))
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
            FetchingService fetch = new FetchingService();
            List<ExplorerListItem> ret = new List<ExplorerListItem>();
            foreach (FileInfo file in fetch.FetchFiles(selectedDir))
            {
                if (file.Name.Contains(searchExpression))
                {
                    ret.Add(new ExplorerListItem(file));
                }
            }
            DirectoryInfo[] dirs = selectedDir.GetDirectories();
            foreach (DirectoryInfo dir in fetch.FetchDirectories(selectedDir))
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
