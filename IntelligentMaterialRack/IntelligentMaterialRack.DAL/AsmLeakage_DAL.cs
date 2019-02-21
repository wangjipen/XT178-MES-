using Dapper;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using SKTrackClient.SKTrackClient.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SKTrackClient.SKTrackClient.DAL
{
    class AsmLeakage_DAL
    {
        public static int AddLeakageByObject(AsmLeakageObject alko)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(alko);
                return Convert.ToInt32(result);
            }
        }
        public static int UpdateLeakageByObject(AsmLeakageObject aso)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Update(aso);
            }
            return Convert.ToInt32(result);
        }
        public static AsmLeakageObject GetLeakageByCondition(string sql)
        {
            AsmLeakageObject aso = null;
            string sl = "SELECT ID,DT,ST,SN,LEAKAGE_NAME,LEAKAGE_PV,LEAKAGE_LV,LEAKAGE_R,EMP,Transfer  FROM dbo.P_ASM_LEAKAGE_T WHERE " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                aso = new AsmLeakageObject();
                aso.ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                aso.DT =Convert.ToDateTime(dt.Rows[0]["DT"].ToString());
                aso.ST = dt.Rows[0]["ST"].ToString();
                aso.SN = dt.Rows[0]["SN"].ToString();
                aso.LEAKAGE_NAME = dt.Rows[0]["LEAKAGE_NAME"].ToString();
                aso.LEAKAGE_PV = dt.Rows[0]["LEAKAGE_PV"].ToString();
                aso.LEAKAGE_LV = dt.Rows[0]["LEAKAGE_LV"].ToString();
                aso.LEAKAGE_R = dt.Rows[0]["LEAKAGE_R"].ToString();
                aso.EMP = dt.Rows[0]["EMP"].ToString();
                aso.Transfer =Convert.ToInt32( dt.Rows[0]["Transfer"].ToString());
            }
            return aso;
        }
        public static List< AsmLeakageObject> GetManyLeakageByCondition(string sql)
        {
            List<AsmLeakageObject> la=new List<AsmLeakageObject>();
            string sl = "SELECT ID,DT,ST,SN,LEAKAGE_NAME,LEAKAGE_PV,LEAKAGE_LV,LEAKAGE_R,EMP,Transfer  FROM dbo.P_ASM_LEAKAGE_T WHERE " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AsmLeakageObject aso = new AsmLeakageObject();
                    aso.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                    aso.DT = Convert.ToDateTime(dt.Rows[i]["DT"].ToString());
                    aso.ST = dt.Rows[i]["ST"].ToString();
                    aso.SN = dt.Rows[i]["SN"].ToString();
                    aso.LEAKAGE_NAME = dt.Rows[i]["LEAKAGE_NAME"].ToString();
                    aso.LEAKAGE_PV = dt.Rows[i]["LEAKAGE_PV"].ToString();
                    aso.LEAKAGE_LV = dt.Rows[i]["LEAKAGE_LV"].ToString();
                    aso.LEAKAGE_R = dt.Rows[i]["LEAKAGE_R"].ToString();
                    aso.EMP = dt.Rows[i]["EMP"].ToString();
                    aso.Transfer = Convert.ToInt32(dt.Rows[i]["Transfer"].ToString());
                    la.Add(aso);
                }
            }
            return la;
        }
        public static DataTable GetLeakageBySn(string ql)
        {
            string sql = "SELECT  DT AS '日期',LEAKAGE_PV AS '气压值',LEAKAGE_LV AS '泄漏值',LEAKAGE_R AS '结果',EMP AS '员工号',ST AS '工位' FROM dbo.P_ASM_LEAKAGE_T WHERE" + ql;
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sql);
            return dt;
        }
    }
}
