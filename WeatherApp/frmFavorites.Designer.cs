namespace WeatherApp
{
    partial class frmFavorites
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
            this.lvAvailable = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvFavorites = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvAvailable
            // 
            this.lvAvailable.Font = new System.Drawing.Font("微軟正黑體", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lvAvailable.HideSelection = false;
            this.lvAvailable.Location = new System.Drawing.Point(2, 45);
            this.lvAvailable.Name = "lvAvailable";
            this.lvAvailable.Size = new System.Drawing.Size(330, 391);
            this.lvAvailable.TabIndex = 0;
            this.lvAvailable.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(-2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "可加入城市清單";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(354, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "已加入最愛城市清單";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvFavorites
            // 
            this.lvFavorites.Font = new System.Drawing.Font("微軟正黑體", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lvFavorites.HideSelection = false;
            this.lvFavorites.Location = new System.Drawing.Point(346, 45);
            this.lvFavorites.Name = "lvFavorites";
            this.lvFavorites.Size = new System.Drawing.Size(330, 391);
            this.lvFavorites.TabIndex = 2;
            this.lvFavorites.UseCompatibleStateImageBehavior = false;
            // 
            // frmFavorites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 439);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvFavorites);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvAvailable);
            this.Name = "frmFavorites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "我的最愛";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFavorites_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvAvailable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvFavorites;
    }
}