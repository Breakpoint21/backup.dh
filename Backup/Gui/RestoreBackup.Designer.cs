namespace Backup.Gui
{
    partial class RestoreBackup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreBackup));
            this.rdbCompleteBackup = new System.Windows.Forms.RadioButton();
            this.rdbSelectedBackup = new System.Windows.Forms.RadioButton();
            this.lblDestination = new System.Windows.Forms.Label();
            this.txtRestoreDestination = new System.Windows.Forms.TextBox();
            this.btnBrowseDestiation = new System.Windows.Forms.Button();
            this.restoreFilesListView = new System.Windows.Forms.ListView();
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtRestoreSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartRestore = new System.Windows.Forms.Button();
            this.restoreWorker = new System.ComponentModel.BackgroundWorker();
            this.prgRestore = new System.Windows.Forms.ProgressBar();
            this.restoreToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // rdbCompleteBackup
            // 
            resources.ApplyResources(this.rdbCompleteBackup, "rdbCompleteBackup");
            this.rdbCompleteBackup.Checked = true;
            this.rdbCompleteBackup.Name = "rdbCompleteBackup";
            this.rdbCompleteBackup.TabStop = true;
            this.rdbCompleteBackup.UseVisualStyleBackColor = true;
            // 
            // rdbSelectedBackup
            // 
            resources.ApplyResources(this.rdbSelectedBackup, "rdbSelectedBackup");
            this.rdbSelectedBackup.Name = "rdbSelectedBackup";
            this.rdbSelectedBackup.UseVisualStyleBackColor = true;
            this.rdbSelectedBackup.CheckedChanged += new System.EventHandler(this.rdbSelectedBackup_CheckedChanged);
            // 
            // lblDestination
            // 
            resources.ApplyResources(this.lblDestination, "lblDestination");
            this.lblDestination.Name = "lblDestination";
            // 
            // txtRestoreDestination
            // 
            resources.ApplyResources(this.txtRestoreDestination, "txtRestoreDestination");
            this.txtRestoreDestination.Name = "txtRestoreDestination";
            this.txtRestoreDestination.Click += new System.EventHandler(this.txtRestoreDestination_Click);
            // 
            // btnBrowseDestiation
            // 
            resources.ApplyResources(this.btnBrowseDestiation, "btnBrowseDestiation");
            this.btnBrowseDestiation.Name = "btnBrowseDestiation";
            this.btnBrowseDestiation.UseVisualStyleBackColor = true;
            this.btnBrowseDestiation.Click += new System.EventHandler(this.btnBrowseDestiation_Click);
            // 
            // restoreFilesListView
            // 
            resources.ApplyResources(this.restoreFilesListView, "restoreFilesListView");
            this.restoreFilesListView.CheckBoxes = true;
            this.restoreFilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File,
            this.size});
            this.restoreFilesListView.Name = "restoreFilesListView";
            this.restoreFilesListView.UseCompatibleStateImageBehavior = false;
            this.restoreFilesListView.View = System.Windows.Forms.View.Details;
            this.restoreFilesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.restoreFilesListView_ItemChecked);
            // 
            // File
            // 
            resources.ApplyResources(this.File, "File");
            // 
            // size
            // 
            resources.ApplyResources(this.size, "size");
            // 
            // btnBrowseSource
            // 
            resources.ApplyResources(this.btnBrowseSource, "btnBrowseSource");
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtRestoreSource
            // 
            resources.ApplyResources(this.txtRestoreSource, "txtRestoreSource");
            this.txtRestoreSource.Name = "txtRestoreSource";
            this.txtRestoreSource.Click += new System.EventHandler(this.txtRestoreSource_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnStartRestore
            // 
            resources.ApplyResources(this.btnStartRestore, "btnStartRestore");
            this.btnStartRestore.Name = "btnStartRestore";
            this.btnStartRestore.UseVisualStyleBackColor = true;
            this.btnStartRestore.Click += new System.EventHandler(this.btnStartRestore_Click);
            // 
            // restoreWorker
            // 
            this.restoreWorker.WorkerReportsProgress = true;
            this.restoreWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.restoreWorker_DoWork);
            this.restoreWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.restoreWorker_ProgressChanged);
            this.restoreWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.restoreWorker_RunWorkerCompleted);
            // 
            // prgRestore
            // 
            resources.ApplyResources(this.prgRestore, "prgRestore");
            this.prgRestore.Name = "prgRestore";
            // 
            // restoreToolTip
            // 
            this.restoreToolTip.IsBalloon = true;
            // 
            // RestoreBackup
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.prgRestore);
            this.Controls.Add(this.btnStartRestore);
            this.Controls.Add(this.btnBrowseSource);
            this.Controls.Add(this.txtRestoreSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.restoreFilesListView);
            this.Controls.Add(this.btnBrowseDestiation);
            this.Controls.Add(this.txtRestoreDestination);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.rdbSelectedBackup);
            this.Controls.Add(this.rdbCompleteBackup);
            this.Name = "RestoreBackup";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.RestoreBackup_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.RestoreBackup_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbCompleteBackup;
        private System.Windows.Forms.RadioButton rdbSelectedBackup;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.TextBox txtRestoreDestination;
        private System.Windows.Forms.Button btnBrowseDestiation;
        private System.Windows.Forms.ListView restoreFilesListView;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.TextBox txtRestoreSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartRestore;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader size;
        private System.ComponentModel.BackgroundWorker restoreWorker;
        private System.Windows.Forms.ProgressBar prgRestore;
        private System.Windows.Forms.ToolTip restoreToolTip;
    }
}