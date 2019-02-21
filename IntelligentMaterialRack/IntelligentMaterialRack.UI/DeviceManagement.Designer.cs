namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    partial class DeviceManagement
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
            this.DGV_DeviceInfor = new System.Windows.Forms.DataGridView();
            this.PL_Title = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PL_Text1 = new System.Windows.Forms.Panel();
            this.CB_ST2 = new System.Windows.Forms.ComboBox();
            this.TB_IP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PL_Text2 = new System.Windows.Forms.Panel();
            this.CB_Type2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_Pro = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PL_Print = new System.Windows.Forms.Panel();
            this.BT_Print = new System.Windows.Forms.Button();
            this.TB_Print = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PL_PLC = new System.Windows.Forms.Panel();
            this.TB_Control = new System.Windows.Forms.TextBox();
            this.TB_CID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PL_Query = new System.Windows.Forms.Panel();
            this.CB_ST1 = new System.Windows.Forms.ComboBox();
            this.CB_Type1 = new System.Windows.Forms.ComboBox();
            this.BT_Edit = new System.Windows.Forms.Button();
            this.BT_Query = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PL_BT = new System.Windows.Forms.Panel();
            this.BT_Clear = new System.Windows.Forms.Button();
            this.BT_Delete = new System.Windows.Forms.Button();
            this.BT_Save = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.station = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controladd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printadd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DeviceInfor)).BeginInit();
            this.PL_Title.SuspendLayout();
            this.PL_Text1.SuspendLayout();
            this.PL_Text2.SuspendLayout();
            this.PL_Print.SuspendLayout();
            this.PL_PLC.SuspendLayout();
            this.PL_Query.SuspendLayout();
            this.PL_BT.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DGV_DeviceInfor, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.PL_Title, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PL_Text1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.PL_Text2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.PL_Print, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.PL_PLC, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.PL_Query, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PL_BT, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1064, 663);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DGV_DeviceInfor
            // 
            this.DGV_DeviceInfor.AllowUserToAddRows = false;
            this.DGV_DeviceInfor.AllowUserToDeleteRows = false;
            this.DGV_DeviceInfor.AllowUserToResizeColumns = false;
            this.DGV_DeviceInfor.AllowUserToResizeRows = false;
            this.DGV_DeviceInfor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.DGV_DeviceInfor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGV_DeviceInfor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_DeviceInfor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_DeviceInfor.ColumnHeadersHeight = 40;
            this.DGV_DeviceInfor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.station,
            this.type,
            this.ip,
            this.protocol,
            this.cid,
            this.controladd,
            this.printadd});
            this.DGV_DeviceInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_DeviceInfor.GridColor = System.Drawing.SystemColors.Control;
            this.DGV_DeviceInfor.Location = new System.Drawing.Point(3, 353);
            this.DGV_DeviceInfor.Name = "DGV_DeviceInfor";
            this.DGV_DeviceInfor.ReadOnly = true;
            this.DGV_DeviceInfor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_DeviceInfor.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_DeviceInfor.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DGV_DeviceInfor.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_DeviceInfor.RowTemplate.Height = 40;
            this.DGV_DeviceInfor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_DeviceInfor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_DeviceInfor.Size = new System.Drawing.Size(1058, 307);
            this.DGV_DeviceInfor.TabIndex = 34;
            this.DGV_DeviceInfor.DoubleClick += new System.EventHandler(this.DGV_DeviceInfor_DoubleClick);
            // 
            // PL_Title
            // 
            this.PL_Title.Controls.Add(this.label1);
            this.PL_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_Title.Location = new System.Drawing.Point(3, 3);
            this.PL_Title.Name = "PL_Title";
            this.PL_Title.Size = new System.Drawing.Size(1058, 44);
            this.PL_Title.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(462, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备管理";
            // 
            // PL_Text1
            // 
            this.PL_Text1.Controls.Add(this.CB_ST2);
            this.PL_Text1.Controls.Add(this.TB_IP);
            this.PL_Text1.Controls.Add(this.label4);
            this.PL_Text1.Controls.Add(this.TB_Name);
            this.PL_Text1.Controls.Add(this.label3);
            this.PL_Text1.Controls.Add(this.label2);
            this.PL_Text1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_Text1.Location = new System.Drawing.Point(3, 103);
            this.PL_Text1.Name = "PL_Text1";
            this.PL_Text1.Size = new System.Drawing.Size(1058, 44);
            this.PL_Text1.TabIndex = 1;
            this.PL_Text1.Visible = false;
            // 
            // CB_ST2
            // 
            this.CB_ST2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_ST2.FormattingEnabled = true;
            this.CB_ST2.Location = new System.Drawing.Point(526, 8);
            this.CB_ST2.Name = "CB_ST2";
            this.CB_ST2.Size = new System.Drawing.Size(206, 27);
            this.CB_ST2.TabIndex = 21;
            // 
            // TB_IP
            // 
            this.TB_IP.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_IP.Location = new System.Drawing.Point(834, 6);
            this.TB_IP.Name = "TB_IP";
            this.TB_IP.Size = new System.Drawing.Size(206, 30);
            this.TB_IP.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(755, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "IP地址：";
            // 
            // TB_Name
            // 
            this.TB_Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_Name.Location = new System.Drawing.Point(150, 7);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(206, 30);
            this.TB_Name.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(406, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "工    位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(52, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "名  称：";
            // 
            // PL_Text2
            // 
            this.PL_Text2.Controls.Add(this.CB_Type2);
            this.PL_Text2.Controls.Add(this.label5);
            this.PL_Text2.Controls.Add(this.CB_Pro);
            this.PL_Text2.Controls.Add(this.label6);
            this.PL_Text2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_Text2.Location = new System.Drawing.Point(3, 153);
            this.PL_Text2.Name = "PL_Text2";
            this.PL_Text2.Size = new System.Drawing.Size(1058, 44);
            this.PL_Text2.TabIndex = 2;
            this.PL_Text2.Visible = false;
            // 
            // CB_Type2
            // 
            this.CB_Type2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_Type2.FormattingEnabled = true;
            this.CB_Type2.Items.AddRange(new object[] {
            "拧紧枪",
            "键合机",
            "机器人",
            "气密性测试仪",
            "打印机",
            "PLC"});
            this.CB_Type2.Location = new System.Drawing.Point(150, 8);
            this.CB_Type2.Name = "CB_Type2";
            this.CB_Type2.Size = new System.Drawing.Size(206, 27);
            this.CB_Type2.TabIndex = 21;
            this.CB_Type2.SelectedIndexChanged += new System.EventHandler(this.CB_Type2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(52, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "设备类型：";
            // 
            // CB_Pro
            // 
            this.CB_Pro.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_Pro.FormattingEnabled = true;
            this.CB_Pro.Items.AddRange(new object[] {
            "TCP/IP协议",
            "NetBEUI协议",
            "IPX/SPX协议",
            "CANBUS协议",
            "Modbus协议",
            "PROFIBUS协议",
            "UDP协议"});
            this.CB_Pro.Location = new System.Drawing.Point(526, 8);
            this.CB_Pro.Name = "CB_Pro";
            this.CB_Pro.Size = new System.Drawing.Size(206, 27);
            this.CB_Pro.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(406, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "通讯协议：";
            // 
            // PL_Print
            // 
            this.PL_Print.Controls.Add(this.BT_Print);
            this.PL_Print.Controls.Add(this.TB_Print);
            this.PL_Print.Controls.Add(this.label7);
            this.PL_Print.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_Print.Location = new System.Drawing.Point(3, 203);
            this.PL_Print.Name = "PL_Print";
            this.PL_Print.Size = new System.Drawing.Size(1058, 44);
            this.PL_Print.TabIndex = 3;
            this.PL_Print.Visible = false;
            // 
            // BT_Print
            // 
            this.BT_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Print.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Print.Location = new System.Drawing.Point(800, 7);
            this.BT_Print.Name = "BT_Print";
            this.BT_Print.Size = new System.Drawing.Size(95, 33);
            this.BT_Print.TabIndex = 16;
            this.BT_Print.Tag = "9999";
            this.BT_Print.Text = "选择";
            this.BT_Print.UseVisualStyleBackColor = true;
            this.BT_Print.Click += new System.EventHandler(this.BT_Print_Click);
            // 
            // TB_Print
            // 
            this.TB_Print.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_Print.Location = new System.Drawing.Point(207, 7);
            this.TB_Print.Name = "TB_Print";
            this.TB_Print.Size = new System.Drawing.Size(540, 30);
            this.TB_Print.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(52, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "打印模板地址：";
            // 
            // PL_PLC
            // 
            this.PL_PLC.Controls.Add(this.TB_Control);
            this.PL_PLC.Controls.Add(this.TB_CID);
            this.PL_PLC.Controls.Add(this.label9);
            this.PL_PLC.Controls.Add(this.label8);
            this.PL_PLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_PLC.Location = new System.Drawing.Point(3, 253);
            this.PL_PLC.Name = "PL_PLC";
            this.PL_PLC.Size = new System.Drawing.Size(1058, 44);
            this.PL_PLC.TabIndex = 4;
            this.PL_PLC.Visible = false;
            // 
            // TB_Control
            // 
            this.TB_Control.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_Control.Location = new System.Drawing.Point(526, 7);
            this.TB_Control.Name = "TB_Control";
            this.TB_Control.Size = new System.Drawing.Size(312, 30);
            this.TB_Control.TabIndex = 15;
            // 
            // TB_CID
            // 
            this.TB_CID.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_CID.Location = new System.Drawing.Point(150, 7);
            this.TB_CID.Name = "TB_CID";
            this.TB_CID.Size = new System.Drawing.Size(206, 30);
            this.TB_CID.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(406, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "控制字地址：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(52, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "卡槽号：";
            // 
            // PL_Query
            // 
            this.PL_Query.Controls.Add(this.CB_ST1);
            this.PL_Query.Controls.Add(this.CB_Type1);
            this.PL_Query.Controls.Add(this.BT_Edit);
            this.PL_Query.Controls.Add(this.BT_Query);
            this.PL_Query.Controls.Add(this.label11);
            this.PL_Query.Controls.Add(this.label10);
            this.PL_Query.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_Query.Location = new System.Drawing.Point(3, 53);
            this.PL_Query.Name = "PL_Query";
            this.PL_Query.Size = new System.Drawing.Size(1058, 44);
            this.PL_Query.TabIndex = 5;
            // 
            // CB_ST1
            // 
            this.CB_ST1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_ST1.FormattingEnabled = true;
            this.CB_ST1.Location = new System.Drawing.Point(526, 8);
            this.CB_ST1.Name = "CB_ST1";
            this.CB_ST1.Size = new System.Drawing.Size(206, 27);
            this.CB_ST1.TabIndex = 20;
            // 
            // CB_Type1
            // 
            this.CB_Type1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_Type1.FormattingEnabled = true;
            this.CB_Type1.Items.AddRange(new object[] {
            "拧紧枪",
            "键合机",
            "机器人",
            "气密性测试仪",
            "打印机",
            "PLC"});
            this.CB_Type1.Location = new System.Drawing.Point(150, 10);
            this.CB_Type1.Name = "CB_Type1";
            this.CB_Type1.Size = new System.Drawing.Size(206, 27);
            this.CB_Type1.TabIndex = 18;
            // 
            // BT_Edit
            // 
            this.BT_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Edit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Edit.Location = new System.Drawing.Point(935, 7);
            this.BT_Edit.Name = "BT_Edit";
            this.BT_Edit.Size = new System.Drawing.Size(95, 33);
            this.BT_Edit.TabIndex = 15;
            this.BT_Edit.Tag = "9999";
            this.BT_Edit.Text = "编辑";
            this.BT_Edit.UseVisualStyleBackColor = true;
            this.BT_Edit.Click += new System.EventHandler(this.BT_Edit_Click);
            // 
            // BT_Query
            // 
            this.BT_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Query.Location = new System.Drawing.Point(800, 7);
            this.BT_Query.Name = "BT_Query";
            this.BT_Query.Size = new System.Drawing.Size(95, 33);
            this.BT_Query.TabIndex = 14;
            this.BT_Query.Tag = "9999";
            this.BT_Query.Text = "查询";
            this.BT_Query.UseVisualStyleBackColor = true;
            this.BT_Query.Click += new System.EventHandler(this.BT_Query_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(406, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "工    位：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(52, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "设备类型：";
            // 
            // PL_BT
            // 
            this.PL_BT.Controls.Add(this.BT_Clear);
            this.PL_BT.Controls.Add(this.BT_Delete);
            this.PL_BT.Controls.Add(this.BT_Save);
            this.PL_BT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_BT.Location = new System.Drawing.Point(3, 303);
            this.PL_BT.Name = "PL_BT";
            this.PL_BT.Size = new System.Drawing.Size(1058, 44);
            this.PL_BT.TabIndex = 7;
            this.PL_BT.Visible = false;
            // 
            // BT_Clear
            // 
            this.BT_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Clear.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Clear.Location = new System.Drawing.Point(674, 6);
            this.BT_Clear.Name = "BT_Clear";
            this.BT_Clear.Size = new System.Drawing.Size(95, 33);
            this.BT_Clear.TabIndex = 19;
            this.BT_Clear.Tag = "9999";
            this.BT_Clear.Text = "取消";
            this.BT_Clear.UseVisualStyleBackColor = true;
            this.BT_Clear.Click += new System.EventHandler(this.BT_Clear_Click);
            // 
            // BT_Delete
            // 
            this.BT_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Delete.Location = new System.Drawing.Point(410, 6);
            this.BT_Delete.Name = "BT_Delete";
            this.BT_Delete.Size = new System.Drawing.Size(95, 33);
            this.BT_Delete.TabIndex = 18;
            this.BT_Delete.Tag = "9999";
            this.BT_Delete.Text = "删除";
            this.BT_Delete.UseVisualStyleBackColor = true;
            this.BT_Delete.Visible = false;
            this.BT_Delete.Click += new System.EventHandler(this.BT_Delete_Click);
            // 
            // BT_Save
            // 
            this.BT_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Save.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Save.Location = new System.Drawing.Point(143, 6);
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Size = new System.Drawing.Size(95, 33);
            this.BT_Save.TabIndex = 15;
            this.BT_Save.Tag = "9999";
            this.BT_Save.Text = "保存";
            this.BT_Save.UseVisualStyleBackColor = true;
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // name
            // 
            this.name.DataPropertyName = "DEVICE_NAME";
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.name.Width = 148;
            // 
            // station
            // 
            this.station.DataPropertyName = "DEVICE_STATION";
            this.station.HeaderText = "工位";
            this.station.Name = "station";
            this.station.ReadOnly = true;
            this.station.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.station.Width = 86;
            // 
            // type
            // 
            this.type.DataPropertyName = "DEVICE_TYPE";
            this.type.HeaderText = "设备类型";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.type.Width = 132;
            // 
            // ip
            // 
            this.ip.DataPropertyName = "DEVICE_IP";
            this.ip.HeaderText = "IP地址";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            this.ip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ip.Width = 160;
            // 
            // protocol
            // 
            this.protocol.DataPropertyName = "DEVICE_PROTOCOL";
            this.protocol.HeaderText = "通讯地址";
            this.protocol.Name = "protocol";
            this.protocol.ReadOnly = true;
            this.protocol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.protocol.Width = 131;
            // 
            // cid
            // 
            this.cid.DataPropertyName = "DEVICE_CID";
            this.cid.HeaderText = "卡槽号";
            this.cid.Name = "cid";
            this.cid.ReadOnly = true;
            this.cid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cid.Width = 90;
            // 
            // controladd
            // 
            this.controladd.DataPropertyName = "DEVICE_CONTROLADD";
            this.controladd.HeaderText = "控制字地址";
            this.controladd.Name = "controladd";
            this.controladd.ReadOnly = true;
            this.controladd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.controladd.Width = 160;
            // 
            // printadd
            // 
            this.printadd.DataPropertyName = "DEVICE_PRINTADD";
            this.printadd.HeaderText = "打印模板地址";
            this.printadd.Name = "printadd";
            this.printadd.ReadOnly = true;
            this.printadd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.printadd.Width = 148;
            // 
            // DeviceManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1064, 663);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DeviceManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备管理";
            this.Load += new System.EventHandler(this.DeviceManagement_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DeviceInfor)).EndInit();
            this.PL_Title.ResumeLayout(false);
            this.PL_Title.PerformLayout();
            this.PL_Text1.ResumeLayout(false);
            this.PL_Text1.PerformLayout();
            this.PL_Text2.ResumeLayout(false);
            this.PL_Text2.PerformLayout();
            this.PL_Print.ResumeLayout(false);
            this.PL_Print.PerformLayout();
            this.PL_PLC.ResumeLayout(false);
            this.PL_PLC.PerformLayout();
            this.PL_Query.ResumeLayout(false);
            this.PL_Query.PerformLayout();
            this.PL_BT.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel PL_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PL_Text1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PL_Text2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel PL_Print;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel PL_PLC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel PL_Query;
        private System.Windows.Forms.Panel PL_BT;
        private System.Windows.Forms.Button BT_Save;
        private System.Windows.Forms.Button BT_Delete;
        private System.Windows.Forms.Button BT_Clear;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BT_Query;
        private System.Windows.Forms.Button BT_Edit;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.TextBox TB_Print;
        private System.Windows.Forms.TextBox TB_Control;
        private System.Windows.Forms.TextBox TB_CID;
        private System.Windows.Forms.ComboBox CB_Type1;
        private System.Windows.Forms.ComboBox CB_ST2;
        private System.Windows.Forms.TextBox TB_IP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_Type2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CB_Pro;
        private System.Windows.Forms.Button BT_Print;
        private System.Windows.Forms.ComboBox CB_ST1;
        public System.Windows.Forms.DataGridView DGV_DeviceInfor;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn station;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cid;
        private System.Windows.Forms.DataGridViewTextBoxColumn controladd;
        private System.Windows.Forms.DataGridViewTextBoxColumn printadd;
    }
}