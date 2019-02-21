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
    class AsmReworkReson_DAL
    {
        public static int AddReworkReson(AsmReworkResonObject uo)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(uo);
                return Convert.ToInt32(result);
            }
        }
        public static bool IsExistReworkReson(String sql)
        {
            string sl = "SELECT * FROM dbo.P_ASM_REWORK_RESON_T WHERE " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static DataTable GetReasonByCondition(string sql)
        {
            string sl = "SELECT * FROM dbo.P_ASM_REWORK_RESON_T WHERE " + sql;
            DataTable dt =ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }

        public static void DeleteReasonByCondition(string sql)
        {
            string sl = "delete  FROM dbo.P_ASM_REWORK_RESON_T WHERE " + sql;
            ClsCommon.dbSql.ExecuteDataTable(sl);
        }
    }
}
