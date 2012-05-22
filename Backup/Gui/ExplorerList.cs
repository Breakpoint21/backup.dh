using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Backup.Core;

namespace Backup.Gui
{
    public partial class ExplorerList : UserControl
    {
        private ListView exListView;
        private ListViewColumnSorter lstviewSorter;

        public ListView ExListView
        {
            get { return exListView; }
            set { exListView = value; }
        }

        public ExplorerList()
        {
            InitializeComponent();
            lstviewSorter = new ListViewColumnSorter();
            this.explorerListView.ListViewItemSorter = lstviewSorter;
            prepareListView();
            ExListView = this.explorerListView;
        }

        private void prepareListView()
        {
            explorerListView.Items.Clear();
            imageList1.ImageSize = new Size(48, 48);
            explorerListView.CheckBoxes = false;
            explorerListView.View = View.SmallIcon;
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                explorerListView.Items.Add(new ExplorerListItem(drive));
            }
        }

        public void fillListView(DirectoryInfo selectedDir)
        {
            explorerListView.View = View.Details;
            imageList1.ImageSize = new Size(16, 16);
            explorerListView.CheckBoxes = true;
            explorerListView.Items.Clear();
            FetchingService fetchServ = new FetchingService();
            foreach (DirectoryInfo dir in fetchServ.FetchDirectories(selectedDir))
            {
                explorerListView.Items.Add(new ExplorerListItem(dir));
            }
            foreach (FileInfo file in fetchServ.FetchFiles(selectedDir))
            {
                explorerListView.Items.Add(new ExplorerListItem(file));
            }
        }

        private void explorerListView_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selected = explorerListView.SelectedItems;
            ExplorerListItem sel = selected[0] as ExplorerListItem;
            if(sel.DirInfo != null)
            {
                fillListView(sel.DirInfo);
            }
        }

        internal void DirectoryBack()
        {
            ExplorerListItem item = explorerListView.Items[0] as ExplorerListItem;
            if (item != null)
            {
                if (item.ParentDir.Parent != null)
                {
                    fillListView(item.ParentDir.Parent);   
                }
                else
                {
                    prepareListView();
                }
            }
        }

        private void explorerListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lstviewSorter.ColumnToSort)
            {
                if (lstviewSorter.SortingOrder == SortOrder.Ascending)
                {
                    lstviewSorter.SortingOrder = SortOrder.Descending;
                }
                else
                {
                    lstviewSorter.SortingOrder = SortOrder.Ascending;
                }
            }
            else
	        {
                lstviewSorter.SortingOrder = SortOrder.Ascending;
	        }
            lstviewSorter.ColumnToSort = e.Column;

            this.explorerListView.Sort();
        }
    }
}
