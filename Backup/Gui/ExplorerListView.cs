using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Backup.Gui
{
    public class ExplorerListView : ListView
    {
        //Required to prevent Listview from checking Items when they are double clicked
        private bool checkFromDoubleClick = false;

        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            if (this.checkFromDoubleClick)
            {
                ice.NewValue = ice.CurrentValue;
                this.checkFromDoubleClick = false;
            }
            else
            {
                base.OnItemCheck(ice);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (e.Clicks > 1))
            {
                this.checkFromDoubleClick = true;
            }
            base.OnMouseDown(e);

            ListViewItem item = this.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                if (this.SelectedItems.Count == 1)
                {
                    this.SelectedItems.Clear();   
                }
                item.Selected = true;
            }
            
        }
    }
}
