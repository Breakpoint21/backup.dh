﻿using System;
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

        private void FillListView(List<string> list)
        {
            foreach (string file in list)
            {
                restoreFilesListView.Items.Add(new ListViewItem(file));
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
            Controller.RestoreBackup();
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
    }
}