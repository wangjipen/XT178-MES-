namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    partial class PlanManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanManager));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.PL_BTPanel = new System.Windows.Forms.Panel();
            this.BT_Edit = new System.Windows.Forms.Button();
            this.PL_EDPanel = new System.Windows.Forms.Panel();
            this.BT_Clean = new System.Windows.Forms.Button();
            this.BT_Save = new System.Windows.Forms.Button();
            this.TB_OperationUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_Line = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UD_ProductionNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_ProductionType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_PlanNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PL_LogPanel = new System.Windows.Forms.Panel();
            this.BT_Down = new System.Windows.Forms.Button();
            this.BT_Up = new System.Windows.Forms.Button();
            this.DGV_Plan = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.planNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.youxianji = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.planid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productionid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            this.PL_BTPanel.SuspendLayout();
            this.PL_EDPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UD_ProductionNumber)).BeginInit();
            this.PL_LogPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Plan)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(563, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(196, 45);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "计划管理";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.PL_BTPanel);
            this.flowLayoutPanel1.Controls.Add(this.PL_EDPanel);
            this.flowLayoutPanel1.Controls.Add(this.PL_LogPanel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 65);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1277, 680);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // PL_BTPanel
            // 
            this.PL_BTPanel.Controls.Add(this.BT_Edit);
            this.PL_BTPanel.Location = new System.Drawing.Point(3, 3);
            this.PL_BTPanel.Name = "PL_BTPanel";
            this.PL_BTPanel.Size = new System.Drawing.Size(1274, 39);
            this.PL_BTPanel.TabIndex = 0;
            // 
            // BT_Edit
            // 
            this.BT_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Edit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Edit.Location = new System.Drawing.Point(1170, 3);
            this.BT_Edit.Name = "BT_Edit";
            this.BT_Edit.Size = new System.Drawing.Size(95, 33);
            this.BT_Edit.TabIndex = 0;
            this.BT_Edit.Tag = "9999";
            this.BT_Edit.Text = "编辑";
            this.BT_Edit.UseVisualStyleBackColor = true;
            this.BT_Edit.Click += new System.EventHandler(this.BT_Edit_Click);
            // 
            // PL_EDPanel
            // 
            this.PL_EDPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PL_EDPanel.Controls.Add(this.BT_Clean);
            this.PL_EDPanel.Controls.Add(this.BT_Save);
            this.PL_EDPanel.Controls.Add(this.TB_OperationUser);
            this.PL_EDPanel.Controls.Add(this.label5);
            this.PL_EDPanel.Controls.Add(this.CB_Line);
            this.PL_EDPanel.Controls.Add(this.label4);
            this.PL_EDPanel.Controls.Add(this.UD_ProductionNumber);
            this.PL_EDPanel.Controls.Add(this.label3);
            this.PL_EDPanel.Controls.Add(this.CB_ProductionType);
            this.PL_EDPanel.Controls.Add(this.label2);
            this.PL_EDPanel.Controls.Add(this.TB_PlanNumber);
            this.PL_EDPanel.Controls.Add(this.label1);
            this.PL_EDPanel.Location = new System.Drawing.Point(3, 46);
            this.PL_EDPanel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.PL_EDPanel.Name = "PL_EDPanel";
            this.PL_EDPanel.Size = new System.Drawing.Size(1274, 206);
            this.PL_EDPanel.TabIndex = 1;
            this.PL_EDPanel.Visible = false;
            // 
            // BT_Clean
            // 
            this.BT_Clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Clean.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Clean.Location = new System.Drawing.Point(659, 157);
            this.BT_Clean.Name = "BT_Clean";
            this.BT_Clean.Size = new System.Drawing.Size(95, 33);
            this.BT_Clean.TabIndex = 11;
            this.BT_Clean.Tag = "9999";
            this.BT_Clean.Text = "取消";
            this.BT_Clean.UseVisualStyleBackColor = true;
            this.BT_Clean.Click += new System.EventHandler(this.BT_Clean_Click);
            // 
            // BT_Save
            // 
            this.BT_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Save.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Save.Location = new System.Drawing.Point(402, 157);
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Size = new System.Drawing.Size(95, 33);
            this.BT_Save.TabIndex = 10;
            this.BT_Save.Tag = "9999";
            this.BT_Save.Text = "确定";
            this.BT_Save.UseVisualStyleBackColor = true;
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // TB_OperationUser
            // 
            this.TB_OperationUser.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_OperationUser.Location = new System.Drawing.Point(530, 85);
            this.TB_OperationUser.Name = "TB_OperationUser";
            this.TB_OperationUser.Size = new System.Drawing.Size(261, 30);
            this.TB_OperationUser.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(425, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "操作人员:";
            // 
            // CB_Line
            // 
            this.CB_Line.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_Line.FormattingEnabled = true;
            this.CB_Line.Location = new System.Drawing.Point(108, 28);
            this.CB_Line.Name = "CB_Line";
            this.CB_Line.Size = new System.Drawing.Size(252, 28);
            this.CB_Line.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "产线:";
            // 
            // UD_ProductionNumber
            // 
            this.UD_ProductionNumber.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UD_ProductionNumber.Location = new System.Drawing.Point(108, 86);
            this.UD_ProductionNumber.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.UD_ProductionNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UD_ProductionNumber.Name = "UD_ProductionNumber";
            this.UD_ProductionNumber.Size = new System.Drawing.Size(252, 30);
            this.UD_ProductionNumber.TabIndex = 5;
            this.UD_ProductionNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "生产数量:";
            // 
            // CB_ProductionType
            // 
            this.CB_ProductionType.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_ProductionType.FormattingEnabled = true;
            this.CB_ProductionType.Location = new System.Drawing.Point(946, 28);
            this.CB_ProductionType.Name = "CB_ProductionType";
            this.CB_ProductionType.Size = new System.Drawing.Size(252, 28);
            this.CB_ProductionType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(841, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "产品类别:";
            // 
            // TB_PlanNumber
            // 
            this.TB_PlanNumber.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_PlanNumber.Location = new System.Drawing.Point(530, 28);
            this.TB_PlanNumber.Name = "TB_PlanNumber";
            this.TB_PlanNumber.Size = new System.Drawing.Size(261, 30);
            this.TB_PlanNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(425, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "工单编号:";
            // 
            // PL_LogPanel
            // 
            this.PL_LogPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PL_LogPanel.Controls.Add(this.BT_Down);
            this.PL_LogPanel.Controls.Add(this.BT_Up);
            this.PL_LogPanel.Controls.Add(this.DGV_Plan);
            this.PL_LogPanel.Location = new System.Drawing.Point(1, 256);
            this.PL_LogPanel.Margin = new System.Windows.Forms.Padding(1);
            this.PL_LogPanel.Name = "PL_LogPanel";
            this.PL_LogPanel.Size = new System.Drawing.Size(1276, 424);
            this.PL_LogPanel.TabIndex = 2;
            // 
            // BT_Down
            // 
            this.BT_Down.FlatAppearance.BorderSize = 0;
            this.BT_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Down.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Down.Image = ((System.Drawing.Image)(resources.GetObject("BT_Down.Image")));
            this.BT_Down.Location = new System.Drawing.Point(1210, 264);
            this.BT_Down.Name = "BT_Down";
            this.BT_Down.Size = new System.Drawing.Size(53, 72);
            this.BT_Down.TabIndex = 12;
            this.BT_Down.Tag = "9999";
            this.BT_Down.UseVisualStyleBackColor = true;
            this.BT_Down.Click += new System.EventHandler(this.BT_Down_Click);
            // 
            // BT_Up
            // 
            this.BT_Up.FlatAppearance.BorderSize = 0;
            this.BT_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Up.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Up.Image = ((System.Drawing.Image)(resources.GetObject("BT_Up.Image")));
            this.BT_Up.Location = new System.Drawing.Point(1210, 115);
            this.BT_Up.Name = "BT_Up";
            this.BT_Up.Size = new System.Drawing.Size(53, 72);
            this.BT_Up.TabIndex = 11;
            this.BT_Up.Tag = "9999";
            this.BT_Up.UseVisualStyleBackColor = true;
            this.BT_Up.Click += new System.EventHandler(this.BT_Up_Click);
            // 
            // DGV_Plan
            // 
            this.DGV_Plan.AllowUserToAddRows = false;
            this.DGV_Plan.AllowUserToDeleteRows = false;
            this.DGV_Plan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.DGV_Plan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.operation,
            this.planid,
            this.productionid,
            this.lineId});
            this.DGV_Plan.GridColor = System.Drawing.SystemColors.Control;
            this.DGV_Plan.Location = new System.Drawing.Point(0, 3);
            this.DGV_Plan.Name = "DGV_Plan";
            this.DGV_Plan.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_Plan.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Plan.RowHeadersVisible = false;
            this.DGV_Plan.RowTemplate.Height = 40;
            this.DGV_Plan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Plan.Size = new System.Drawing.Size(1204, 418);
            this.DGV_Plan.TabIndex = 0;
            this.DGV_Plan.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DGV_Plan_DataError);
            this.DGV_Plan.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_Plan_EditingControlShowing);
            // 
            // planNo
            // 
            this.planNo.DataPropertyName = "NAME";
            this.planNo.HeaderText = "工单编号";
            this.planNo.MinimumWidth = 40;
            this.planNo.Name = "planNo";
            this.planNo.ReadOnly = true;
            this.planNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.planNo.Width = 172;
            // 
            // datetime
            // 
            this.datetime.DataPropertyName = "DT";
            this.datetime.HeaderText = "日期";
            this.datetime.Name = "datetime";
            this.datetime.ReadOnly = true;
            this.datetime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.datetime.Width = 171;
            // 
            // line
            // 
            this.line.DataPropertyName = "LineName";
            this.line.HeaderText = "产线";
            this.line.Name = "line";
            this.line.ReadOnly = true;
            this.line.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.line.Width = 172;
            // 
            // productionType
            // 
            this.productionType.DataPropertyName = "PRODUCTION_NAME";
            this.productionType.HeaderText = "产品类别";
            this.productionType.Name = "productionType";
            this.productionType.ReadOnly = true;
            this.productionType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.productionType.Width = 171;
            // 
            // planNumber
            // 
            this.planNumber.DataPropertyName = "NUMBER";
            this.planNumber.HeaderText = "数量";
            this.planNumber.Name = "planNumber";
            this.planNumber.ReadOnly = true;
            this.planNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.planNumber.Width = 172;
            // 
            // completeNumber
            // 
            this.completeNumber.DataPropertyName = "COMPLETE_NUMBER";
            this.completeNumber.HeaderText = "完成";
            this.completeNumber.Name = "completeNumber";
            this.completeNumber.ReadOnly = true;
            this.completeNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // youxianji
            // 
            this.youxianji.DataPropertyName = "PLAN_LEVEL";
            this.youxianji.HeaderText = "优先级";
            this.youxianji.Name = "youxianji";
            this.youxianji.ReadOnly = true;
            this.youxianji.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.youxianji.Width = 171;
            // 
            // operation
            // 
            this.operation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.operation.DataPropertyName = "COMPLETE_FLAG";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.operation.DefaultCellStyle = dataGridViewCellStyle2;
            this.operation.DisplayStyleForCurrentCellOnly = true;
            this.operation.DropDownWidth = 4;
            this.operation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.operation.HeaderText = "操作";
            this.operation.Items.AddRange(new object[] {
            "初始化",
            "开始",
            "暂停",
            "强制关闭"});
            this.operation.Name = "operation";
            // 
            // planid
            // 
            this.planid.DataPropertyName = "ID";
            this.planid.HeaderText = "计划编号";
            this.planid.Name = "planid";
            this.planid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.planid.Visible = false;
            // 
            // productionid
            // 
            this.productionid.DataPropertyName = "PRODUCTION_ID";
            this.productionid.HeaderText = "产品编号";
            this.productionid.Name = "productionid";
            this.productionid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.productionid.Visible = false;
            // 
            // lineId
            // 
            this.lineId.DataPropertyName = "LINE_ID";
            this.lineId.HeaderText = "产线编号";
            this.lineId.Name = "lineId";
            this.lineId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lineId.Visible = false;
            // 
            // PlanManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1282, 745);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PlanManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计划管理";
            this.Load += new System.EventHandler(this.PlanManager_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.PL_BTPanel.ResumeLayout(false);
            this.PL_EDPanel.ResumeLayout(false);
            this.PL_EDPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UD_ProductionNumber)).EndInit();
            this.PL_LogPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Plan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel PL_BTPanel;
        private System.Windows.Forms.Panel PL_EDPanel;
        private System.Windows.Forms.Panel PL_LogPanel;
        private System.Windows.Forms.Button BT_Edit;
        private System.Windows.Forms.TextBox TB_PlanNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_ProductionType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown UD_ProductionNumber;
        private System.Windows.Forms.Button BT_Save;
        private System.Windows.Forms.TextBox TB_OperationUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CB_Line;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BT_Clean;
        public System.Windows.Forms.DataGridView DGV_Plan;
        private System.Windows.Forms.Button BT_Up;
        private System.Windows.Forms.Button BT_Down;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn planNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn line;
        private System.Windows.Forms.DataGridViewTextBoxColumn productionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn planNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn completeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn youxianji;
        private System.Windows.Forms.DataGridViewComboBoxColumn operation;
        private System.Windows.Forms.DataGridViewTextBoxColumn planid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productionid;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineId;
    }
}