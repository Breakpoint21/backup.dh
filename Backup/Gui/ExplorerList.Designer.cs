namespace Backup.Gui
{
    partial class ExplorerList
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerList));
            this.explorerListView = new Backup.Gui.ExplorerListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // explorerListView
            // 
            this.explorerListView.CheckBoxes = true;
            this.explorerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.explorerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerListView.FullRowSelect = true;
            this.explorerListView.Location = new System.Drawing.Point(0, 0);
            this.explorerListView.Name = "explorerListView";
            this.explorerListView.Size = new System.Drawing.Size(334, 150);
            this.explorerListView.SmallImageList = this.imageList1;
            this.explorerListView.TabIndex = 0;
            this.explorerListView.UseCompatibleStateImageBehavior = false;
            this.explorerListView.View = System.Windows.Forms.View.Details;
            this.explorerListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.explorerListView_ColumnClick);
            this.explorerListView.DoubleClick += new System.EventHandler(this.explorerListView_DoubleClick);
            this.explorerListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.explorerListView_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "Name";
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "LastWriteTime";
            this.columnHeader2.Text = "File Type";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Hard_Drive.png");
            this.imageList1.Images.SetKeyName(1, "FolderOpen_16x16_72.png");
            this.imageList1.Images.SetKeyName(2, "Hard_Drive.png");
            // 
            // ExplorerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.explorerListView);
            this.Name = "ExplorerList";
            this.Size = new System.Drawing.Size(334, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private Backup.Gui.ExplorerListView explorerListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
