using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using Dapper;

namespace IntelligentMaterialRack.IntelligentMaterialRack.DAL
{
    class AsmPlanPrint_DAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appo"></param>
        public static void AddPlanPrint(AsmPlanPrintObject appo)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(appo);               
            }
        }

        public static DataTable GetBarcodeByCondition(string sql)
        {
            string sl = "select  SN from R_PLAN_PRINT_T where PLAN_ID='"+sql+"'";
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }

    }
}
