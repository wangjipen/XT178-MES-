namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    partial class FinishPlanQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.DGV_Plan = new System.Windows.Forms.DataGridView();
            this.BT_Query = new System.Windows.Forms.Button();
            this.txtCode = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.chkCode = new System.Windows.Forms.CheckBox();
            this.planNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.youxianji = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operation_site = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productionid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Plan)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Font = new System.Drawing.Font("楷体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelX1.Location = new System.Drawing.Point(519, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(269, 45);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "已完成工单查询";
            // 
            // DGV_Plan
            // 
            this.DGV_Plan.AllowUserToAddRows = false;
            this.DGV_Plan.AllowUserToDeleteRows = false;
            this.DGV_Plan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.DGV_Plan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGV_Plan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Plan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Plan.ColumnHeadersHeight = 40;
            this.DGV_Plan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.planNo,
            this.datetime,
            this.line,
            this.productionType,
            this.planNumber,
            this.completeNumber,
            this.youxianji,
            this.operation_site,
            this.planid,
            this.productionid,
            this.lineId});
            this.DGV_Plan.GridColor = System.Drawing.SystemColors.Control;
            this.DGV_Plan.Location = new System.Drawing.Point(16, 174);
            this.DGV_Plan.Name = "DGV_Plan";
            this.DGV_Plan.ReadOnly = true;
            this.DGV_Plan.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_Plan.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Plan.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DGV_Plan.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Plan.RowTemplate.Height = 40;
            this.DGV_Plan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_Plan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Plan.Size = new System.Drawing.Size(1256, 500);
            this.DGV_Plan.TabIndex = 3;
            this.DGV_Plan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Plan_CellContentClick_1);
            this.DGV_Plan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_Plan_CellFormatting);
            // 
            // BT_Query
            // 
            this.BT_Query.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BT_Query.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BT_Query.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.BT_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Query.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Query.Location = new System.Drawing.Point(894, 132);
            this.BT_Query.Name = "BT_Query";
            this.BT_Query.Size = new System.Drawing.Size(81, 36);
            this.BT_Query.TabIndex = 4;
            this.BT_Query.Tag = "9999";
            this.BT_Query.Text = "查询";
            this.BT_Query.UseVisualStyleBackColor = false;
            this.BT_Query.Click += new System.EventHandler(this.BT_Query_Click);
            // 
            // txtCode
            // 
            // 
            // 
            // 
            this.txtCode.BackgroundStyle.Class = "TextBoxBorder";
            this.txtCode.ButtonClear.Visible = true;
            this.txtCode.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCode.Location = new System.Drawing.Point(278, 132);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(572, 31);
            this.txtCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtCode.TabIndex = 18;
            this.txtCode.Text = "";
            this.txtCode.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtCode_MaskInputRejected);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yy-MM-dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(246, 81);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(130, 31);
            this.dateTimePicker1.TabIndex = 20;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "HH:mm:ss";
            this.dateTimePicker2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(382, 81);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(130, 31);
            this.dateTimePicker2.TabIndex = 21;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(524, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 22;
            this.label1.Text = "——";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "yy-MM-dd";
            this.dateTimePicker3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(584, 81);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(130, 31);
            this.dateTimePicker3.TabIndex = 23;
            this.dateTimePicker3.ValueChanged += new System.EventHandler(this.dateTimePicker3_ValueChanged);
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.CustomFormat = "HH:mm:ss";
            this.dateTimePicker4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(720, 81);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.ShowUpDown = true;
            this.dateTimePicker4.Size = new System.Drawing.Size(130, 31);
            this.dateTimePicker4.TabIndex = 24;
            this.dateTimePicker4.ValueChanged += new System.EventHandler(this.dateTimePicker4_ValueChanged);
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.Checked = true;
            this.chkTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTime.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkTime.Location = new System.Drawing.Point(114, 81);
            this.chkTime.Name = "chkTime";
            this.chkTime.Size = new System.Drawing.Size(107, 33);
            this.chkTime.TabIndex = 33;
            this.chkTime.Tag = "9999";
            this.chkTime.Text = "时间:";
            this.chkTime.UseVisualStyleBackColor = true;
            // 
            // chkCode
            // 
            this.chkCode.AutoSize = true;
            this.chkCode.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkCode.Location = new System.Drawing.Point(114, 130);
            this.chkCode.Name = "chkCode";
            this.chkCode.Size = new System.Drawing.Size(167, 33);
            this.chkCode.TabIndex = 34;
            this.chkCode.Tag = "9999";
            this.chkCode.Text = "工单编号:";
            this.chkCode.UseVisualStyleBackColor = true;
            // 
            // planNo
            // 
            this.planNo.DataPropertyName = "NAME";
            this.planNo.HeaderText = "工单编号";
            this.planNo.MinimumWidth = 40;
            this.planNo.Name = "planNo";
            this.planNo.ReadOnly = true;
            this.planNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.planNo.Width = 160;
            // 
            // datetime
            // 
            this.datetime.DataPropertyName = "DT";
            this.datetime.HeaderText = "日期";
            this.datetime.Name = "datetime";
            this.datetime.ReadOnly = true;
            this.datetime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.datetime.Width = 200;
            // 
            // line
            // 
            this.line.DataPropertyName = "LineName";
            this.line.HeaderText = "产线";
            this.line.Name = "line";
            this.line.ReadOnly = true;
            this.line.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.line.Width = 157;
            // 
            // productionType
            // 
            this.productionType.DataPropertyName = "PRODUCTION_VR";
            this.productionType.HeaderText = "产品类别";
            this.productionType.Name = "productionType";
            this.productionType.ReadOnly = true;
            this.productionType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.productionType.Width = 208;
            // 
            // planNumber
            // 
            this.planNumber.DataPropertyName = "NUMBER";
            this.planNumber.HeaderText = "数量";
            this.planNumber.Name = "planNumber";
            this.planNumber.ReadOnly = true;
            this.planNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.planNumber.Width = 120;
            // 
            // completeNumber
            // 
            this.completeNumber.DataPropertyName = "COMPLETE_NUMBER";
            this.completeNumber.HeaderText = "完成";
            this.completeNumber.Name = "completeNumber";
            this.completeNumber.ReadOnly = true;
            this.completeNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.completeNumber.Width = 120;
            // 
            // youxianji
            // 
            this.youxianji.DataPropertyName = "PLAN_LEVEL";
            this.youxianji.HeaderText = "优先级";
            this.youxianji.Name = "youxianji";
            this.youxianji.ReadOnly = true;
            this.youxianji.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.youxianji.Width = 120;
            // 
            // operation_site
            // 
            this.operation_site.DataPropertyName = "COMPLETE_FLAG";
            this.operation_site.HeaderText = "状态";
            this.operation_site.MinimumWidth = 10;
            this.operation_site.Name = "operation_site";
            this.operation_site.ReadOnly = true;
            this.operation_site.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.operation_site.Width = 168;
            // 
            // planid
            // 
            this.planid.DataPropertyName = "ID";
            this.planid.HeaderText = "计划编号";
            this.planid.Name = "planid";
            this.planid.ReadOnly = true;
            this.planid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.planid.Visible = false;
            // 
            // productionid
            // 
            this.productionid.DataPropertyName = "PRODUCTION_ID";
            this.productionid.HeaderText = "产品编号";
            this.productionid.Name = "productionid";
            this.productionid.ReadOnly = true;
            this.productionid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.productionid.Visible = false;
            // 
            // lineId
            // 
            this.lineId.DataPropertyName = "LINE_ID";
            this.lineId.HeaderText = "产线编号";
            this.lineId.Name = "lineId";
            this.lineId.ReadOnly = true;
            this.lineId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lineId.Visible = false;
            // 
            // FinishPlanQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1284, 684);
            this.Controls.Add(this.chkCode);
            this.Controls.Add(this.chkTime);
            this.Controls.Add(this.dateTimePicker4);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.BT_Query);
            this.Controls.Add(this.DGV_Plan);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FinishPlanQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "已完成工单";
            this.Load += new System.EventHandler(this.FinishPlanQuery_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Plan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        public System.Windows.Forms.DataGridView DGV_Plan;
        private System.Windows.Forms.Button BT_Query;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtCode;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.DataGridViewTextBoxColumn operation;
        private System.Windows.Forms.CheckBox chkTime;
        private System.Windows.Forms.CheckBox chkCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn planNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn line;
        private System.Windows.Forms.DataGridViewTextBoxColumn productionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn planNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn completeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn youxianji;
        private System.Windows.Forms.DataGridViewTextBoxColumn operation_site;
        private System.Windows.Forms.DataGridViewTextBoxColumn planid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productionid;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineId;
    }
}