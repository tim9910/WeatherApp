using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class frmView : Form
    {
        ClickHistory clickHistory;
        List<CityClick> cityClicks;

        bool sortAscending = true;
        int lastSortColumn = 0; // 記錄最後一次排序的欄位索引，預設為0（第一欄）
        private int _hoveredRowIndex = -1;

        public frmView()
        {
            InitializeComponent();
            Show();
        }

        private void Show()
        {
            clickHistory = new ClickHistory();
            cityClicks = clickHistory.GetAll();
            UpdateListView();
            //disabled 視窗的最大化和最小化按鈕，讓使用者只能關閉視窗
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //disbled 視窗的調整大小功能，讓使用者無法改變視窗大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //LoadWeather(cbBoxCity.Text.Trim());
        }

        private void UpdateListView()
        {
            lvwResult.BeginUpdate(); //暫停重繪

            // 清除ListView的所有項目
            lvwResult.Items.Clear();
            // 將WordCollection物件中的資料載入到ListView中
            foreach (CityClick item in cityClicks)
            {
                // 建立ListViewItem物件
                ListViewItem lvi = new ListViewItem(item.City);
                lvi.SubItems.Add(item.ClickCount.ToString());
                lvi.SubItems.Add(item.ModifyTime.ToString());
                // 將ListViewItem物件加入到ListView中
                lvwResult.Items.Add(lvi);
            }
            lvwResult.EndUpdate(); //重繪;  
        }

        private void frmView_Load(object sender, EventArgs e)
        {

            lvwResult.HeaderStyle = ColumnHeaderStyle.Clickable;
            lvwResult.OwnerDraw = true;

            // 啟用雙緩衝，減少閃爍
            lvwResult.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(lvwResult, true, null);


            lvwResult.DrawColumnHeader += (s, e2) =>
            {

                e2.Graphics.FillRectangle(Brushes.LightBlue, e2.Bounds); //背景色
                e2.Graphics.DrawRectangle(Pens.Gray, e2.Bounds);

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;// 設定文字水平靠左                
                sf.LineAlignment = StringAlignment.Center;// 設定文字垂直置中
                e2.Graphics.DrawString(e2.Header.Text, e2.Font, Brushes.Black, e2.Bounds, sf);// 繪製文字                
                sf.Dispose();// 使用完畢後釋放資源

                if (e2.ColumnIndex == lastSortColumn)//如果是目前排序的欄位，才顯示箭頭
                {
                    string text = e2.Header.Text;
                    if (sortAscending)
                    {

                        text = text + " ▲";
                    }
                    else
                    {
                        text = text + " ▼";
                    }
                    // 建立 StringFormat 物件
                    sf = new StringFormat();
                    sf.Alignment = StringAlignment.Near;// 設定文字水平靠左                
                    sf.LineAlignment = StringAlignment.Center;// 設定文字垂直置中
                    e2.Graphics.DrawString(text, e2.Font, Brushes.Black, e2.Bounds, sf);// 繪製文字                
                    sf.Dispose();// 使用完畢後釋放資源
                }

            };

            lvwResult.DrawSubItem += (s, e2) =>
            {
                Brush backBrush;
                if (e2.ItemIndex == _hoveredRowIndex)
                    backBrush = Brushes.LightBlue; // 滑鼠移到該列時的顏色
                else
                    backBrush = (e2.ItemIndex % 2 == 0) ? Brushes.White : Brushes.LightYellow;

                e2.Graphics.FillRectangle(backBrush, e2.Bounds);
                e2.Graphics.DrawRectangle(Pens.LightGray, e2.Bounds);

                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                string text = "";
                if (e2.SubItem.Text != null)
                {
                    text = e2.SubItem.Text.Replace("\r\n", " ").Replace('\n', ' ').Replace('\r', ' ');
                }

                TextRenderer.DrawText(e2.Graphics, text, lvwResult.Font, e2.Bounds, Color.Black, flags);
            };

            lvwResult.MouseMove += lvwResult_MouseMove;
            lvwResult.MouseLeave += lvwResult_MouseLeave;


            lvwResult.ColumnClick += (s, e2) =>
            {
                int tmp = lastSortColumn;
                lastSortColumn = -1;// 先把所有欄位重繪成「原始狀態」(因為後續只會針對點擊欄位重繪)
                //lvwWord.Invalidate();    // 觸發 DrawColumnHeader 重繪所有欄位
                lvwResult.Refresh();

                lastSortColumn = tmp;

                if (e2.Column == lastSortColumn)
                    sortAscending = !sortAscending; // 切換升冪/降冪
                else
                    sortAscending = true; // 預設升冪

                lastSortColumn = e2.Column; // 更新最後排序的欄位索引

                lvwResult.ListViewItemSorter = new ListViewItemComparer(e2.Column, sortAscending);
                lvwResult.Sort();
                lvwResult.Refresh();
            };
        }

        private void lvwResult_MouseMove(object sender, MouseEventArgs e)
        {
            var info = lvwResult.HitTest(e.Location);
            int newIndex = -1;
            if (info.Item != null)
            {
                newIndex = info.Item.Index;
            }
            if (newIndex != _hoveredRowIndex)
            {
                _hoveredRowIndex = newIndex;
                lvwResult.Invalidate();
            }
        }

        private void lvwResult_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredRowIndex != -1)
            {
                _hoveredRowIndex = -1;
                lvwResult.Invalidate();
            }
        }
    }
}
