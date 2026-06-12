using Newtonsoft.Json.Linq;   // 需要安裝 Newtonsoft.Json 套件
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class frmWeather : Form
    {
        ToolTip toolTip = null;
        System.Windows.Forms.Label selectedHotLabel = null;
        System.Windows.Forms.Label selectedFavorityLabel = null;
        System.Windows.Forms.Label selectedSearchLabel = null;
        ///<summary>
        ///連接資料庫的物件
        ///</summary>
        SqlConnection sqlDb = null;

        ///<summary>
        ///關於視窗
        ///</summary>
        frmAbout about = new frmAbout();
        //frmView view = new frmView();
        frmApilog apilog = new frmApilog();
        public static readonly Dictionary<string, string> CityCodeMap = new Dictionary<string, string>
            {
                    {"宜蘭縣", "F-C0032-013"},
                    {"花蓮縣", "F-C0032-012"},
                    {"臺東縣", "F-C0032-027"},
                    {"澎湖縣", "F-C0032-015"},
                    {"金門縣", "F-C0032-014"},
                    {"連江縣", "F-C0032-030"},
                    {"臺北市", "F-C0032-009"},
                    {"新北市", "F-C0032-010"},
                    {"桃園市", "F-C0032-022"},
                    {"臺中市", "F-C0032-021"},
                    {"臺南市", "F-C0032-016"},
                    {"高雄市", "F-C0032-017"},
                    {"基隆市", "F-C0032-011"},
                    {"新竹縣", "F-C0032-023"},
                    {"新竹市", "F-C0032-024"},
                    {"苗栗縣", "F-C0032-020"},
                    {"彰化縣", "F-C0032-028"},
                    {"南投縣", "F-C0032-026"},
                    {"雲林縣", "F-C0032-029"},
                    {"嘉義縣", "F-C0032-018"},
                    {"嘉義市", "F-C0032-019"},
                    {"屏東縣", "F-C0032-025"}
            };

        private void initDB()
        {
            string cntStr = @"Data Source=(localDB)\MSSQLLocalDB;" + @"AttachDBFilename=|DataDirectory|db.mdf;";
            try
            {
                sqlDb = new SqlConnection(cntStr);
                sqlDb.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public frmWeather()
        {
            InitializeComponent();
            initDB();
            InitFile(); // 初始化檔案
            init();
            initToolTip();

            //disabled 視窗的最大化和最小化按鈕，讓使用者只能關閉視窗
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //disbled 視窗的調整大小功能，讓使用者無法改變視窗大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //LoadWeather(cbBoxCity.Text.Trim());

            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += TabControl1_DrawItem;
            
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tabPage = tabControl1.TabPages[e.Index];
            Rectangle tabRect = tabControl1.GetTabRect(e.Index);

            // 判斷是否為目前選取頁籤
            bool isSelected = (e.Index == tabControl1.SelectedIndex);

            // 設定顏色
            Color backColor = isSelected ? Color.Orange : Color.LightGray;
            Color textColor = Color.Black;

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                g.FillRectangle(brush, tabRect);
            }

            TextRenderer.DrawText(
                g,
                tabPage.Text,
                tabControl1.Font,
                tabRect,
                textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private void initToolTip()
        {
            toolTip = new ToolTip();
            toolTip.SetToolTip(cbBoxCity, "選擇縣市查詢天氣");
            toolTip.SetToolTip(picWeather, "溫度分佈圖");
            toolTip.SetToolTip(pictureBox1, "日出時間");
            toolTip.SetToolTip(pictureBox2, "日落時間");
            toolTip.SetToolTip(dataGridView1, "今明36小時天氣預報");
            toolTip.SetToolTip(dataGridView2, "未來一週天氣預報");
        }

        public void init()
        {
            //lbTitle.AutoSize = true; // 啟用自動調整大小
            //lbTitle.Width = this.ClientSize.Width; // 設定標題寬度為表單的寬度
            //lbTitle.Height = 40; // 設定標題高度
            //lbTitle.TextAlign = ContentAlignment.MiddleCenter; // 設定文字置中對齊
            lbMsg.Text = "";
            //縣市選項
            cbBoxCity.Items.Clear();
            cbBoxCity.Items.AddRange(CityCodeMap.Keys.ToArray());
            cbBoxCity.SelectedIndex = 6; // 預設

            btnQry.Text = "";
            btnQry.Image = ResizeImage(GetImage("search"), new Size(34, 34));
            btnQry.MouseEnter += (sender, e) =>
            {
                btnQry.Image = ResizeImage(GetImage("search"), new Size(28, 28));
            };

            btnQry.MouseLeave += (sender, e) =>
            {
                btnQry.Image = ResizeImage(GetImage("search"), new Size(34, 34));
            };

        }

        public void InitFile()
        {
            string dPath = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Path.GetFullPath(Path.Combine(dPath, @"..\.."));

            string[] files = { "favorites.txt", "search_history.txt" };

            foreach (var file in files)
            {
                string sourceFile = Path.Combine(projectPath, file);
                string destFile = Path.Combine(dPath, file);

                if (!File.Exists(destFile))
                {
                    if (File.Exists(sourceFile))
                    {
                        File.Copy(sourceFile, destFile);
                    }
                }
            }
        }

        // 直接從資源中取得圖片
        private Image GetImage(string name)
        {
            return Properties.Resources.ResourceManager.GetObject(name) as Image;
        }

        // 從檔案路徑載入圖片
        private Image GetImage(string folderPath, string fileName)
        {

            Image img = null;
            try
            {
                string fullPath = Path.Combine(folderPath, fileName);
                if (File.Exists(fullPath))
                {
                    img = Image.FromFile(fullPath);
                }
            }
            catch (Exception ex)
            {
                img = null;
            }
            return img;
        }

        private Image ResizeImage(Image img, Size size)
        {
            return new Bitmap(img, size);
        }
        private Image ResizeImage(Image img, int width, int height)
        {
            return new Bitmap(img, new Size(width, height));
        }


        private void frmWeather_Load(object sender, EventArgs e)
        {
            lbMarquee.Text = "                                     ";
            lbMarquee.Left = panelMarquee.Width;
            timerMarquee.Interval = 30;
            timerMarquee.Start();
        }

        private void timerMarquee_Tick(object sender, EventArgs e)
        {
            lbMarquee.Left -= 2; // 每次移動 2 像素

            if (lbMarquee.Right < 0) // 當文字完全移出左邊界時，重新從右邊開始
            {
                lbMarquee.Left = panelMarquee.Width;
            }
        }

        private void UpdateMarquee(string city, int pop)
        {
            if (pop >= 60)
            {
                lbMarquee.Text = $"📢 今日提醒：{city} 降雨機率 {pop}%，外出建議攜帶雨具。";
            }
            else
            {
                lbMarquee.Text = $"🌤️ 今日提醒：{city} 天氣狀況穩定。";
            }

            lbMarquee.Left = panelMarquee.Width;
        }
        private async Task LoadWeather(string city)
        {
            // 記錄點擊歷史
            ClickHistory clickHistory = new ClickHistory();
            clickHistory.Add(city);

            ShowFavorites();
            ShowHot();
            ShowRecent();

            string apiKey = "CWA-1562A959-5BFE-4853-A145-0111EE8FD270";
            int pop = 0;
            //[一般天氣預報-天氣小幫手]
            string json = await WeatherHelp(apiKey, city, "help");
            if (json != null)
            {
                //把json檔存在檔案裡
                SaveJsonToFile(json, city, "help");

                //解析json檔
                LoadWeatherToListView(json);
            }

            //[今明 36 小時天氣預報]
            json = await Get36hrWeather(apiKey, city, "36hr");
            if (json != null)
            {
                //把json檔存在檔案裡
                SaveJsonToFile(json, city, "36hr");

                //解析json檔，取得Wx天氣現象, PoP降雨機率12小時分段, MinT最低溫度, CI舒適度, MaxT最高溫度，寫入dataGridView1
                pop = LoadWeatherToDataGridView1(json);

            }

            // [未來1週天氣預報]
            json = await GetWeekWeather(apiKey, city, "week");
            if (json != null)
            {
                //把json檔存在檔案裡
                SaveJsonToFile(json, city, "week");

                //解析json檔，取得Wx天氣現象, PoP降雨機率12小時分段, MinT最低溫度, CI舒適度, MaxT最高溫度，寫入dataGridView1
                LoadWeatherToDataGridView2(json);

            }

            //日出日沒時刻
            json = await SunRiseAndSetTime(apiKey, city, "sun");
            if (json != null)
            {
                //把json檔存在檔案裡
                SaveJsonToFile(json, city, "sun");
                //解析json檔
                JObject root = JObject.Parse(json);
                string sunRiseTime = root["records"]?["locations"]?["location"]?[0]?["time"]?[0]?["SunRiseTime"]?.ToString();
                string sunSetTime = root["records"]?["locations"]?["location"]?[0]?["time"]?[0]?["SunSetTime"]?.ToString();
                lblSunrise.Text = sunRiseTime;
                lblSunset.Text = sunSetTime;
            }

            //[溫度分布圖]
            json = await Temperature(apiKey, city, "temperature");
            if (json != null)
            {
                try
                {
                    JObject obj = JObject.Parse(json);
                    string productUrl = obj["cwaopendata"]?["dataset"]?["Resource"]?["ProductURL"]?.ToString();

                    if (string.IsNullOrEmpty(productUrl))
                    {
                        lbMsg.Text = "資料來源：中央氣象署 Open Data API | 最後更新：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + " | 狀態：圖片URL無效";
                        return;
                    }

                    Image img = LoadImageFromUrl(productUrl, picWeather.Width, picWeather.Height);
                    picWeather.Image = img;
                    picWeather.Refresh();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("圖片異常: " + ex.Message);
                    lbMsg.Text = "資料來源：中央氣象署 Open Data API | 最後更新：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + " | 狀態：圖片載入失敗";
                }
            }

            UpdateMarquee(city, pop);
        }

        private static Image LoadImageFromUrl(string url, int width, int height)
        {
            using (WebClient wc = new WebClient())
            {
                byte[] bytes = wc.DownloadData(url);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    Image original = Image.FromStream(ms);

                    Bitmap resized = new Bitmap(width, height);
                    using (Graphics g = Graphics.FromImage(resized))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(original, 0, 0, width, height);
                    }
                    return resized;
                }
            }
        }

        private async void btnQry_Click(object sender, EventArgs e)
        {
            string city = cbBoxCity.Text.Trim();
            await LoadWeather(city);
        }

        //一般天氣預報-天氣小幫手        
        private async Task<string> WeatherHelp(string apiKey, string city, string type)
        {

            CityCodeMap.TryGetValue(city, out string cityId);
            string url =
                $"https://opendata.cwa.gov.tw/fileapi/v1/opendataapi/{cityId}" +
                $"?Authorization={apiKey}" +
                $"&downloadType=WEB&format=JSON";

            string json = await GetWeatherJsonAsync(url, city, type);
            return json;
        }


        //今明 36 小時天氣預報
        private async Task<string> Get36hrWeather(string apiKey, string city, string type)
        {

            string dataId = "F-C0032-001";
            string url =
                $"https://opendata.cwa.gov.tw/api/v1/rest/datastore/{dataId}" +
                $"?Authorization={apiKey}" +
                $"&locationName={WebUtility.UrlEncode(city)}";

            string json = await GetWeatherJsonAsync(url, city, type);
            return json;
        }

        // 未來1週天氣預報
        private async Task<string> GetWeekWeather(string apiKey, string city, string type)
        {

            string dataId = "F-D0047-091";
            string elementSet = "最高溫度,最低溫度,天氣現象";
            string url =
                $"https://opendata.cwa.gov.tw/api/v1/rest/datastore/{dataId}" +
                $"?Authorization={apiKey}" +
                $"&LocationName={WebUtility.UrlEncode(city)}" +
                $"&ElementName={WebUtility.UrlEncode(elementSet)}" +
                $"&sort=time";

            string json = await GetWeatherJsonAsync(url, city, type);
            return json;
        }


        //日出日沒時刻
        private async Task<string> SunRiseAndSetTime(string apiKey, string city, string type)
        {
            string url =
                $"https://opendata.cwa.gov.tw/api/v1/rest/datastore/A-B0062-001" +
                $"?Authorization={apiKey}" +
                $"&CountyName={WebUtility.UrlEncode(city)}" +
                $"&Date={DateTime.Now.ToString("yyyy-MM-dd")}" +
                $"&parameter=SunRiseTime,SunSetTime";

            string json = await GetWeatherJsonAsync(url, city, type);
            return json;
        }

        private async Task<string> Temperature(string apiKey, string city, string type)
        {

            CityCodeMap.TryGetValue(city, out string cityId);
            string url =
                $"https://opendata.cwa.gov.tw/fileapi/v1/opendataapi/O-A0038-001" +
                $"?Authorization={apiKey}" +
                $"&downloadType=WEB&format=JSON";

            string json = await GetWeatherJsonAsync(url, city, type);
            return json;
        }


        private void SaveJsonToFile(string json, string city, string type)
        {
            try
            {
                // 建立資料夾，例如：程式執行目錄/WeatherData
                string folderPath = Path.Combine(Application.StartupPath, "WeatherData");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // 檔名：<type>_<city>_Cache.json
                string fileName = $"{type}_{city}_Cache.json";

                string filePath = Path.Combine(folderPath, fileName);

                // 寫入 JSON 檔案
                File.WriteAllText(filePath, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                lbMsg.Text = "資料來源：中央氣象署 Open Data API | 最後更新：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + " | 狀態：儲存失敗";
            }
        }


        private void LoadWeatherToListView(string json)
        {
            try
            {
                JObject root = JObject.Parse(json);

                flowLayoutPanel1.Controls.Clear();

                flowLayoutPanel1.AutoScroll = true;
                flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                flowLayoutPanel1.WrapContents = false;

                int labelWidth = flowLayoutPanel1.ClientSize.Width
                                 - SystemInformation.VerticalScrollBarWidth
                                 - 10;

                if (root["cwaopendata"] == null)
                    return;

                var dataset = root["cwaopendata"]["Dataset"];
                if (dataset == null)
                    return;

                var locations = dataset["Locations"];
                if (locations == null)
                    return;

                var location = locations["Location"];
                if (location == null)
                    return;

                //Debug.WriteLine(location.ToString());

                var elementValue = location["WeatherElement"]?["ElementValue"];
                if (elementValue == null)
                    return;

                //Debug.WriteLine(elementValue.ToString());

                var descArray = elementValue["WeatherDescription"] as JArray;
                if (descArray == null)
                    return;

                foreach (var item in descArray)
                {
                    string text = item.ToString();

                    System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                    lbl.Text = "     " + text;
                    lbl.AutoSize = false;
                    lbl.Width = flowLayoutPanel1.ClientSize.Width
                                - SystemInformation.VerticalScrollBarWidth
                                - 10;

                    lbl.Height = 20;

                    lbl.AutoEllipsis = true;

                    lbl.Margin = new Padding(3);
                    lbl.Padding = new Padding(2);

                    if (text.Contains("多雲") && text.Contains("雨"))
                    {
                        lbl.Image = ResizeImage(GetImage("raincloud"), new Size(16, 16));
                    }
                    else if (text.Contains("多雲") && text.Contains("晴"))
                    {
                        lbl.Image = ResizeImage(GetImage("suncloud"), new Size(16, 16));
                    }
                    else if (text.Contains("風"))
                    {
                        lbl.Image = ResizeImage(GetImage("windy"), new Size(16, 16));
                    }
                    else if (text.Contains("晴"))
                    {
                        lbl.Image = ResizeImage(GetImage("sunny"), new Size(16, 16));
                    }
                    else if (text.Contains("雨"))
                    {
                        lbl.Image = ResizeImage(GetImage("rain"), new Size(16, 16));
                    }
                    else
                    {
                        lbl.Image = ResizeImage(GetImage("windsock"), new Size(16, 16));
                    }
                    lbl.ImageAlign = ContentAlignment.MiddleLeft;
                    toolTip.SetToolTip(lbl, WrapText(text, 25));

                    flowLayoutPanel1.Controls.Add(lbl);
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = "資料來源：中央氣象署 Open Data API | 最後更新：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + " | 狀態：查詢失敗";
            }
        }

        private int LoadWeatherToDataGridView1(string json)
        {
            int maxpop = 0;
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.RowTemplate.Height = 15;


                dataGridView1.Columns.Add("StartTime", "開始時間");
                dataGridView1.Columns.Add("EndTime", "結束時間");

                //dataGridView1.Columns.Add("PoP", "降雨機率");
                dataGridView1.Columns.Add("MaxT", "最高溫");
                dataGridView1.Columns.Add("MinT", "最低溫");
                dataGridView1.Columns.Add("Wx", "天氣現象");
                //dataGridView1.Columns.Add("CI", "舒適度");

                // 前面欄位依內容自動寬度
                dataGridView1.Columns["StartTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["EndTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["MaxT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["MinT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // 最後一欄吃掉剩餘空間
                dataGridView1.Columns["Wx"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                JObject root = JObject.Parse(json);

                JArray weatherElements = (JArray)root["records"]["location"][0]["weatherElement"];

                JArray wxTimes = null;
                JArray popTimes = null;
                JArray minTTimes = null;
                JArray ciTimes = null;
                JArray maxTTimes = null;

                foreach (JObject element in weatherElements)
                {
                    string elementName = element["elementName"].ToString();

                    if (elementName == "Wx")
                        wxTimes = (JArray)element["time"];
                    else if (elementName == "PoP")
                        popTimes = (JArray)element["time"];
                    else if (elementName == "MinT")
                        minTTimes = (JArray)element["time"];
                    else if (elementName == "CI")
                        ciTimes = (JArray)element["time"];
                    else if (elementName == "MaxT")
                        maxTTimes = (JArray)element["time"];
                }

                int count = wxTimes.Count;

                for (int i = 0; i < count; i++)
                {
                    string startTime = wxTimes[i]["startTime"].ToString();
                    string endTime = wxTimes[i]["endTime"].ToString();

                    string wx = wxTimes[i]["parameter"]["parameterName"].ToString();
                    int popValue = int.Parse(popTimes[i]["parameter"]["parameterName"].ToString());
                    if (popValue > maxpop) maxpop = popValue; // 更新最大降雨機率
                    string pop = popTimes[i]["parameter"]["parameterName"].ToString() + "%";
                    string minT = minTTimes[i]["parameter"]["parameterName"].ToString() + "°C";
                    string ci = ciTimes[i]["parameter"]["parameterName"].ToString();
                    string maxT = maxTTimes[i]["parameter"]["parameterName"].ToString() + "°C";

                    dataGridView1.Rows.Add(
                        startTime,
                        endTime,
                        maxT,
                        minT,
                        wx

                    );
                }

                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
            }
            catch (Exception ex)
            {
                lbMsg.Text = "資料來源：中央氣象署 Open Data API | 最後更新：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + " | 狀態：查詢失敗";
            }

            return maxpop;
        }

        private void LoadWeatherToDataGridView2(string json)
        {
            try
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();
                //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ReadOnly = true;
                dataGridView2.RowHeadersVisible = false;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.MultiSelect = false;
                dataGridView2.RowTemplate.Height = 15;

                dataGridView2.Columns.Add("StartTime", "開始時間");
                dataGridView2.Columns.Add("EndTime", "結束時間");

                //dataGridView2.Columns.Add("PoP", "降雨機率");
                dataGridView2.Columns.Add("MaxT", "最高溫");
                dataGridView2.Columns.Add("MinT", "最低溫");
                dataGridView2.Columns.Add("Wx", "天氣現象");
                //dataGridView2.Columns.Add("CI", "舒適度");

                // 前面欄位依內容自動寬度
                dataGridView2.Columns["StartTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns["EndTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns["MaxT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns["MinT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // 最後一欄吃掉剩餘空間
                dataGridView2.Columns["Wx"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                JObject root = JObject.Parse(json);

                JArray weatherElements =
                    (JArray)root["records"]["Locations"][0]["Location"][0]["WeatherElement"];

                JArray maxTTimes = GetWeatherElementTimes(weatherElements, "最高溫度");
                JArray minTTimes = GetWeatherElementTimes(weatherElements, "最低溫度");
                JArray wxTimes = GetWeatherElementTimes(weatherElements, "天氣現象");

                if (maxTTimes == null || minTTimes == null || wxTimes == null)
                {
                    MessageBox.Show("JSON 中缺少最高溫度、最低溫度或天氣現象資料。");
                    return;
                }

                int count = Math.Min(maxTTimes.Count, Math.Min(minTTimes.Count, wxTimes.Count));

                for (int i = 0; i < count; i++)
                {
                    string startTime = FormatTime(maxTTimes[i]["StartTime"]?.ToString());
                    string endTime = FormatTime(maxTTimes[i]["EndTime"]?.ToString());

                    string maxT = GetElementValue(maxTTimes[i], "MaxTemperature") + "°C";
                    string minT = GetElementValue(minTTimes[i], "MinTemperature") + "°C";
                    string wx = GetElementValue(wxTimes[i], "Weather");

                    dataGridView2.Rows.Add(
                        startTime,
                        endTime,
                        //pop,
                        maxT,
                        minT,
                        //ci,
                        wx


                    );
                }

                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
            }
            catch (Exception ex)
            {
                lbMsg.Text = "資料來源：中央氣象署 Open Data API | 最後更新：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + " | 狀態：查詢失敗";
            }
        }

        private JArray GetWeatherElementTimes(JArray weatherElements, string elementName)
        {
            foreach (JObject element in weatherElements)
            {
                string name = element["ElementName"]?.ToString();

                if (name == elementName)
                {
                    return (JArray)element["Time"];
                }
            }

            return null;
        }

        private string GetElementValue(JToken timeToken, string valueName)
        {
            JArray values = (JArray)timeToken["ElementValue"];

            if (values == null || values.Count == 0)
            {
                return "";
            }

            return values[0][valueName]?.ToString() ?? "";
        }
        private string FormatTime(string time)
        {
            if (DateTime.TryParse(time, out DateTime dt))
            {
                return dt.ToString("yyyy/MM/dd HH:mm");
            }

            return time;
        }

        private void frmWeather_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("確定要關閉應用程式嗎？", "關閉確認",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // 取消關閉
            }
            else
            {
                if (sqlDb != null && sqlDb.State == ConnectionState.Open)
                {
                    sqlDb.Close();
                }
            }
        }

        private async Task<string> GetWeatherJsonAsync(string url, string city, string type)
        {
            // 先從API取得資料，若失敗則讀取Cache檔案
            HttpResponseMessage response = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //string json = await client.GetStringAsync(url);
                    // 發送 GET 請求
                    response = await client.GetAsync(url);

                    // 狀態碼
                    int statusCode = (int)response.StatusCode;

                    // 是否成功 (200~299)
                    bool success = response.IsSuccessStatusCode;

                    // 取得回應內容
                    string json = await response.Content.ReadAsStringAsync();

                    lbMsg.Text = "資料來源：中央氣象署 Open Data API | 最後更新：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + " | 狀態：查詢成功";
                    APIlog apilog = new APIlog(sqlDb);
                    apilog.InsertLog(type, url, city, statusCode, success ? "T" : "F", "");
                    return json;
                }
            }
            catch (Exception ex)
            {
                //讀取Cache檔案
                string folderPath = Path.Combine(Application.StartupPath, "WeatherData");
                string fileName = $"{type}_{city}_Cache.json";
                string fullPath = Path.Combine(folderPath, fileName);

                if (!File.Exists(fullPath))
                    return null;

                string json = File.ReadAllText(fullPath);
                DateTime lastWriteTime = File.GetLastWriteTime(fullPath);

                lbMsg.Text = "資料來源：中央氣象署 Open Data API | 最後更新：" + lastWriteTime.ToString("yyyy/MM/dd HH:mm") + " | 狀態：快取";
                // 狀態碼
                int statusCode = 404;
                // 是否成功 (200~299)
                bool success = false;
                if (response != null)
                {
                    statusCode = (int)response.StatusCode;
                    success = response.IsSuccessStatusCode;
                }


                APIlog apilog = new APIlog(sqlDb);
                apilog.InsertLog(type, url, city, statusCode, success ? "T" : "F", ex.Message);
                return json;
            }
        }


        private string WrapText(string text, int lineLength)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i += lineLength)
            {
                int length = Math.Min(lineLength, text.Length - i);
                sb.AppendLine(text.Substring(i, length));
            }

            return sb.ToString();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            // 顯示關於視窗
            about.ShowDialog(this);
        }

        private void tsmiMyFavorites_Click(object sender, EventArgs e)
        {
            frmFavorites myFavorites = new frmFavorites();
            myFavorites.ShowDialog(this);
        }


        private void ShowHot()
        {
            ClickHistory hot = new ClickHistory();

            tlpHot.Controls.Clear();
            tlpHot.RowStyles.Clear();
            tlpHot.ColumnStyles.Clear();

            var data = hot.TopHot(6).ToList();

            // 2欄
            tlpHot.ColumnCount = 2;
            tlpHot.RowCount = 3;
            tlpHot.AutoSize = true;
            tlpHot.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            int index = 0;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    if (index >= data.Count) break;

                    var city = data[index++].City;

                    System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                    
                    lbl.Text = city;
                    lbl.AutoSize = true;
                    lbl.Cursor = Cursors.Hand;
                    lbl.Margin = new Padding(2);
                    lbl.Font = new Font("微軟正黑體", 9);

                    // click event
                    lbl.Click += (s, e) =>
                    {
                        cbBoxCity.Text = city;
                        btnQry.PerformClick();
                    };
                    lbl.MouseEnter += (s, e) =>
                    {
                        if (lbl != selectedHotLabel)
                            lbl.BackColor = Color.LightPink;
                    };

                    lbl.MouseLeave += (s, e) =>
                    {
                        if (lbl != selectedHotLabel)
                            lbl.BackColor = Color.Transparent;
                    };
                    tlpHot.Controls.Add(lbl, col, row);
                }
            }
        }


        public void ShowRecent()
        {
            ClickHistory recent = new ClickHistory();

            tlpSearch.Controls.Clear();
            tlpSearch.RowStyles.Clear();
            tlpSearch.ColumnStyles.Clear();

            var data = recent.Recent(6).ToList();

            // 2欄
            tlpSearch.ColumnCount = 2;
            tlpSearch.RowCount = 3;
            tlpSearch.AutoSize = true;
            tlpSearch.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            int index = 0;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    if (index >= data.Count) break;

                    var city = data[index++].City;

                    System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();

                    lbl.Text = city;
                    lbl.AutoSize = true;
                    lbl.Cursor = Cursors.Hand;
                    lbl.Margin = new Padding(2);
                    lbl.Font = new Font("微軟正黑體", 9);

                    // click event
                    lbl.Click += (s, e) =>
                    {
                        cbBoxCity.Text = city;
                        btnQry.PerformClick();
                    };
                    lbl.MouseEnter += (s, e) =>
                    {
                        if (lbl != selectedSearchLabel)
                            lbl.BackColor = Color.LightPink;
                    };

                    lbl.MouseLeave += (s, e) =>
                    {
                        if (lbl != selectedSearchLabel)
                            lbl.BackColor = Color.Transparent;
                    };
                    tlpSearch.Controls.Add(lbl, col, row);
                }
            }
        }

        public void ShowFavorites()
        {
            Favorites favorites = new Favorites();

            tlpMyFavorites.Controls.Clear();
            tlpMyFavorites.RowStyles.Clear();
            tlpMyFavorites.ColumnStyles.Clear();

            var data = favorites.GetTop(6).ToList();

            // 2欄
            tlpMyFavorites.ColumnCount = 2;
            tlpMyFavorites.RowCount = 3;
            tlpMyFavorites.AutoSize = true;
            tlpMyFavorites.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            int index = 0;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    if (index >= data.Count) break;

                    var city = data[index++];

                    System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();

                    lbl.Text = city;
                    lbl.AutoSize = true;
                    lbl.Cursor = Cursors.Hand;
                    lbl.Margin = new Padding(2);
                    lbl.Font = new Font("微軟正黑體", 9);

                    // click event
                    lbl.Click += (s, e) =>
                    {
                        cbBoxCity.Text = city;
                        btnQry.PerformClick();
                    };
                    lbl.MouseEnter += (s, e) =>
                    {
                        if (lbl != selectedFavorityLabel)
                            lbl.BackColor = Color.LightPink;
                    };

                    lbl.MouseLeave += (s, e) =>
                    {
                        if (lbl != selectedFavorityLabel)
                            lbl.BackColor = Color.Transparent;
                    };
                    tlpMyFavorites.Controls.Add(lbl, col, row);
                }
            }
        }


        private void 搜尋紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmView view = new frmView();
            view.ShowDialog(this);
        }

        private void tsmlAPI_Click(object sender, EventArgs e)
        {
            // 顯示API使用說明視窗
            apilog.ShowDialog(this);
        }
    }
}
