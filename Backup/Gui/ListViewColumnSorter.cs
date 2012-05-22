using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Backup.Core;
using System.IO;

namespace Backup.Gui
{
    class ListViewColumnSorter : IComparer
    {
        private SortOrder sortOrder;

        public SortOrder SortingOrder
        {
            get { return sortOrder; }
            set { sortOrder = value; }
        }
        private int columnToSort;

        public int ColumnToSort
        {
            get { return columnToSort; }
            set { columnToSort = value; }
        }


        public int Compare(object x, object y)
        {
            int ret;
            ExplorerListItem first = x as ExplorerListItem;
            ExplorerListItem second = y as ExplorerListItem;

            if (ColumnToSort == 3)
            {
                ret = DateTime.Compare(DateTime.Parse(first.SubItems[ColumnToSort].Text), DateTime.Parse(second.SubItems[ColumnToSort].Text));
            }
            else
            {
                CaseInsensitiveComparer comp = new CaseInsensitiveComparer();

                ret = comp.Compare(first.SubItems[ColumnToSort].Text, second.SubItems[ColumnToSort].Text);
            }

            if (SortingOrder == SortOrder.Ascending)
            {
                return ret;
            }
            else if(SortingOrder == SortOrder.Descending)
            {
                return (-ret);
            }
            else
            {
                return 0;
            }
        }
    }
}
