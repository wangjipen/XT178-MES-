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
    class AsmDevice_DAL
    {
        public static bool IsExistCode(String sql)
        {
            string sl = "SELECT * FROM C_ASM_DEVICE_T WHERE " + sql;
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
        public static int AddDeviceObject(AsmDeviceObject uo)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(uo);
                return Convert.ToInt32(result);
            }
        }
        public static AsmDeviceObject GetDeviceObjectByCondition(string sql)
        {
            AsmDeviceObject ado = null;
            string sl = "SELECT * FROM dbo.C_ASM_DEVICE_T  " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                ado = new AsmDeviceObject();
                ado.ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                ado.DEVICE_NAME= dt.Rows[0]["DEVICE_NAME"].ToString();
                ado.DEVICE_STATION= dt.Rows[0]["DEVICE_STATION"].ToString();
                ado.DEVICE_TYPE= dt.Rows[0]["DEVICE_TYPE"].ToString();
                ado.DEVICE_IP= dt.Rows[0]["DEVICE_IP"].ToString();
                ado.DEVICE_CID= dt.Rows[0]["DEVICE_CID"].ToString();
                ado.DEVICE_PROTOCOL= dt.Rows[0]["DEVICE_PROTOCOL"].ToString();
                ado.DEVICE_PRINTADD= dt.Rows[0]["DEVICE_PRINTADD"].ToString();
                ado.DEVICE_CONTROLADD = dt.Rows[0]["DEVICE_CONTROLADD"].ToString();
            }
            return ado;
        }
        public static int UpdateDeviceObject(AsmDeviceObject uo)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Update(uo);
            }
            return Convert.ToInt32(result);
        }
        public static DataTable GetDevices()
        {
            string sl = "SELECT  DEVICE_NAME,DEVICE_STATION,DEVICE_TYPE,DEVICE_IP,DEVICE_PROTOCOL,DEVICE_CID,DEVICE_CONTROLADD,DEVICE_PRINTADD FROM C_ASM_DEVICE_T  ORDER BY ID DESC";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
        public static int DeleteDeviceByCondition(string sql)
        {
            string sl = "DELETE FROM C_ASM_DEVICE_T  WHERE " + sql;
            int a = ClsCommon.dbSql.ExecuteNonQuery(sl);
            return a;
        }
        public static DataTable GetDevicesByCondition(string sql)
        {
            string sl = "SELECT DEVICE_NAME,DEVICE_STATION,DEVICE_TYPE,DEVICE_IP,DEVICE_PROTOCOL,DEVICE_CID,DEVICE_CONTROLADD,DEVICE_PRINTADD FROM C_ASM_DEVICE_T where " + sql + "ORDER BY ID DESC";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
    }
}
