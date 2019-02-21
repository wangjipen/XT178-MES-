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
    class AsmRecipeDetail_DAL
    {
        /// <summary>
        /// 增加BOM信息
        /// </summary>
        /// <param name="pbo"></param>
        /// <returns></returns>
        public static int AddRecipeDetail(AsmRecipeDetailObject ardo)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(ardo);
                return Convert.ToInt32(result);
            }
        }
        /// <summary>
        /// 获取对应BOM的详细信息
        /// </summary>
        /// <param name="bomId"></param>
        /// <returns></returns>
        public static DataTable GetAllRecipeDetailByCondition(string bomId)
        {
            string sql = "SELECT RECIPE_DATIL_ID,StepNo,Step_Category,Material_Name,Number,Gun_No,Program_No,Photo_No,Sleeve_No,MaterialPn,BoltEQS,A_Limit,T_Limit,RECIPE_ID,PICPath,T_Target,T_Limits,L_Program,L_Rate FROM dbo.C_ASM_RECIPE_DATIL_T WHERE RECIPE_ID=" + bomId+ " order by CAST(StepNo AS int),RECIPE_DATIL_ID";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sql);
            return dt;
        }
        public static DataTable GetRecipeDetailByStationAndProduction(string stationId, string productionId)
        {
            string sql = "SELECT RD.RECIPE_DATIL_ID,RD.StepNo,RD.Step_Category,RD.Material_Name,RD.Number,RD.Gun_No,RD.Program_No,RD.Photo_No,RD.Sleeve_No,RD.MaterialPn,RD.BoltEQS,RD.A_Limit,RD.T_Limit,RD.RECIPE_ID FROM dbo.C_ASM_RECIPE_DATIL_T RD,(SELECT RECIPE_ID FROM dbo.C_ASM_PRODUCTION_RECIPE_T WHERE PRODUCTION_ID="+productionId +" AND STATION_ID="+ stationId+") CAPR WHERE RD.RECIPE_ID=CAPR.RECIPE_ID order by CAST(StepNo AS int),RECIPE_DATIL_ID";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sql);
            return dt;
        }
        /// <summary>
        /// 更新BOM详细信息
        /// </summary>
        /// <param name="po"></param>
        /// <returns></returns>
        public static int UpdateProductionBOM(AsmRecipeDetailObject pbo)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Update(pbo);
            }
            return Convert.ToInt32(result);
        }
        /// <summary>
        /// 根据对象删除产品
        /// </summary>
        /// <param name="uo"></param>
        /// <returns></returns>
        public static int DeleteProductionBomByObject(AsmRecipeDetailObject pbo)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())
            {
                result = conn.Delete(pbo);
            }
            return Convert.ToInt32(result);
        }
        /// <summary>
        /// 根据条件删除BOM详细信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int DeleteRecieDetailByCondition(string sql)
        {
            string sl = "DELETE FROM dbo.C_ASM_RECIPE_DATIL_T WHERE " + sql;
            int res = ClsCommon.dbSql.ExecuteNonQuery(sl);
            return res;
        }
    }
}
