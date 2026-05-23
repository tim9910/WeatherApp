using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class frmFavorites : Form
    {
        Favorites favorites;
        List<string> allCities = new List<string>
        {
            "宜蘭縣","花蓮縣","臺東縣","澎湖縣","金門縣","連江縣","臺北市","新北市",
            "桃園市","臺中市","臺南市","高雄市","基隆市","新竹縣","新竹市","苗栗縣",
            "彰化縣","南投縣","雲林縣","嘉義縣","嘉義市","屏東縣"
        };
        public frmFavorites()
        {
            InitializeComponent();
            favorites = new Favorites();
            lvAvailable.View = View.List;   // 左邊：未加入
            lvFavorites.View = View.List;   // 右邊：已加入
            lvAvailable.Click += lvAvailable_Click;
            lvFavorites.Click += lvFavorites_Click;

            RefreshListViews();
            //disabled 視窗的最大化和最小化按鈕，讓使用者只能關閉視窗
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //disbled 視窗的調整大小功能，讓使用者無法改變視窗大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        // 更新 ListView 顯示
        private void RefreshListViews()
        {
            lvAvailable.Items.Clear();
            lvFavorites.Items.Clear();

            var favoriteCities = favorites.GetAll();
            Console.WriteLine($"讀取最愛數量: {favoriteCities.Count}");
            // 左邊：未加入
            foreach (var city in allCities)
            {
                if (!favoriteCities.Contains(city))
                    lvAvailable.Items.Add(city);
            }

            // 右邊：已加入
            foreach (var city in favoriteCities)
            {
                lvFavorites.Items.Add(city);
            }
        }

        private void lvAvailable_Click(object sender, EventArgs e)
        {
            if (lvAvailable.SelectedItems.Count > 0)
            {
                string city = lvAvailable.SelectedItems[0].Text;
                favorites.Add(city);           // 加入我的最愛
                RefreshListViews();            // 更新左右列表
            }
        }

        private void lvFavorites_Click(object sender, EventArgs e)
        {
            if (lvFavorites.SelectedItems.Count > 0)
            {
                string city = lvFavorites.SelectedItems[0].Text;
                favorites.Remove(city);        // 移除我的最愛
                RefreshListViews();
            }
        }

        private void frmFavorites_FormClosing(object sender, FormClosingEventArgs e)
        {
            //refresh 主視窗的最愛列表
            if (this.Owner is frmWeather mainForm)
            {
                mainForm.ShowFavorites();
            }

        }
    }
}
