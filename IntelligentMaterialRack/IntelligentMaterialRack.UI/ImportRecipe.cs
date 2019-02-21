using DevComponents.DotNetBar;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using MyExcel;
using NPOI.SS.UserModel;
using SKTraceablity.SKTraceablity.BLL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SKTraceablity.Config
{
    public partial class ImportRecipe : Office2007Form
    {
        DataTable tb3;//DATAGRIDVIEW的数据源

        public ImportRecipe()
        {
            InitializeComponent();
        }

        private void ImportRecipe_Load(object sender, EventArgs e)
        {

        }

        private void BT_ImportRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Title = "请选择要导入的Excel文件";
                open.Filter = "excel文件(*.xls)|*.xlsx|所有文件(*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string fileName = open.FileName;
                    ExcelHelper execl = new ExcelHelper(fileName);
                    //if (tb3.Rows.Count > 0)
                    //{
                    //    tb3.Clear();
                    //}
                    if (tb3 == null)
                    {
                        tb3 = new DataTable();
                    }
                    tb3 = execl.ExcelToDataTable("Sheet1", true);
                    if (tb3.Rows.Count > 0)
                    {
                        if (dataGridView2.Rows.Count > 0)
                        {
                            dataGridView2.DataSource = tb3;
                            dataGridView2.Refresh();
                            this.dataGridView2.ClearSelection();
                        }
                        else
                        {
                            dataGridView2.DataSource = tb3;
                            this.dataGridView2.ClearSelection();
                        }

                        MessageBox.Show("导入配方成功，请仔细检查配方后保存！");
                    }
                    else
                    {
                        MessageBox.Show("导入数据为空，请检查EXCEL文件！");
                    }
                    execl.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入配方失败，请检查EXCEL文件格式与模板的差异" + ex.Message);
            }
        }
        public void dataBind()
        {
            DataTable dt = new DataTable();
            dt = AsmProduction_BLL.GetAllAsmProduction();
            if (dt.Rows.Count > 0)
            {
                cmbCount.DataSource = dt;
                cmbCount.DisplayMember = "PRODUCTION_VR";
                cmbCount.ValueMember = "PRODUCTION_VR";
            }
        }

        private void BT_SaveRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckProductionAndPnSame())
                {
                    #region
                    List<StationProductionObject> sp = GetDisctinctStationAndProdiction();
                    if (sp.Count > 0)
                    {
                        foreach (StationProductionObject spoByPPT in sp)
                        {
                            #region>>>>>是否存在导入的产品
                            AsmStationObject aso = AsmStation_BLL.GetStationByCondition("STATION_NAME='" + spoByPPT.StationName + "'");
                            AsmProductionObject apo = AsmProduction_BLL.GetAsmProductionByCondition("PRODUCTION_VR='" + spoByPPT.ProductionPn + "'");//判断是否有对应的产品
                            if (apo != null)
                            {
                                #region>>>>>存在该产品且判断是否存在名字相同的配方
                                AsmRecipeObject aro = AsmRecipe_BLL.GetRecipeByCondition("RECIPE_NAME='" + spoByPPT.ProductionPn + "-" + spoByPPT.StationName + "'");
                                if (aro != null)
                                {
                                    #region>>>>>存在名字相同的配方且比较是否绑定的同一配方
                                    AsmProductionRecipeObject apro = AsmProductionRecipe_BLL.GetProductionRecipeByProAndSta(apo.PRODUCTION_ID, spoByPPT.StationName);
                                    if (apro != null)
                                    {
                                        #region>>>>>该产品已绑定配方
                                        if (apro.RECIPE_ID == aro.RECIPE_ID)
                                        {
                                            #region>>>>>删除该配方下原有的所有明细记录并新增最新的记录
                                            var sql = $"select Count(*) from C_ASM_RECIPE_DATIL_T WHERE RECIPE_ID={aro.RECIPE_ID}";
                                            if (Convert.ToInt32(ClsCommon.dbSql.ExecuteScalar(sql)) > 0)
                                                AsmRecipeDetail_BLL.DeleteRecieDetailByCondition("RECIPE_ID=" + aro.RECIPE_ID);
                                            List<StationProductionObject> recipeByStationList = GetAllImportRecipe(spoByPPT.StationName, spoByPPT.ProductionName, spoByPPT.ProductionPn);
                                            if (recipeByStationList.Count > 0)
                                            {
                                                for (int i = 1; i <= recipeByStationList.Count; i++)
                                                {
                                                    AsmRecipeDetailObject ardo = new AsmRecipeDetailObject();
                                                    ardo.StepNo = recipeByStationList[i - 1].StepNo;
                                                    ardo.Step_Category = recipeByStationList[i - 1].Step_Category;
                                                    ardo.Material_Name = recipeByStationList[i - 1].Material_Name;
                                                    ardo.MaterialPn = recipeByStationList[i - 1].MaterialPn;
                                                    if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Number))
                                                    {
                                                        ardo.Number = recipeByStationList[i - 1].Number;
                                                    }
                                                    else
                                                    {
                                                        ardo.Number = "0";
                                                    }
                                                    if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Gun_No))
                                                    {
                                                        ardo.Gun_No = recipeByStationList[i - 1].Gun_No;
                                                    }
                                                    else
                                                    {
                                                        ardo.Gun_No = "0";
                                                    }
                                                    if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Program_No))
                                                    {
                                                        ardo.Program_No = recipeByStationList[i - 1].Program_No;
                                                    }
                                                    else
                                                    {
                                                        ardo.Program_No = "0";
                                                    }
                                                    if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Sleeve_No))
                                                    {
                                                        ardo.Sleeve_No = recipeByStationList[i - 1].Sleeve_No;
                                                    }
                                                    else
                                                    {
                                                        ardo.Sleeve_No = "0";
                                                    }
                                                    if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Photo_No))
                                                    {
                                                        ardo.Photo_No = recipeByStationList[i - 1].Photo_No;
                                                    }
                                                    //else
                                                    //{
                                                    //    ardo.Photo_No = "0";
                                                    //}
                                                    ardo.RECIPE_ID = aro.RECIPE_ID;
                                                    ardo.A_Limit = recipeByStationList[i - 1].A_Limit;
                                                    ardo.T_Limit = recipeByStationList[i - 1].T_Limit;
                                                    ardo.BoltEQS = recipeByStationList[i - 1].BoltEQS;
                                                    ardo.T_Target = recipeByStationList[i - 1].T_Target;
                                                    ardo.T_Limits = recipeByStationList[i - 1].T_Limits;
                                                    ardo.L_Program = recipeByStationList[i - 1].L_Program;
                                                    ardo.L_Rate = recipeByStationList[i - 1].L_Rate;
                                                    ardo.PICPath = recipeByStationList[i - 1].PICPath;
                                                    AsmRecipeDetail_BLL.AddRecipeDetail(ardo);
                                                }
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            #region>>>>>解除现有产品的绑定并新增现有的配方绑定
                                            AsmProductionRecipe_BLL.DeleteProductionRecipeByObject(apro);
                                            AsmProductionRecipeObject aproNew = new AsmProductionRecipeObject();
                                            aproNew.PRODUCTION_ID = apo.PRODUCTION_ID;
                                            aproNew.RECIPE_ID = aro.RECIPE_ID;
                                            aproNew.STATION_ID = aso.STATION_ID;
                                            AsmProductionRecipe_BLL.AddProductionRecipeByObject(aproNew);
                                            #endregion
                                            #region>>>>>删除该配方下原有的所有明细记录并新增最新的记录
                                            AsmRecipeDetail_BLL.DeleteRecieDetailByCondition("RECIPE_ID=" + aro.RECIPE_ID);
                                            List<StationProductionObject> recipeByStationList = GetAllImportRecipe(spoByPPT.StationName, spoByPPT.ProductionName, spoByPPT.ProductionPn);
                                            if (recipeByStationList.Count > 0)
                                            {
                                                for (int i = 1; i <= recipeByStationList.Count; i++)
                                                {
                                                    AsmRecipeDetailObject ardo = new AsmRecipeDetailObject();
                                                    ardo.StepNo = recipeByStationList[i - 1].StepNo;
                                                    ardo.Step_Category = recipeByStationList[i - 1].Step_Category;
                                                    ardo.Material_Name = recipeByStationList[i - 1].Material_Name;
                                                    ardo.MaterialPn = recipeByStationList[i - 1].MaterialPn;
                                                    if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Number))
                                                    {
                                                        ardo.Number = recipeByStationList[i - 1].Number;
                                                    }
                                                    else
                                                    {
                                                        ardo.Number = "0";
                                                    }
                                                    if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Gun_No))
                                                    {
                                                        ardo.Gun_No = recipeByStationList[i - 1].Gun_No;
                                                    }
                                                    else
                                                    {
                                                        ardo.Gun_No = "0";
                                                    }
                                                    if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Program_No))
                                                    {
                                                        ardo.Program_No = recipeByStationList[i - 1].Program_No;
                                                    }
                                                    else
                                                    {
                                                        ardo.Program_No = "0";
                                                    }
                                                    if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Sleeve_No))
                                                    {
                                                        ardo.Sleeve_No = recipeByStationList[i - 1].Sleeve_No;
                                                    }
                                                    else
                                                    {
                                                        ardo.Sleeve_No = "0";
                                                    }
                                                    if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Photo_No))
                                                    {
                                                        ardo.Photo_No = recipeByStationList[i - 1].Photo_No;
                                                    }
                                                    //else
                                                    //{
                                                    //    ardo.Photo_No = "0";
                                                    //}
                                                    ardo.RECIPE_ID = aro.RECIPE_ID;
                                                    ardo.A_Limit = recipeByStationList[i - 1].A_Limit;
                                                    ardo.T_Limit = recipeByStationList[i - 1].T_Limit;
                                                    ardo.BoltEQS = recipeByStationList[i - 1].BoltEQS;
                                                    ardo.T_Target = recipeByStationList[i - 1].T_Target;
                                                    ardo.T_Limits = recipeByStationList[i - 1].T_Limits;
                                                    ardo.L_Program = recipeByStationList[i - 1].L_Program;
                                                    ardo.L_Rate = recipeByStationList[i - 1].L_Rate;
                                                    ardo.PICPath = recipeByStationList[i - 1].PICPath;
                                                    AsmRecipeDetail_BLL.AddRecipeDetail(ardo);
                                                }
                                            }
                                            #endregion
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        #region>>>>>新增现有的配方绑定
                                        AsmProductionRecipeObject aproNew = new AsmProductionRecipeObject();
                                        aproNew.PRODUCTION_ID = apo.PRODUCTION_ID;
                                        aproNew.RECIPE_ID = aro.RECIPE_ID;
                                        aproNew.STATION_ID = aso.STATION_ID;
                                        AsmProductionRecipe_BLL.AddProductionRecipeByObject(aproNew);
                                        #endregion
                                        #region>>>>>删除该配方下原有的所有明细记录并新增最新的记录
                                        AsmRecipeDetail_BLL.DeleteRecieDetailByCondition("RECIPE_ID=" + aro.RECIPE_ID);
                                        List<StationProductionObject> recipeByStationList = GetAllImportRecipe(spoByPPT.StationName, spoByPPT.ProductionName, spoByPPT.ProductionPn);
                                        if (recipeByStationList.Count > 0)
                                        {
                                            for (int i = 1; i <= recipeByStationList.Count; i++)
                                            {
                                                AsmRecipeDetailObject ardo = new AsmRecipeDetailObject();
                                                ardo.StepNo = recipeByStationList[i - 1].StepNo;
                                                ardo.Step_Category = recipeByStationList[i - 1].Step_Category;
                                                ardo.Material_Name = recipeByStationList[i - 1].Material_Name;
                                                ardo.MaterialPn = recipeByStationList[i - 1].MaterialPn;
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Number))
                                                {
                                                    ardo.Number = recipeByStationList[i - 1].Number;
                                                }
                                                else
                                                {
                                                    ardo.Number = "0";
                                                }
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Gun_No))
                                                {
                                                    ardo.Gun_No = recipeByStationList[i - 1].Gun_No;
                                                }
                                                else
                                                {
                                                    ardo.Gun_No = "0";
                                                }
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Program_No))
                                                {
                                                    ardo.Program_No = recipeByStationList[i - 1].Program_No;
                                                }
                                                else
                                                {
                                                    ardo.Program_No = "0";
                                                }
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Sleeve_No))
                                                {
                                                    ardo.Sleeve_No = recipeByStationList[i - 1].Sleeve_No;
                                                }
                                                else
                                                {
                                                    ardo.Sleeve_No = "0";
                                                }
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Photo_No))
                                                {
                                                    ardo.Photo_No = recipeByStationList[i - 1].Photo_No;
                                                }
                                                //else
                                                //{
                                                //    ardo.Photo_No = "0";
                                                //}
                                                ardo.RECIPE_ID = aro.RECIPE_ID;
                                                ardo.A_Limit = recipeByStationList[i - 1].A_Limit;
                                                ardo.T_Limit = recipeByStationList[i - 1].T_Limit;
                                                ardo.BoltEQS = recipeByStationList[i - 1].BoltEQS;
                                                ardo.T_Target = recipeByStationList[i - 1].T_Target;
                                                ardo.T_Limits = recipeByStationList[i - 1].T_Limits;
                                                ardo.L_Program = recipeByStationList[i - 1].L_Program;
                                                ardo.L_Rate = recipeByStationList[i - 1].L_Rate;
                                                ardo.PICPath = recipeByStationList[i - 1].PICPath;
                                                AsmRecipeDetail_BLL.AddRecipeDetail(ardo);
                                            }
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region>>>>>不存在名字相同的配方
                                    #region>>>>>新增配方
                                    AsmRecipeObject aroNew = new AsmRecipeObject();
                                    aroNew.RECIPE_NAME = spoByPPT.ProductionPn + "-" + spoByPPT.StationName;
                                    aroNew.RECIPE_DISCRIPTION = "导入自动生成";
                                    aroNew.RECIPE_ID = AsmRecipe_BLL.AddAsmRecipeByObject(aroNew);
                                    #endregion
                                    #region>>>>>产品是否在该工位绑定了配方
                                    AsmProductionRecipeObject apro = AsmProductionRecipe_BLL.GetProductionRecipeByProAndSta(apo.PRODUCTION_ID, spoByPPT.StationName);
                                    if (apro != null)
                                    {
                                        #region>>>>>解除现有产品的绑定并新增现有的配方绑定
                                        AsmProductionRecipe_BLL.DeleteProductionRecipeByObject(apro);
                                        AsmProductionRecipeObject aproNew = new AsmProductionRecipeObject();
                                        aproNew.PRODUCTION_ID = apo.PRODUCTION_ID;
                                        aproNew.RECIPE_ID = aroNew.RECIPE_ID;
                                        aproNew.STATION_ID = aso.STATION_ID;
                                        AsmProductionRecipe_BLL.AddProductionRecipeByObject(aproNew);
                                        #endregion
                                        #region>>>>>删除该配方下原有的所有明细记录并新增最新的记录
                                        List<StationProductionObject> recipeByStationList = GetAllImportRecipe(spoByPPT.StationName, spoByPPT.ProductionName, spoByPPT.ProductionPn);
                                        if (recipeByStationList.Count > 0)
                                        {
                                            for (int i = 1; i <= recipeByStationList.Count; i++)
                                            {
                                                AsmRecipeDetailObject ardo = new AsmRecipeDetailObject();
                                                ardo.StepNo = recipeByStationList[i - 1].StepNo;
                                                ardo.Step_Category = recipeByStationList[i - 1].Step_Category;
                                                ardo.Material_Name = recipeByStationList[i - 1].Material_Name;
                                                ardo.MaterialPn = recipeByStationList[i - 1].MaterialPn;
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Number))
                                                {
                                                    ardo.Number = recipeByStationList[i - 1].Number;
                                                }
                                                else
                                                {
                                                    ardo.Number = "0";
                                                }
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Gun_No))
                                                {
                                                    ardo.Gun_No = recipeByStationList[i - 1].Gun_No;
                                                }
                                                else
                                                {
                                                    ardo.Gun_No = "0";
                                                }
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Program_No))
                                                {
                                                    ardo.Program_No = recipeByStationList[i - 1].Program_No;
                                                }
                                                else
                                                {
                                                    ardo.Program_No = "0";
                                                }
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Sleeve_No))
                                                {
                                                    ardo.Sleeve_No = recipeByStationList[i - 1].Sleeve_No;
                                                }
                                                else
                                                {
                                                    ardo.Sleeve_No = "0";
                                                }
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Photo_No))
                                                {
                                                    ardo.Photo_No = recipeByStationList[i - 1].Photo_No;
                                                }
                                                //else
                                                //{
                                                //    ardo.Photo_No = "0";
                                                //}
                                                ardo.RECIPE_ID = aroNew.RECIPE_ID;
                                                ardo.A_Limit = recipeByStationList[i - 1].A_Limit;
                                                ardo.T_Limit = recipeByStationList[i - 1].T_Limit;
                                                ardo.BoltEQS = recipeByStationList[i - 1].BoltEQS;
                                                ardo.T_Target = recipeByStationList[i - 1].T_Target;
                                                ardo.T_Limits = recipeByStationList[i - 1].T_Limits;
                                                ardo.L_Program = recipeByStationList[i - 1].L_Program;
                                                ardo.L_Rate = recipeByStationList[i - 1].L_Rate;
                                                ardo.PICPath = recipeByStationList[i - 1].PICPath;
                                                AsmRecipeDetail_BLL.AddRecipeDetail(ardo);
                                            }
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        #region>>>>>新增现有的配方绑定
                                        AsmProductionRecipeObject aproNew = new AsmProductionRecipeObject();
                                        aproNew.PRODUCTION_ID = apo.PRODUCTION_ID;
                                        aproNew.RECIPE_ID = aroNew.RECIPE_ID;
                                        aproNew.STATION_ID = aso.STATION_ID;
                                        AsmProductionRecipe_BLL.AddProductionRecipeByObject(aproNew);
                                        #endregion
                                        #region>>>>>新增最新的记录
                                        List<StationProductionObject> recipeByStationList = GetAllImportRecipe(spoByPPT.StationName, spoByPPT.ProductionName, spoByPPT.ProductionPn);
                                        if (recipeByStationList.Count > 0)
                                        {
                                            for (int i = 1; i <= recipeByStationList.Count; i++)
                                            {
                                                AsmRecipeDetailObject ardo = new AsmRecipeDetailObject();
                                                ardo.StepNo = recipeByStationList[i - 1].StepNo;
                                                ardo.Step_Category = recipeByStationList[i - 1].Step_Category;
                                                ardo.Material_Name = recipeByStationList[i - 1].Material_Name;
                                                ardo.MaterialPn = recipeByStationList[i - 1].MaterialPn;
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Number))
                                                {
                                                    ardo.Number = recipeByStationList[i - 1].Number;
                                                }
                                                else
                                                {
                                                    ardo.Number = "0";
                                                }
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Gun_No))
                                                {
                                                    ardo.Gun_No = recipeByStationList[i - 1].Gun_No;
                                                }
                                                else
                                                {
                                                    ardo.Gun_No = "0";
                                                }
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Program_No))
                                                {
                                                    ardo.Program_No = recipeByStationList[i - 1].Program_No;
                                                }
                                                else
                                                {
                                                    ardo.Program_No = "0";
                                                }
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Sleeve_No))
                                                {
                                                    ardo.Sleeve_No = recipeByStationList[i - 1].Sleeve_No;
                                                }
                                                else
                                                {
                                                    ardo.Sleeve_No = "0";
                                                }
                                                if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Photo_No))
                                                {
                                                    ardo.Photo_No = recipeByStationList[i - 1].Photo_No;
                                                }
                                                //else
                                                //{
                                                //    ardo.Photo_No = "0";
                                                //}
                                                ardo.RECIPE_ID = aroNew.RECIPE_ID;
                                                ardo.A_Limit = recipeByStationList[i - 1].A_Limit;
                                                ardo.T_Limit = recipeByStationList[i - 1].T_Limit;
                                                ardo.BoltEQS = recipeByStationList[i - 1].BoltEQS;
                                                ardo.T_Target = recipeByStationList[i - 1].T_Target;
                                                ardo.T_Limits = recipeByStationList[i - 1].T_Limits;
                                                ardo.L_Program = recipeByStationList[i - 1].L_Program;
                                                ardo.L_Rate = recipeByStationList[i - 1].L_Rate;
                                                ardo.PICPath = recipeByStationList[i - 1].PICPath;
                                                AsmRecipeDetail_BLL.AddRecipeDetail(ardo);
                                            }
                                        }
                                        #endregion
                                    }
                                    #endregion
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                #region>>>>>不存在该产品
                                #region>>>>>新增产品获取ID
                                AsmProductionObject newApo = new AsmProductionObject();
                                newApo.PRODUCTION_NAME = spoByPPT.ProductionName;
                                newApo.PRODUCTION_VR = spoByPPT.ProductionPn;
                                newApo.PRODUCTION_TYPE = "AUTO";
                                newApo.PRODUCTION_DISCRIPTION = "集中导入";
                                newApo.PRODUCTION_STE = "1";
                                newApo.PRODUCTION_SERIES = "1";
                                newApo.PRODUCTION_ID = AsmProduction_BLL.AddAsmProductionByObjectReturnId(newApo);
                                #endregion
                                #region>>>>>是否存在该工位下相同名称的配方
                                AsmRecipeObject aro = AsmRecipe_BLL.GetRecipeByCondition("RECIPE_NAME='" + spoByPPT.ProductionPn + "-" + spoByPPT.StationName + "'");
                                if (aro != null)
                                {
                                    #region>>>>>存在名称相同的配方
                                    #region>>>>>新增关联
                                    AsmProductionRecipeObject apro = new AsmProductionRecipeObject();
                                    apro.PRODUCTION_ID = newApo.PRODUCTION_ID;
                                    apro.RECIPE_ID = aro.RECIPE_ID;
                                    apro.STATION_ID = aso.STATION_ID;
                                    AsmProductionRecipe_BLL.AddProductionRecipeByObject(apro);
                                    #endregion
                                    #region>>>>>删除该配方下原有的所有明细记录并新增最新的记录
                                    AsmRecipeDetail_BLL.DeleteRecieDetailByCondition("RECIPE_ID=" + aro.RECIPE_ID);
                                    List<StationProductionObject> recipeByStationList = GetAllImportRecipe(spoByPPT.StationName, spoByPPT.ProductionName, spoByPPT.ProductionPn);
                                    if (recipeByStationList.Count > 0)
                                    {
                                        for (int i = 1; i <= recipeByStationList.Count; i++)
                                        {
                                            AsmRecipeDetailObject ardo = new AsmRecipeDetailObject();
                                            ardo.StepNo = recipeByStationList[i - 1].StepNo;
                                            ardo.Step_Category = recipeByStationList[i - 1].Step_Category;
                                            ardo.Material_Name = recipeByStationList[i - 1].Material_Name;
                                            ardo.MaterialPn = recipeByStationList[i - 1].MaterialPn;
                                            if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Number))
                                            {
                                                ardo.Number = recipeByStationList[i - 1].Number;
                                            }
                                            else
                                            {
                                                ardo.Number = "0";
                                            }
                                            if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Gun_No))
                                            {
                                                ardo.Gun_No = recipeByStationList[i - 1].Gun_No;
                                            }
                                            else
                                            {
                                                ardo.Gun_No = "0";
                                            }
                                            if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Program_No))
                                            {
                                                ardo.Program_No = recipeByStationList[i - 1].Program_No;
                                            }
                                            else
                                            {
                                                ardo.Program_No = "0";
                                            }
                                            if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Sleeve_No))
                                            {
                                                ardo.Sleeve_No = recipeByStationList[i - 1].Sleeve_No;
                                            }
                                            else
                                            {
                                                ardo.Sleeve_No = "0";
                                            }
                                            if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Photo_No))
                                            {
                                                ardo.Photo_No = recipeByStationList[i - 1].Photo_No;
                                            }
                                            //else
                                            //{
                                            //    ardo.Photo_No = "0";
                                            //}                                           
                                            ardo.RECIPE_ID = aro.RECIPE_ID;
                                            ardo.A_Limit = recipeByStationList[i - 1].A_Limit;
                                            ardo.T_Limit = recipeByStationList[i - 1].T_Limit;
                                            ardo.BoltEQS = recipeByStationList[i - 1].BoltEQS;
                                            ardo.T_Target = recipeByStationList[i - 1].T_Target;
                                            ardo.T_Limits = recipeByStationList[i - 1].T_Limits;
                                            ardo.L_Program = recipeByStationList[i - 1].L_Program;
                                            ardo.L_Rate = recipeByStationList[i - 1].L_Rate;
                                            ardo.PICPath = recipeByStationList[i - 1].PICPath;
                                            AsmRecipeDetail_BLL.AddRecipeDetail(ardo);
                                        }
                                    }
                                    #endregion
                                    #endregion
                                }
                                else
                                {
                                    #region>>>>>不存在名称相同的配方
                                    #region>>>>>新增配方
                                    AsmRecipeObject aroNew = new AsmRecipeObject();
                                    aroNew.RECIPE_NAME = spoByPPT.ProductionPn + "-" + spoByPPT.StationName;
                                    aroNew.RECIPE_DISCRIPTION = "导入自动生成";
                                    aroNew.RECIPE_ID = AsmRecipe_BLL.AddAsmRecipeByObject(aroNew);
                                    #endregion
                                    #region>>>>>新增关联
                                    AsmProductionRecipeObject apro = new AsmProductionRecipeObject();
                                    apro.PRODUCTION_ID = newApo.PRODUCTION_ID;
                                    apro.RECIPE_ID = aroNew.RECIPE_ID;
                                    apro.STATION_ID = aso.STATION_ID;
                                    AsmProductionRecipe_BLL.AddProductionRecipeByObject(apro);
                                    #endregion
                                    #region>>>>>新增配方明细
                                    List<StationProductionObject> recipeByStationList = GetAllImportRecipe(spoByPPT.StationName, spoByPPT.ProductionName, spoByPPT.ProductionPn);
                                    if (recipeByStationList.Count > 0)
                                    {
                                        for (int i = 1; i <= recipeByStationList.Count; i++)
                                        {
                                            AsmRecipeDetailObject ardo = new AsmRecipeDetailObject();
                                            ardo.StepNo = recipeByStationList[i - 1].StepNo;
                                            ardo.Step_Category = recipeByStationList[i - 1].Step_Category;
                                            ardo.Material_Name = recipeByStationList[i - 1].Material_Name;
                                            ardo.MaterialPn = recipeByStationList[i - 1].MaterialPn;
                                            if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Number))
                                            {
                                                ardo.Number = recipeByStationList[i - 1].Number;
                                            }
                                            else
                                            {
                                                ardo.Number = "0";
                                            }
                                            if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Gun_No))
                                            {
                                                ardo.Gun_No = recipeByStationList[i - 1].Gun_No;
                                            }
                                            else
                                            {
                                                ardo.Gun_No = "0";
                                            }
                                            if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Program_No))
                                            {
                                                ardo.Program_No = recipeByStationList[i - 1].Program_No;
                                            }
                                            else
                                            {
                                                ardo.Program_No = "0";
                                            }
                                            if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Sleeve_No))
                                            {
                                                ardo.Sleeve_No = recipeByStationList[i - 1].Sleeve_No;
                                            }
                                            else
                                            {
                                                ardo.Sleeve_No = "0";
                                            }
                                            if (!String.IsNullOrEmpty(recipeByStationList[i - 1].Photo_No))
                                            {
                                                ardo.Photo_No = recipeByStationList[i - 1].Photo_No;
                                            }
                                            //else
                                            //{
                                            //    ardo.Photo_No = "0";
                                            //}
                                            ardo.RECIPE_ID = aroNew.RECIPE_ID;
                                            ardo.A_Limit = recipeByStationList[i - 1].A_Limit;
                                            ardo.T_Limit = recipeByStationList[i - 1].T_Limit;
                                            ardo.BoltEQS = recipeByStationList[i - 1].BoltEQS;
                                            ardo.T_Target = recipeByStationList[i - 1].T_Target;
                                            ardo.T_Limits = recipeByStationList[i - 1].T_Limits;
                                            ardo.L_Program = recipeByStationList[i - 1].L_Program;
                                            ardo.L_Rate = recipeByStationList[i - 1].L_Rate;
                                            ardo.PICPath = recipeByStationList[i - 1].PICPath;
                                            AsmRecipeDetail_BLL.AddRecipeDetail(ardo);
                                        }
                                    }
                                    #endregion
                                    #endregion
                                }
                                #endregion
                                #endregion
                            }
                            #endregion
                        }
                    }
                    #region
                    MessageBox.Show("保存成功......");
                    cmbCount.Refresh();
                    dataBind();
                    tb3.Clear();
                    #endregion
                    #endregion
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ImportRecipe_Shown(object sender, EventArgs e)
        {
            dataBind();
        }

        private void BT_Find_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbCount.SelectedValue.ToString()))
            {
                string sql = "SELECT ARD.Step_Category AS '操作类别',ARD.Material_Name AS '工序名称',ARD.Number AS '数量',ARD.Gun_No AS '枪号',ARD.Program_No AS '程序号',ARD.MaterialPn AS '物料PN',ARD.Sleeve_No AS '套筒号',ARD.StepNo AS '工序',ARD.T_Limit AS '上传代码',ARD.Photo_No AS '条码规则',ARD.BoltEQS AS '工位节拍',AST.STATION_NAME AS '工位名称',AP.PRODUCTION_NAME AS '产品名称',AP.PRODUCTION_VR AS 'PACKPN',ARD.T_Target AS '目标扭矩',ARD.T_Limits AS '上下限',ARD.L_Program AS '泄露测试程序编号',ARD.L_Rate AS '泄露率',ARD.PICPath AS '图片路径'  FROM dbo.C_ASM_RECIPE_DATIL_T ARD,dbo.C_ASM_PRODUCTION_RECIPE_T APR,dbo.C_ASM_PRODUCTION_T AP,dbo.C_ASM_RECIPE_T AR,dbo.C_ASM_STATION_T AST WHERE AP.PRODUCTION_ID=APR.PRODUCTION_ID AND AST.STATION_ID=APR.STATION_ID AND AR.RECIPE_ID=APR.RECIPE_ID AND AR.RECIPE_ID=ARD.RECIPE_ID AND AP.PRODUCTION_VR = '" + cmbCount.SelectedValue.ToString().Trim() + "' order by RECIPE_DATIL_ID ASC;";
                tb3 = ClsCommon.dbSql.ExecuteDataTable(sql);
                dataGridView2.DataSource = tb3;
            }
            else
            {
                MessageBox.Show("请选择产品PN号......");
            }
        }
        public bool CheckProductionAndPnSame()
        {
            for (int i = 1; i < tb3.Rows.Count; i++)
            {
                if (tb3.Rows[i]["产品名称"].ToString().Trim() != tb3.Rows[i - 1]["产品名称"].ToString().Trim())
                {
                    MessageBox.Show("产品名称不一致，请检查后重新导入！");
                    return false;
                }
                if (tb3.Rows[i]["PACKPN"].ToString().Trim() != tb3.Rows[i - 1]["PACKPN"].ToString().Trim())
                {
                    MessageBox.Show("PACKPN不一致，请检查后重新导入！");
                    return false;
                }
            }
            return true;
        }
        private List<StationProductionObject> GetDisctinctStationAndProdiction()
        {
            List<StationProductionObject> lsp = new List<StationProductionObject>();
            List<StationProductionObject> lspTemp = new List<StationProductionObject>();
            if (CheckProductionAndPnSame())
            {
                for (int i = 0; i < tb3.Rows.Count; i++)
                {
                    StationProductionObject spo = new StationProductionObject();
                    spo.StationName = tb3.Rows[i]["工位名称"].ToString().Trim();
                    spo.ProductionName = tb3.Rows[i]["产品名称"].ToString().Trim();
                    spo.ProductionPn = tb3.Rows[i]["PACKPN"].ToString().Trim();
                    lsp.Add(spo);
                }

            }
            lspTemp = lsp.Distinct().ToList();
            return lspTemp;
        }
        public List<StationProductionObject> GetAllImportRecipe(string station, string productionName, string productionPn)
        {
            List<StationProductionObject> allList = new List<StationProductionObject>();
            for (int i = 0; i < tb3.Rows.Count; i++)
            {
                if (tb3.Rows[i]["工位名称"].ToString().Trim() == station && tb3.Rows[i]["产品名称"].ToString().Trim() == productionName && tb3.Rows[i]["PACKPN"].ToString().Trim() == productionPn)
                {
                    StationProductionObject spo = new StationProductionObject();
                    spo.StepNo = tb3.Rows[i]["工序"].ToString().Trim();
                    spo.Step_Category = tb3.Rows[i]["操作类别"].ToString().Trim();
                    spo.Material_Name = tb3.Rows[i]["工序名称"].ToString().Trim();
                    spo.MaterialPn = tb3.Rows[i]["物料PN"].ToString().Trim();
                    spo.Number = tb3.Rows[i]["数量"].ToString().Trim();
                    spo.Gun_No = tb3.Rows[i]["枪号"].ToString().Trim();
                    spo.T_Limit = tb3.Rows[i]["上传代码"].ToString().Trim();
                    spo.Program_No = tb3.Rows[i]["程序号"].ToString().Trim();
                    // spo.A_Limit= tb3.Rows[i]["工序"].ToString().Trim();
                    spo.Sleeve_No = tb3.Rows[i]["套筒号"].ToString().Trim();
                    spo.Photo_No = tb3.Rows[i]["条码规则"].ToString().Trim();
                    spo.BoltEQS = tb3.Rows[i]["工位节拍"].ToString().Trim();
                    spo.T_Target = tb3.Rows[i]["目标扭矩"].ToString().Trim();
                    spo.T_Limits = tb3.Rows[i]["上下限"].ToString().Trim();
                    spo.L_Program = tb3.Rows[i]["泄露测试程序编号"].ToString().Trim();
                    spo.L_Rate = tb3.Rows[i]["泄漏率"].ToString().Trim();
                    spo.PICPath = tb3.Rows[i]["图片路径"].ToString().Trim();
                    allList.Add(spo);
                }
            }
            return allList;
        }

        private void BT_D_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog frm = new SaveFileDialog();
                frm.FileName = DateTime.Now.ToString("yyyyMMddHHmm");
                frm.Filter = "excel文件(*.xls)|*.xlsx|所有文件(*.*)|*.*";
                if (DialogResult.OK == frm.ShowDialog())
                {
                    string strFileName = frm.FileName;
                    ExcelHelper execl = new ExcelHelper(strFileName);
                    if (execl.DataGridViewToExcel(dataGridView2, "配方导出", true) > 0)
                    {
                        MessageBox.Show("Excel导出成功。");
                    }
                    else
                    {
                        MessageBox.Show("Excel导出失败。");
                    }
                    execl.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("Excel导出失败。");
                MyLog.Log.InformationLog.Error("Excel导出失败。", ex);
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
