using Dapper;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMaterialRack.IntelligentMaterialRack.DAL
{
    class AsmReworkWay_DAL
    {
        public static int AddReworkWay(AsmReworkWayObject uo)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(uo);
                return Convert.ToInt32(result);
            }
        }

        
        public static DataTable  SelectWayByCondition(string sql)
        {
            string sl = " select  ST_NAME as STATION_NAME ,ST_ID as STATION_ID from R_ASM_REWORK_WAY_T   where " + sql;
            DataTable dt =  ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }

        public static void DeleteWayBycondition(string sql)
        {
            string sl = " delete from R_ASM_REWORK_WAY_T where "+sql;
            ClsCommon.dbSql.ExecuteDataTable(sl);
        }
    }
}
