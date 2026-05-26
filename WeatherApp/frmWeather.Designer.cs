namespace WeatherApp
{
    partial class frmWeather
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeather));
            this.grpQuery = new System.Windows.Forms.GroupBox();
            this.lblSunset = new System.Windows.Forms.Label();
            this.lblSunrise = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnQry = new System.Windows.Forms.Button();
            this.cbBoxCity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpQryResult = new System.Windows.Forms.GroupBox();
            this.picWeather = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tlpMyFavorites = new System.Windows.Forms.TableLayoutPanel();
            this.panelMarquee = new System.Windows.Forms.Panel();
            this.lbMarquee = new System.Windows.Forms.Label();
            this.timerMarquee = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lbMsg = new System.Windows.Forms.Label();
            this.grpHot = new System.Windows.Forms.GroupBox();
            this.tlpHot = new System.Windows.Forms.TableLayoutPanel();
            this.mnWeather = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMyFavorites = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.grpQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpQryResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelMarquee.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.grpHot.SuspendLayout();
            this.mnWeather.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpQuery
            // 
            this.grpQuery.Controls.Add(this.lblSunset);
            this.grpQuery.Controls.Add(this.lblSunrise);
            this.grpQuery.Controls.Add(this.pictureBox2);
            this.grpQuery.Controls.Add(this.pictureBox1);
            this.grpQuery.Controls.Add(this.btnQry);
            this.grpQuery.Controls.Add(this.cbBoxCity);
            this.grpQuery.Controls.Add(this.label1);
            this.grpQuery.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpQuery.Location = new System.Drawing.Point(4, 94);
            this.grpQuery.Margin = new System.Windows.Forms.Padding(2);
            this.grpQuery.Name = "grpQuery";
            this.grpQuery.Padding = new System.Windows.Forms.Padding(2);
            this.grpQuery.Size = new System.Drawing.Size(610, 96);
            this.grpQuery.TabIndex = 1;
            this.grpQuery.TabStop = false;
            // 
            // lblSunset
            // 
            this.lblSunset.AutoSize = true;
            this.lblSunset.Location = new System.Drawing.Point(458, 63);
            this.lblSunset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSunset.Name = "lblSunset";
            this.lblSunset.Size = new System.Drawing.Size(100, 26);
            this.lblSunset.TabIndex = 6;
            this.lblSunset.Text = "00:00:00";
            // 
            // lblSunrise
            // 
            this.lblSunrise.AutoSize = true;
            this.lblSunrise.Location = new System.Drawing.Point(352, 67);
            this.lblSunrise.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSunrise.Name = "lblSunrise";
            this.lblSunrise.Size = new System.Drawing.Size(100, 26);
            this.lblSunrise.TabIndex = 5;
            this.lblSunrise.Text = "00:00:00";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WeatherApp.Properties.Resources.sunset1;
            this.pictureBox2.Location = new System.Drawing.Point(462, 16);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(96, 58);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WeatherApp.Properties.Resources.sunrise1;
            this.pictureBox1.Location = new System.Drawing.Point(357, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 58);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnQry
            // 
            this.btnQry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQry.FlatAppearance.BorderSize = 0;
            this.btnQry.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnQry.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnQry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQry.Location = new System.Drawing.Point(284, 21);
            this.btnQry.Margin = new System.Windows.Forms.Padding(2);
            this.btnQry.Name = "btnQry";
            this.btnQry.Size = new System.Drawing.Size(63, 46);
            this.btnQry.TabIndex = 2;
            this.btnQry.Text = "查詢";
            this.btnQry.UseVisualStyleBackColor = true;
            this.btnQry.Visible = false;
            this.btnQry.Click += new System.EventHandler(this.btnQry_Click);
            // 
            // cbBoxCity
            // 
            this.cbBoxCity.FormattingEnabled = true;
            this.cbBoxCity.Location = new System.Drawing.Point(130, 28);
            this.cbBoxCity.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxCity.Name = "cbBoxCity";
            this.cbBoxCity.Size = new System.Drawing.Size(150, 34);
            this.cbBoxCity.TabIndex = 1;
            this.cbBoxCity.SelectedIndexChanged += new System.EventHandler(this.btnQry_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "選擇縣市";
            // 
            // grpQryResult
            // 
            this.grpQryResult.Controls.Add(this.flowLayoutPanel1);
            this.grpQryResult.Font = new System.Drawing.Font("微軟正黑體", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpQryResult.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.grpQryResult.Location = new System.Drawing.Point(7, 194);
            this.grpQryResult.Margin = new System.Windows.Forms.Padding(2);
            this.grpQryResult.Name = "grpQryResult";
            this.grpQryResult.Padding = new System.Windows.Forms.Padding(2);
            this.grpQryResult.Size = new System.Drawing.Size(607, 252);
            this.grpQryResult.TabIndex = 2;
            this.grpQryResult.TabStop = false;
            // 
            // picWeather
            // 
            this.picWeather.BackColor = System.Drawing.Color.Transparent;
            this.picWeather.Location = new System.Drawing.Point(618, 92);
            this.picWeather.Margin = new System.Windows.Forms.Padding(2);
            this.picWeather.Name = "picWeather";
            this.picWeather.Size = new System.Drawing.Size(333, 349);
            this.picWeather.TabIndex = 1;
            this.picWeather.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 19);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(607, 232);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // grpSearch
            // 
            this.grpSearch.BackColor = System.Drawing.Color.MistyRose;
            this.grpSearch.Controls.Add(this.tlpSearch);
            this.grpSearch.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpSearch.Location = new System.Drawing.Point(24, 654);
            this.grpSearch.Margin = new System.Windows.Forms.Padding(2);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Padding = new System.Windows.Forms.Padding(2);
            this.grpSearch.Size = new System.Drawing.Size(247, 156);
            this.grpSearch.TabIndex = 4;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "[ 搜尋紀錄 ]";
            // 
            // tlpSearch
            // 
            this.tlpSearch.ColumnCount = 2;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch.Location = new System.Drawing.Point(14, 33);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.RowCount = 2;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch.Size = new System.Drawing.Size(214, 113);
            this.tlpSearch.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FloralWhite;
            this.groupBox2.Controls.Add(this.tlpMyFavorites);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(337, 654);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(247, 156);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[ 我的最愛 ]";
            // 
            // tlpMyFavorites
            // 
            this.tlpMyFavorites.ColumnCount = 2;
            this.tlpMyFavorites.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMyFavorites.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMyFavorites.Location = new System.Drawing.Point(28, 33);
            this.tlpMyFavorites.Name = "tlpMyFavorites";
            this.tlpMyFavorites.RowCount = 2;
            this.tlpMyFavorites.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMyFavorites.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMyFavorites.Size = new System.Drawing.Size(200, 111);
            this.tlpMyFavorites.TabIndex = 0;
            // 
            // panelMarquee
            // 
            this.panelMarquee.Controls.Add(this.lbMarquee);
            this.panelMarquee.Location = new System.Drawing.Point(4, 51);
            this.panelMarquee.Margin = new System.Windows.Forms.Padding(2);
            this.panelMarquee.Name = "panelMarquee";
            this.panelMarquee.Size = new System.Drawing.Size(948, 37);
            this.panelMarquee.TabIndex = 7;
            // 
            // lbMarquee
            // 
            this.lbMarquee.AutoSize = true;
            this.lbMarquee.ForeColor = System.Drawing.Color.Red;
            this.lbMarquee.Location = new System.Drawing.Point(7, 9);
            this.lbMarquee.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMarquee.Name = "lbMarquee";
            this.lbMarquee.Size = new System.Drawing.Size(97, 21);
            this.lbMarquee.TabIndex = 0;
            this.lbMarquee.Text = "lbMarquee";
            // 
            // timerMarquee
            // 
            this.timerMarquee.Tick += new System.EventHandler(this.timerMarquee_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-2, 450);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(961, 201);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(953, 166);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "36小時預報";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 38;
            this.dataGridView1.Size = new System.Drawing.Size(929, 152);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(953, 166);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "1週預報";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(5, 4);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 82;
            this.dataGridView2.RowTemplate.Height = 38;
            this.dataGridView2.Size = new System.Drawing.Size(929, 152);
            this.dataGridView2.TabIndex = 0;
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbMsg.Location = new System.Drawing.Point(46, 836);
            this.lbMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(767, 21);
            this.lbMsg.TabIndex = 9;
            this.lbMsg.Text = "資料來源：中央氣象署 Open Data API | 最後更新：2026/05/04 14:30 | 狀態：查詢成功";
            // 
            // grpHot
            // 
            this.grpHot.BackColor = System.Drawing.Color.Azure;
            this.grpHot.Controls.Add(this.tlpHot);
            this.grpHot.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpHot.Location = new System.Drawing.Point(656, 654);
            this.grpHot.Margin = new System.Windows.Forms.Padding(2);
            this.grpHot.Name = "grpHot";
            this.grpHot.Padding = new System.Windows.Forms.Padding(2);
            this.grpHot.Size = new System.Drawing.Size(280, 156);
            this.grpHot.TabIndex = 6;
            this.grpHot.TabStop = false;
            this.grpHot.Text = "[ 熱門查詢 ]";
            // 
            // tlpHot
            // 
            this.tlpHot.ColumnCount = 2;
            this.tlpHot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHot.Location = new System.Drawing.Point(16, 33);
            this.tlpHot.Name = "tlpHot";
            this.tlpHot.RowCount = 2;
            this.tlpHot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHot.Size = new System.Drawing.Size(239, 118);
            this.tlpHot.TabIndex = 0;
            // 
            // mnWeather
            // 
            this.mnWeather.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnWeather.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.mnWeather.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.helpToolMenu});
            this.mnWeather.Location = new System.Drawing.Point(0, 0);
            this.mnWeather.Name = "mnWeather";
            this.mnWeather.Size = new System.Drawing.Size(951, 34);
            this.mnWeather.TabIndex = 10;
            this.mnWeather.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSet,
            this.toolStripSeparator1,
            this.tsmiHistory,
            this.toolStripSeparator2,
            this.ExitMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(97, 30);
            this.FileMenu.Text = "檔案(&F)";
            // 
            // tsmiSet
            // 
            this.tsmiSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMyFavorites});
            this.tsmiSet.Name = "tsmiSet";
            this.tsmiSet.Size = new System.Drawing.Size(199, 40);
            this.tsmiSet.Text = "設定(&S)";
            // 
            // tsmiMyFavorites
            // 
            this.tsmiMyFavorites.Name = "tsmiMyFavorites";
            this.tsmiMyFavorites.Size = new System.Drawing.Size(244, 40);
            this.tsmiMyFavorites.Text = "我的最愛(&O)";
            this.tsmiMyFavorites.Click += new System.EventHandler(this.tsmiMyFavorites_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // tsmiHistory
            // 
            this.tsmiHistory.Name = "tsmiHistory";
            this.tsmiHistory.Size = new System.Drawing.Size(199, 40);
            this.tsmiHistory.Text = "檢視(&V)";
            this.tsmiHistory.Click += new System.EventHandler(this.tsmiHistory_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(199, 40);
            this.ExitMenuItem.Text = "離開(&X)";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // helpToolMenu
            // 
            this.helpToolMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.helpToolMenu.Name = "helpToolMenu";
            this.helpToolMenu.Size = new System.Drawing.Size(102, 30);
            this.helpToolMenu.Text = "幫助(&H)";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(200, 40);
            this.tsmiAbout.Text = "關於(&A)";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // frmWeather
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(951, 883);
            this.Controls.Add(this.picWeather);
            this.Controls.Add(this.grpHot);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelMarquee);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpQryResult);
            this.Controls.Add(this.grpQuery);
            this.Controls.Add(this.mnWeather);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnWeather;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmWeather";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "台灣天氣查詢系統";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWeather_FormClosing);
            this.Load += new System.EventHandler(this.frmWeather_Load);
            this.grpQuery.ResumeLayout(false);
            this.grpQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpQryResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panelMarquee.ResumeLayout(false);
            this.panelMarquee.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.grpHot.ResumeLayout(false);
            this.mnWeather.ResumeLayout(false);
            this.mnWeather.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBoxCity;
        private System.Windows.Forms.GroupBox grpQryResult;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picWeather;
        private System.Windows.Forms.Button btnQry;
        private System.Windows.Forms.Panel panelMarquee;
        private System.Windows.Forms.Label lbMarquee;
        private System.Windows.Forms.Timer timerMarquee;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.GroupBox grpHot;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblSunrise;
        private System.Windows.Forms.Label lblSunset;
        private System.Windows.Forms.MenuStrip mnWeather;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem helpToolMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiSet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiMyFavorites;
        private System.Windows.Forms.ToolStripMenuItem tsmiHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TableLayoutPanel tlpHot;
        private System.Windows.Forms.TableLayoutPanel tlpMyFavorites;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
    }
}

