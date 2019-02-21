using Dapper;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.DAL
{
    class AsmProductionRecipe_DAL
    {
        public static List<DbParameter> parameters;
        public static int AddProductionRecipeByObject(AsmProductionRecipeObject apro)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(apro);
                return Convert.ToInt32(result);
            }
        }
        public static int UpdateProductionRecipeByObject(AsmProductionRecipeObject apro)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Update(apro);
            }
            return Convert.ToInt32(result);
        }
        public static int DeleteProductionRecipeByCondition(string sql)
        {
            string sll = "SELECT * FROM C_ASM_PRODUCTION_RECIPE_T WHERE " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sll);
            if (dt.Rows.Count > 0)
            {
                string sl = "DELETE FROM C_ASM_PRODUCTION_RECIPE_T WHERE  " + sql;
                int a = ClsCommon.dbSql.ExecuteNonQuery(sl);
                return a;
            }
            else
            {
                return 1;
            }
        }
        public static DataTable GetAllProductionRecipe()
        {
            string sql = "SELECT AP.PRODUCTION_ID,AP.PRODUCTION_NAME,AP.PRODUCTION_DISCRIPTION,APR.PRODUCTION_RECIPE_ID,R.RECIPE_ID,R.RECIPE_NAME,R.RECIPE_DISCRIPTION,ST.STATION_ID,ST.STATION_NAME FROM dbo.C_ASM_PRODUCTION_RECIPE_T APR,dbo.C_ASM_PRODUCTION_T AP,dbo.C_ASM_RECIPE_T R,C_ASM_STATION_T ST WHERE APR.PRODUCTION_ID=AP.PRODUCTION_ID AND APR.RECIPE_ID=R.RECIPE_ID AND ST.STATION_ID=APR.STATION_ID";
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sql);
            return dt;
        }
        public static DataTable GetManyProductionRecipeByCondition(string sl)
        {
            string sql = "SELECT AP.PRODUCTION_ID,AP.PRODUCTION_NAME,AP.PRODUCTION_DISCRIPTION,APR.PRODUCTION_RECIPE_ID,R.RECIPE_ID,R.RECIPE_NAME,R.RECIPE_DISCRIPTION,ST.STATION_ID,ST.STATION_NAME FROM dbo.C_ASM_PRODUCTION_RECIPE_T APR,dbo.C_ASM_PRODUCTION_T AP,dbo.C_ASM_RECIPE_T R,C_ASM_STATION_T ST WHERE APR.PRODUCTION_ID=AP.PRODUCTION_ID AND APR.RECIPE_ID=R.RECIPE_ID AND ST.STATION_ID=APR.STATION_ID "+sl;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sql);
            return dt;
        }
        public static AsmProductionRecipeObject GetProductionRecipeCondition(string sl)
        {
            AsmProductionRecipeObject apro = null;
            string sql = "SELECT PRODUCTION_RECIPE_ID,PRODUCTION_ID,RECIPE_ID,STATION_ID  FROM dbo.C_ASM_PRODUCTION_RECIPE_T WHERE  " + sl;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                apro = new AsmProductionRecipeObject();
                apro.PRODUCTION_RECIPE_ID = Convert.ToInt32(dt.Rows[0]["PRODUCTION_RECIPE_ID"].ToString());
                apro.PRODUCTION_ID = Convert.ToInt32(dt.Rows[0]["PRODUCTION_ID"].ToString());
                apro.RECIPE_ID = Convert.ToInt32(dt.Rows[0]["RECIPE_ID"].ToString());
                apro.STATION_ID = Convert.ToInt32(dt.Rows[0]["STATION_ID"].ToString());
            }
            return apro;
        }
        public static AsmProductionRecipeObject GetProductionRecipeByProAndSta(int productionId, string stationName)
        {
            AsmProductionRecipeObject apro = null;
            string sql = "SELECT APR.PRODUCTION_RECIPE_ID,APR.PRODUCTION_ID,APR.RECIPE_ID,APR.STATION_ID  FROM dbo.C_ASM_PRODUCTION_RECIPE_T APR,C_ASM_STATION_T AST WHERE AST.STATION_ID=APR.STATION_ID AND APR.PRODUCTION_ID=" + productionId+ " AND AST.STATION_NAME='"+stationName+"'";
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                apro = new AsmProductionRecipeObject();
                apro.PRODUCTION_RECIPE_ID = Convert.ToInt32(dt.Rows[0]["PRODUCTION_RECIPE_ID"].ToString());
                apro.PRODUCTION_ID = Convert.ToInt32(dt.Rows[0]["PRODUCTION_ID"].ToString());
                apro.RECIPE_ID = Convert.ToInt32(dt.Rows[0]["RECIPE_ID"].ToString());
                apro.STATION_ID = Convert.ToInt32(dt.Rows[0]["STATION_ID"].ToString());
            }
            return apro;
        }
        public static List<AsmProductionRecipeObject> GetManyProductionRecipeObjectByCondition(string sql)
        {
            List<AsmProductionRecipeObject> ar = new List<AsmProductionRecipeObject>();
            string sl = "SELECT PRODUCTION_RECIPE_ID,PRODUCTION_ID,RECIPE_ID,STATION_ID FROM C_ASM_PRODUCTION_RECIPE_T WHERE " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AsmProductionRecipeObject aro = new AsmProductionRecipeObject();
                    aro.PRODUCTION_RECIPE_ID = Convert.ToInt32(dt.Rows[i]["PRODUCTION_RECIPE_ID"].ToString());
                    aro.PRODUCTION_ID = Convert.ToInt32(dt.Rows[i]["PRODUCTION_ID"].ToString());
                    aro.RECIPE_ID = Convert.ToInt32(dt.Rows[i]["RECIPE_ID"].ToString());
                    aro.STATION_ID = Convert.ToInt32(dt.Rows[i]["STATION_ID"].ToString());
                    ar.Add(aro);
                }
            }
            return ar;
        }
        public static List<AsmRecipeDetailObject> GetRecipesByProductionAndStation(string productionVr, string stationName)
        {
            List<AsmRecipeDetailObject> lar = new List<AsmRecipeDetailObject>();
            string sql = "SELECT ARD.RECIPE_DATIL_ID,ARD.StepNo,ARD.Step_Category,ARD.Material_Name,ARD.Number,ARD.Gun_No,ARD.Program_No,ARD.Photo_No,ARD.Sleeve_No,ARD.ReworkTimes,ARD.Feacode,ARD.CheckOrNo,ARD.ReviewOrNo,ARD.ExactOrNo,ARD.MaterialPn,ARD.BoltEQS,ARD.A_Limit,ARD.T_Limit,ARD.RECIPE_ID  FROM dbo.C_ASM_RECIPE_DATIL_T ARD,dbo.C_ASM_PRODUCTION_RECIPE_T APR,dbo.C_ASM_PRODUCTION_T AP,dbo.C_ASM_RECIPE_T AR,dbo.C_ASM_STATION_T AST WHERE AP.PRODUCTION_ID=APR.PRODUCTION_ID AND AST.STATION_ID=APR.STATION_ID AND AR.RECIPE_ID=APR.RECIPE_ID AND AR.RECIPE_ID=ARD.RECIPE_ID AND AP.PRODUCTION_VR LIKE '%" + productionVr + "%' AND AST.STATION_NAME='"+ stationName + "'";
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AsmRecipeDetailObject ardo = new AsmRecipeDetailObject();
                    ardo.RECIPE_DATIL_ID = Convert.ToInt32(dt.Rows[i]["RECIPE_DATIL_ID"].ToString());
                    ardo.StepNo = dt.Rows[i]["StepNo"].ToString();
                    ardo.Step_Category= dt.Rows[i]["Step_Category"].ToString();
                    ardo.Material_Name= dt.Rows[i]["Material_Name"].ToString(); 
                    ardo.Number= dt.Rows[i]["Number"].ToString(); 
                    ardo.Gun_No= dt.Rows[i]["Gun_No"].ToString();
                    ardo.Program_No= dt.Rows[i]["Program_No"].ToString();
                    ardo.Photo_No= dt.Rows[i]["Photo_No"].ToString();
                    ardo.Sleeve_No= dt.Rows[i]["Sleeve_No"].ToString();
                    ardo.ReworkTimes= dt.Rows[i]["ReworkTimes"].ToString();
                    ardo.Feacode= dt.Rows[i]["Feacode"].ToString();
                    ardo.CheckOrNo= dt.Rows[i]["CheckOrNo"].ToString();
                    ardo.ReviewOrNo= dt.Rows[i]["ReviewOrNo"].ToString();
                    ardo.ExactOrNo= dt.Rows[i]["ExactOrNo"].ToString();
                    ardo.MaterialPn= dt.Rows[i]["MaterialPn"].ToString(); 
                    ardo.BoltEQS= dt.Rows[i]["BoltEQS"].ToString();
                    ardo.A_Limit= dt.Rows[i]["A_Limit"].ToString();
                    ardo.T_Limit= dt.Rows[i]["T_Limit"].ToString();
                    ardo.RECIPE_ID=Convert.ToInt32(dt.Rows[i]["RECIPE_ID"].ToString());
                    lar.Add(ardo);
                }
            }
            return lar;
        }
        public static int DeleteProductionRecipeByObject(AsmProductionRecipeObject pcb)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Delete(pcb);
            }
            return Convert.ToInt32(result);
        }
    }
}
