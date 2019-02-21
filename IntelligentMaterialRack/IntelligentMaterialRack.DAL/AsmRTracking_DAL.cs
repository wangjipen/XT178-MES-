using Dapper;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.DAL
{
    class AsmRTracking_DAL
    {
        public static int AddAsmRTrackingByObject(AsmRTrackingObject arto)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(arto);
                return Convert.ToInt32(result);
            }
        }
        public static int UpdateAsmRTrackingByObject(AsmRTrackingObject arto)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Update(arto);
            }
            return Convert.ToInt32(result);
        }

        internal static int DeleteRTrackingByCondition(object sql)
        {
            string sl = "DELETE FROM dbo.R_ASM_TRACKING_T WHERE " + sql;
            int a = ClsCommon.dbSql.ExecuteNonQuery(sl);
            return a;
        }

        public static AsmRTrackingObject GetAsmRTrackingObjectBySn(string sql)
        {
            AsmRTrackingObject arto = null;
            string sl = "SELECT R_TRACKING_ID,DT,ST,BST,SN,EngineSN,GearboxSN,TypeName,TrayNum,ProductNum,STATUS,PLAN_ID,REWORK_FLAG FROM dbo.R_ASM_TRACKING_T WHERE  " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                arto = new AsmRTrackingObject();
                arto.R_TRACKING_ID = Convert.ToInt32(dt.Rows[0]["R_TRACKING_ID"].ToString());
                arto.DT = Convert.ToDateTime(dt.Rows[0]["DT"].ToString());
                arto.ST = dt.Rows[0]["ST"].ToString();
                arto.BST = dt.Rows[0]["BST"].ToString();
                arto.SN = dt.Rows[0]["SN"].ToString();
                arto.EngineSN = dt.Rows[0]["EngineSN"].ToString();
                arto.GearboxSN = dt.Rows[0]["GearboxSN"].ToString();
                arto.TypeName = dt.Rows[0]["TypeName"].ToString();
                arto.TrayNum = dt.Rows[0]["TrayNum"].ToString();
                arto.ProductNum = dt.Rows[0]["ProductNum"].ToString();
                arto.STATUS = dt.Rows[0]["STATUS"].ToString();
                //arto.PLAN_ID = Convert.ToInt32(dt.Rows[0]["PLAN_ID"]?.ToString());
                arto.REWORK_FLAG= dt.Rows[0]["REWORK_FLAG"].ToString();
            }
            return arto;
        }
    }
}
