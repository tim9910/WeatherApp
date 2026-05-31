namespace WeatherApp
{
    partial class frmApilog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvApiResult = new System.Windows.Forms.DataGridView();
            this.plTop = new System.Windows.Forms.Panel();
            this.plQuery = new System.Windows.Forms.Panel();
            this.cbBoxAPI = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApiResult)).BeginInit();
            this.plTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvApiResult);
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1276, 583);
            this.panel2.TabIndex = 5;
            // 
            // dgvApiResult
            // 
            this.dgvApiResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvApiResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApiResult.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvApiResult.Location = new System.Drawing.Point(0, 0);
            this.dgvApiResult.Name = "dgvApiResult";
            this.dgvApiResult.RowHeadersWidth = 72;
            this.dgvApiResult.RowTemplate.Height = 35;
            this.dgvApiResult.Size = new System.Drawing.Size(1276, 583);
            this.dgvApiResult.TabIndex = 4;
            this.dgvApiResult.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvApiResult_CellFormatting);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.plQuery);
            this.plTop.Controls.Add(this.cbBoxAPI);
            this.plTop.Controls.Add(this.label1);
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(1276, 46);
            this.plTop.TabIndex = 6;
            // 
            // plQuery
            // 
            this.plQuery.Location = new System.Drawing.Point(280, 8);
            this.plQuery.Name = "plQuery";
            this.plQuery.Size = new System.Drawing.Size(993, 37);
            this.plQuery.TabIndex = 11;
            // 
            // cbBoxAPI
            // 
            this.cbBoxAPI.Font = new System.Drawing.Font("微軟正黑體", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbBoxAPI.FormattingEnabled = true;
            this.cbBoxAPI.Location = new System.Drawing.Point(119, 8);
            this.cbBoxAPI.Name = "cbBoxAPI";
            this.cbBoxAPI.Size = new System.Drawing.Size(155, 37);
            this.cbBoxAPI.TabIndex = 10;
            this.cbBoxAPI.SelectedIndexChanged += new System.EventHandler(this.cbBoxAPI_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "查詢條件";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmApilog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 636);
            this.Controls.Add(this.plTop);
            this.Controls.Add(this.panel2);
            this.MaximumSize = new System.Drawing.Size(1300, 700);
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "frmApilog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "API 呼叫紀錄查詢";
            this.Load += new System.EventHandler(this.frmApilog_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApiResult)).EndInit();
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvApiResult;
        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Panel plQuery;
        private System.Windows.Forms.ComboBox cbBoxAPI;
        private System.Windows.Forms.Label label1;
    }
}