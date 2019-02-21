namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    partial class Airtightness
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
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.bt_Export = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_search_X = new System.Windows.Forms.Button();
            this.btn_ExTWO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // plotView1
            // 
            this.plotView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.plotView1.BackgroundImage = global::IntelligentMaterialRack.Properties.Resources.AX;
            this.plotView1.Location = new System.Drawing.Point(8, 52);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(1347, 685);
            this.plotView1.TabIndex = 0;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM";
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 12F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(148, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.Value = new System.DateTime(2017, 12, 13, 17, 3, 52, 0);
            // 
            // bt_Export
            // 
            this.bt_Export.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Export.Location = new System.Drawing.Point(1397, 6);
            this.bt_Export.Name = "bt_Export";
            this.bt_Export.Size = new System.Drawing.Size(75, 44);
            this.bt_Export.TabIndex = 7;
            this.bt_Export.Text = "导出";
            this.bt_Export.UseVisualStyleBackColor = true;
            this.bt_Export.Click += new System.EventHandler(this.bt_Export_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "选择日期：";
            // 
            // bt_search_X
            // 
            this.bt_search_X.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_search_X.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_search_X.Location = new System.Drawing.Point(366, 7);
            this.bt_search_X.Name = "bt_search_X";
            this.bt_search_X.Size = new System.Drawing.Size(75, 34);
            this.bt_search_X.TabIndex = 13;
            this.bt_search_X.Tag = "9999";
            this.bt_search_X.Text = "查询";
            this.bt_search_X.UseVisualStyleBackColor = true;
            this.bt_search_X.Click += new System.EventHandler(this.bt_search_X_Click);
            // 
            // btn_ExTWO
            // 
            this.btn_ExTWO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ExTWO.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ExTWO.Location = new System.Drawing.Point(1280, 7);
            this.btn_ExTWO.Name = "btn_ExTWO";
            this.btn_ExTWO.Size = new System.Drawing.Size(75, 35);
            this.btn_ExTWO.TabIndex = 15;
            this.btn_ExTWO.Tag = "9999";
            this.btn_ExTWO.Text = "导出";
            this.btn_ExTWO.UseVisualStyleBackColor = true;
            this.btn_ExTWO.Click += new System.EventHandler(this.btn_ExTWO_Click_1);
            // 
            // Airtightness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 742);
            this.Controls.Add(this.btn_ExTWO);
            this.Controls.Add(this.bt_search_X);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Export);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.plotView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Airtightness";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "气密性测试统计";
            this.Load += new System.EventHandler(this.Airtightness_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button bt_Export;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_search_X;
        private System.Windows.Forms.Button btn_ExTWO;
    }
}