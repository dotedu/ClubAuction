using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubAuction
{
    public class ListViewItemComparer : IComparer
    {
        public bool sort_b;
        public SortOrder order = SortOrder.Ascending;

        private int col;

        public ListViewItemComparer()
        {
            col = 0;
        }

        public ListViewItemComparer(int column, bool sort)
        {
            col = column;
            sort_b = sort;
        }

        public int Compare(object x, object y)
        {
            if (sort_b)
            {
                return string.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text, StringComparison.Ordinal);
            }
            else
            {
                return string.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text, StringComparison.Ordinal);
            }
        }
    }
}
