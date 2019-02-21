namespace SKTraceablity.Config
{
    partial class ImportRecipe
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
            this.BT_ImportRecipe = new DevComponents.DotNetBar.ButtonX();
            this.BT_SaveRecipe = new DevComponents.DotNetBar.ButtonX();
            this.dataGridView2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Production = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductionPn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Step_Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialPn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Program_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcondLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gun_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BT_D = new DevComponents.DotNetBar.ButtonX();
            this.cmbCount = new System.Windows.Forms.ComboBox();
            this.BT_Find = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BT_ImportRecipe
            // 
            this.BT_ImportRecipe.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BT_ImportRecipe.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BT_ImportRecipe.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_ImportRecipe.Location = new System.Drawing.Point(439, 0);
            this.BT_ImportRecipe.Margin = new System.Windows.Forms.Padding(4);
            this.BT_ImportRecipe.Name = "BT_ImportRecipe";
            this.BT_ImportRecipe.Size = new System.Drawing.Size(100, 52);
            this.BT_ImportRecipe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BT_ImportRecipe.TabIndex = 0;
            this.BT_ImportRecipe.Text = "导入";
            this.BT_ImportRecipe.Click += new System.EventHandler(this.BT_ImportRecipe_Click);
            // 
            // BT_SaveRecipe
            // 
            this.BT_SaveRecipe.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BT_SaveRecipe.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BT_SaveRecipe.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_SaveRecipe.Location = new System.Drawing.Point(561, 0);
            this.BT_SaveRecipe.Margin = new System.Windows.Forms.Padding(4);
            this.BT_SaveRecipe.Name = "BT_SaveRecipe";
            this.BT_SaveRecipe.Size = new System.Drawing.Size(100, 52);
            this.BT_SaveRecipe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BT_SaveRecipe.TabIndex = 1;
            this.BT_SaveRecipe.Text = "保存";
            this.BT_SaveRecipe.Click += new System.EventHandler(this.BT_SaveRecipe_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Production,
            this.ProductionPn,
            this.Station,
            this.gx,
            this.scdm,
            this.Material_Name,
            this.Step_Category,
            this.Number,
            this.MaterialPn,
            this.Program_No,
            this.sl,
            this.barcondLength,
            this.st,
            this.Gun_No,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridView2.Location = new System.Drawing.Point(1, 59);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1589, 726);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.Tag = "9999";
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Production
            // 
            this.Production.DataPropertyName = "产品名称";
            this.Production.HeaderText = "产品名称";
            this.Production.Name = "Production";
            this.Production.ReadOnly = true;
            this.Production.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProductionPn
            // 
            this.ProductionPn.DataPropertyName = "PACKPN";
            this.ProductionPn.HeaderText = "PACKPN";
            this.ProductionPn.Name = "ProductionPn";
            this.ProductionPn.ReadOnly = true;
            this.ProductionPn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Station
            // 
            this.Station.DataPropertyName = "工位名称";
            this.Station.HeaderText = "工位名称";
            this.Station.Name = "Station";
            this.Station.ReadOnly = true;
            this.Station.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gx
            // 
            this.gx.DataPropertyName = "工序";
            this.gx.HeaderText = "工序";
            this.gx.Name = "gx";
            this.gx.ReadOnly = true;
            this.gx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // scdm
            // 
            this.scdm.DataPropertyName = "上传代码";
            this.scdm.HeaderText = "上传代码";
            this.scdm.Name = "scdm";
            this.scdm.ReadOnly = true;
            this.scdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Material_Name
            // 
            this.Material_Name.DataPropertyName = "工序名称";
            this.Material_Name.HeaderText = "工序名称";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            this.Material_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Step_Category
            // 
            this.Step_Category.DataPropertyName = "操作类别";
            this.Step_Category.HeaderText = "操作类别";
            this.Step_Category.Name = "Step_Category";
            this.Step_Category.ReadOnly = true;
            this.Step_Category.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "数量";
            this.Number.HeaderText = "数量";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MaterialPn
            // 
            this.MaterialPn.DataPropertyName = "物料PN";
            this.MaterialPn.HeaderText = "物料PN";
            this.MaterialPn.Name = "MaterialPn";
            this.MaterialPn.ReadOnly = true;
            this.MaterialPn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Program_No
            // 
            this.Program_No.DataPropertyName = "程序号";
            this.Program_No.HeaderText = "程序号";
            this.Program_No.Name = "Program_No";
            this.Program_No.ReadOnly = true;
            this.Program_No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sl
            // 
            this.sl.DataPropertyName = "套筒号";
            this.sl.HeaderText = "套筒号";
            this.sl.Name = "sl";
            this.sl.ReadOnly = true;
            this.sl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // barcondLength
            // 
            this.barcondLength.DataPropertyName = "条码规则";
            this.barcondLength.HeaderText = "条码规则";
            this.barcondLength.Name = "barcondLength";
            this.barcondLength.ReadOnly = true;
            this.barcondLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // st
            // 
            this.st.DataPropertyName = "工位节拍";
            this.st.HeaderText = "工位节拍";
            this.st.Name = "st";
            this.st.ReadOnly = true;
            this.st.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Gun_No
            // 
            this.Gun_No.DataPropertyName = "枪号";
            this.Gun_No.HeaderText = "枪号";
            this.Gun_No.Name = "Gun_No";
            this.Gun_No.ReadOnly = true;
            this.Gun_No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "目标扭矩";
            this.Column1.HeaderText = "目标扭矩";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "上下限";
            this.Column2.HeaderText = "上下限";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "泄露测试程序编号";
            this.Column3.HeaderText = "泄露程序号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "图片路径";
            this.Column5.HeaderText = "图片路径";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "泄露率";
            this.Column4.HeaderText = "泄露率";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // BT_D
            // 
            this.BT_D.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BT_D.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BT_D.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_D.Location = new System.Drawing.Point(681, 1);
            this.BT_D.Margin = new System.Windows.Forms.Padding(4);
            this.BT_D.Name = "BT_D";
            this.BT_D.Size = new System.Drawing.Size(100, 52);
            this.BT_D.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BT_D.TabIndex = 19;
            this.BT_D.Text = "导出";
            this.BT_D.Click += new System.EventHandler(this.BT_D_Click);
            // 
            // cmbCount
            // 
            this.cmbCount.FormattingEnabled = true;
            this.cmbCount.Location = new System.Drawing.Point(112, 18);
            this.cmbCount.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCount.Name = "cmbCount";
            this.cmbCount.Size = new System.Drawing.Size(185, 23);
            this.cmbCount.TabIndex = 18;
            // 
            // BT_Find
            // 
            this.BT_Find.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BT_Find.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BT_Find.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Find.Location = new System.Drawing.Point(318, 0);
            this.BT_Find.Margin = new System.Windows.Forms.Padding(4);
            this.BT_Find.Name = "BT_Find";
            this.BT_Find.Size = new System.Drawing.Size(100, 52);
            this.BT_Find.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BT_Find.TabIndex = 4;
            this.BT_Find.Text = "查询";
            this.BT_Find.Click += new System.EventHandler(this.BT_Find_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(7, 14);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(109, 36);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "PACKPN:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.cmbCount);
            this.panel1.Controls.Add(this.BT_ImportRecipe);
            this.panel1.Controls.Add(this.BT_Find);
            this.panel1.Controls.Add(this.BT_SaveRecipe);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1589, 56);
            this.panel1.TabIndex = 4;
            // 
            // ImportRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1589, 800);
            this.Controls.Add(this.BT_D);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView2);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配方导入";
            this.Load += new System.EventHandler(this.ImportRecipe_Load);
            this.Shown += new System.EventHandler(this.ImportRecipe_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX BT_ImportRecipe;
        private DevComponents.DotNetBar.ButtonX BT_SaveRecipe;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridView2;
        private DevComponents.DotNetBar.ButtonX BT_Find;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.ComboBox cmbCount;
        private DevComponents.DotNetBar.ButtonX BT_D;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Production;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductionPn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station;
        private System.Windows.Forms.DataGridViewTextBoxColumn gx;
        private System.Windows.Forms.DataGridViewTextBoxColumn scdm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Step_Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialPn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Program_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcondLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn st;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gun_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}