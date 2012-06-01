namespace Backup.Gui
{
    partial class DHBWBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DHBWBackup));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.explorer = new Backup.Gui.Explorer();
            this.explorerList = new Backup.Gui.ExplorerList();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.stBackup = new System.Windows.Forms.StatusStrip();
            this.lblSelectedFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNumbSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.tsBackupControl = new System.Windows.Forms.ToolStrip();
            this.lblBackupDestination = new System.Windows.Forms.ToolStripLabel();
            this.txtBackupDestination = new System.Windows.Forms.ToolStripTextBox();
            this.btnBrowse = new System.Windows.Forms.ToolStripButton();
            this.startBackupLabel = new System.Windows.Forms.ToolStripLabel();
            this.btnStartBackup = new System.Windows.Forms.ToolStripButton();
            this.lblRestore = new System.Windows.Forms.ToolStripLabel();
            this.btnRestore = new System.Windows.Forms.ToolStripButton();
            this.cbxFilter = new System.Windows.Forms.ToolStripComboBox();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.menuButtonBack = new System.Windows.Forms.ToolStripButton();
            this.backupWorker = new System.ComponentModel.BackgroundWorker();
            this.tsExplorer = new System.Windows.Forms.ToolStrip();
            this.txtExplorerPath = new System.Windows.Forms.ToolStripTextBox();
            this.dstToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.stBackup.SuspendLayout();
            this.tsBackupControl.SuspendLayout();
            this.tsExplorer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.explorer);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.explorerList);
            // 
            // explorer
            // 
            resources.ApplyResources(this.explorer, "explorer");
            this.explorer.Name = "explorer";
            // 
            // explorerList
            // 
            resources.ApplyResources(this.explorerList, "explorerList");
            this.explorerList.CurrentDir = null;
            this.explorerList.Name = "explorerList";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpen,
            this.menuItemExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Name = "menuItemOpen";
            resources.ApplyResources(this.menuItemOpen, "menuItemOpen");
            this.menuItemOpen.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            resources.ApplyResources(this.menuItemExit, "menuItemExit");
            this.menuItemExit.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            resources.ApplyResources(this.menuItemAbout, "menuItemAbout");
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // stBackup
            // 
            this.stBackup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSelectedFiles,
            this.lblNumbSel,
            this.pgbStatus});
            this.stBackup.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            resources.ApplyResources(this.stBackup, "stBackup");
            this.stBackup.Name = "stBackup";
            // 
            // lblSelectedFiles
            // 
            this.lblSelectedFiles.Name = "lblSelectedFiles";
            resources.ApplyResources(this.lblSelectedFiles, "lblSelectedFiles");
            // 
            // lblNumbSel
            // 
            this.lblNumbSel.Name = "lblNumbSel";
            resources.ApplyResources(this.lblNumbSel, "lblNumbSel");
            // 
            // pgbStatus
            // 
            this.pgbStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pgbStatus.Name = "pgbStatus";
            resources.ApplyResources(this.pgbStatus, "pgbStatus");
            // 
            // tsBackupControl
            // 
            this.tsBackupControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBackupDestination,
            this.txtBackupDestination,
            this.btnBrowse,
            this.startBackupLabel,
            this.btnStartBackup,
            this.lblRestore,
            this.btnRestore});
            resources.ApplyResources(this.tsBackupControl, "tsBackupControl");
            this.tsBackupControl.Name = "tsBackupControl";
            // 
            // lblBackupDestination
            // 
            this.lblBackupDestination.Name = "lblBackupDestination";
            resources.ApplyResources(this.lblBackupDestination, "lblBackupDestination");
            // 
            // txtBackupDestination
            // 
            this.txtBackupDestination.Name = "txtBackupDestination";
            resources.ApplyResources(this.txtBackupDestination, "txtBackupDestination");
            this.txtBackupDestination.Click += new System.EventHandler(this.txtBackupDestination_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // startBackupLabel
            // 
            this.startBackupLabel.Name = "startBackupLabel";
            resources.ApplyResources(this.startBackupLabel, "startBackupLabel");
            // 
            // btnStartBackup
            // 
            this.btnStartBackup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnStartBackup, "btnStartBackup");
            this.btnStartBackup.Name = "btnStartBackup";
            this.btnStartBackup.Click += new System.EventHandler(this.startBackupLabel_Click);
            // 
            // lblRestore
            // 
            this.lblRestore.Name = "lblRestore";
            resources.ApplyResources(this.lblRestore, "lblRestore");
            // 
            // btnRestore
            // 
            this.btnRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnRestore, "btnRestore");
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // cbxFilter
            // 
            this.cbxFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cbxFilter.DropDownWidth = 75;
            this.cbxFilter.Items.AddRange(new object[] {
            resources.GetString("cbxFilter.Items"),
            resources.GetString("cbxFilter.Items1"),
            resources.GetString("cbxFilter.Items2"),
            resources.GetString("cbxFilter.Items3"),
            resources.GetString("cbxFilter.Items4"),
            resources.GetString("cbxFilter.Items5")});
            this.cbxFilter.Name = "cbxFilter";
            resources.ApplyResources(this.cbxFilter, "cbxFilter");
            // 
            // txtSearch
            // 
            this.txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtSearch.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Margin = new System.Windows.Forms.Padding(1);
            this.txtSearch.Name = "txtSearch";
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            // 
            // menuButtonBack
            // 
            this.menuButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.menuButtonBack, "menuButtonBack");
            this.menuButtonBack.Name = "menuButtonBack";
            this.menuButtonBack.Click += new System.EventHandler(this.menuButtonBack_Click);
            // 
            // backupWorker
            // 
            this.backupWorker.WorkerReportsProgress = true;
            this.backupWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backupWorker_DoWork);
            this.backupWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backupWorker_ProgressChanged);
            this.backupWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backupWorker_RunWorkerCompleted);
            // 
            // tsExplorer
            // 
            this.tsExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuButtonBack,
            this.txtExplorerPath,
            this.cbxFilter,
            this.txtSearch});
            resources.ApplyResources(this.tsExplorer, "tsExplorer");
            this.tsExplorer.Name = "tsExplorer";
            // 
            // txtExplorerPath
            // 
            this.txtExplorerPath.Name = "txtExplorerPath";
            resources.ApplyResources(this.txtExplorerPath, "txtExplorerPath");
            // 
            // dstToolTip
            // 
            this.dstToolTip.IsBalloon = true;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Hard_Drive.png");
            this.imageList.Images.SetKeyName(1, "FolderOpen_16x16_72.png");
            this.imageList.Images.SetKeyName(2, "Hard_Drive.png");
            // 
            // DHBWBackup
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.tsExplorer);
            this.Controls.Add(this.stBackup);
            this.Controls.Add(this.tsBackupControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "DHBWBackup";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DHBWBackup_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DHBWBackup_DragEnter);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.stBackup.ResumeLayout(false);
            this.stBackup.PerformLayout();
            this.tsBackupControl.ResumeLayout(false);
            this.tsBackupControl.PerformLayout();
            this.tsExplorer.ResumeLayout(false);
            this.tsExplorer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip stBackup;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Explorer explorer;
        private ExplorerList explorerList;
        private System.Windows.Forms.ToolStrip tsBackupControl;
        private System.Windows.Forms.ToolStripButton menuButtonBack;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripStatusLabel lblSelectedFiles;
        private System.Windows.Forms.ToolStripLabel startBackupLabel;
        private System.ComponentModel.BackgroundWorker backupWorker;
        private System.Windows.Forms.ToolStrip tsExplorer;
        private System.Windows.Forms.ToolStripLabel lblBackupDestination;
        private System.Windows.Forms.ToolStripTextBox txtBackupDestination;
        private System.Windows.Forms.ToolStripButton btnBrowse;
        private System.Windows.Forms.ToolStripButton btnRestore;
        private System.Windows.Forms.ToolStripButton btnStartBackup;
        private System.Windows.Forms.ToolStripProgressBar pgbStatus;
        private System.Windows.Forms.ToolStripComboBox cbxFilter;
        private System.Windows.Forms.ToolStripStatusLabel lblNumbSel;
        private System.Windows.Forms.ToolTip dstToolTip;
        private System.Windows.Forms.ToolStripLabel lblRestore;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripTextBox txtExplorerPath;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
    }
}