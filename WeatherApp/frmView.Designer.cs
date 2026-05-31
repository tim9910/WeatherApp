namespace WeatherApp
{
    partial class frmView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmView));
            this.lvwResult = new System.Windows.Forms.ListView();
            this.city = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clickcnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clicktime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwResult
            // 
            this.lvwResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.city,
            this.clickcnt,
            this.clicktime});
            this.lvwResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwResult.HideSelection = false;
            this.lvwResult.Location = new System.Drawing.Point(0, 0);
            this.lvwResult.Name = "lvwResult";
            this.lvwResult.Size = new System.Drawing.Size(764, 443);
            this.lvwResult.TabIndex = 0;
            this.lvwResult.UseCompatibleStateImageBehavior = false;
            this.lvwResult.View = System.Windows.Forms.View.Details;
            this.lvwResult.MouseLeave += new System.EventHandler(this.lvwResult_MouseLeave);
            this.lvwResult.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvwResult_MouseMove);
            // 
            // city
            // 
            this.city.Text = "縣市";
            this.city.Width = 100;
            // 
            // clickcnt
            // 
            this.clickcnt.Text = "查詢次數";
            this.clickcnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clickcnt.Width = 120;
            // 
            // clicktime
            // 
            this.clicktime.Text = "最後查詢時間";
            this.clicktime.Width = 170;
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 443);
            this.Controls.Add(this.lvwResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "搜尋紀錄檢視";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmView_FormClosing);
            this.Load += new System.EventHandler(this.frmView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwResult;
        private System.Windows.Forms.ColumnHeader city;
        private System.Windows.Forms.ColumnHeader clickcnt;
        private System.Windows.Forms.ColumnHeader clicktime;
    }
}