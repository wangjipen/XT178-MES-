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
    class AsmRecipe_DAL
    {
        public static List<DbParameter> parameters;
        public static int AddAsmRecipeByObject(AsmRecipeObject aro)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(aro);
                return Convert.ToInt32(result);
            }
        }
        public static int UpdateAsmRecipeByObject(AsmRecipeObject pcb)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Update(pcb);
            }
            return Convert.ToInt32(result);
        }
        public static AsmRecipeObject GetAsmRecipeByObject(string sql)
        {
            AsmRecipeObject uo;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                uo = conn.Get<AsmRecipeObject>(sql);
            }
            return uo;
        }
        public static DataTable GetAllRecipeByCondition()
        {
            string sql = "SELECT RECIPE_ID,RECIPE_NAME,RECIPE_DISCRIPTION FROM dbo.C_ASM_RECIPE_T";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sql);
            return dt;
        }
        public static AsmRecipeObject GetRecipeByCondition(string sql)
        {
            AsmRecipeObject pcbo = null;
            string sl = "SELECT RECIPE_ID,RECIPE_NAME,RECIPE_DISCRIPTION FROM dbo.C_ASM_RECIPE_T WHERE " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                pcbo = new AsmRecipeObject();
                pcbo.RECIPE_ID = Convert.ToInt32(dt.Rows[0]["RECIPE_ID"].ToString());
                pcbo.RECIPE_NAME = dt.Rows[0]["RECIPE_NAME"].ToString();
                pcbo.RECIPE_DISCRIPTION = dt.Rows[0]["RECIPE_DISCRIPTION"].ToString();
            }
            return pcbo;
        }
        public static int DeleteRecipeByObject(AsmRecipeObject pcb)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Delete(pcb);
            }
            return Convert.ToInt32(result);
        }
        public static int DeleteProductionRecipe(AsmRecipeObject aro)
        {
            parameters = new List<DbParameter>();
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@RECIPE_ID", ParameterDirection.Input, aro.RECIPE_ID));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@NAME", ParameterDirection.Input, aro.RECIPE_NAME));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@DISCRIPTION", ParameterDirection.Input, aro.RECIPE_DISCRIPTION));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@R", ParameterDirection.Output, ""));
            ClsCommon.dbSql.ExecuteNonQuery("F_ASM_DELETEPRODUCTIONRECIPE_P", parameters, CommandType.StoredProcedure);
            object bj = parameters[parameters.Count - 1].Value.ToString();
            return Convert.ToInt32(bj);
        }
       
    }
}
