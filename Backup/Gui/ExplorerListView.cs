using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Backup.Gui
{
    public class ExplorerListView : ListView
    {
        //protected override void WndProc(ref Message m)
        //{
        //    // Filter WM_LBUTTONDBLCLK
        //    if (m.Msg != 0x203) base.WndProc(ref m);
        //}
        private bool checkFromDoubleClick = false;

        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            if (this.checkFromDoubleClick)
            {
                ice.NewValue = ice.CurrentValue;
                this.checkFromDoubleClick = false;
            }
            else
                base.OnItemCheck(ice);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Is this a double-click?
            if ((e.Button == MouseButtons.Left) && (e.Clicks > 1))
            {
                this.checkFromDoubleClick = true;
            }
            base.OnMouseDown(e);
        }

        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    this.checkFromDoubleClick = false;
        //    base.OnKeyDown(e);
        //}

    }
}
