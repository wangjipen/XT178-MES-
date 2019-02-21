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

namespace SKTraceablity.Config
{
    public partial class RecipeMg : Office2007Form
    {
        public RecipeMg()
        {
            InitializeComponent();
        }
        DataTable productionDt;
        DataTable productionRecipeDt;
        DataTable recipeDt;
        DataTable stationDt;
        int recipeId;
        int productionRecipeId;
        private bool edditRemark = true;
        private bool mark = false;
        private void BT_RE_Click(object sender, EventArgs e)
        {
            if (edditRemark)
            {
                PL_ADF.Visible = true;
                edditRemark = false;
            }
            else
            {
                PL_ADF.Visible = false;
                edditRemark = true;
            }
        }

        private void RecipeMg_Load(object sender, EventArgs e)
        {
            CB_RP.SelectedItem = null;
            BT_RD.Enabled = false;
            ProductionAndStationRefish();
            PL_ADF.Visible = false;
            ProductionRecipeRefish();
        }
        public void ProductionAndStationRefish()
        {
            productionDt = null;
            productionDt = AsmProduction_BLL.GetAllAsmProduction();
            CB_RP.DataSource = productionDt;
            CB_RP.DisplayMember = "PRODUCTION_NAME";
            CB_RP.ValueMember = "PRODUCTION_ID";
            CB_RP.SelectedItem = null;
            stationDt = null;
            stationDt = AsmStation_BLL.GetAllStation();
            CB_S.DataSource = stationDt;
            CB_S.DisplayMember = "STATION_NAME";
            CB_S.ValueMember = "STATION_ID";
            CB_S.SelectedItem = null;
        }
        public void ProductionRecipeRefish()
        {
            
            productionRecipeDt = null;
            recipeDt = null;
            productionRecipeDt = AsmProductionRecipe_BLL.GetAllProductionRecipe();
            DGV_PR.DataSource = productionRecipeDt;
            recipeDt = AsmRecipe_BLL.GetAllRecipeByCondition();
            DGV_R.DataSource = recipeDt;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_RS_Click(object sender, EventArgs e)
        {
            AsmRecipeObject aro = null;
            AsmProductionRecipeObject apro = null;
            List<AsmProductionRecipeObject> lapro = null;
            int selectValue;
            int stationSelectValue;
            if (!String.IsNullOrEmpty(TB_RN.Text))
            {
                #region
                aro = AsmRecipe_BLL.GetRecipeByCondition(" RECIPE_NAME='" + TB_RN.Text.Trim() + "'");
                #region>>>>>处理产品下拉选项的只  不选则为0 
                if (CB_RP.SelectedValue == null)
                {
                    if (CB_S.SelectedValue == null)
                    {
                        selectValue = 0;
                        stationSelectValue = 0;
                    }
                    else
                    {
                        selectValue = 0;
                        stationSelectValue = 0;
                        CB_S.SelectedItem = null;
                    }
                }
                else
                {
                    if (CB_S.SelectedValue != null)
                    {
                        selectValue = Convert.ToInt32(CB_RP.SelectedValue);
                        stationSelectValue = Convert.ToInt32(CB_S.SelectedValue);
                    }
                    else
                    {
                        MessageBox.Show("已选择产品，请选择对应的工位......");
                        return;
                    }
                }
                #endregion
                if (aro != null)
                {
                    #region
                    lapro = AsmProductionRecipe_BLL.GetManyProductionRecipeObjectByCondition(" RECIPE_ID=" + aro.RECIPE_ID);
                    if (lapro.Count > 0)
                    {
                        for (int i = 0; i < lapro.Count; i++)
                        {
                            #region>>>>> 有关联产品
                            if (selectValue == lapro[i].PRODUCTION_ID && stationSelectValue == lapro[i].STATION_ID)//判读是否绑定同一产品
                            {
                                #region>>>>>更新本BOM
                                aro.RECIPE_NAME = TB_RN.Text.Trim();
                                aro.RECIPE_DISCRIPTION = TB_RD.Text.Trim();
                                if (AsmRecipe_BLL.UpdateAsmRecipeByObject(aro) > 0)
                                {
                                    MessageBox.Show("更新配方成功......");
                                    TB_RN.Text = "";
                                    TB_RD.Text = "";
                                    CB_RP.SelectedItem = null;
                                    CB_S.SelectedItem = null;
                                    PL_ADF.Visible = false;
                                    edditRemark = true;
                                    ProductionRecipeRefish();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("更新配方信息失败......");
                                    return;
                                }
                                #endregion
                            }
                            #endregion
                        }
                        AsmProductionRecipeObject apro1 = AsmProductionRecipe_BLL.GetProductionRecipeCondition(" PRODUCTION_ID=" + selectValue+" AND  STATION_ID="+stationSelectValue);
                        if (apro1 == null)
                        {
                            #region>>>>>更新本BOM和新增产品关联
                            aro.RECIPE_NAME = TB_RN.Text.Trim();
                            aro.RECIPE_DISCRIPTION = TB_RD.Text.Trim();
                            if (AsmRecipe_BLL.UpdateAsmRecipeByObject(aro) > 0)
                            {
                                #region>>>>>新增BOM和产品关联
                                AsmProductionRecipeObject pr = new AsmProductionRecipeObject();
                                pr.PRODUCTION_ID = selectValue;
                                pr.RECIPE_ID = aro.RECIPE_ID;
                                pr.STATION_ID = stationSelectValue;
                                if (AsmProductionRecipe_BLL.AddProductionRecipeByObject(pr) > 0)
                                {
                                    MessageBox.Show("更新配方成功......");
                                    TB_RN.Text = "";
                                    TB_RD.Text = "";
                                    CB_RP.SelectedItem = null;
                                    CB_S.SelectedItem = null;
                                    PL_ADF.Visible = false;
                                    edditRemark = true;
                                    ProductionRecipeRefish();
                                }
                                #endregion
                            }
                            else
                            {
                                CB_RP.SelectedItem = null;
                                CB_S.SelectedItem = null;
                                ProductionRecipeRefish();
                                MessageBox.Show("更新配方信息失败......");
                            }
                            #endregion
                        }
                        else
                        {
                            MessageBox.Show("选中的产品在该工位已经绑定了配方，请先解绑后再进行操作......");
                            return;
                        }                        
                    }
                    else
                    {
                        #region>>>>> 无关联产品
                        if (selectValue == 0) //是否选择了关联产品
                        {
                            #region>>>>>更新本BOM
                            aro.RECIPE_NAME = TB_RN.Text.Trim();
                            aro.RECIPE_DISCRIPTION = TB_RD.Text.Trim();
                            if (AsmRecipe_BLL.UpdateAsmRecipeByObject(aro) > 0)
                            {
                                MessageBox.Show("更新配方成功......");
                                TB_RN.Text = "";
                                TB_RD.Text = "";
                                CB_RP.SelectedItem = null;
                                CB_S.SelectedItem = null;
                                PL_ADF.Visible = false;
                                edditRemark = true;
                                ProductionRecipeRefish();
                            }
                            else
                            {
                                MessageBox.Show("更新配方信息失败......");
                                return;
                            }
                            #endregion
                        }
                        else
                        {
                            #region>>>>>新增BOM和产品关联
                            apro = AsmProductionRecipe_BLL.GetProductionRecipeCondition(" PRODUCTION_ID=" + selectValue+" AND STATION_ID="+stationSelectValue);
                            if (apro != null)
                            {
                                MessageBox.Show("选中的产品上已经绑定了配方，请先解绑后再进行操作......");
                            }
                            else
                            {
                                #region>>>>>新增BOM同时新增关联产品
                                aro.RECIPE_NAME = TB_RN.Text.Trim();
                                aro.RECIPE_DISCRIPTION = TB_RD.Text.Trim();
                                if (AsmRecipe_BLL.UpdateAsmRecipeByObject(aro) > 0)
                                {
                                    aro = AsmRecipe_BLL.GetRecipeByCondition(" RECIPE_NAME='" + aro.RECIPE_NAME + "' AND RECIPE_DISCRIPTION='" + aro.RECIPE_DISCRIPTION + "';");
                                    AsmProductionRecipeObject p = new AsmProductionRecipeObject();
                                    p.PRODUCTION_ID = selectValue;
                                    p.RECIPE_ID = aro.RECIPE_ID;
                                    p.STATION_ID = stationSelectValue;
                                    if (AsmProductionRecipe_BLL.AddProductionRecipeByObject(p) > 0)
                                    {
                                        TB_RN.Text = "";
                                        TB_RD.Text = "";
                                        CB_RP.SelectedItem = null;
                                        CB_S.SelectedItem = null;
                                        PL_ADF.Visible = false;
                                        edditRemark = true;
                                        ProductionRecipeRefish();
                                        MessageBox.Show("更新配方成功......");
                                    }
                                    else
                                    {
                                        CB_RP.SelectedItem = null;
                                        CB_S.SelectedItem = null;
                                        ProductionRecipeRefish();
                                        MessageBox.Show("更新配方失败......");
                                    }
                                }
                                #endregion
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    #region>>>>>新增BOM或者新增BOM和产品关联
                    if (selectValue == 0) //新增BOM
                    {
                        #region
                        aro = new AsmRecipeObject();
                        aro.RECIPE_NAME = TB_RN.Text.Trim();
                        aro.RECIPE_DISCRIPTION = TB_RD.Text.Trim();
                        if (AsmRecipe_BLL.AddAsmRecipeByObject(aro) > 0)
                        {
                            TB_RN.Text = "";
                            TB_RD.Text = "";
                            CB_RP.SelectedItem = null;
                            CB_S.SelectedItem = null;
                            PL_ADF.Visible = false;
                            edditRemark = true;
                            ProductionRecipeRefish();
                            MessageBox.Show("新增配方成功......");
                        }
                        #endregion
                    }
                    else
                    {
                        #region>>>>>新增BOM和产品关联
                        apro = AsmProductionRecipe_BLL.GetProductionRecipeCondition(" PRODUCTION_ID=" + selectValue + " AND STATION_ID=" + stationSelectValue);
                        if (apro != null)
                        {
                            MessageBox.Show("选中的产品在该工位已经绑定了配方，请先解绑后再进行操作......");
                        }
                        else
                        {
                            #region>>>>>新增BOM同时新增关联产品
                            aro = new AsmRecipeObject();
                            aro.RECIPE_NAME = TB_RN.Text.Trim();
                            aro.RECIPE_DISCRIPTION = TB_RD.Text.Trim();
                            if (AsmRecipe_BLL.AddAsmRecipeByObject(aro) > 0)
                            {
                                aro = AsmRecipe_BLL.GetRecipeByCondition(" RECIPE_NAME='" + aro.RECIPE_NAME + "' AND RECIPE_DISCRIPTION='" + aro.RECIPE_DISCRIPTION + "';");
                                apro = new AsmProductionRecipeObject();
                                apro.PRODUCTION_ID = selectValue;
                                apro.RECIPE_ID = aro.RECIPE_ID;
                                apro.STATION_ID = stationSelectValue;
                                if (AsmProductionRecipe_BLL.AddProductionRecipeByObject(apro) > 0)
                                {
                                    TB_RN.Text = "";
                                    TB_RD.Text = "";
                                    CB_RP.SelectedItem = null;
                                    CB_S.SelectedItem = null;
                                    PL_ADF.Visible = false;
                                    edditRemark = true;
                                    ProductionRecipeRefish();
                                    MessageBox.Show("新增配方成功......");
                                }
                                else
                                {
                                    AsmRecipe_BLL.DeleteProductionRecipe(aro);
                                    CB_RP.SelectedItem = null;
                                    CB_S.SelectedItem = null;
                                    ProductionRecipeRefish();
                                    MessageBox.Show("新增配方失败......");
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
            }
            else
            {
                MessageBox.Show("已存在相同名字的配方......");
            }
            mark = true;
            BT_RD.Enabled = false;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_RD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除配方,将删除对应的详细信息，确认删除？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int row = DGV_R.SelectedRows[0].Index;
                AsmRecipeObject pcbo = new AsmRecipeObject();
                pcbo.RECIPE_ID = Convert.ToInt32(recipeDt.Rows[row]["RECIPE_ID"].ToString());
                pcbo.RECIPE_NAME = recipeDt.Rows[row]["RECIPE_NAME"].ToString();
                pcbo.RECIPE_DISCRIPTION = recipeDt.Rows[row]["RECIPE_DISCRIPTION"].ToString();
                if (AsmRecipe_BLL.DeleteProductionRecipe(pcbo) == 0)
                {
                    MessageBox.Show("删除配方成功......");
                    ProductionRecipeRefish();
                    TB_RN.Text = "";
                    TB_RD.Text = "";
                    CB_RP.SelectedItem = null;
                    CB_S.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("删除配方失败......");
                }
            }
        }

        private void DGV_R_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mark = false;
            int row = DGV_R.SelectedRows[0].Index;
            this.TB_RN.Text = recipeDt.Rows[row]["RECIPE_NAME"].ToString();
            this.TB_RD.Text = recipeDt.Rows[row]["RECIPE_DISCRIPTION"].ToString();
            CB_RP.SelectedItem = null;
            CB_S.SelectedItem = null;
            recipeId = Convert.ToInt32(recipeDt.Rows[row]["RECIPE_ID"].ToString());
            BT_RD.Enabled = true;
        }

        private void DGV_PR_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mark = false;
            int row = DGV_PR.SelectedRows[0].Index;
            this.TB_RN.Text = productionRecipeDt.Rows[row]["RECIPE_NAME"].ToString();
            this.TB_RD.Text = productionRecipeDt.Rows[row]["RECIPE_DISCRIPTION"].ToString();
            CB_RP.SelectedValue = Convert.ToInt32(productionRecipeDt.Rows[row]["PRODUCTION_ID"].ToString());
            CB_S.SelectedValue = Convert.ToInt32(productionRecipeDt.Rows[row]["STATION_ID"].ToString());
            productionRecipeId = Convert.ToInt32(productionRecipeDt.Rows[row]["PRODUCTION_RECIPE_ID"].ToString());
        }

        private void BT_DR_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认解除绑定？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                int row = DGV_PR.SelectedRows[0].Index;
                if (AsmProductionRecipe_BLL.DeleteProductionRecipeByCondition(" PRODUCTION_RECIPE_ID=" + Convert.ToInt32(productionRecipeDt.Rows[row]["PRODUCTION_RECIPE_ID"].ToString())) > 0)
                {
                    MessageBox.Show("解绑成功......");
                    ProductionRecipeRefish();
                }
                else
                {
                    MessageBox.Show("解绑失败......");
                }
            }
        }

        private void CB_S_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (mark && CB_S.SelectedItem != null)
            //{
            //    productionRecipeDt = null;
            //    productionRecipeDt = AsmProductionRecipe_BLL.GetManyProductionRecipeByCondition(" AND ST.STATION_ID=" + Convert.ToInt32(CB_S.SelectedValue.ToString()));
            //    DGV_PR.DataSource = productionRecipeDt;
            //    CB_S.SelectedItem = null;
            //}
            ////if (mark && CB_S.SelectedItem != null && CB_RP.SelectedItem != null)
            ////{
            ////    productionRecipeDt = null;
            ////    productionRecipeDt = AsmProductionRecipe_BLL.GetManyProductionRecipeByCondition(" AND APR.STATION_ID=" + Convert.ToInt32(CB_S.SelectedValue.ToString()) + " AND APR.PRODUCTION_ID=" + Convert.ToInt32(CB_RP.SelectedValue.ToString()));
            ////    CB_S.SelectedItem = null;
            ////}
            //DGV_PR.DataSource = productionRecipeDt;
        }

        private void CB_RP_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (mark && CB_RP.SelectedItem!=null && CB_S.SelectedItem!=null)
            //{
            //    productionRecipeDt = null;
            //    productionRecipeDt = AsmProductionRecipe_BLL.GetManyProductionRecipeByCondition(" AND APR.PRODUCTION_ID=" + Convert.ToInt32(CB_RP.SelectedValue.ToString())+" AND APR.STATION_ID="+Convert.ToInt32(CB_S.SelectedValue.ToString()));
            //    CB_RP.SelectedItem = null;
            //}
            //if (mark && CB_RP.SelectedItem != null)
            //{
            //    productionRecipeDt = null;
            //    productionRecipeDt = AsmProductionRecipe_BLL.GetManyProductionRecipeByCondition(" AND APR.PRODUCTION_ID=" + Convert.ToInt32(CB_RP.SelectedValue.ToString()));
            //    CB_RP.SelectedItem = null;
            //}
            //DGV_PR.DataSource = productionRecipeDt;
        }

        private void RecipeMg_Shown(object sender, EventArgs e)
        {
            mark = false;
        }
    }
}
