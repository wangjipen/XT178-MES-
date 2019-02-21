using Dapper;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.DAL
{
    class AsmLine_DAL
    {
        public static int AddLineByObject(AsmLineObject aso)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(aso);
                return Convert.ToInt32(result);
            }
        }
        public static int UpdateLineByObject(AsmLineObject aso)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Update(aso);
            }
            return Convert.ToInt32(result);
        }
        public static AsmLineObject GetLineByCondition(string sql)
        {
            AsmLineObject aso = null;
            string sl = "SELECT ID,DT,NAME,DSC FROM dbo.C_PMS_LINE_T WHERE " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                aso = new AsmLineObject();
                aso.ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                aso.NAME = dt.Rows[0]["NAME"].ToString();
                aso.DSC = dt.Rows[0]["DSC"].ToString();
                aso.DT =Convert.ToDateTime( dt.Rows[0]["DT"].ToString());
            }
            return aso;
        }
        public static int DeleteLineByCondition(string sql)
        {
            int a = 0;
            AsmLineObject aso = GetLineByCondition(sql);
            if (aso != null)
            {
                string sl = "DELETE FROM dbo.C_PMS_LINE_T WHERE " + sql;
                a = ClsCommon.dbSql.ExecuteNonQuery(sl);
            }
            return a;
        }
        public static DataTable GetAllLines()
        {
            string sl = "SELECT ID,DT,NAME,DSC FROM dbo.C_PMS_LINE_T  ";
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
    }
}
