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
    class AsmAlarmCode_DAL
    {
        public static DataTable GetAlarmCodes()
        {
            string sl = "SELECT  DT,ST,CODE,MESSAGE FROM C_ASM_ALARM_MESSAGE_T  ORDER BY DT DESC";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
        public static DataTable GetAlarmCodesByCondition(string sql)
        {
            string sl = "SELECT  ALARM_CODE,ALARM_TEXT,ALARM_ENGLISH FROM C_ASM_ALARM_CODE_T where "+ sql + " ORDER BY ALARM_CODE ASC";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
        public static bool IsExistCode(String sql)
        {
            string sl = "SELECT * FROM C_ASM_ALARM_CODE_T WHERE " + sql;
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
        public static int AddAlarmCode(AsmAlarmCodeObject uo)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(uo);
                return Convert.ToInt32(result);
            }
        }
        public static int UpdateAlarmCode(AsmAlarmCodeObject uo)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Update(uo);
            }
            return Convert.ToInt32(result);
        }
        public static AsmAlarmCodeObject GetAlarmCodeObjectByCondition(string sql)
        {
            AsmAlarmCodeObject aaco = null;
            string sl = "SELECT * FROM dbo.C_ASM_ALARM_CODE_T  " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                aaco = new AsmAlarmCodeObject();
                aaco.ID= Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                aaco.DT= Convert.ToDateTime(dt.Rows[0]["DT"].ToString());
                aaco.ALARM_CODE= Convert.ToInt32(dt.Rows[0]["ALARM_CODE"].ToString());
                aaco.ALARM_TEXT=  dt.Rows[0]["ALARM_TEXT"].ToString();
                aaco.ALARM_ENGLISH= dt.Rows[0]["ALARM_ENGLISH"].ToString();
            }
            return aaco;
        }
        public static int DeleteAlarmCodeByCondition(string sql)
        {
            string sl = "DELETE FROM dbo.C_ASM_ALARM_CODE_T  WHERE " + sql;
            int a = ClsCommon.dbSql.ExecuteNonQuery(sl);
            return a;
        }
    }
}
