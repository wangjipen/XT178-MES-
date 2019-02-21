namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    partial class frm_routing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_routing));
            this.panel1 = new System.Windows.Forms.Panel();
            this.addFlow = new Lassalle.Flow.AddFlow();
            this.label1 = new System.Windows.Forms.Label();
            this.cB_product_name = new System.Windows.Forms.ComboBox();
            this.btn_select = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.rTB_stationproperty = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addFlow);
            this.panel1.Location = new System.Drawing.Point(1, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1411, 691);
            this.panel1.TabIndex = 0;
            // 
            // addFlow
            // 
            this.addFlow.BackColor = System.Drawing.Color.Transparent;
            this.addFlow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addFlow.CanFireError = true;
            this.addFlow.CaptionModel.Dock = System.Windows.Forms.DockStyle.None;
            this.addFlow.CaptionModel.FillColor = System.Drawing.Color.Transparent;
            this.addFlow.CaptionModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addFlow.CaptionModel.GradientColor = System.Drawing.Color.Transparent;
            this.addFlow.CaptionModel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.addFlow.CaptionModel.IsCaptionsHilighted = false;
            this.addFlow.CaptionModel.Location = ((System.Drawing.PointF)(resources.GetObject("resource.Location")));
            this.addFlow.CaptionModel.ShadowSize = new System.Drawing.Size(8, 8);
            this.addFlow.CaptionModel.Size = new System.Drawing.SizeF(0F, 0F);
            this.addFlow.CaptionModel.Tag = null;
            this.addFlow.CaptionModel.Thickness = 1F;
            this.addFlow.CaptionModel.ZOrder = -1;
            this.addFlow.Enabled = false;
            this.addFlow.LinkSelectionAreaWidth = 6F;
            this.addFlow.Location = new System.Drawing.Point(3, 9);
            this.addFlow.Name = "addFlow";
            this.addFlow.NodeModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addFlow.NodeModel.GradientColor = System.Drawing.SystemColors.Window;
            this.addFlow.NodeModel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.addFlow.NodeModel.Location = ((System.Drawing.PointF)(resources.GetObject("resource.Location1")));
            this.addFlow.NodeModel.ShadowSize = new System.Drawing.Size(8, 8);
            this.addFlow.NodeModel.ShapeFamily = Lassalle.Flow.ShapeFamily.Ellipse;
            this.addFlow.NodeModel.Size = new System.Drawing.SizeF(0F, 0F);
            this.addFlow.NodeModel.Tag = null;
            this.addFlow.NodeModel.Thickness = 1F;
            this.addFlow.NodeModel.ZOrder = -1;
            this.addFlow.PinColor2 = System.Drawing.Color.Purple;
            this.addFlow.RemovePointDistance = 6F;
            this.addFlow.Size = new System.Drawing.Size(1405, 685);
            this.addFlow.TabIndex = 1;
            this.addFlow.SelectionChange += new Lassalle.Flow.AddFlow.SelectionChangeEventHandler(this.addFlow_SelectionChange);
            this.addFlow.AfterAddLink += new Lassalle.Flow.AddFlow.AfterAddLinkEventHandler(this.addFlow_AfterAddLink);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "产品名称：";
            // 
            // cB_product_name
            // 
            this.cB_product_name.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cB_product_name.FormattingEnabled = true;
            this.cB_product_name.Location = new System.Drawing.Point(172, 16);
            this.cB_product_name.Name = "cB_product_name";
            this.cB_product_name.Size = new System.Drawing.Size(283, 32);
            this.cB_product_name.TabIndex = 3;
            // 
            // btn_select
            // 
            this.btn_select.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_select.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_select.Location = new System.Drawing.Point(1220, 16);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(101, 41);
            this.btn_select.TabIndex = 4;
            this.btn_select.Tag = "9999";
            this.btn_select.Text = "查询";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.bt_save);
            this.groupBox1.Controls.Add(this.btn_select);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cB_product_name);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1679, 63);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // bt_save
            // 
            this.bt_save.Enabled = false;
            this.bt_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_save.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_save.Location = new System.Drawing.Point(1384, 15);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(99, 42);
            this.bt_save.TabIndex = 5;
            this.bt_save.Tag = "9999";
            this.bt_save.Text = "保存";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // rTB_stationproperty
            // 
            this.rTB_stationproperty.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.rTB_stationproperty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTB_stationproperty.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rTB_stationproperty.Location = new System.Drawing.Point(1418, 81);
            this.rTB_stationproperty.Name = "rTB_stationproperty";
            this.rTB_stationproperty.Size = new System.Drawing.Size(264, 691);
            this.rTB_stationproperty.TabIndex = 6;
            this.rTB_stationproperty.Text = "";
            // 
            // frm_routing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IntelligentMaterialRack.Properties.Resources.AX;
            this.ClientSize = new System.Drawing.Size(1684, 776);
            this.Controls.Add(this.rTB_stationproperty);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_routing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工艺路线";
            this.Load += new System.EventHandler(this.frm_routing_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Lassalle.Flow.AddFlow addFlow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cB_product_name;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RichTextBox rTB_stationproperty;
    }
}