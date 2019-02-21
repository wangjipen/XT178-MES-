namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    partial class WarningManagement
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DGV_CodeInfor = new System.Windows.Forms.DataGridView();
            this.datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PL_Title = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PL_BT = new System.Windows.Forms.Panel();
            this.BT_Query = new System.Windows.Forms.Button();
            this.TB_CodeQuery = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BT_Edit = new System.Windows.Forms.Button();
            this.PL_Edit = new System.Windows.Forms.Panel();
            this.BT_Delete = new System.Windows.Forms.Button();
            this.BT_Clear = new System.Windows.Forms.Button();
            this.BT_Save = new System.Windows.Forms.Button();
            this.TB_EnglishInfor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Code = new System.Windows.Forms.TextBox();
            this.TB_ChineseInfor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PL_Delete = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CodeInfor)).BeginInit();
            this.PL_Title.SuspendLayout();
            this.PL_BT.SuspendLayout();
            this.PL_Edit.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DGV_CodeInfor, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.PL_Title, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PL_BT, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PL_Edit, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.PL_Delete, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1278, 706);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DGV_CodeInfor
            // 
            this.DGV_CodeInfor.AllowUserToAddRows = false;
            this.DGV_CodeInfor.AllowUserToDeleteRows = false;
            this.DGV_CodeInfor.AllowUserToResizeColumns = false;
            this.DGV_CodeInfor.AllowUserToResizeRows = false;
            this.DGV_CodeInfor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.DGV_CodeInfor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGV_CodeInfor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_CodeInfor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_CodeInfor.ColumnHeadersHeight = 40;
            this.DGV_CodeInfor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datetime,
            this.line,
            this.productionType});
            this.DGV_CodeInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_CodeInfor.GridColor = System.Drawing.SystemColors.Control;
            this.DGV_CodeInfor.Location = new System.Drawing.Point(3, 270);
            this.DGV_CodeInfor.Name = "DGV_CodeInfor";
            this.DGV_CodeInfor.ReadOnly = true;
            this.DGV_CodeInfor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_CodeInfor.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_CodeInfor.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DGV_CodeInfor.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_CodeInfor.RowTemplate.Height = 40;
            this.DGV_CodeInfor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_CodeInfor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_CodeInfor.Size = new System.Drawing.Size(1272, 294);
            this.DGV_CodeInfor.TabIndex = 33;
            this.DGV_CodeInfor.DoubleClick += new System.EventHandler(this.DGV_CodeInfor_DoubleClick);
            // 
            // datetime
            // 
            this.datetime.DataPropertyName = "ALARM_CODE";
            this.datetime.HeaderText = "报警代码";
            this.datetime.Name = "datetime";
            this.datetime.ReadOnly = true;
            this.datetime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.datetime.Width = 153;
            // 
            // line
            // 
            this.line.DataPropertyName = "ALARM_TEXT";
            this.line.HeaderText = "中文信息";
            this.line.Name = "line";
            this.line.ReadOnly = true;
            this.line.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.line.Width = 558;
            // 
            // productionType
            // 
            this.productionType.DataPropertyName = "ALARM_ENGLISH";
            this.productionType.HeaderText = "英文信息";
            this.productionType.Name = "productionType";
            this.productionType.ReadOnly = true;
            this.productionType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.productionType.Width = 558;
            // 
            // PL_Title
            // 
            this.PL_Title.Controls.Add(this.label1);
            this.PL_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_Title.Location = new System.Drawing.Point(3, 3);
            this.PL_Title.Name = "PL_Title";
            this.PL_Title.Size = new System.Drawing.Size(1272, 44);
            this.PL_Title.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(517, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "报警信息管理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PL_BT
            // 
            this.PL_BT.Controls.Add(this.BT_Query);
            this.PL_BT.Controls.Add(this.TB_CodeQuery);
            this.PL_BT.Controls.Add(this.label5);
            this.PL_BT.Controls.Add(this.BT_Edit);
            this.PL_BT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_BT.Location = new System.Drawing.Point(3, 53);
            this.PL_BT.Name = "PL_BT";
            this.PL_BT.Size = new System.Drawing.Size(1272, 55);
            this.PL_BT.TabIndex = 35;
            // 
            // BT_Query
            // 
            this.BT_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Query.Location = new System.Drawing.Point(980, 6);
            this.BT_Query.Name = "BT_Query";
            this.BT_Query.Size = new System.Drawing.Size(95, 33);
            this.BT_Query.TabIndex = 13;
            this.BT_Query.Tag = "9999";
            this.BT_Query.Text = "查询";
            this.BT_Query.UseVisualStyleBackColor = true;
            this.BT_Query.Click += new System.EventHandler(this.BT_Query_Click);
            // 
            // TB_CodeQuery
            // 
            this.TB_CodeQuery.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_CodeQuery.Location = new System.Drawing.Point(143, 6);
            this.TB_CodeQuery.Name = "TB_CodeQuery";
            this.TB_CodeQuery.Size = new System.Drawing.Size(389, 30);
            this.TB_CodeQuery.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(38, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "报警代码:";
            // 
            // BT_Edit
            // 
            this.BT_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Edit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Edit.Location = new System.Drawing.Point(1126, 6);
            this.BT_Edit.Name = "BT_Edit";
            this.BT_Edit.Size = new System.Drawing.Size(95, 33);
            this.BT_Edit.TabIndex = 1;
            this.BT_Edit.Tag = "9999";
            this.BT_Edit.Text = "编辑";
            this.BT_Edit.UseVisualStyleBackColor = true;
            this.BT_Edit.Click += new System.EventHandler(this.BT_Edit_Click);
            // 
            // PL_Edit
            // 
            this.PL_Edit.Controls.Add(this.BT_Delete);
            this.PL_Edit.Controls.Add(this.BT_Clear);
            this.PL_Edit.Controls.Add(this.BT_Save);
            this.PL_Edit.Controls.Add(this.TB_EnglishInfor);
            this.PL_Edit.Controls.Add(this.label3);
            this.PL_Edit.Controls.Add(this.TB_Code);
            this.PL_Edit.Controls.Add(this.TB_ChineseInfor);
            this.PL_Edit.Controls.Add(this.label2);
            this.PL_Edit.Controls.Add(this.label4);
            this.PL_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_Edit.Location = new System.Drawing.Point(3, 114);
            this.PL_Edit.Name = "PL_Edit";
            this.PL_Edit.Size = new System.Drawing.Size(1272, 150);
            this.PL_Edit.TabIndex = 36;
            this.PL_Edit.Visible = false;
            // 
            // BT_Delete
            // 
            this.BT_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Delete.Location = new System.Drawing.Point(587, 94);
            this.BT_Delete.Name = "BT_Delete";
            this.BT_Delete.Size = new System.Drawing.Size(95, 33);
            this.BT_Delete.TabIndex = 17;
            this.BT_Delete.Tag = "9999";
            this.BT_Delete.Text = "删除";
            this.BT_Delete.UseVisualStyleBackColor = true;
            this.BT_Delete.Visible = false;
            this.BT_Delete.Click += new System.EventHandler(this.BT_Delete_Click);
            // 
            // BT_Clear
            // 
            this.BT_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Clear.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Clear.Location = new System.Drawing.Point(787, 94);
            this.BT_Clear.Name = "BT_Clear";
            this.BT_Clear.Size = new System.Drawing.Size(95, 33);
            this.BT_Clear.TabIndex = 15;
            this.BT_Clear.Tag = "9999";
            this.BT_Clear.Text = "取消";
            this.BT_Clear.UseVisualStyleBackColor = true;
            this.BT_Clear.Click += new System.EventHandler(this.BT_Clear_Click);
            // 
            // BT_Save
            // 
            this.BT_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Save.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Save.Location = new System.Drawing.Point(393, 94);
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Size = new System.Drawing.Size(95, 33);
            this.BT_Save.TabIndex = 14;
            this.BT_Save.Tag = "9999";
            this.BT_Save.Text = "确定";
            this.BT_Save.UseVisualStyleBackColor = true;
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // TB_EnglishInfor
            // 
            this.TB_EnglishInfor.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_EnglishInfor.Location = new System.Drawing.Point(980, 27);
            this.TB_EnglishInfor.Name = "TB_EnglishInfor";
            this.TB_EnglishInfor.Size = new System.Drawing.Size(261, 30);
            this.TB_EnglishInfor.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(865, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "英文信息：";
            // 
            // TB_Code
            // 
            this.TB_Code.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_Code.Location = new System.Drawing.Point(143, 25);
            this.TB_Code.Name = "TB_Code";
            this.TB_Code.Size = new System.Drawing.Size(261, 30);
            this.TB_Code.TabIndex = 11;
            // 
            // TB_ChineseInfor
            // 
            this.TB_ChineseInfor.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_ChineseInfor.Location = new System.Drawing.Point(560, 26);
            this.TB_ChineseInfor.Name = "TB_ChineseInfor";
            this.TB_ChineseInfor.Size = new System.Drawing.Size(261, 30);
            this.TB_ChineseInfor.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(445, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "中文信息：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(38, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "报警代码:";
            // 
            // PL_Delete
            // 
            this.PL_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_Delete.Location = new System.Drawing.Point(3, 570);
            this.PL_Delete.Name = "PL_Delete";
            this.PL_Delete.Size = new System.Drawing.Size(1272, 235);
            this.PL_Delete.TabIndex = 37;
            // 
            // WarningManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1278, 706);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "WarningManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报警信息管理";
            this.Load += new System.EventHandler(this.WarningManagement_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CodeInfor)).EndInit();
            this.PL_Title.ResumeLayout(false);
            this.PL_Title.PerformLayout();
            this.PL_BT.ResumeLayout(false);
            this.PL_BT.PerformLayout();
            this.PL_Edit.ResumeLayout(false);
            this.PL_Edit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView DGV_CodeInfor;
        private System.Windows.Forms.Panel PL_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PL_BT;
        private System.Windows.Forms.Button BT_Edit;
        private System.Windows.Forms.Panel PL_Edit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_ChineseInfor;
        private System.Windows.Forms.TextBox TB_Code;
        private System.Windows.Forms.TextBox TB_EnglishInfor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BT_Save;
        private System.Windows.Forms.Button BT_Clear;
        private System.Windows.Forms.Panel PL_Delete;
        private System.Windows.Forms.Button BT_Query;
        private System.Windows.Forms.TextBox TB_CodeQuery;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BT_Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn line;
        private System.Windows.Forms.DataGridViewTextBoxColumn productionType;
    }
}