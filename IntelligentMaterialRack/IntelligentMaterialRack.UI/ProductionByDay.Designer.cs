namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    partial class ProductionByDay
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.bt_search_X = new System.Windows.Forms.Button();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.btn_ExTWO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "选择日期：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM";
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 12F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(162, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker1.Value = new System.DateTime(2017, 12, 13, 17, 3, 52, 0);
            // 
            // bt_search_X
            // 
            this.bt_search_X.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_search_X.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_search_X.Location = new System.Drawing.Point(417, 11);
            this.bt_search_X.Name = "bt_search_X";
            this.bt_search_X.Size = new System.Drawing.Size(75, 34);
            this.bt_search_X.TabIndex = 11;
            this.bt_search_X.Tag = "9999";
            this.bt_search_X.Text = "查询";
            this.bt_search_X.UseVisualStyleBackColor = true;
            this.bt_search_X.Click += new System.EventHandler(this.bt_search_X_Click);
            // 
            // plotView1
            // 
            this.plotView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.plotView1.BackgroundImage = global::IntelligentMaterialRack.Properties.Resources.AX;
            this.plotView1.Location = new System.Drawing.Point(15, 56);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(1328, 673);
            this.plotView1.TabIndex = 12;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // btn_ExTWO
            // 
            this.btn_ExTWO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ExTWO.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ExTWO.Location = new System.Drawing.Point(1238, 10);
            this.btn_ExTWO.Name = "btn_ExTWO";
            this.btn_ExTWO.Size = new System.Drawing.Size(75, 39);
            this.btn_ExTWO.TabIndex = 13;
            this.btn_ExTWO.Tag = "9999";
            this.btn_ExTWO.Text = "导出";
            this.btn_ExTWO.UseVisualStyleBackColor = true;
            this.btn_ExTWO.Click += new System.EventHandler(this.btn_ExTWO_Click);
            // 
            // ProductionByDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 742);
            this.Controls.Add(this.btn_ExTWO);
            this.Controls.Add(this.plotView1);
            this.Controls.Add(this.bt_search_X);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProductionByDay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日产量统计";
            this.Load += new System.EventHandler(this.ProductionByDay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button bt_search_X;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.Button btn_ExTWO;
    }
}