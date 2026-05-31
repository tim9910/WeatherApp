using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class frmApilog : Form
    {
        ///<summary>
        ///連接資料庫的物件
        ///</summary>
        SqlConnection sqlDb= null;

        public static readonly Dictionary<string, string> queryType = new Dictionary<string, string>
        {
            {"日期", "0"},
            {"縣市", "1"},
            {"API類型", "2"},
            {"狀態", "3"}
        };

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

        List<string> apiNameList = new List<string>()
        {
            "天氣小幫手",
            "今明 36 小時天氣預報",
            "未來1週天氣預報",
            "日出日沒時刻",
            "溫度分布圖"
        };

        public frmApilog()
        {
            InitializeComponent();
        }

        private void frmApilog_Load(object sender, EventArgs e)
        {
            cbBoxAPI.Items.Clear();
            cbBoxAPI.Items.AddRange(queryType.Keys.ToArray());
            cbBoxAPI.SelectedIndex = 0; // 預設
            initDB();
            btnQuery_Click(sender, e);
        }

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

        private void cbBoxAPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cbBoxAPI.SelectedItem.ToString();

            plQuery.Controls.Clear();
            int queryBtnPos = 0;
            
            if (selectedType == "日期")
            {
                DateTimePicker dtpStart = new DateTimePicker();
                dtpStart.Name = "dtpStart";
                dtpStart.Value = DateTime.Now.AddDays(-7);
                dtpStart.Font = new Font("微軟正黑體", 9);
                dtpStart.Format = DateTimePickerFormat.Short;
                dtpStart.Width = 95;
                dtpStart.Location = new Point(5, 0);

                Label lblEnd = new Label();
                lblEnd.Text = "～";
                lblEnd.Font = new Font("微軟正黑體", 9);
                lblEnd.AutoSize = true;
                lblEnd.Location = new Point(100, 4);

                DateTimePicker dtpEnd = new DateTimePicker();
                dtpEnd.Name = "dtpEnd";
                dtpEnd.Value = DateTime.Now;
                dtpEnd.Font = new Font("微軟正黑體", 9);
                dtpEnd.Format = DateTimePickerFormat.Short;
                dtpEnd.Width = 95;
                dtpEnd.Location = new Point(120, 0);

                plQuery.Controls.Add(dtpStart);
                plQuery.Controls.Add(lblEnd);
                plQuery.Controls.Add(dtpEnd);
                queryBtnPos = 220;
            }
            else
            {
                ComboBox cbBoxValue = new ComboBox();
                cbBoxValue.Name = "cbBoxValue";
                cbBoxValue.DropDownStyle = ComboBoxStyle.DropDownList;
                cbBoxValue.Font = new Font("微軟正黑體", 10);
                cbBoxValue.AutoSize = true;
                cbBoxValue.Location = new Point(0, 0);

                switch (selectedType)
                {
                    case "縣市":
                        cbBoxValue.Items.AddRange(CityCodeMap.Keys.ToArray());
                        break;
                    case "API類型":
                        cbBoxValue.Items.AddRange(apiNameList.ToArray());
                        break;
                    case "狀態":
                        cbBoxValue.Items.AddRange(new string[] { "成功", "失敗" });
                        break;
                }

                if (cbBoxValue.Items.Count > 0)
                    cbBoxValue.SelectedIndex = 0;

                plQuery.Controls.Add(cbBoxValue);
                queryBtnPos = cbBoxValue.Location.X + cbBoxValue.Width + 10;
                cbBoxValue.SelectedIndexChanged += (s, ev) => btnQuery_Click(s, ev);
            }

            cbBoxAPI.SelectedIndexChanged += (s, ev) => btnQuery_Click(s, ev);

            Button btnQuery = new Button();
            btnQuery.Name = "btnQuery";
            btnQuery.Text = "查詢";
            btnQuery.Font = new Font("微軟正黑體", 9);
            btnQuery.Width = 70;
            btnQuery.Height = 25;
            btnQuery.Location = new Point(queryBtnPos, 0);
            btnQuery.Click += btnQuery_Click;
            plQuery.Controls.Add(btnQuery);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string selectedType = cbBoxAPI.SelectedItem.ToString();
            APIlog apilog = new APIlog(sqlDb);
            DataTable dt = null;

            try
            {
                switch (selectedType)
                {
                    case "日期":
                        DateTimePicker dtpStart = plQuery.Controls["dtpStart"] as DateTimePicker;
                        DateTimePicker dtpEnd = plQuery.Controls["dtpEnd"] as DateTimePicker;
                        dt = apilog.QueryByDate(dtpStart.Value.Date, dtpEnd.Value.Date);
                        break;

                    case "縣市":
                        ComboBox cbBoxCity = plQuery.Controls["cbBoxValue"] as ComboBox;
                        dt = apilog.QueryByCity(cbBoxCity.SelectedItem.ToString());
                        break;

                    case "API類型":
                        ComboBox cbBoxApiType = plQuery.Controls["cbBoxValue"] as ComboBox;
                        dt = apilog.QueryByApiName(cbBoxApiType.SelectedItem.ToString());
                        break;

                    case "狀態":
                        ComboBox cbBoxStatus = plQuery.Controls["cbBoxValue"] as ComboBox;
                        string status = cbBoxStatus.SelectedItem.ToString() == "成功" ? "T" : "F";
                        dt = apilog.QueryByStatus(status);
                        break;
                }

                ShowData(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 處理 DataGridView 
        private void ShowData(DataTable dt)
        {
            dgvApiResult.Rows.Clear();
            dgvApiResult.Columns.Clear();

            dgvApiResult.RowsDefaultCellStyle.BackColor = Color.White;
            dgvApiResult.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;

            dgvApiResult.EnableHeadersVisualStyles = false;
            dgvApiResult.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvApiResult.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;


            dgvApiResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvApiResult.AllowUserToAddRows = false;
            dgvApiResult.ReadOnly = true;
            dgvApiResult.RowHeadersVisible = false;
            dgvApiResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApiResult.MultiSelect = false;
            dgvApiResult.RowTemplate.Height = 15;

            dgvApiResult.Columns.Add("logid", "序號");
            dgvApiResult.Columns.Add("apiname", "API名稱");
            dgvApiResult.Columns.Add("apiurl", "API網址");
            dgvApiResult.Columns.Add("cityname", "縣市");
            dgvApiResult.Columns.Add("requesttime", "查詢時間");
            dgvApiResult.Columns.Add("statuscode", "狀態碼");
            dgvApiResult.Columns.Add("success", "查詢結果");
            dgvApiResult.Columns.Add("result", "備註");

            dgvApiResult.Columns["logid"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvApiResult.Columns["apiname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgvApiResult.Columns["apiurl"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvApiResult.Columns["cityname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvApiResult.Columns["requesttime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvApiResult.Columns["statuscode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvApiResult.Columns["success"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvApiResult.Columns["result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // if dt.Rows is empty, the foreach loop will be skipped and the DataGridView will just show the column headers without any rows.
            if (dt.Rows.Count == 0)
            {
                dgvApiResult.Rows.Add("", "沒有查詢到資料", "", "", "", "", "", "");

                return;
            }

            int idx = 0;
            foreach (DataRow row in dt.Rows)
            {
                dgvApiResult.Rows.Add(++idx, row["apiname"], row["apiurl"], row["cityname"], 
                                  row["requesttime"], row["statuscode"], row["success"], row["result"]);
            }
        }

        private void dgvApiResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvApiResult.Columns[e.ColumnIndex].Name != "success")
                return;

            if (e.Value != null && e.Value.ToString() == "F")
            {
                dgvApiResult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                dgvApiResult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }
    }
}
