namespace Backup.Gui
{
    partial class Explorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            this.explorerTreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // explorerTreeView
            // 
            this.explorerTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerTreeView.ImageIndex = 0;
            this.explorerTreeView.ImageList = this.imageList1;
            this.explorerTreeView.Location = new System.Drawing.Point(0, 0);
            this.explorerTreeView.Name = "explorerTreeView";
            this.explorerTreeView.SelectedImageIndex = 1;
            this.explorerTreeView.Size = new System.Drawing.Size(184, 312);
            this.explorerTreeView.TabIndex = 0;
            this.explorerTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.explorerTreeView_BeforeExpand);
            this.explorerTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.explorerTreeView_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Hard_Drive.png");
            this.imageList1.Images.SetKeyName(1, "FolderOpen_16x16_72.png");
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.explorerTreeView);
            this.Name = "Explorer";
            this.Size = new System.Drawing.Size(184, 312);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView explorerTreeView;
        private System.Windows.Forms.ImageList imageList1;
    }
}
