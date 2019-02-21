using DevComponents.DotNetBar;
using SKTraceablity.SKTraceablity.BLL;
using SKTraceablity.SKTraceablity.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SKTraceablity.Config
{
    public partial class ProductionMg : Office2007Form
    {
        public ProductionMg()
        {
            InitializeComponent();
        }
        private bool edditRemark = true;
        DataTable dt = new DataTable();
        int productionID;

        private void BT_ED_Click(object sender, EventArgs e)
        {
            if (edditRemark)
            {
                PL_D.Visible = true;
                edditRemark = false;
            }
            else
            {
                PL_D.Visible = false;
                edditRemark = true;
            }
        }

        private void ProductionMg_Load(object sender, EventArgs e)
        {
            PL_D.Visible = false;
            DataBind();
           
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        public void DataBind()
        {
            dt = null;
            dt = AsmProduction_DAL.GetAllAsmProduction();
            DGV_P.DataSource = dt;
        }

        private void DGV_P_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = DGV_P.SelectedRows[0].Index;
            this.TB_PN.Text = dt.Rows[row]["PRODUCTION_NAME"].ToString();
            this.TB_PT.Text = dt.Rows[row]["PRODUCTION_TYPE"].ToString();
            this.TB_PS.Text = dt.Rows[row]["PRODUCTION_SERIES"].ToString();
            this.TB_VR.Text = dt.Rows[row]["PRODUCTION_VR"].ToString();
            this.TB_PD.Text = dt.Rows[row]["PRODUCTION_DISCRIPTION"].ToString();
            this.TB_PTR.Text= dt.Rows[row]["PRODUCTION_TRADEMARK"].ToString();
            // this.TB_ET.Text= dt.Rows[row]["PRODUCTION_ET"].ToString();
            // this.TB_GT.Text = dt.Rows[row]["PRODUCTION_GT"].ToString();
            if (dt.Rows[row]["PRODUCTION_STE"].ToString() == "1")
            {
                CB_Online.Checked = true;
            }
            if (dt.Rows[row]["PRODUCTION_STE"].ToString() == "2")
            {
                CB_Offline.Checked = true;
            }
            productionID = Convert.ToInt32(dt.Rows[row]["PRODUCTION_ID"].ToString());
        }

        private void BT_D_Click(object sender, EventArgs e)
        {
            if (productionID > 0)
            {
                if (MessageBox.Show("若删除该产品，对应配方将解绑，确认删除此产品？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int res = AsmProduction_BLL.DeleteAamProductionByID(productionID);
                    if (res > 0)
                    {
                      //  ProductionRelationBom_BLL.DeleteProductionRelationBomByCondition(" PRODUCTION_ID=" + productionID);
                        productionID = 0;
                        MessageBox.Show("删除产品成功......");
                        TB_PN.Text = "";
                        TB_PT.Text = "";
                        TB_PS.Text = "";
                        TB_VR.Text = "";
                        TB_PD.Text = "";
                        CB_Online.Checked=true;
                        // TB_ET.Text = "";
                        //TB_GT.Text = "";
                        DataBind();
                    }
                    else
                    {
                        MessageBox.Show("删除产品失败......");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的产品......");
            }
        }

        private void BT_S_Click(object sender, EventArgs e)
        {
            AsmProductionObject apo = null;
            if (!String.IsNullOrEmpty(TB_PN.Text.Trim()) && !String.IsNullOrEmpty(TB_PT.Text.Trim()))
            {
                apo = AsmProduction_BLL.GetAsmProductionByCondition(" PRODUCTION_TYPE= '" + TB_PT.Text.Trim() + "' AND PRODUCTION_NAME='" + TB_PN.Text.Trim()+"' AND PRODUCTION_VR='"+ TB_VR.Text.Trim() + "'");
                if (apo != null)
                {
                    apo.PRODUCTION_NAME = TB_PN.Text.Trim();
                    apo.PRODUCTION_TYPE = TB_PT.Text.Trim();
                    apo.PRODUCTION_SERIES= TB_PS.Text.Trim();
                    apo.PRODUCTION_TRADEMARK = TB_PTR.Text.Trim();
                    apo.PRODUCTION_VR = TB_VR.Text.Trim();
                    apo.PRODUCTION_DISCRIPTION = TB_PD.Text.Trim();
                    if (CB_Online.Checked)
                    {
                        apo.PRODUCTION_STE = "1";//在线模式
                    }
                    if (CB_Offline.Checked)
                    {
                        apo.PRODUCTION_STE = "2";//离线模式
                    }
                    // apo.PRODUCTION_GT = TB_GT.Text.Trim();
                    if (AsmProduction_BLL.UpdateAsmProductionById(apo) > 0)
                    {
                        MessageBox.Show("更新产品信息成功......");
                        TB_PN.Text = "";
                        TB_PT.Text = "";
                        TB_PS.Text = "";
                        TB_VR.Text = "";
                        TB_PD.Text = "";
                        CB_Online.Checked = true;
                       // TB_ET.Text = "";
                       // TB_GT.Text = "";
                        PL_D.Visible = false;
                        DataBind();
                    }
                    else
                    {
                        MessageBox.Show("更新产品信息失败......");
                    }
                }
                else
                {
                    apo =new AsmProductionObject();
                    apo.PRODUCTION_NAME = TB_PN.Text.Trim();
                    apo.PRODUCTION_TYPE = TB_PT.Text.Trim();
                    apo.PRODUCTION_SERIES = TB_PS.Text.Trim();
                    apo.PRODUCTION_TRADEMARK = TB_PTR.Text.Trim();
                    apo.PRODUCTION_VR = TB_VR.Text.Trim();
                    apo.PRODUCTION_DISCRIPTION = TB_PD.Text.Trim();
                    if (CB_Online.Checked)
                    {
                        apo.PRODUCTION_STE = "1";//在线模式
                    }
                    if (CB_Offline.Checked)
                    {
                        apo.PRODUCTION_STE = "2";//离线模式
                    }
                    // apo.PRODUCTION_GT = TB_GT.Text.Trim();
                    if (AsmProduction_BLL.AddAsmProductionByObject(apo) > 0)
                    {
                        TB_PN.Text = "";
                        TB_PT.Text = "";
                        TB_PS.Text = "";
                        TB_VR.Text = "";
                        TB_PD.Text = "";
                        CB_Online.Checked = true;
                        //  TB_GT.Text = "";
                        PL_D.Visible = false;
                        DataBind();
                        MessageBox.Show("添加产品信息成功......");
                    }
                    else
                    {
                        MessageBox.Show("添加产品信息失败......");
                    }
                }
            }
            else
            {
                MessageBox.Show("输入产品信息不全.....");
            }
        }

        private void TB_PS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
            //else
            //{
            //    TB_PS.Text = "";
            //    MessageBox.Show("请输入数字.....");
            //}
        }

        private void CB_Online_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Online.Checked)
            {
                CB_Offline.Checked = false;
            }
        }

        private void CB_Offline_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Offline.Checked)
            {
                CB_Online.Checked = false;
            }
        }

        private void DGV_P_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
                return;
            DataGridView view = (DataGridView)sender;
            object originalValue = e.Value;
            //更改类别显示
            if (view.Columns[e.ColumnIndex].DataPropertyName == "PRODUCTION_STE")
                switch (Convert.ToInt32(originalValue))
                {
                    case 1:
                        e.Value = "在线";
                        break;
                    case 2:
                        e.Value = "离线";
                        break;
                    default:
                        e.Value = "";
                        break;
                }       
        }

        private void labelX5_Click(object sender, EventArgs e)
        {

        }
    }
}
