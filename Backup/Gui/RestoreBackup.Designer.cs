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
            this.rdbCompleteBackup = new System.Windows.Forms.RadioButton();
            this.rdbSelectedBackup = new System.Windows.Forms.RadioButton();
            this.lblDestination = new System.Windows.Forms.Label();
            this.txtRestoreDestination = new System.Windows.Forms.TextBox();
            this.btnBrowseDestiation = new System.Windows.Forms.Button();
            this.restoreFilesListView = new System.Windows.Forms.ListView();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtRestoreSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartRestore = new System.Windows.Forms.Button();
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // rdbCompleteBackup
            // 
            this.rdbCompleteBackup.AutoSize = true;
            this.rdbCompleteBackup.Checked = true;
            this.rdbCompleteBackup.Location = new System.Drawing.Point(13, 59);
            this.rdbCompleteBackup.Name = "rdbCompleteBackup";
            this.rdbCompleteBackup.Size = new System.Drawing.Size(109, 17);
            this.rdbCompleteBackup.TabIndex = 0;
            this.rdbCompleteBackup.TabStop = true;
            this.rdbCompleteBackup.Text = "Complete Backup";
            this.rdbCompleteBackup.UseVisualStyleBackColor = true;
            // 
            // rdbSelectedBackup
            // 
            this.rdbSelectedBackup.AutoSize = true;
            this.rdbSelectedBackup.Location = new System.Drawing.Point(13, 83);
            this.rdbSelectedBackup.Name = "rdbSelectedBackup";
            this.rdbSelectedBackup.Size = new System.Drawing.Size(79, 17);
            this.rdbSelectedBackup.TabIndex = 1;
            this.rdbSelectedBackup.Text = "Select Files";
            this.rdbSelectedBackup.UseVisualStyleBackColor = true;
            this.rdbSelectedBackup.CheckedChanged += new System.EventHandler(this.rdbSelectedBackup_CheckedChanged);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(13, 40);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(32, 13);
            this.lblDestination.TabIndex = 2;
            this.lblDestination.Text = "Path:";
            // 
            // txtRestoreDestination
            // 
            this.txtRestoreDestination.Location = new System.Drawing.Point(54, 37);
            this.txtRestoreDestination.Name = "txtRestoreDestination";
            this.txtRestoreDestination.Size = new System.Drawing.Size(300, 20);
            this.txtRestoreDestination.TabIndex = 3;
            this.txtRestoreDestination.Click += new System.EventHandler(this.txtRestoreDestination_Click);
            // 
            // btnBrowseDestiation
            // 
            this.btnBrowseDestiation.Location = new System.Drawing.Point(360, 35);
            this.btnBrowseDestiation.Name = "btnBrowseDestiation";
            this.btnBrowseDestiation.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDestiation.TabIndex = 4;
            this.btnBrowseDestiation.Text = "Browse";
            this.btnBrowseDestiation.UseVisualStyleBackColor = true;
            this.btnBrowseDestiation.Click += new System.EventHandler(this.btnBrowseDestiation_Click);
            // 
            // restoreFilesListView
            // 
            this.restoreFilesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreFilesListView.CheckBoxes = true;
            this.restoreFilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File});
            this.restoreFilesListView.Enabled = false;
            this.restoreFilesListView.Location = new System.Drawing.Point(13, 106);
            this.restoreFilesListView.Name = "restoreFilesListView";
            this.restoreFilesListView.Size = new System.Drawing.Size(561, 192);
            this.restoreFilesListView.TabIndex = 5;
            this.restoreFilesListView.UseCompatibleStateImageBehavior = false;
            this.restoreFilesListView.View = System.Windows.Forms.View.Details;
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(360, 9);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSource.TabIndex = 8;
            this.btnBrowseSource.Text = "Browse";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtRestoreSource
            // 
            this.txtRestoreSource.Location = new System.Drawing.Point(54, 11);
            this.txtRestoreSource.Name = "txtRestoreSource";
            this.txtRestoreSource.Size = new System.Drawing.Size(300, 20);
            this.txtRestoreSource.TabIndex = 7;
            this.txtRestoreSource.Click += new System.EventHandler(this.txtRestoreSource_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Path:";
            // 
            // btnStartRestore
            // 
            this.btnStartRestore.Location = new System.Drawing.Point(499, 304);
            this.btnStartRestore.Name = "btnStartRestore";
            this.btnStartRestore.Size = new System.Drawing.Size(75, 23);
            this.btnStartRestore.TabIndex = 9;
            this.btnStartRestore.Text = "Start";
            this.btnStartRestore.UseVisualStyleBackColor = true;
            this.btnStartRestore.Click += new System.EventHandler(this.btnStartRestore_Click);
            // 
            // File
            // 
            this.File.Width = 382;
            // 
            // RestoreBackup
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 332);
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
            this.Text = "Form1";
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
    }
}