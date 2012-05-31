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
    public partial class ExplorerList : UserControl, INotifyPropertyChanged
    {
        private ExplorerListView exListView;
        private ListViewColumnSorter lstviewSorter;
        private DirectoryInfo currentDir;
        public event PropertyChangedEventHandler PropertyChanged;
        public DirectoryInfo CurrentDir
        {
            get { return currentDir; }
            set { currentDir = value;
                OnPropertyChanged("CurrentDir");
            }
        }

        public ExplorerListView ExListView
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
            imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(new System.ComponentModel.ComponentResourceManager(typeof(ExplorerList)).GetObject("imageList1.ImageStream")));
            imageList1.Images.SetKeyName(0, "Hard_Drive.png");
            imageList1.Images.SetKeyName(1, "FolderOpen_16x16_72.png");
            imageList1.Images.SetKeyName(2, "Hard_Drive.png");
            explorerListView.CheckBoxes = false;
            explorerListView.View = View.Details;
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    explorerListView.Items.Add(new ExplorerListItem(drive));
                }
            }
        }

        public void fillListView(DirectoryInfo selectedDir)
        {
            CurrentDir = selectedDir;
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
          
            if (sel.DirInfo != null)
            {
                fillListView(sel.DirInfo);
            }
        }

        internal void DirectoryBack()
        {
            if (CurrentDir != null)
            {
                if (CurrentDir.Parent != null)
                {
                    fillListView(CurrentDir.Parent);
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

        internal void fillListView(List<ExplorerListItem> matches)
        {
            explorerListView.Items.Clear();
            foreach (ExplorerListItem item in matches)
            {
                explorerListView.Items.Add(item);
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
