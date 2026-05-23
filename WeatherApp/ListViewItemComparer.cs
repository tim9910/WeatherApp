using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    internal class ListViewItemComparer : System.Collections.IComparer
    {
        private int col;
        private bool ascending;

        public ListViewItemComparer(int column, bool ascending = true)
        {
            col = column;
            this.ascending = ascending;
        }

        public int Compare(object x, object y)
        {
            string s1 = ((ListViewItem)x).SubItems[col].Text;
            string s2 = ((ListViewItem)y).SubItems[col].Text;

            // 數字比較
            if (double.TryParse(s1, out double d1) && double.TryParse(s2, out double d2))
            {
                return ascending ? d1.CompareTo(d2) : d2.CompareTo(d1);
            }

            // 文字比較
            return ascending ? string.Compare(s1, s2) : string.Compare(s2, s1);
        }
    }
}
