using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backup.Core;
using System.IO;

namespace Backup.Gui
{
    public partial class RestoreBackup : Form
    {
        private RestoreController controller;

        public RestoreController Controller
        {
            get { return controller; }
            set { controller = value; }
        }
        private string sourcePath;

        public string SourcePath
        {
            get { return sourcePath; }
            set 
            { 
                sourcePath = value;
                this.txtRestoreSource.Text = sourcePath;
            }
        }
        private string destinationPath;

        public string DestinationPath
        {
            get { return destinationPath; }
            set 
            { 
                destinationPath = value;
                this.txtRestoreDestination.Text = destinationPath;
            }
        }

        public RestoreBackup()
        {
            this.Controller = RestoreController.getInstance();
            InitializeComponent();
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.CheckFileExists = true;
            dia.DefaultExt = "dhbw";
            DialogResult res = dia.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                Controller.BackupFile = new FileInfo(dia.FileName);
                this.SourcePath = dia.FileName;
                FillListView(Controller.BuildIndex());
            }
        }

        private void FillListView(Dictionary<FileInfo, long> list)
        {
            restoreFilesListView.Items.Clear();
            foreach (KeyValuePair<FileInfo, long> file in list)
            {
                restoreFilesListView.Items.Add(new RestoreListItem(file));
            }
        }

        private void btnBrowseDestiation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dia = new FolderBrowserDialog();
            dia.ShowNewFolderButton = true;
            DialogResult res = dia.ShowDialog(this);

            if (res==DialogResult.OK)
            {
                Controller.RestoreDestination = new DirectoryInfo(dia.SelectedPath);
                this.DestinationPath = dia.SelectedPath;
            }
        }

        private void btnStartRestore_Click(object sender, EventArgs e)
        {
            if (rdbCompleteBackup.Checked)
            {
                Controller.RestoreBackup();
            }
            else
            {
                Controller.RestoreSelectedFiles();
            }
        }

        private void rdbSelectedBackup_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = sender as RadioButton;
            if (button.Checked)
            {
                restoreFilesListView.Enabled = true;
            }
            else
            {
                restoreFilesListView.Enabled = false;
            }
        }

        private void txtRestoreSource_Click(object sender, EventArgs e)
        {
            if (txtRestoreSource.Text == string.Empty)
            {
                btnBrowseSource_Click(null, EventArgs.Empty);
            }
        }

        private void txtRestoreDestination_Click(object sender, EventArgs e)
        {
            if (txtRestoreDestination.Text == string.Empty)
            {
                btnBrowseDestiation_Click(null, EventArgs.Empty);
            }
        }

        private void RestoreBackup_DragEnter(object sender, DragEventArgs e)
        {
            string[] fileNames = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (fileNames.Length > 0)
            {
                FileInfo backupFile = new FileInfo(fileNames[0]);
                if (backupFile.Extension == ".dhbw")
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void RestoreBackup_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (fileNames.Length > 0)
            {
                FileInfo backupFile = new FileInfo(fileNames[0]);
                if (backupFile.Extension == ".dhbw")
                {
                    this.SourcePath = backupFile.FullName;
                }
            }
        }

        private void restoreFilesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            RestoreListItem item = e.Item as RestoreListItem;
            if (item != null)
            {
                if (item.Checked)
                {
                    Controller.SelectedFiles.Add(item.BackupFile, item.FileSize);
                }
                else
                {
                    Controller.SelectedFiles.Remove(item.BackupFile);
                }
            }
        }

        private void restoreWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void restoreWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void restoreWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
