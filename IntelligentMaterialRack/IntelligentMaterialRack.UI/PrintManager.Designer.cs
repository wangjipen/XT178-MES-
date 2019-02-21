namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    partial class PrintManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintManager));
            this.dGV_Print = new System.Windows.Forms.DataGridView();
            this.rTB_Barcode = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_operationuser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tB_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_select = new System.Windows.Forms.Button();
            this.lb_LINE_ID = new System.Windows.Forms.ComboBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_VR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPREATION_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLAN_LEVEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Print)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGV_Print
            // 
            this.dGV_Print.AllowUserToAddRows = false;
            this.dGV_Print.AllowUserToResizeColumns = false;
            this.dGV_Print.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_Print.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGV_Print.ColumnHeadersHeight = 40;
            this.dGV_Print.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PRODUCTION_VR,
            this.NAME,
            this.DT,
            this.PRODUCTION_ID,
            this.LINE_ID,
            this.NUMBER,
            this.OPREATION_USER,
            this.PLAN_LEVEL});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGV_Print.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGV_Print.Location = new System.Drawing.Point(-4, 67);
            this.dGV_Print.Name = "dGV_Print";
            this.dGV_Print.ReadOnly = true;
            this.dGV_Print.RowHeadersVisible = false;
            this.dGV_Print.RowTemplate.Height = 41;
            this.dGV_Print.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_Print.Size = new System.Drawing.Size(1078, 678);
            this.dGV_Print.TabIndex = 0;
            this.dGV_Print.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Print_CellContentClick);
            this.dGV_Print.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dGV_Print_CellFormatting);
            this.dGV_Print.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dGV_Print_EditingControlShowing);
            // 
            // rTB_Barcode
            // 
            this.rTB_Barcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(250)))));
            this.rTB_Barcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTB_Barcode.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rTB_Barcode.Location = new System.Drawing.Point(1082, 67);
            this.rTB_Barcode.Name = "rTB_Barcode";
            this.rTB_Barcode.Size = new System.Drawing.Size(277, 678);
            this.rTB_Barcode.TabIndex = 2;
            this.rTB_Barcode.Text = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(35, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "生成条码动态展示";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1080, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 60);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // tb_operationuser
            // 
            this.tb_operationuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_operationuser.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_operationuser.Location = new System.Drawing.Point(643, 20);
            this.tb_operationuser.Multiline = true;
            this.tb_operationuser.Name = "tb_operationuser";
            this.tb_operationuser.Size = new System.Drawing.Size(145, 29);
            this.tb_operationuser.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(551, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "操作人员:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(9, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "产线:";
            // 
            // tB_name
            // 
            this.tB_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_name.Location = new System.Drawing.Point(372, 23);
            this.tB_name.Multiline = true;
            this.tB_name.Name = "tB_name";
            this.tB_name.Size = new System.Drawing.Size(145, 29);
            this.tB_name.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(280, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "产品类型:";
            // 
            // bt_select
            // 
            this.bt_select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(250)))));
            this.bt_select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_select.Image = ((System.Drawing.Image)(resources.GetObject("bt_select.Image")));
            this.bt_select.Location = new System.Drawing.Point(863, 20);
            this.bt_select.Name = "bt_select";
            this.bt_select.Size = new System.Drawing.Size(111, 32);
            this.bt_select.TabIndex = 13;
            this.bt_select.UseVisualStyleBackColor = false;
            this.bt_select.Click += new System.EventHandler(this.bt_select_Click);
            // 
            // lb_LINE_ID
            // 
            this.lb_LINE_ID.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_LINE_ID.FormattingEnabled = true;
            this.lb_LINE_ID.Location = new System.Drawing.Point(53, 21);
            this.lb_LINE_ID.Name = "lb_LINE_ID";
            this.lb_LINE_ID.Size = new System.Drawing.Size(221, 28);
            this.lb_LINE_ID.TabIndex = 14;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "工单编号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCTION_VR
            // 
            this.PRODUCTION_VR.DataPropertyName = "PRODUCTION_VR";
            this.PRODUCTION_VR.HeaderText = "产品类型";
            this.PRODUCTION_VR.Name = "PRODUCTION_VR";
            this.PRODUCTION_VR.ReadOnly = true;
            this.PRODUCTION_VR.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PRODUCTION_VR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCTION_VR.Width = 165;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "工单";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NAME.Width = 165;
            // 
            // DT
            // 
            this.DT.DataPropertyName = "DT";
            this.DT.HeaderText = "日期";
            this.DT.Name = "DT";
            this.DT.ReadOnly = true;
            this.DT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DT.Width = 190;
            // 
            // PRODUCTION_ID
            // 
            this.PRODUCTION_ID.DataPropertyName = "PRODUCTION_ID";
            this.PRODUCTION_ID.HeaderText = "产品ID";
            this.PRODUCTION_ID.Name = "PRODUCTION_ID";
            this.PRODUCTION_ID.ReadOnly = true;
            this.PRODUCTION_ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PRODUCTION_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCTION_ID.Visible = false;
            this.PRODUCTION_ID.Width = 90;
            // 
            // LINE_ID
            // 
            this.LINE_ID.DataPropertyName = "LINE_ID";
            this.LINE_ID.HeaderText = "产线";
            this.LINE_ID.Name = "LINE_ID";
            this.LINE_ID.ReadOnly = true;
            this.LINE_ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LINE_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LINE_ID.Width = 70;
            // 
            // NUMBER
            // 
            this.NUMBER.DataPropertyName = "NUMBER";
            this.NUMBER.HeaderText = "数量";
            this.NUMBER.Name = "NUMBER";
            this.NUMBER.ReadOnly = true;
            this.NUMBER.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NUMBER.Width = 70;
            // 
            // OPREATION_USER
            // 
            this.OPREATION_USER.DataPropertyName = "OPREATION_USER";
            this.OPREATION_USER.HeaderText = "操作人员";
            this.OPREATION_USER.Name = "OPREATION_USER";
            this.OPREATION_USER.ReadOnly = true;
            this.OPREATION_USER.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OPREATION_USER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OPREATION_USER.Width = 120;
            // 
            // PLAN_LEVEL
            // 
            this.PLAN_LEVEL.DataPropertyName = "PLAN_LEVEL";
            this.PLAN_LEVEL.HeaderText = "优先级";
            this.PLAN_LEVEL.Name = "PLAN_LEVEL";
            this.PLAN_LEVEL.ReadOnly = true;
            this.PLAN_LEVEL.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PLAN_LEVEL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PLAN_LEVEL.Width = 90;
            // 
            // PrintManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 745);
            this.Controls.Add(this.lb_LINE_ID);
            this.Controls.Add(this.bt_select);
            this.Controls.Add(this.tb_operationuser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tB_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rTB_Barcode);
            this.Controls.Add(this.dGV_Print);
            this.Name = "PrintManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成条码";
            this.Load += new System.EventHandler(this.PrintManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Print)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV_Print;
        private System.Windows.Forms.RichTextBox rTB_Barcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_operationuser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tB_name;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Button bt_select;
        private System.Windows.Forms.ComboBox lb_LINE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_VR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPREATION_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_LEVEL;
    }
}