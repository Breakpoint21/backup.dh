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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.explorer1 = new Backup.Gui.Explorer();
            this.explorerList1 = new Backup.Gui.ExplorerList();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNumbSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.txtExplorerPath = new System.Windows.Forms.ToolStripTextBox();
            this.dstToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.explorer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.explorerList1);
            // 
            // explorer1
            // 
            resources.ApplyResources(this.explorer1, "explorer1");
            this.explorer1.Name = "explorer1";
            // 
            // explorerList1
            // 
            resources.ApplyResources(this.explorerList1, "explorerList1");
            this.explorerList1.CurrentDir = null;
            this.explorerList1.Name = "explorerList1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            resources.ApplyResources(this.öffnenToolStripMenuItem, "öffnenToolStripMenuItem");
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            resources.ApplyResources(this.beendenToolStripMenuItem, "beendenToolStripMenuItem");
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblNumbSel,
            this.pgbStatus});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
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
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBackupDestination,
            this.txtBackupDestination,
            this.btnBrowse,
            this.startBackupLabel,
            this.btnStartBackup,
            this.lblRestore,
            this.btnRestore});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
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
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuButtonBack,
            this.txtExplorerPath,
            this.cbxFilter,
            this.txtSearch});
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.Name = "toolStrip2";
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Hard_Drive.png");
            this.imageList1.Images.SetKeyName(1, "FolderOpen_16x16_72.png");
            this.imageList1.Images.SetKeyName(2, "Hard_Drive.png");
            // 
            // DHBWBackup
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DHBWBackup";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DHBWBackup_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DHBWBackup_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Explorer explorer1;
        private ExplorerList explorerList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton menuButtonBack;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripLabel startBackupLabel;
        private System.ComponentModel.BackgroundWorker backupWorker;
        private System.Windows.Forms.ToolStrip toolStrip2;
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
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripTextBox txtExplorerPath;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
    }
}