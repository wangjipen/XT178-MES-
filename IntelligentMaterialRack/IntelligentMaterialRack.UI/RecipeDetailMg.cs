using DevComponents.DotNetBar;
using SKTraceablity.SKTraceablity.BLL;
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
    public partial class RecipeDetailMg : Office2007Form
    {
        public RecipeDetailMg()
        {
            InitializeComponent();
        }
        private bool edditRemark = true;
        DataTable recipeDt;
        DataTable recipeDetailDt;
        DataTable productionDt;
        DataTable stationDt;
        int recipeDetailID;
        DataTable CategoryDt = new DataTable();
        private void BT_ED_Click(object sender, EventArgs e)
        {
            if (edditRemark)
            {
                PL_ED.Visible = true;
                edditRemark = false;
            }
            else
            {
                PL_ED.Visible = false;
                edditRemark = true;
            }
        }

        private void RecipeDetailMg_Load(object sender, EventArgs e)
        {
            PL_ED.Visible = false;
            BT_Z.Visible = false;
            RecipeRefresh();
            RecipeDetailRefresh();
            ProductionAndStationRefish();
            #region>>>>>初始化选择类别        
            CategoryDt.Columns.Add("NAME");
            CategoryDt.Columns.Add("VALUE");
            DataRow drow2 = CategoryDt.NewRow();
            drow2["NAME"] = "扫描1";
            drow2["VALUE"] = "扫描1";
            CategoryDt.Rows.Add(drow2);
            DataRow drow3 = CategoryDt.NewRow();
            drow3["NAME"] = "扫描2";
            drow3["VALUE"] = "扫描2";
            CategoryDt.Rows.Add(drow3);
            DataRow drow10 = CategoryDt.NewRow();
            drow10["NAME"] = "安装";
            drow10["VALUE"] = "安装";
            CategoryDt.Rows.Add(drow10);
            DataRow drow5 = CategoryDt.NewRow();
            drow5["NAME"] = "拧紧";
            drow5["VALUE"] = "拧紧";
            CategoryDt.Rows.Add(drow5);
            DataRow drow7 = CategoryDt.NewRow();
            drow7["NAME"] = "气密性测试";
            drow7["VALUE"] = "气密性测试";
            CategoryDt.Rows.Add(drow7);
            DataRow drow8 = CategoryDt.NewRow();
            drow8["NAME"] = "扫描模组";
            drow8["VALUE"] = "扫描模组";
            CategoryDt.Rows.Add(drow8);
            DataRow drow4 = CategoryDt.NewRow();
            drow4["NAME"] = "扫描电芯";
            drow4["VALUE"] = "扫描电芯";
            CategoryDt.Rows.Add(drow4);
            DataRow drow9 = CategoryDt.NewRow();
            drow9["NAME"] = "用户录入";
            drow9["VALUE"] = "用户录入";
            CategoryDt.Rows.Add(drow9);
            DataRow drow6 = CategoryDt.NewRow();
            drow6["NAME"] = "END";
            drow6["VALUE"] = "END";
            CategoryDt.Rows.Add(drow6);
            CB_CG.DisplayMember = "NAME";
            CB_CG.ValueMember = "VALUE";
            CB_CG.DataSource = CategoryDt;
            #endregion
        }

        public void RecipeRefresh()
        {
            recipeDt = null;
            recipeDt = AsmRecipe_BLL.GetAllRecipeByCondition();
            CB_R.DisplayMember = "RECIPE_NAME";
            CB_R.ValueMember = "RECIPE_ID";
            CB_R.DataSource = recipeDt;
        }
        public void RecipeDetailRefresh()
        {
            recipeDetailDt = null;
            if (CB_R.SelectedValue != null)
                recipeDetailDt = AsmRecipeDetail_BLL.GetAllRecipeDetailByCondition(CB_R.SelectedValue?.ToString());
            DGV_RD.DataSource = recipeDetailDt;
        }
        public void ProductionAndStationRefish()
        {
            productionDt = null;
            productionDt = AsmProduction_BLL.GetAllAsmProduction();
            CB_Production.DataSource = productionDt;
            CB_Production.DisplayMember = "PRODUCTION_VR";
            CB_Production.ValueMember = "PRODUCTION_ID";
            if (CB_Production.Items.Count > 0) CB_Production.SelectedIndex = 0;
            stationDt = null;
            stationDt = AsmStation_BLL.GetAllStation();
            CB_Station.DataSource = stationDt;
            CB_Station.DisplayMember = "STATION_NAME";
            CB_Station.ValueMember = "STATION_ID";
            CB_Station.SelectedIndex = 0;
        }
        private void CB_R_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecipeDetailRefresh();
        }
        /// <summary>
        /// 界面变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CB_CG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_CG.SelectedItem == null)
            {
                return;
            }
            if (CB_CG.SelectedValue.ToString().Trim() == "扫描1")
            {
                PL_N.Visible = true;//名称
                PL_NUM.Visible = true;//数量
                PL_GN.Visible = false;//枪号
                PL_PN.Visible = false;//程序号
                PL_PH.Visible = true;//条码长度
                PL_SL.Visible = true;//节拍
                PL_EQS.Visible = false;//EQS
                                       //  PL_AL.Visible = true;//工序
                PL_TL.Visible = true;//上传代码
                PL_VR.Visible = true;//校验规则
                PL_TT.Visible = false;//目标扭矩
                PL_TLM.Visible = false;//扭矩上下限
                PL_LP.Visible = false;//泄露程序号
                PL_LR.Visible = false;//泄露率
                PL_PICP.Visible = true;//图片路径
            }
            if (CB_CG.SelectedValue.ToString().Trim() == "扫描2")
            {
                PL_N.Visible = true;//名称
                PL_NUM.Visible = true;//数量
                PL_GN.Visible = false;//枪号
                PL_PN.Visible = false;//程序号
                PL_PH.Visible = true;//条码长度
                PL_SL.Visible = true;//节拍
                PL_EQS.Visible = false;//套筒号
                                       //  PL_AL.Visible = true;//工序
                PL_TL.Visible = true;//上传代码
                PL_VR.Visible = true;//校验规则
                PL_TT.Visible = false;//目标扭矩
                PL_TLM.Visible = false;//扭矩上下限
                PL_LP.Visible = false;//泄露程序号
                PL_LR.Visible = false;//泄露率
                PL_PICP.Visible = true;//图片路径
            }
            if (CB_CG.SelectedValue.ToString().Trim() == "安装")
            {
                PL_N.Visible = true;//名称
                PL_NUM.Visible = true;//数量
                PL_GN.Visible = false;//枪号
                PL_PN.Visible = false;//程序号
                PL_PH.Visible = false;//条码长度
                PL_SL.Visible = false;//节拍
                PL_EQS.Visible = false;//套筒号
                PL_TL.Visible = false;//上传代码
                PL_VR.Visible = true;//校验规则
                PL_TT.Visible = false;//目标扭矩
                PL_TLM.Visible = false;//扭矩上下限
                PL_LP.Visible = false;//泄露程序号
                PL_LR.Visible = false;//泄露率
                PL_PICP.Visible = true;//图片路径
            }
            if (CB_CG.SelectedValue.ToString().Trim() == "扫描模组")
            {
                PL_N.Visible = true;//名称
                PL_NUM.Visible = true;//数量
                PL_GN.Visible = false;//枪号
                PL_PN.Visible = false;//程序号
                PL_PH.Visible = true;//条码长度
                PL_SL.Visible = true;//节拍
                PL_EQS.Visible = false;//套筒号
                                       // PL_AL.Visible = true;//工序
                PL_TL.Visible = true;//上传代码
                PL_VR.Visible = true;//校验规则
                PL_TT.Visible = false;//目标扭矩
                PL_TLM.Visible = false;//扭矩上下限
                PL_LP.Visible = false;//泄露程序号
                PL_LR.Visible = false;//泄露率
                PL_PICP.Visible = true;//图片路径
            }
            if (CB_CG.SelectedValue.ToString().Trim() == "扫描电芯")
            {
                PL_N.Visible = true;//名称
                PL_NUM.Visible = true;//数量
                PL_GN.Visible = false;//枪号
                PL_PN.Visible = false;//程序号
                PL_PH.Visible = true;//条码长度
                PL_SL.Visible = true;//节拍
                PL_EQS.Visible = false;//套筒号
                                       // PL_AL.Visible = true;//工序
                PL_TL.Visible = true;//上传代码
                PL_VR.Visible = true;//校验规则
                PL_TT.Visible = false;//目标扭矩
                PL_TLM.Visible = false;//扭矩上下限
                PL_LP.Visible = false;//泄露程序号
                PL_LR.Visible = false;//泄露率
                PL_PICP.Visible = true;//图片路径
            }
            if (CB_CG.SelectedValue.ToString().Trim() == "拧紧")
            {
                PL_N.Visible = true;//名称
                PL_NUM.Visible = true;//数量
                PL_GN.Visible = true;//枪号
                PL_PN.Visible = true;//程序号
                PL_PH.Visible = false;//相机号
                PL_SL.Visible = true;//节拍
                PL_EQS.Visible = true;//套筒号
                                      //   PL_AL.Visible = true;//工序
                PL_TL.Visible = true;//上传代码
                PL_VR.Visible = false;//校验规则
                PL_TT.Visible = true;//目标扭矩
                PL_TLM.Visible = true;//扭矩上下限
                PL_LP.Visible = false;//泄露程序号
                PL_LR.Visible = false;//泄露率
                PL_PICP.Visible = true;//图片路径
            }
            if (CB_CG.SelectedValue.ToString().Trim() == "气密性测试")
            {
                PL_N.Visible = true;//名称
                PL_NUM.Visible = true;//数量
                PL_GN.Visible = true;//枪号
                PL_PN.Visible = false;//程序号
                PL_PH.Visible = false;//条码长度
                PL_SL.Visible = true;//节拍
                PL_EQS.Visible = false;//套筒号
                                       // PL_AL.Visible = true;//工序
                PL_TL.Visible = true;//上传代码
                PL_VR.Visible = false;//校验规则
                PL_TT.Visible = false;//目标扭矩
                PL_TLM.Visible = false;//扭矩上下限
                PL_LP.Visible = true;//泄露程序号
                PL_LR.Visible = true;//泄露率
                PL_PICP.Visible = true;//图片路径
            }
            if (CB_CG.SelectedValue.ToString().Trim() == "用户录入")
            {
                PL_N.Visible = true;//名称
                PL_NUM.Visible = false;//数量
                PL_GN.Visible = false;//枪号
                PL_PN.Visible = false;//程序号
                PL_PH.Visible = false;//条码长度
                PL_SL.Visible = true;//节拍
                PL_EQS.Visible = false;//套筒号
                PL_TL.Visible = false;//上传代码
                PL_VR.Visible = false;//校验规则
                PL_TT.Visible = false;//目标扭矩
                PL_TLM.Visible = false;//扭矩上下限
                PL_LP.Visible = false;//泄露程序号
                PL_LR.Visible = false;//泄露率
                PL_PICP.Visible = true;//图片路径
            }
            if (CB_CG.SelectedValue.ToString().Trim() == "END")
            {
                PL_N.Visible = true;//名称
                PL_NUM.Visible = false;//数量
                PL_GN.Visible = false;//枪号
                PL_PN.Visible = false;//程序号
                PL_PH.Visible = false;//条码长度
                PL_SL.Visible = false;//节拍
                PL_EQS.Visible = false;//套筒号
                PL_TL.Visible = false;//上传代码
                PL_VR.Visible = false;//校验规则
                PL_TT.Visible = false;//目标扭矩
                PL_TLM.Visible = false;//扭矩上下限
                PL_LP.Visible = false;//泄露程序号
                PL_LR.Visible = false;//泄露率
                PL_PICP.Visible = false;//图片路径
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_S_Click(object sender, EventArgs e)
        {
            if (CheckInfo())
            {
                if (recipeDetailID == 0)
                {
                    #region>>>>>新增
                    AsmRecipeDetailObject ardo = new AsmRecipeDetailObject();
                    ardo.StepNo = UP_SN.Value.ToString();//工序
                    ardo.Step_Category = CB_CG.SelectedValue.ToString().Trim();//类别
                    ardo.Material_Name = TB_Name.Text.Trim();//名称
                    ardo.Number = TB_Number.Text.Trim();//数量
                    ardo.Gun_No = TB_Gn.Text.Trim();//枪号
                    ardo.Program_No = TB_PN.Text.Trim();//程序号
                    ardo.Photo_No = TB_PH.Text.Trim();//条码长度
                    ardo.Sleeve_No = TB_EQS.Text.Trim();//套筒号
                    ardo.MaterialPn = TB_VR.Text.Trim();//物料PN
                    ardo.BoltEQS = TB_SL.Text.Trim();//节拍
                                                     // ardo.A_Limit = TB_AL.Text.Trim();//工序
                    ardo.T_Limit = TB_TL.Text.Trim();//上传代码
                    ardo.RECIPE_ID = Convert.ToInt32(CB_R.SelectedValue);
                    ardo.T_Limits = TB_TLM.Text.Trim();
                    ardo.T_Target = TB_TT.Text.Trim();
                    ardo.L_Program = TB_LP.Text.Trim();
                    ardo.L_Rate = TB_LR.Text.Trim();
                    ardo.PICPath = TB_PICP.Text.Trim();
                    if (AsmRecipeDetail_BLL.AddRecipeDetail(ardo) > 0)
                    {
                        MessageBox.Show("增加配方详细信息成功......");
                        UP_SN.Value = UP_SN.Value + 1;
                        CB_CG.SelectedItem = null;
                        TB_Name.Text = "";
                        TB_Number.Value = 0;
                        TB_Gn.Value = 0;
                        TB_PN.Value = 0;
                        TB_PH.Text = "";
                        TB_SL.Value = 0;
                        TB_VR.Text = "";
                        TB_EQS.Value = 0;
                        // TB_AL.Text = "";
                        TB_TL.Text = "";
                        RecipeDetailRefresh();
                    }
                    #endregion
                }
                else
                {
                    #region>>>>>更新
                    AsmRecipeDetailObject ardo = new AsmRecipeDetailObject();
                    ardo.RECIPE_DATIL_ID = recipeDetailID;
                    ardo.StepNo = UP_SN.Value.ToString();
                    ardo.Step_Category = CB_CG.SelectedValue.ToString().Trim();
                    ardo.Material_Name = TB_Name.Text.Trim();//名称
                    ardo.Number = TB_Number.Text.Trim();//数量
                    ardo.Gun_No = TB_Gn.Text.Trim();//枪号
                    ardo.Program_No = TB_PN.Text.Trim();//程序号
                    ardo.Photo_No = TB_PH.Text.Trim();//条码长度
                    ardo.Sleeve_No = TB_EQS.Text.Trim();//套筒号
                    ardo.MaterialPn = TB_VR.Text.Trim();//物料PN
                    ardo.BoltEQS = TB_SL.Text.Trim();//节拍
                                                     // ardo.A_Limit = TB_AL.Text.Trim();//工序
                    ardo.T_Limit = TB_TL.Text.Trim();//上传代码
                    ardo.RECIPE_ID = Convert.ToInt32(CB_R.SelectedValue);
                    ardo.T_Limits = TB_TLM.Text.Trim();
                    ardo.T_Target = TB_TT.Text.Trim();
                    ardo.L_Program = TB_LP.Text.Trim();
                    ardo.L_Rate = TB_LR.Text.Trim();
                    ardo.PICPath = TB_PICP.Text.Trim();
                    if (AsmRecipeDetail_BLL.UpdateProductionBOM(ardo) > 0)
                    {
                        MessageBox.Show("增加配方详细信息成功......");
                        recipeDetailID = 0;
                        UP_SN.Value = 0;
                        CB_CG.SelectedItem = null;
                        TB_Name.Text = "";
                        TB_Number.Value = 0;
                        TB_Gn.Value = 0;
                        TB_PN.Value = 0;
                        TB_PH.Text = "";
                        TB_SL.Value = 0;
                        TB_EQS.Value = 0;
                        TB_VR.Text = "";
                        // TB_AL.Text = "";
                        TB_TL.Text = "";
                        RecipeDetailRefresh();
                    }
                    #endregion
                }
                BT_Z.Visible = true;
            }
            else
            {
                MessageBox.Show("输入信息不全......");
            }
        }
        public bool CheckInfo()
        {
            bool rusult = false;
            if (CB_CG.SelectedValue != null)
            {
                if (CB_CG.SelectedValue.ToString().Trim() == "扫描1")
                {
                    if (!String.IsNullOrEmpty(TB_Name.Text.Trim()) && !String.IsNullOrEmpty(TB_Number.Text.Trim()))
                    {
                        rusult = true;
                    }
                    else
                    {
                        rusult = false;
                    }
                }
                else if (CB_CG.SelectedValue.ToString().Trim() == "扫描2")
                {
                    if (!String.IsNullOrEmpty(TB_Name.Text.Trim()) && !String.IsNullOrEmpty(TB_Number.Text.Trim()))
                    {
                        rusult = true;
                    }
                    else
                    {
                        rusult = false;
                    }
                }
                else if (CB_CG.SelectedValue.ToString().Trim() == "扫描模组")
                {
                    if (!String.IsNullOrEmpty(TB_Name.Text.Trim()) && !String.IsNullOrEmpty(TB_Number.Text.Trim()))
                    {
                        rusult = true;
                    }
                    else
                    {
                        rusult = false;
                    }
                }
                else if (CB_CG.SelectedValue.ToString().Trim() == "扫描电芯")
                {
                    if (!String.IsNullOrEmpty(TB_Name.Text.Trim()) && !String.IsNullOrEmpty(TB_Number.Text.Trim()))
                    {
                        rusult = true;
                    }
                    else
                    {
                        rusult = false;
                    }
                }
                else if (CB_CG.SelectedValue.ToString().Trim() == "拧紧")
                {
                    if (!String.IsNullOrEmpty(TB_Name.Text.Trim()) && !String.IsNullOrEmpty(TB_Number.Text.Trim()) && !String.IsNullOrEmpty(TB_Gn.Text.Trim()) && !String.IsNullOrEmpty(TB_PN.Text.Trim()))
                    {
                        rusult = true;
                    }
                    else
                    {
                        rusult = false;
                    }
                }
                else if (CB_CG.SelectedValue.ToString().Trim() == "气密性测试")
                {
                    rusult = true;
                }
                else
                {
                    rusult = true;
                }
                return rusult;
            }
            else
            {
                return false;
            }
        }
        private void BT_D_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除后不可恢复，确定删除？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (recipeDetailID != 0)
                {

                    if (AsmRecipeDetail_BLL.DeleteRecieDetailByCondition(" RECIPE_DATIL_ID=" + recipeDetailID) > 0)
                    {
                        MessageBox.Show("删除详细配方成功，请整理步序，否则实际生产中会因步序不连续而出错......");
                        recipeDetailID = 0;
                        UP_SN.Value = 0;
                        CB_CG.SelectedItem = null;
                        TB_Name.Text = "";
                        TB_Number.Value = 0;
                        TB_Gn.Value = 0;
                        TB_PN.Value = 0;
                        TB_PH.Text = "";
                        TB_SL.Value = 0;
                        TB_EQS.Value = 0;
                        TB_VR.Text = "";
                        // TB_AL.Text = "";
                        TB_TL.Text = "";
                        BT_Z.Visible = true;
                        RecipeDetailRefresh();
                    }
                }
                else
                {
                    MessageBox.Show("所选对象不能为空！");
                }


            }
            else
            {
                MessageBox.Show("删除失败，请重试......");
            }

        }

        private void DGV_RD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = DGV_RD.SelectedRows[0].Index;
            recipeDetailID = Convert.ToInt32(recipeDetailDt.Rows[row]["RECIPE_DATIL_ID"].ToString());
            CB_R.SelectedValue = Convert.ToInt32(recipeDetailDt.Rows[row]["RECIPE_ID"].ToString());
            UP_SN.Value = Convert.ToInt32(recipeDetailDt.Rows[row]["StepNo"].ToString());
            CB_CG.SelectedValue = recipeDetailDt.Rows[row]["Step_Category"].ToString();
            TB_Name.Text = recipeDetailDt.Rows[row]["Material_Name"].ToString();
            TB_Number.Value = Convert.ToInt32(recipeDetailDt.Rows[row]["Number"].ToString());
            TB_Gn.Value = Convert.ToInt32(recipeDetailDt.Rows[row]["Gun_No"].ToString());
            TB_PN.Value = Convert.ToInt32(recipeDetailDt.Rows[row]["Program_No"].ToString());
            TB_PH.Text = recipeDetailDt.Rows[row]["Photo_No"].ToString();
            string a = recipeDetailDt.Rows[row]["Sleeve_No"].ToString();
            TB_EQS.Value = Convert.ToInt32(recipeDetailDt.Rows[row]["Sleeve_No"].ToString());
            TB_SL.Text = recipeDetailDt.Rows[row]["BoltEQS"].ToString();
            // TB_AL.Text= recipeDetailDt.Rows[row]["A_Limit"].ToString();
            TB_TL.Text = recipeDetailDt.Rows[row]["T_Limit"].ToString();
            TB_VR.Text = recipeDetailDt.Rows[row]["MaterialPn"].ToString();
            TB_TT.Text= recipeDetailDt.Rows[row]["T_Target"].ToString();
            TB_TLM.Text = recipeDetailDt.Rows[row]["T_Limits"].ToString();
            TB_LP.Text = recipeDetailDt.Rows[row]["L_Program"].ToString();
            TB_LR.Text = recipeDetailDt.Rows[row]["L_Rate"].ToString();
            TB_PICP.Text = recipeDetailDt.Rows[row]["PICPath"].ToString();
        }

        private void BT_Z_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < recipeDetailDt.Rows.Count; i++)
            {
                recipeDetailDt.Rows[i]["StepNo"] = i + 1;
                AsmRecipeDetailObject ardo = new AsmRecipeDetailObject();
                ardo.RECIPE_DATIL_ID = Convert.ToInt32(recipeDetailDt.Rows[i]["RECIPE_DATIL_ID"].ToString());
                ardo.StepNo = recipeDetailDt.Rows[i]["StepNo"].ToString();
                ardo.Step_Category = recipeDetailDt.Rows[i]["Step_Category"].ToString();
                ardo.Material_Name = recipeDetailDt.Rows[i]["Material_Name"].ToString();
                ardo.Number = recipeDetailDt.Rows[i]["Number"].ToString();
                ardo.Gun_No = recipeDetailDt.Rows[i]["Gun_No"].ToString();
                ardo.Program_No = recipeDetailDt.Rows[i]["Program_No"].ToString();
                ardo.Photo_No = recipeDetailDt.Rows[i]["Photo_No"].ToString();
                ardo.Sleeve_No = recipeDetailDt.Rows[i]["Sleeve_No"].ToString();
                ardo.MaterialPn = recipeDetailDt.Rows[i]["MaterialPn"].ToString();
                ardo.BoltEQS = recipeDetailDt.Rows[i]["BoltEQS"].ToString();
                ardo.A_Limit = recipeDetailDt.Rows[i]["A_Limit"].ToString();
                ardo.T_Limit = recipeDetailDt.Rows[i]["T_Limit"].ToString();
                ardo.RECIPE_ID = Convert.ToInt32(recipeDetailDt.Rows[i]["RECIPE_ID"].ToString());
                ardo.T_Limits = recipeDetailDt.Rows[i]["T_Limits"].ToString(); 
                ardo.T_Target = recipeDetailDt.Rows[i]["T_Target"].ToString();
                ardo.L_Program = recipeDetailDt.Rows[i]["L_Program"].ToString();
                ardo.L_Rate = recipeDetailDt.Rows[i]["L_Rate"].ToString();
                ardo.PICPath = recipeDetailDt.Rows[i]["PICPath"].ToString();
                if (AsmRecipeDetail_BLL.UpdateProductionBOM(ardo) == 0)
                {
                    MessageBox.Show("整理步序失败，请重试......");
                    break;
                }
            }
            RecipeDetailRefresh();
        }
        /// <summary>
        /// 条件查询配方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(CB_Production.SelectedItem.ToString()) && !String.IsNullOrEmpty(CB_Station.SelectedItem.ToString()))
            {
                recipeDetailDt = null;
                recipeDetailDt = AsmRecipeDetail_BLL.GetRecipeDetailByStationAndProduction(CB_Station.SelectedValue.ToString(), CB_Production.SelectedValue.ToString());
                DGV_RD.DataSource = recipeDetailDt;
            }
        }
        private void TB_PH_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.ToolTipTitle = "提示:";

            this.toolTip1.IsBalloon = false;

            this.toolTip1.UseFading = true;
            this.toolTip1.Show("规则长度必须和实际长度一致，具体规则：所有:* 字母:$ 数字:@ 其它:# 多种规则用'|'号隔开(为空则不比对规则)", this.TB_PH, 10000);
        }
    }
}
